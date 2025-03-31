using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportProduct : Form
    {
        private int currentRowIndex = 0;

        public formReportProduct()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        private void formReportProduct_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataToGrid();
                ApplyDataGridViewStyling();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("เกิดข้อผิดพลาดในการโหลดฟอร์ม", ex);
            }
        }

        private void ApplyDataGridViewStyling()
        {
            // Basic Grid Styling
            dataGridResult.BorderStyle = BorderStyle.None;
            dataGridResult.EnableHeadersVisualStyles = false;
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResult.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridResult.RowHeadersVisible = false;
            dataGridResult.AllowUserToAddRows = false;
            dataGridResult.ReadOnly = true;
            dataGridResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResult.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridResult.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridResult.ColumnHeadersHeight = 40;
            dataGridResult.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 59);
            dataGridResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResult.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);
            dataGridResult.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridResult.GridColor = Color.FromArgb(221, 221, 221);

            // Column-specific formatting
            if (dataGridResult.Columns.Contains("Price") || dataGridResult.Columns.Contains("CostPrice"))
            {
                dataGridResult.Columns["Price"].DefaultCellStyle.Format = "N2";
                dataGridResult.Columns["CostPrice"].DefaultCellStyle.Format = "N2";
                dataGridResult.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridResult.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dataGridResult.Columns.Contains("Quality"))
            {
                dataGridResult.Columns["Quality"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Set Thai column headers
            if (dataGridResult.Columns.Contains("SuppilerName")) dataGridResult.Columns["SuppilerName"].HeaderText = "ชื่อผู้ผลิต";
            if (dataGridResult.Columns.Contains("ProductID")) dataGridResult.Columns["ProductID"].HeaderText = "รหัสสินค้า";
            if (dataGridResult.Columns.Contains("ProductName")) dataGridResult.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
            if (dataGridResult.Columns.Contains("CostPrice")) dataGridResult.Columns["CostPrice"].HeaderText = "ราคาทุน";
            if (dataGridResult.Columns.Contains("Price")) dataGridResult.Columns["Price"].HeaderText = "ราคาขาย";
            if (dataGridResult.Columns.Contains("Quality")) dataGridResult.Columns["Quality"].HeaderText = "จำนวน";
            if (dataGridResult.Columns.Contains("ProductType")) dataGridResult.Columns["ProductType"].HeaderText = "ประเภท";

            // Add some padding to cells
            dataGridResult.DefaultCellStyle.Padding = new Padding(5);
            dataGridResult.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        }

        private void LoadDataToGrid()
        {
            try
            {
                using (conn = new SqlConnection(InitializeUser._key_con))
                {
                    conn.Open();
                    string query = BuildBaseQuery();
                    cmd = new SqlCommand(query, conn);
                    AddSearchParameters();

                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    dataGridResult.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("เกิดข้อผิดพลาดในการโหลดข้อมูล", ex);
            }
        }

        private string BuildBaseQuery()
        {
            return @"
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
        }

        private void AddSearchParameters()
        {
            // Product ID filter
            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                cmd.CommandText += " AND Products.ProductID LIKE @ProductID";
                cmd.Parameters.AddWithValue("@ProductID", "%" + txtProductID.Text + "%");
            }

            // Product Name filter
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                cmd.CommandText += " AND Products.ProductName LIKE @ProductName";
                cmd.Parameters.AddWithValue("@ProductName", "%" + txtProductName.Text + "%");
            }

            // Price range filter
            if (!string.IsNullOrEmpty(txtStartPrice.Text) && decimal.TryParse(txtStartPrice.Text, out decimal startPrice))
            {
                cmd.CommandText += " AND Products.Price >= @StartPrice";
                cmd.Parameters.AddWithValue("@StartPrice", startPrice);
            }

            if (!string.IsNullOrEmpty(txtEndPrice.Text) && decimal.TryParse(txtEndPrice.Text, out decimal endPrice))
            {
                cmd.CommandText += " AND Products.Price <= @EndPrice";
                cmd.Parameters.AddWithValue("@EndPrice", endPrice);
            }

            cmd.CommandText += " ORDER BY Suppilers.SuppilerName, Products.ProductID";
        }

        private void btn_print_to_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                currentRowIndex = 0;
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDocument.PrinterSettings.PrintFileName = "C:\\Users\\Public\\Documents\\Product_Report.pdf";
                printDocument.DefaultPageSettings.Landscape = true;
                printDocument.PrintPage += PrintPageHandler;
                printDocument.Print();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("เกิดข้อผิดพลาดในการพิมพ์", ex);
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            try
            {
                int pageWidth = e.PageBounds.Width - 100;
                int pageHeight = e.PageBounds.Height - 100;
                int columnCount = dataGridResult.ColumnCount;
                int rowCount = dataGridResult.RowCount;

                int cellHeight = 40;
                int startX = 50;
                int startY = 50;
                int cellWidth = (pageWidth - startX) / columnCount;

                // Header style
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Brush headerBrush = new SolidBrush(Color.White);
                Pen headerBorderPen = new Pen(Color.FromArgb(34, 34, 59), 1);
                Brush headerBackBrush = new SolidBrush(Color.FromArgb(34, 34, 59));

                // Cell style
                Font cellFont = new Font("Arial", 11);
                Brush cellBrush = new SolidBrush(Color.Black);
                Pen cellBorderPen = new Pen(Color.LightGray, 1);

                // Draw header
                for (int i = 0; i < columnCount; i++)
                {
                    RectangleF headerRect = new RectangleF(startX + (i * cellWidth), startY, cellWidth, cellHeight);

                    // Draw header background and border
                    e.Graphics.FillRectangle(headerBackBrush, headerRect);
                    e.Graphics.DrawRectangle(headerBorderPen, headerRect.X, headerRect.Y, headerRect.Width, headerRect.Height);

                    // Draw header text
                    e.Graphics.DrawString(
                        dataGridResult.Columns[i].HeaderText,
                        headerFont,
                        headerBrush,
                        headerRect,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }

                // Draw rows
                int rowY = startY + cellHeight;
                for (int i = currentRowIndex; i < rowCount; i++)
                {
                    // Alternate row color
                    Brush rowBrush = (i % 2 == 0) ? Brushes.White : new SolidBrush(Color.FromArgb(245, 245, 255));

                    for (int j = 0; j < columnCount; j++)
                    {
                        RectangleF cellRect = new RectangleF(startX + (j * cellWidth), rowY, cellWidth, cellHeight);
                        string cellText = dataGridResult.Rows[i].Cells[j].Value?.ToString() ?? "";

                        // Draw cell background and border
                        e.Graphics.FillRectangle(rowBrush, cellRect);
                        e.Graphics.DrawRectangle(cellBorderPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                        // Draw cell text with proper alignment
                        StringFormat format = new StringFormat();
                        if (dataGridResult.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
                            format.Alignment = StringAlignment.Far;
                        else if (dataGridResult.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                            format.Alignment = StringAlignment.Center;
                        else
                            format.Alignment = StringAlignment.Near;

                        format.LineAlignment = StringAlignment.Center;

                        e.Graphics.DrawString(
                            cellText,
                            cellFont,
                            cellBrush,
                            cellRect,
                            format
                        );
                    }

                    rowY += cellHeight;

                    // Check for page break
                    if (rowY + cellHeight > pageHeight && i < rowCount - 1)
                    {
                        currentRowIndex = i + 1;
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
                currentRowIndex = 0;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("เกิดข้อผิดพลาดในการสร้างรายงาน", ex);
                e.HasMorePages = false;
            }
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

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Validate numeric input for price fields
        private void txtStartPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(sender, e);
        }

        private void txtEndPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(sender, e);
        }

        private void ValidateNumericInput(object sender ,  KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtEndPrice_KeyPress(object sender, KeyEventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}