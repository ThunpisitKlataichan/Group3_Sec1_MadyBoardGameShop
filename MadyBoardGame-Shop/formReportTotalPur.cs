using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportTotalPur : Form
    {
        public formReportTotalPur()
        {
            InitializeComponent();
        }

        SqlConnection purconnection;
        SqlCommand purcommand;
        SqlDataAdapter puradapter;
        DataTable purtable;

        private void formReportPur_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize connection string (replace with your actual connection string)
                purconnection = new SqlConnection(InitializeUser._key_con);

                dateTimeEnd.MaxDate = DateTime.Now.AddDays(1);
                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = DateTime.Now.AddMonths(-1);
                dateTimeStart.MaxDate = DateTime.Now;
                comboDateTypeSelect.SelectedIndex = 0;

                LoadDataToDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้: {ex.Message}");
            }
        }
        private void CalculateTotalSum()
        {
            decimal totalSum = 0;

            // ตรวจสอบว่ามีข้อมูลใน DataGridView หรือไม่
            if (dataGridResult.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridResult.Rows)
                {
                    if (row.Cells["Total Spend"].Value != null)
                    {
                        decimal value;
                        if (decimal.TryParse(row.Cells["Total Spend"].Value.ToString(), out value))
                        {
                            totalSum += value;
                        }
                    }
                }
            }

            // แสดงผลรวมใน textBoxSumPur พร้อมหน่วย "บาท"
            textBoxSumPur.Text = $"{totalSum:N2} บาท";
        }

        private void CustomizeDataGridView()
        {
            // ตั้งค่าพื้นหลัง
            dataGridResult.BackgroundColor = Color.White;
            dataGridResult.GridColor = Color.LightGray;
            dataGridResult.BorderStyle = BorderStyle.None;

            // ตั้งค่าหัวตาราง
            dataGridResult.EnableHeadersVisualStyles = false;
            dataGridResult.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResult.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridResult.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridResult.ColumnHeadersHeight = 40;

            // ตั้งค่าตัวอักษรภายใน DataGridView
            dataGridResult.DefaultCellStyle.Font = new Font("Arial", 11);
            dataGridResult.DefaultCellStyle.ForeColor = Color.Black;
            dataGridResult.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridResult.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridResult.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ตั้งค่าสีแถวสลับ
            dataGridResult.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255);

            // ปิดไฮไลท์ที่แถว
            dataGridResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResult.MultiSelect = false;

            // ปิดการแก้ไขค่าใน DataGridView
            dataGridResult.ReadOnly = true;

            // ซ่อนเส้นขอบ
            dataGridResult.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridResult.RowHeadersVisible = false;

            // ตั้งค่าขนาดของแถวให้พอดี
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private string GetReportQuery()
        {
            string baseQuery = @"
        SELECT 
            {0} AS [Purchase Date],
            COUNT(DISTINCT Purchasing.PurID) AS [Purchase Count],
            COUNT(Products.ProductID) AS [Product Items],
            SUM(TRY_CAST(PurchaseDetail.Quality AS INT)) AS [Total Quantity],
            SUM(TRY_CAST(PurchaseDetail.Quality AS DECIMAL(18,2)) * CostPrice) AS [Total Spend]
        FROM Purchasing
        INNER JOIN PurchaseDetail ON Purchasing.PurID = PurchaseDetail.PurID
        INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
        INNER JOIN Employees ON Purchasing.empID = Employees.empID
        WHERE PurlDate BETWEEN @StartDate AND @EndDate
        GROUP BY {1}
        ORDER BY {2}";

            switch (comboDateTypeSelect.SelectedItem.ToString())
            {
                case "รายวัน":
                    return string.Format(baseQuery,
                        "FORMAT(PurlDate, 'dd/MM/yyyy')",
                        "FORMAT(PurlDate, 'dd/MM/yyyy')",
                        "MIN(PurlDate)");

                case "รายเดือน":
                    return string.Format(baseQuery,
                        "'Month ' + CAST(DATEPART(MONTH, PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, PurlDate) AS VARCHAR)",
                        "DATEPART(MONTH, PurlDate), DATEPART(YEAR, PurlDate)",
                        "DATEPART(YEAR, PurlDate), DATEPART(MONTH, PurlDate)");

                case "รายปี":
                    return string.Format(baseQuery,
                        "CAST(DATEPART(YEAR, PurlDate) AS VARCHAR)",
                        "DATEPART(YEAR, PurlDate)",
                        "DATEPART(YEAR, PurlDate)");

                default:
                    return "";
            }
        }

        private void LoadDataToDataGrid()
        {
            try
            {
                if (purconnection.State != ConnectionState.Open)
                    purconnection.Open();

                string query = GetReportQuery();

                purcommand = new SqlCommand(query, purconnection);

                // Add parameters with values
                purcommand.Parameters.AddWithValue("@StartDate", dateTimeStart.Value.Date);
                purcommand.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1));

                puradapter = new SqlDataAdapter(purcommand);
                purtable = new DataTable();
                puradapter.Fill(purtable);

                dataGridResult.DataSource = purtable;
                dataGridResult.AutoResizeColumns();
                CustomizeDataGridView();
                FormatPriceColumn();
                CalculateTotalSum();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูล: {ex.Message}");
            }
            finally
            {
                if (purconnection.State == ConnectionState.Open)
                    purconnection.Close();
            }
        }
        private void FormatPriceColumn()
        {
            // ตรวจสอบว่าตารางมีข้อมูลหรือไม่
            if (dataGridResult.Columns.Count == 0) return;

            // ระบุชื่อคอลัมน์ที่ต้องการจัดรูปแบบ (ชื่อจาก SQL Query)
            string columnName = "Total Spend"; // หรือใช้ชื่อที่ตรงกับฐานข้อมูล

            if (dataGridResult.Columns.Contains(columnName))
            {
                dataGridResult.Columns[columnName].DefaultCellStyle.Format = "N2"; // แสดง 2 ตำแหน่งทศนิยม
                dataGridResult.Columns[columnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // ชิดขวา
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องไม่มากกว่าวันที่สิ้นสุด");
                return;
            }

            LoadDataToDataGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Now.AddMonths(-1);
            dateTimeEnd.Value = DateTime.Now;
            comboDateTypeSelect.SelectedIndex = 0;
            LoadDataToDataGrid();
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToDataGrid();
        }

        private int currentRowIndex = 0; // ใช้เก็บ index ของแถวที่พิมพ์ล่าสุด
        private void btn_print_to_pdf_Click(object sender, EventArgs e)
        {
            currentRowIndex = 0; // รีเซ็ตค่าเมื่อเริ่มพิมพ์ใหม่
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrinterSettings.PrintFileName = "C:\\Users\\Public\\Documents\\DataGridView_AutoFit.pdf";
            printDocument.DefaultPageSettings.Landscape = true; // พิมพ์แนวนอน
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int pageWidth = e.PageBounds.Width - 100;  // เหลือขอบซ้าย/ขวา 50px
            int pageHeight = e.PageBounds.Height - 100; // เหลือขอบบน/ล่าง 50px
            int columnCount = dataGridResult.ColumnCount;
            int rowCount = dataGridResult.RowCount;

            int cellHeight = 50; // ความสูงของแต่ละเซลล์
            int startX = 50; // จุดเริ่มต้น X
            int startY = 50; // จุดเริ่มต้น Y

            int cellWidth = pageWidth / columnCount;
            using (Pen blackPen = new Pen(Color.Black, 1))
            using (Font font = new Font("Arial", 12))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                //  วาด Header
                for (int i = 0; i < columnCount; i++)
                {
                    e.Graphics.DrawRectangle(blackPen, startX + (i * cellWidth), startY, cellWidth, cellHeight);
                    e.Graphics.DrawString(
                        dataGridResult.Columns[i].HeaderText, font, brush,
                        new RectangleF(startX + (i * cellWidth), startY, cellWidth, cellHeight),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }

                // วาดข้อมูลตาราง เริ่มจาก currentRowIndex
                int rowY = startY + cellHeight;
                for (int i = currentRowIndex; i < rowCount - 1; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        string cellText = dataGridResult.Rows[i].Cells[j].Value?.ToString() ?? "";
                        e.Graphics.DrawRectangle(blackPen, startX + (j * cellWidth), rowY, cellWidth, cellHeight);
                        e.Graphics.DrawString(
                            cellText, font, brush,
                            new RectangleF(startX + (j * cellWidth), rowY, cellWidth, cellHeight),
                            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                        );
                    }

                    rowY += cellHeight;

                    // ถ้าเกินหน้ากระดาษให้หยุดพิมพ์และขึ้นหน้าใหม่
                    if (rowY + cellHeight > pageHeight)
                    {
                        currentRowIndex = i + 1; // บันทึกแถวสุดท้ายที่พิมพ์
                        e.HasMorePages = true;
                        return;
                    }
                }

                //ถ้าพิมพ์ครบทุกแถวแล้วให้ปิด HasMorePages
                e.HasMorePages = false;
                currentRowIndex = 0; // รีเซ็ตค่า
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}