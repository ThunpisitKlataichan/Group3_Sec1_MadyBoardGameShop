using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportOrderDetail : Form
    {
        private int currentRowIndex = 0; // ใช้เก็บ index ของแถวที่พิมพ์ล่าสุด
        public formReportOrderDetail()
        {
            InitializeComponent();
        }

        SqlConnection orderconnection;
        SqlCommand ordercommand;
        SqlDataAdapter orderadapter;
        DataTable ordertable;

        private void formReportOrders_Load(object sender, EventArgs e)
        {
            LoadDataGridview();
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            // Basic styling
            dataGridResult.BorderStyle = BorderStyle.None;
            dataGridResult.EnableHeadersVisualStyles = false;
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridResult.RowHeadersVisible = false;
            dataGridResult.AllowUserToAddRows = false;
            dataGridResult.ReadOnly = true;
            dataGridResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResult.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridResult.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridResult.ColumnHeadersHeight = 40;
            dataGridResult.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dataGridResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResult.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridResult.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridResult.GridColor = Color.FromArgb(221, 221, 221);

            // Column-specific formatting
            if (dataGridResult.Columns.Contains("OrderDate"))
            {
                dataGridResult.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridResult.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridResult.Columns.Contains("TotalPrice"))
            {
                dataGridResult.Columns["TotalPrice"].DefaultCellStyle.Format = "N2";
                dataGridResult.Columns["TotalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dataGridResult.Columns.Contains("Quantity"))
            {
                dataGridResult.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Set column header texts
            if (dataGridResult.Columns.Contains("OrderID")) dataGridResult.Columns["OrderID"].HeaderText = "เลขที่ใบสั่งซื้อ";
            if (dataGridResult.Columns.Contains("OrderDetailID")) dataGridResult.Columns["OrderDetailID"].HeaderText = "รหัสรายการ";
            if (dataGridResult.Columns.Contains("memName")) dataGridResult.Columns["memName"].HeaderText = "ชื่อสมาชิก";
            if (dataGridResult.Columns.Contains("memLName")) dataGridResult.Columns["memLName"].HeaderText = "นามสกุล";
            if (dataGridResult.Columns.Contains("OrderDate")) dataGridResult.Columns["OrderDate"].HeaderText = "วันที่สั่งซื้อ";
            if (dataGridResult.Columns.Contains("ProductName")) dataGridResult.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
            if (dataGridResult.Columns.Contains("Quantity")) dataGridResult.Columns["Quantity"].HeaderText = "จำนวน";
            if (dataGridResult.Columns.Contains("TotalPrice")) dataGridResult.Columns["TotalPrice"].HeaderText = "ราคารวม (บาท)";

            // Add some padding to cells
            dataGridResult.DefaultCellStyle.Padding = new Padding(5);
        }

        private void LoadDataGridview()
        {
            try
            {
                using (orderconnection = new SqlConnection(InitializeUser._key_con))
                {
                    orderconnection.Open();
                    string qry = BuildBaseQuery();

                    using (ordercommand = new SqlCommand(qry, orderconnection))
                    {
                        orderadapter = new SqlDataAdapter(ordercommand);
                        ordertable = new DataTable();
                        orderadapter.Fill(ordertable);
                        dataGridResult.DataSource = ordertable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string BuildBaseQuery()
        {
            return @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Orders.OrderID ORDER BY OrderDetailID) = 1 
                         THEN CAST(Orders.OrderID AS VARCHAR) 
                         ELSE '' 
                    END AS OrderID,
                    OrderDetailID,
                    memName,
                    memLName,
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Orders.OrderID ORDER BY OrderDetailID) = 1 
                         THEN OrderDate 
                         ELSE NULL 
                    END AS OrderDate,
                    ProductName,
                    OrderDetails.Quantity,
                    (Price * OrderDetails.Quantity) as TotalPrice
                FROM Orders 
                INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
                INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID 
                INNER JOIN Member ON Orders.memID = Member.memID";
        }
        private void ApplyFilters()
        {
            try
            {
                string whereClause = "";
                bool hasFilter = false;

                // OrderID filter
                if (!string.IsNullOrEmpty(txtOrderFind.Text))
                {
                    whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                                  "Orders.OrderID LIKE @OrderID";
                    hasFilter = true;
                }

                // MemberID filter
                if (!string.IsNullOrEmpty(txtmemIDFind.Text))
                {
                    whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                                  "Orders.memID LIKE @memID";
                    hasFilter = true;
                }

                // Price range filter
                decimal minPrice, maxPrice;
                bool hasMin = decimal.TryParse(textTotalPricemin.Text, out minPrice);
                bool hasMax = decimal.TryParse(textTotalPricemac.Text, out maxPrice);

                if (hasMin && hasMax)
                {
                    whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                                  "(Price * OrderDetails.Quantity) BETWEEN @MinPrice AND @MaxPrice";
                    hasFilter = true;
                }
                else if (hasMin)
                {
                    whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                                  "(Price * OrderDetails.Quantity) >= @MinPrice";
                    hasFilter = true;
                }
                else if (hasMax)
                {
                    whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                                  "(Price * OrderDetails.Quantity) <= @MaxPrice";
                    hasFilter = true;
                }

                string orderByClause = "ORDER BY Orders.OrderID, OrderDetailID";

                using (orderconnection = new SqlConnection(InitializeUser._key_con))
                {
                    orderconnection.Open();
                    string qry = BuildBaseQuery() + " " + whereClause + " " + orderByClause;

                    using (ordercommand = new SqlCommand(qry, orderconnection))
                    {
                        if (!string.IsNullOrEmpty(txtOrderFind.Text))
                        {
                            ordercommand.Parameters.AddWithValue("@OrderID", "%" + txtOrderFind.Text + "%");
                        }

                        if (!string.IsNullOrEmpty(txtmemIDFind.Text))
                        {
                            ordercommand.Parameters.AddWithValue("@memID", "%" + txtmemIDFind.Text + "%");
                        }

                        if (hasMin)
                        {
                            ordercommand.Parameters.AddWithValue("@MinPrice", minPrice);
                        }

                        if (hasMax)
                        {
                            ordercommand.Parameters.AddWithValue("@MaxPrice", maxPrice);
                        }

                        orderadapter = new SqlDataAdapter(ordercommand);
                        ordertable = new DataTable();
                        orderadapter.Fill(ordertable);
                        dataGridResult.DataSource = ordertable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการกรองข้อมูล: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        // ลบ Event TextChanged ที่ไม่จำเป็นแล้ว
        private void txtOrderFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กด Enter เพื่อค้นหา
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void txtmemIDFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void textTotalPricemin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กรอกเฉพาะตัวเลขและจุด
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // อนุญาตให้กด Enter เพื่อค้นหา
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // เคลียร์ค่ากรองทั้งหมด
            txtOrderFind.Text = "";
            txtmemIDFind.Text = "";
            textTotalPricemin.Text = "";
            textTotalPricemac.Text = "";

            // โหลดข้อมูลทั้งหมดใหม่
            LoadDataGridview();
        }

        private void textTotalPricemac_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กรอกเฉพาะตัวเลขและจุด
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // อนุญาตให้กด Enter เพื่อค้นหา
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
                for (int i = currentRowIndex; i < rowCount-1; i++)
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