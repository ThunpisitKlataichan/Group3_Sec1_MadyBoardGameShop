using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportSuppiler : Form
    {
        private int currentRowIndex = 0; // ใช้เก็บ index ของแถวที่พิมพ์ล่าสุด
        public formReportSuppiler()
        {
            InitializeComponent();
        }

        SqlConnection consuppilier;
        SqlCommand cmdsuppiler;
        SqlDataAdapter dasuppiler;
        DataTable dtsuppiler;

        private void formReportSuppiler_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private string BuildBaseQuery()
        {
            return @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Suppilers.SuppilerID ORDER BY ProductID) = 1 
                         THEN CAST(Suppilers.SuppilerID AS VARCHAR) 
                         ELSE '' 
                    END AS SuppilerID,
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Suppilers.SuppilerID ORDER BY ProductID) = 1 
                         THEN SuppilerName 
                         ELSE '' 
                    END AS SuppilerName,
                    ProductID,
                    ProductName,
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Suppilers.SuppilerID ORDER BY ProductID) = 1 
                         THEN SuppilerCoutry 
                         ELSE '' 
                    END AS SuppilerCoutry
                FROM Suppilers
                INNER JOIN Products ON Products.SuppilersID = Suppilers.SuppilerID";
        }

        private void LoadDataToGridView()
        {
            using (consuppilier = new SqlConnection(InitializeUser._key_con))
            {
                consuppilier.Open();
                string qry = BuildBaseQuery() + " ORDER BY Suppilers.SuppilerID, ProductID";

                cmdsuppiler = new SqlCommand(qry, consuppilier);
                dasuppiler = new SqlDataAdapter(cmdsuppiler);
                dtsuppiler = new DataTable();
                dasuppiler.Fill(dtsuppiler);
                dataGridResult.DataSource = dtsuppiler;
            }
        }

        private void ApplyFilters()
        {
            string whereClause = "";
            bool hasFilter = false;

            // เงื่อนไขการค้นหาด้วย SupplierID
            if (!string.IsNullOrEmpty(txtSuppilerID.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "Suppilers.SuppilerID LIKE @SuppilerID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย SupplierName
            if (!string.IsNullOrEmpty(txtSuppilerName.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "SuppilerName LIKE @SuppilerName";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย ProductID
            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "ProductID LIKE @ProductID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย ProductName
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "ProductName LIKE @ProductName";
                hasFilter = true;
            }

            string orderByClause = "ORDER BY Suppilers.SuppilerID, ProductID";

            using (consuppilier = new SqlConnection(InitializeUser._key_con))
            {
                consuppilier.Open();
                string qry = BuildBaseQuery() + " " + whereClause + " " + orderByClause;

                using (cmdsuppiler = new SqlCommand(qry, consuppilier))
                {
                    // เพิ่มพารามิเตอร์ตามเงื่อนไข
                    if (!string.IsNullOrEmpty(txtSuppilerID.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@SuppilerID", "%" + txtSuppilerID.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtSuppilerName.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@SuppilerName", "%" + txtSuppilerName.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtProductID.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@ProductID", "%" + txtProductID.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtProductName.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@ProductName", "%" + txtProductName.Text + "%");
                    }

                    dasuppiler = new SqlDataAdapter(cmdsuppiler);
                    dtsuppiler = new DataTable();
                    dasuppiler.Fill(dtsuppiler);
                    dataGridResult.DataSource = dtsuppiler;
                }
            }
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // เคลียร์ค่ากรองทั้งหมด
            txtSuppilerID.Text = "";
            txtSuppilerName.Text = "";
            txtProductID.Text = "";
            txtProductName.Text = "";

            // โหลดข้อมูลทั้งหมดใหม่
            LoadDataToGridView();
        }
        private void txtSuppilerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
        private void txtSuppilerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

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
    }
}