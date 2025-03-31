using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportDetailPur : Form
    {
        public formReportDetailPur()
        {
            InitializeComponent();
        }
        SqlConnection detailpurconnection;
        SqlCommand detailpurcommand;
        SqlDataAdapter detailpuradapter;
        DataTable detailpurtable;
        private void formReportDetailPur_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDatatoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDatatoGrid()
        {
            try
            {
                using (detailpurconnection = new SqlConnection(InitializeUser._key_con))
                {
                    detailpurconnection.Open();

                    using (detailpurcommand = new SqlCommand(GetPurchaseDetailQuery(), detailpurconnection))
                    {
                        // Add parameters for search functionality
                        if (!string.IsNullOrEmpty(txtPurIDFind.Text))
                            detailpurcommand.Parameters.AddWithValue("@PurID", txtPurIDFind.Text);

                        if (!string.IsNullOrEmpty(txtempIDFind.Text))
                            detailpurcommand.Parameters.AddWithValue("@empID", txtempIDFind.Text);

                        if (!string.IsNullOrEmpty(textTotalPricemin.Text) && decimal.TryParse(textTotalPricemin.Text, out decimal minPrice))
                            detailpurcommand.Parameters.AddWithValue("@MinPrice", minPrice);

                        if (!string.IsNullOrEmpty(textTotalPricemax.Text) && decimal.TryParse(textTotalPricemax.Text, out decimal maxPrice))
                            detailpurcommand.Parameters.AddWithValue("@MaxPrice", maxPrice);

                        detailpuradapter = new SqlDataAdapter(detailpurcommand);
                        detailpurtable = new DataTable();
                        detailpuradapter.Fill(detailpurtable);

                        dataGridResult.DataSource = detailpurtable;
                        ConfigureDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        private void ConfigureDataGridView()
        {
            // ตั้งค่าคุณสมบัติพื้นฐานของ DataGridView
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridResult.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridResult.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridResult.EnableHeadersVisualStyles = false;
            dataGridResult.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridResult.ColumnHeadersHeight = 40;
            dataGridResult.RowHeadersVisible = false;
            dataGridResult.AllowUserToAddRows = false;
            dataGridResult.ReadOnly = true;
            dataGridResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // ตั้งค่าการจัดเรียงข้อมูล
            dataGridResult.Columns["PurID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridResult.Columns["PurDetailID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridResult.Columns["Quality"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridResult.Columns["Total Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ตั้งค่ารูปแบบตัวเลข
            dataGridResult.Columns["Total Price"].DefaultCellStyle.Format = "N2";

            // ตั้งค่าสีสลับแถว
            dataGridResult.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            // ตั้งค่าความกว้างของคอลัมน์ (ถ้าต้องการกำหนดเอง)
            dataGridResult.Columns["PurID"].Width = 80;
            dataGridResult.Columns["PurDetailID"].Width = 80;
            dataGridResult.Columns["Employee Name"].Width = 150;
            dataGridResult.Columns["PurlDate"].Width = 100;
            dataGridResult.Columns["ProductName"].Width = 200;
            dataGridResult.Columns["Quality"].Width = 80;
            dataGridResult.Columns["Total Price"].Width = 100;
        }
        private string GetPurchaseDetailQuery()
        {
            string query = @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY PurDetailID) = 1 
                        THEN CAST(Purchasing.PurID AS VARCHAR) 
                        ELSE '' 
                    END AS PurID,
                    PurDetailID,
                    empName AS [Employee Name],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY PurDetailID) = 1 
                        THEN FORMAT(PurlDate, 'dd/MM/yyyy') 
                        ELSE '' 
                    END AS PurlDate,
                    ProductName,
                    PurchaseDetail.Quality,
                    (PurchaseDetail.Quality * CostPrice) AS [Total Price]
                FROM PurchaseDetail
                INNER JOIN Purchasing ON PurchaseDetail.PurID = Purchasing.PurID
                INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
                INNER JOIN Employees ON Purchasing.empID = Employees.empID
                WHERE 1=1"; // Base condition for easy WHERE clause building

            // Add search conditions based on input
            if (!string.IsNullOrEmpty(txtPurIDFind.Text))
                query += " AND Purchasing.PurID = @PurID";

            if (!string.IsNullOrEmpty(txtempIDFind.Text))
                query += " AND Purchasing.empID = @empID";

            if (!string.IsNullOrEmpty(textTotalPricemin.Text) && decimal.TryParse(textTotalPricemin.Text, out _))
                query += " AND (PurchaseDetail.Quality * CostPrice) >= @MinPrice";

            if (!string.IsNullOrEmpty(textTotalPricemax.Text) && decimal.TryParse(textTotalPricemax.Text, out _))
                query += " AND (PurchaseDetail.Quality * CostPrice) <= @MaxPrice";

            query += " ORDER BY Purchasing.PurID, PurDetailID";

            return query;
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            // Validate price inputs
            if ((!string.IsNullOrEmpty(textTotalPricemin.Text) && !decimal.TryParse(textTotalPricemin.Text, out _)) ||
                (!string.IsNullOrEmpty(textTotalPricemax.Text) && !decimal.TryParse(textTotalPricemax.Text, out _)))
            {
                MessageBox.Show("กรุณากรอกช่วงราคาเป็นตัวเลข");
                return;
            }

            LoadDatatoGrid();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Clear all search fields
            txtPurIDFind.Text = "";
            txtempIDFind.Text = "";
            textTotalPricemin.Text = "";
            textTotalPricemax.Text = "";

            LoadDatatoGrid();
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
