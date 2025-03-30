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

        SqlConnection profitconnection;
        SqlCommand profitcommand;
        SqlDataAdapter profitadapter;
        DataTable profittable;
        private int currentRowIndex = 0;

        private void formReportProfit_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimeEnd.MaxDate = DateTime.Now.AddDays(1);
                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = DateTime.Now.AddMonths(-1);
                dateTimeStart.MaxDate = DateTime.Now;
                comboDateTypeSelect.SelectedIndex = 0;
                LoadDataIntoDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void LoadDataIntoDataGrid()
        {
            try
            {
                using (profitconnection = new SqlConnection(InitializeUser._key_con))
                {
                    profitconnection.Open();
                    string qry = GetReportQuery();

                    using (profitcommand = new SqlCommand(qry, profitconnection))
                    {
                        // Add date parameters
                        profitcommand.Parameters.AddWithValue("@StartDate", dateTimeStart.Value.Date);
                        profitcommand.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1));

                        profitadapter = new SqlDataAdapter(profitcommand);
                        profittable = new DataTable();
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

                        // แสดงผลกำไรสุทธิ 2 ตำแหน่งทศนิยม
                        textBoxProfit.Text = totalProfit.ToString("N2"); // "N2" = Number with 2 decimal places

                        // หรือใช้รูปแบบสกุลเงิน (มีเครื่องหมายบาท)
                        // textBoxProfit.Text = totalProfit.ToString("C2", new System.Globalization.CultureInfo("th-TH"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
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
    ORDER BY {2} DESC";  // เพิ่ม DESC เพื่อเรียงจากมากไปน้อย (วันที่ล่าสุดขึ้นก่อน)

            switch (comboDateTypeSelect.SelectedItem.ToString())
            {
                case "รายวัน":
                    return string.Format(baseQuery,
                        "FORMAT(Purchasing.PurlDate, 'dd/MM/yyyy')",
                        "FORMAT(Purchasing.PurlDate, 'dd/MM/yyyy')",
                        "MAX(Purchasing.PurlDate)");  // เปลี่ยนจาก MIN เป็น MAX

                case "รายสัปดาห์":
                    return string.Format(baseQuery,
                        "'Week ' + CAST(DATEPART(WEEK, Purchasing.PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(WEEK, Purchasing.PurlDate), DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");  // เรียงตามวันที่ล่าสุดของสัปดาห์

                case "รายเดือน":
                    return string.Format(baseQuery,
                        "'Month ' + CAST(DATEPART(MONTH, Purchasing.PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(MONTH, Purchasing.PurlDate), DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");  // เรียงตามวันที่ล่าสุดของเดือน

                case "รายปี":
                    return string.Format(baseQuery,
                        "CAST(DATEPART(YEAR, Purchasing.PurlDate) AS VARCHAR)",
                        "DATEPART(YEAR, Purchasing.PurlDate)",
                        "MAX(Purchasing.PurlDate)");  // เรียงตามวันที่ล่าสุดของปี

                default:
                    return "";
            }
        }

        private void btn_print_to_pdf_Click(object sender, EventArgs e)
        {
            currentRowIndex = 0;
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrinterSettings.PrintFileName = "C:\\Users\\Public\\Documents\\ProfitReport.pdf";
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int pageWidth = e.PageBounds.Width - 100;
            int pageHeight = e.PageBounds.Height - 100;
            int columnCount = dataGridResult.Columns.Count;
            int rowCount = dataGridResult.Rows.Count;

            int cellHeight = 50;
            int startX = 50;
            int startY = 50;

            int cellWidth = pageWidth / columnCount;
            using (Pen blackPen = new Pen(Color.Black, 1))
            using (Font font = new Font("Arial", 12))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                // Draw Header
                for (int i = 0; i < columnCount; i++)
                {
                    e.Graphics.DrawRectangle(blackPen, startX + (i * cellWidth), startY, cellWidth, cellHeight);
                    e.Graphics.DrawString(
                        dataGridResult.Columns[i].HeaderText, font, brush,
                        new RectangleF(startX + (i * cellWidth), startY, cellWidth, cellHeight),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }

                // Draw data rows
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

                    if (rowY + cellHeight > pageHeight)
                    {
                        currentRowIndex = i + 1;
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
                currentRowIndex = 0;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องไม่มากกว่าวันที่สิ้นสุด");
                return;
            }
            LoadDataIntoDataGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Now.AddMonths(-1);
            dateTimeEnd.Value = DateTime.Now;
            LoadDataIntoDataGrid();
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGrid();
        }
    }
}