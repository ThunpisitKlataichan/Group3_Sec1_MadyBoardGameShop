using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportProfit : Form
    {
        public formReportProfit()
        {
            InitializeComponent();
        }

        private int currentRowIndex = 0;
        private Color headerColor = Color.FromArgb(51, 51, 76);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);

        private void formReportProfit_Load(object sender, EventArgs e)
        {
            try
            {
                // Set date range defaults
                dateTimeEnd.MaxDate = DateTime.Now.AddDays(1);
                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = DateTime.Now.AddMonths(-1);
                dateTimeStart.MaxDate = DateTime.Now;

                // Initialize combo box
                comboDateTypeSelect.SelectedIndex = 0;

                // Load data with professional styling
                LoadDataIntoDataGrid();
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

            // Numeric column formatting
            string[] numericColumns = { "Total Quantity Purchased", "Total Purchase Cost",
                                      "Total Quantity Sold", "Total Sales Revenue",
                                      "Net Profit", "Profit Margin %" };

            foreach (string col in numericColumns)
            {
                if (dataGridResult.Columns.Contains(col))
                {
                    dataGridResult.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    if (col != "Profit Margin %")
                    {
                        dataGridResult.Columns[col].DefaultCellStyle.Format = "N2";
                    }
                    else
                    {
                        dataGridResult.Columns[col].DefaultCellStyle.Format = "0.00'%'";
                    }
                }
            }

            // Set Thai column headers where appropriate
            if (dataGridResult.Columns.Contains("Period")) dataGridResult.Columns["Period"].HeaderText = "ช่วงเวลา";
            if (dataGridResult.Columns.Contains("Purchase Count")) dataGridResult.Columns["Purchase Count"].HeaderText = "จำนวนการสั่งซื้อ";
            if (dataGridResult.Columns.Contains("Total Quantity Purchased")) dataGridResult.Columns["Total Quantity Purchased"].HeaderText = "จำนวนสินค้าที่ซื้อ";
            if (dataGridResult.Columns.Contains("Total Purchase Cost")) dataGridResult.Columns["Total Purchase Cost"].HeaderText = "ต้นทุนทั้งหมด";
            if (dataGridResult.Columns.Contains("Sales Count")) dataGridResult.Columns["Sales Count"].HeaderText = "จำนวนการขาย";
            if (dataGridResult.Columns.Contains("Total Quantity Sold")) dataGridResult.Columns["Total Quantity Sold"].HeaderText = "จำนวนสินค้าที่ขาย";
            if (dataGridResult.Columns.Contains("Total Sales Revenue")) dataGridResult.Columns["Total Sales Revenue"].HeaderText = "รายได้ทั้งหมด";
            if (dataGridResult.Columns.Contains("Net Profit")) dataGridResult.Columns["Net Profit"].HeaderText = "กำไรสุทธิ";
            if (dataGridResult.Columns.Contains("Profit Margin %")) dataGridResult.Columns["Profit Margin %"].HeaderText = "อัตรากำไร (%)";

            // Add some padding to cells
            dataGridResult.DefaultCellStyle.Padding = new Padding(5);
            dataGridResult.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        }

        private void LoadDataIntoDataGrid()
        {
            try
            {
                using (SqlConnection profitconnection = new SqlConnection(InitializeUser._key_con))
                {
                    profitconnection.Open();
                    string qry = GetReportQuery();

                    using (SqlCommand profitcommand = new SqlCommand(qry, profitconnection))
                    {
                        // Add date parameters
                        profitcommand.Parameters.AddWithValue("@StartDate", dateTimeStart.Value.Date);
                        profitcommand.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1));

                        SqlDataAdapter profitadapter = new SqlDataAdapter(profitcommand);
                        DataTable profittable = new DataTable();
                        profitadapter.Fill(profittable);

                        // Calculate total profit
                        decimal totalProfit = 0;
                        foreach (DataRow row in profittable.Rows)
                        {
                            if (row["Net Profit"] != DBNull.Value)
                            {
                                totalProfit += Convert.ToDecimal(row["Net Profit"]);
                            }
                        }

                        // Display data
                        dataGridResult.DataSource = profittable;

                        // Format profit display with Thai Baht symbol
                        textBoxProfit.Text = totalProfit.ToString("C2", new System.Globalization.CultureInfo("th-TH"));

                        // Highlight profit/loss
                        textBoxProfit.ForeColor = totalProfit >= 0 ? Color.Green : Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error loading profit data", ex);
            }
        }

        private string GetReportQuery()
        {
            string baseQuery = @"
                SELECT 
                    {0} AS [Period],
                    COUNT(DISTINCT Purchasing.PurID) AS [Purchase Count],
                    SUM(TRY_CAST(PurchaseDetail.Quality AS INT)) AS [Total Quantity Purchased],
                    SUM(TRY_CAST(PurchaseDetail.Quality AS DECIMAL(18,2)) * Products.CostPrice) AS [Total Purchase Cost],
                    
                    COUNT(DISTINCT o.OrderID) AS [Sales Count],
                    SUM(ISNULL(od.Quantity, 0)) AS [Total Quantity Sold],
                    SUM(ISNULL(Products.Price * od.Quantity, 0)) AS [Total Sales Revenue],
                    
                    SUM(ISNULL(Products.Price * od.Quantity, 0)) - 
                    SUM(TRY_CAST(PurchaseDetail.Quality AS DECIMAL(18,2)) * Products.CostPrice) AS [Net Profit],
                    
                    CASE WHEN SUM(ISNULL(Products.Price * od.Quantity, 0)) > 0
                        THEN (SUM(ISNULL(Products.Price * od.Quantity, 0)) - 
                            SUM(TRY_CAST(PurchaseDetail.Quality AS DECIMAL(18,2)) * Products.CostPrice)) / 
                            SUM(ISNULL(Products.Price * od.Quantity, 0)) * 100
                        ELSE 0
                    END AS [Profit Margin %]
                    
                FROM Purchasing
                INNER JOIN PurchaseDetail ON Purchasing.PurID = PurchaseDetail.PurID
                INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
                LEFT JOIN OrderDetails od ON Products.ProductID = od.ProductID
                LEFT JOIN Orders o ON od.OrderID = o.OrderID 
                    AND o.OrderDate BETWEEN Purchasing.PurlDate AND DATEADD(DAY, 30, Purchasing.PurlDate)
                WHERE Purchasing.PurlDate BETWEEN @StartDate AND @EndDate
                GROUP BY {1}
                ORDER BY {2} DESC";

            switch (comboDateTypeSelect.SelectedItem.ToString())
            {
                case "รายวัน":
                    return string.Format(baseQuery,
                        "FORMAT(Purchasing.PurlDate, 'dd/MM/yyyy')",
                        "FORMAT(Purchasing.PurlDate, 'dd/MM/yyyy')",
                        "MAX(Purchasing.PurlDate)");

                case "รายสัปดาห์":
                    return string.Format(baseQuery,
                        "'Week ' + CAST(DATEPART(WEEK, Purchasing.PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(WEEK, Purchasing.PurlDate), DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");

                case "รายเดือน":
                    return string.Format(baseQuery,
                        "'Month ' + CAST(DATEPART(MONTH, Purchasing.PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(MONTH, Purchasing.PurlDate), DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");

                case "รายปี":
                    return string.Format(baseQuery,
                        "CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");

                default:
                    return "";
            }
        }

        private void btn_print_to_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                currentRowIndex = 0;
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                printDocument.PrinterSettings.PrintFileName = $"Profit_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
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
                string title = $"รายงานกำไร {comboDateTypeSelect.SelectedItem} ระหว่าง {dateTimeStart.Value:dd/MM/yyyy} ถึง {dateTimeEnd.Value:dd/MM/yyyy}";
                e.Graphics.DrawString(title, titleFont, Brushes.Navy, new PointF(startX, startY - 40));

                // Draw summary
                Font summaryFont = new Font("Arial", 12, FontStyle.Bold);
                string summary = $"กำไรสุทธิรวม: {textBoxProfit.Text}";
                e.Graphics.DrawString(summary, summaryFont,
                    textBoxProfit.ForeColor == Color.Green ? Brushes.Green : Brushes.Red,
                    new PointF(startX, startY - 20));

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

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องไม่มากกว่าวันที่สิ้นสุด", "ข้อผิดพลาด",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDataIntoDataGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Now.AddMonths(-1);
            dateTimeEnd.Value = DateTime.Now;
            comboDateTypeSelect.SelectedIndex = 0;
            LoadDataIntoDataGrid();
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGrid();
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