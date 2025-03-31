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
        
        public formReportSuppiler()
        {
            InitializeComponent();
        }
        private int currentRowIndex = 0; // ใช้เก็บ index ของแถวที่พิมพ์ล่าสุด
        private Color headerColor = Color.FromArgb(34, 34, 59);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);
        private void formReportSuppiler_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataToGridView();
                ApplyDataGridViewStyling();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error initializing form", ex);
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
            dataGridResult.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridResult.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResult.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;
            dataGridResult.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridResult.GridColor = Color.FromArgb(221, 221, 221);

            // Set Thai column headers
            if (dataGridResult.Columns.Contains("SuppilerID")) dataGridResult.Columns["SuppilerID"].HeaderText = "รหัสผู้ผลิต";
            if (dataGridResult.Columns.Contains("SuppilerName")) dataGridResult.Columns["SuppilerName"].HeaderText = "ชื่อผู้ผลิต";
            if (dataGridResult.Columns.Contains("ProductID")) dataGridResult.Columns["ProductID"].HeaderText = "รหัสสินค้า";
            if (dataGridResult.Columns.Contains("ProductName")) dataGridResult.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
            if (dataGridResult.Columns.Contains("SuppilerCoutry")) dataGridResult.Columns["SuppilerCoutry"].HeaderText = "ประเทศ";

            // Add some padding to cells
            dataGridResult.DefaultCellStyle.Padding = new Padding(5);
            dataGridResult.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
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
            try
            {
                using (SqlConnection consuppilier = new SqlConnection(InitializeUser._key_con))
                {
                    consuppilier.Open();
                    string qry = BuildBaseQuery() + " ORDER BY Suppilers.SuppilerID, ProductID";

                    using (SqlCommand cmdsuppiler = new SqlCommand(qry, consuppilier))
                    {
                        SqlDataAdapter dasuppiler = new SqlDataAdapter(cmdsuppiler);
                        DataTable dtsuppiler = new DataTable();
                        dasuppiler.Fill(dtsuppiler);
                        dataGridResult.DataSource = dtsuppiler;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading supplier data", ex);
            }
        }
        private void ApplyFilters()
        {
            try
            {
                string whereClause = BuildWhereClause();

                using (SqlConnection consuppilier = new SqlConnection(InitializeUser._key_con))
                {
                    consuppilier.Open();
                    string qry = BuildBaseQuery() + " " + whereClause + " ORDER BY Suppilers.SuppilerID, ProductID";

                    using (SqlCommand cmdsuppiler = new SqlCommand(qry, consuppilier))
                    {
                        AddSearchParameters(cmdsuppiler);

                        SqlDataAdapter dasuppiler = new SqlDataAdapter(cmdsuppiler);
                        DataTable dtsuppiler = new DataTable();
                        dasuppiler.Fill(dtsuppiler);
                        dataGridResult.DataSource = dtsuppiler;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error applying filters", ex);
            }
        }
        private string BuildWhereClause()
        {
            string whereClause = "";
            bool hasFilter = false;

            if (!string.IsNullOrEmpty(txtSuppilerID.Text))
            {
                whereClause += "WHERE Suppilers.SuppilerID LIKE @SuppilerID";
                hasFilter = true;
            }

            if (!string.IsNullOrEmpty(txtSuppilerName.Text))
            {
                whereClause += (hasFilter ? " AND " : "WHERE ") + "SuppilerName LIKE @SuppilerName";
                hasFilter = true;
            }

            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                whereClause += (hasFilter ? " AND " : "WHERE ") + "ProductID LIKE @ProductID";
                hasFilter = true;
            }

            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                whereClause += (hasFilter ? " AND " : "WHERE ") + "ProductName LIKE @ProductName";
            }

            return whereClause;
        }

        private void AddSearchParameters(SqlCommand command)
        {
            if (!string.IsNullOrEmpty(txtSuppilerID.Text))
            {
                command.Parameters.AddWithValue("@SuppilerID", "%" + txtSuppilerID.Text + "%");
            }

            if (!string.IsNullOrEmpty(txtSuppilerName.Text))
            {
                command.Parameters.AddWithValue("@SuppilerName", "%" + txtSuppilerName.Text + "%");
            }

            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                command.Parameters.AddWithValue("@ProductID", "%" + txtProductID.Text + "%");
            }

            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                command.Parameters.AddWithValue("@ProductName", "%" + txtProductName.Text + "%");
            }
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtSuppilerID.Text = "";
            txtSuppilerName.Text = "";
            txtProductID.Text = "";
            txtProductName.Text = "";
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
            try
            {
                currentRowIndex = 0;
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDocument.PrinterSettings.PrintFileName = $"Supplier_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                printDocument.DefaultPageSettings.Landscape = true;
                printDocument.PrintPage += PrintPageHandler;
                printDocument.Print();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error printing report", ex);
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            try
            {
                int pageWidth = e.PageBounds.Width - 100;
                int pageHeight = e.PageBounds.Height - 100;
                int columnCount = dataGridResult.Columns.Count;
                int rowCount = dataGridResult.Rows.Count;

                int cellHeight = 40;
                int startX = 50;
                int startY = 80; // Extra space for title

                // Calculate column widths
                int[] colWidths = new int[columnCount];
                int totalWidth = 0;

                for (int i = 0; i < columnCount; i++)
                {
                    colWidths[i] = (int)(dataGridResult.Columns[i].Width / (double)dataGridResult.Width * pageWidth);
                    totalWidth += colWidths[i];
                }

                // Draw title
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                string title = "รายงานข้อมูลผู้ผลิตและสินค้า";
                e.Graphics.DrawString(title, titleFont, Brushes.Navy, new PointF(startX, startY - 40));

                // Header style
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Brush headerBrush = new SolidBrush(Color.White);
                Pen headerBorderPen = new Pen(headerColor, 1);
                Brush headerBackBrush = new SolidBrush(headerColor);

                // Cell style
                Font cellFont = new Font("Arial", 11);
                Brush cellBrush = new SolidBrush(Color.Black);
                Pen cellBorderPen = new Pen(Color.LightGray, 1);

                // Draw header
                int currentX = startX;
                for (int i = 0; i < columnCount; i++)
                {
                    RectangleF headerRect = new RectangleF(currentX, startY, colWidths[i], cellHeight);

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

                    currentX += colWidths[i];
                }

                // Draw rows
                int rowY = startY + cellHeight;
                for (int i = currentRowIndex; i < rowCount; i++)
                {
                    currentX = startX;
                    Brush rowBrush = (i % 2 == 0) ? Brushes.White : new SolidBrush(alternateRowColor);

                    for (int j = 0; j < columnCount; j++)
                    {
                        RectangleF cellRect = new RectangleF(currentX, rowY, colWidths[j], cellHeight);
                        string cellText = dataGridResult.Rows[i].Cells[j].Value?.ToString() ?? "";

                        // Draw cell background and border
                        e.Graphics.FillRectangle(rowBrush, cellRect);
                        e.Graphics.DrawRectangle(cellBorderPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                        // Draw cell text with proper alignment
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;

                        e.Graphics.DrawString(
                            cellText,
                            cellFont,
                            cellBrush,
                            cellRect,
                            format
                        );

                        currentX += colWidths[j];
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
                ShowErrorMessage("Error generating report", ex);
                e.HasMorePages = false;
            }
        }
        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}