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
    public partial class formReportProduct : Form
    {
        public formReportProduct()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
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
        private void formReportProduct_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDataToGrid()
        {
            try
            {
                conn = new SqlConnection(InitializeUser._key_con);
                conn.Open();

                string query = @"
            SELECT 
                CASE 
                    WHEN ROW_NUMBER() OVER (PARTITION BY Suppilers.SuppilerID ORDER BY Products.ProductID) = 1 
                    THEN Suppilers.SuppilerName 
                    ELSE '' 
                END AS SuppilerName,
                Products.ProductID,  
                Products.ProductName,
                Products.CostPrice,
                Products.Price,
                Products.Quality,
                Products.ProductType
            FROM Products 
            INNER JOIN Suppilers ON Products.SuppilersID = Suppilers.SuppilerID
            WHERE 1=1";

                // เพิ่มเงื่อนไขการค้นหาตามที่ระบุในฟอร์ม
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    query += " AND Products.ProductID LIKE @ProductID";
                }

                if (!string.IsNullOrEmpty(txtProductName.Text))
                {
                    query += " AND Products.ProductName LIKE @ProductName";
                }

                if (!string.IsNullOrEmpty(txtStartPrice.Text) && decimal.TryParse(txtStartPrice.Text, out decimal startPrice))
                {
                    query += " AND Products.Price >= @StartPrice";
                }

                if (!string.IsNullOrEmpty(txtEndPrice.Text) && decimal.TryParse(txtEndPrice.Text, out decimal endPrice))
                {
                    query += " AND Products.Price <= @EndPrice";
                }

                query += " ORDER BY Suppilers.SuppilerName, Products.ProductID";

                cmd = new SqlCommand(query, conn);

                // เพิ่ม parameters เพื่อป้องกัน SQL Injection
                if (!string.IsNullOrEmpty(txtProductID.Text))
                {
                    cmd.Parameters.AddWithValue("@ProductID", "%" + txtProductID.Text + "%");
                }

                if (!string.IsNullOrEmpty(txtProductName.Text))
                {
                    cmd.Parameters.AddWithValue("@ProductName", "%" + txtProductName.Text + "%");
                }

                if (!string.IsNullOrEmpty(txtStartPrice.Text) && decimal.TryParse(txtStartPrice.Text, out startPrice))
                {
                    cmd.Parameters.AddWithValue("@StartPrice", startPrice);
                }

                if (!string.IsNullOrEmpty(txtEndPrice.Text) && decimal.TryParse(txtEndPrice.Text, out endPrice))
                {
                    cmd.Parameters.AddWithValue("@EndPrice", endPrice);
                }

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                dataGridResult.DataSource = dt;

                // ปรับแต่งการแสดงผลใน DataGridView
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void CustomizeDataGridView()
        {
            // ซ่อนคอลัมน์ SuppilerID ถ้ามี
            if (dataGridResult.Columns.Contains("SuppilerID"))
            {
                dataGridResult.Columns["SuppilerID"].Visible = false;
            }

            // จัดรูปแบบคอลัมน์ต่างๆ
            if (dataGridResult.Columns.Contains("Price"))
            {
                dataGridResult.Columns["Price"].DefaultCellStyle.Format = "N2";
            }

            if (dataGridResult.Columns.Contains("CostPrice"))
            {
                dataGridResult.Columns["CostPrice"].DefaultCellStyle.Format = "N2";
            }

            // ตั้งค่าความกว้างคอลัมน์อัตโนมัติ
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtStartPrice.Text = "";
            txtEndPrice.Text = "";
            LoadDataToGrid();
        }
    }
}
