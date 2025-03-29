using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportTotalOrders : Form
    {
        public formReportTotalOrders()
        {
            InitializeComponent();
        }
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataAdapter _adapter;
        DataTable _dataTable;
        private void formReportFrontStore_Load(object sender, EventArgs e)
        {
            dateTimeStart.MaxDate = DateTime.Now;
            dateTimeEnd.MaxDate = DateTime.Now;
            dateTimeEnd.MinDate = dateTimeStart.Value;
            comboDateTypeSelect.SelectedIndex = 0;

            // Set default date range (last 30 days)
            dateTimeStart.Value = DateTime.Now.AddDays(-30);
            LoadReportData();
        }
        private void LoadReportData()
        {
            try
            {
                using (_connection = new SqlConnection(InitializeUser._key_con))
                {
                    _connection.Open();

                    string query = GetReportQuery();
                    SqlCommand command = new SqlCommand(query, _connection);
                    command.Parameters.AddWithValue("@startDate", dateTimeStart.Value.Date);
                    command.Parameters.AddWithValue("@endDate", dateTimeEnd.Value.Date.AddDays(1));

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Format the DataGridView columns
                    dataGridResult.DataSource = dataTable;
                    FormatDataGridColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatDataGridColumns()
        {
            switch (comboDateTypeSelect.SelectedIndex)
            {
                case 0: // Daily
                    FormatDailyDataGridColumns();
                    break;
                case 1: // Monthly
                    FormatMonthlyDataGridColumns();
                    break;
                case 2: // Yearly
                    FormatYearlyDataGridColumns();
                    break;
            }
        }
        private void FormatDataGridSizeFill()
        {
            // ตั้งค่าให้คอลัมน์แรกใช้ขนาดตามเนื้อหา
            dataGridResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // ตั้งค่าคอลัมน์อื่นๆ ให้ใช้พื้นที่ที่เหลือทั้งหมด
            for (int i = 1; i < dataGridResult.Columns.Count; i++)
            {
                dataGridResult.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void FormatDailyDataGridColumns()
        {
            dataGridResult.Columns[0].HeaderText = "วัน/เดือน/ปี";
            dataGridResult.Columns[1].HeaderText = "จำนวณการซื้อหน้าร้าน";
            dataGridResult.Columns[2].HeaderText = "จำนวนสินค้าที่ถูกซื้อ(หน้าร้าน)";
            dataGridResult.Columns[3].HeaderText = "ยอดซื้อ";
            dataGridResult.Columns[4].HeaderText = "จำนวนคำสั่งซื้อทั้งหมด";
            dataGridResult.Columns[5].HeaderText = "จำนวนสินค้าที่ถูกซื้อ";
            dataGridResult.Columns[6].HeaderText = "ยอดคำสั่งซื้อ";
            dataGridResult.Columns[7].HeaderText = "ค่าเฉลี่ยคำสั่งซื้อ";
            dataGridResult.Columns[8].HeaderText = "ประเภทคำสั่งซื้อ";

            dataGridResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridResult.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridResult.Columns[3].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[6].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[7].DefaultCellStyle.Format = "c";

            FormatDataGridSizeFill();
        }
        private void FormatMonthlyDataGridColumns()
        {
            dataGridResult.Columns[0].HeaderText = "เดือน";
            dataGridResult.Columns[1].HeaderText = "จำนวณการซื้อหน้าร้าน";
            dataGridResult.Columns[2].HeaderText = "จำนวนสินค้าที่ถูกซื้อ(หน้าร้าน)";
            dataGridResult.Columns[3].HeaderText = "ยอดซื้อ(หน้าร้าน)";
            dataGridResult.Columns[4].HeaderText = "จำนวนคำสั่งซื้อทั้งหมด";
            dataGridResult.Columns[5].HeaderText = "จำนวนสินค้าที่ถูกซื้อ";
            dataGridResult.Columns[6].HeaderText = "ยอดคำสั่งซื้อ";
            dataGridResult.Columns[7].HeaderText = "ค่าเฉลี่ยคำสั่งซื้อ";
            dataGridResult.Columns[8].HeaderText = "ประเภทคำสั่งซื้อ";

            dataGridResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridResult.Columns[0].DefaultCellStyle.Format = "yyyy-MM";
            dataGridResult.Columns[3].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[6].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[7].DefaultCellStyle.Format = "c";

            FormatDataGridSizeFill();
        }
        private void FormatYearlyDataGridColumns()
        {
            dataGridResult.Columns[0].HeaderText = "ปี";
            dataGridResult.Columns[1].HeaderText = "จำนวณการซื้อหน้าร้าน";
            dataGridResult.Columns[2].HeaderText = "จำนวนสินค้าที่ถูกซื้อ(หน้าร้าน)";
            dataGridResult.Columns[3].HeaderText = "ยอดซื้อ(หน้าร้าน)";
            dataGridResult.Columns[4].HeaderText = "จำนวนคำสั่งซื้อทั้งหมด";
            dataGridResult.Columns[5].HeaderText = "จำนวนสินค้าที่ถูกซื้อ";
            dataGridResult.Columns[6].HeaderText = "ยอดคำสั่งซื้อ";
            dataGridResult.Columns[7].HeaderText = "ค่าเฉลี่ยคำสั่งซื้อ";
            dataGridResult.Columns[8].HeaderText = "ประเภทคำสั่งซื้อ";

            dataGridResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridResult.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridResult.Columns[0].DefaultCellStyle.Format = "yyyy";
            dataGridResult.Columns[3].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[6].DefaultCellStyle.Format = "c";
            dataGridResult.Columns[7].DefaultCellStyle.Format = "c";

            FormatDataGridSizeFill();
        }
        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetReportQuery()
        {
            switch (comboDateTypeSelect.SelectedIndex)
            {
                case 0: // Daily
                    return @"
                      -- Combined Sales Report with Date, Order Counts, and Sales Figures
                        SELECT 
                            [Date],
                            [PayFront Orders] AS [Total PayFront Orders],
                            [PayFront Quality] AS [Total Quality],
                            [PayFront Sales] AS [Total Sales],
                            NULL AS [Total Orders],
                            NULL AS [Items Sold],
                            NULL AS [Order Sales],
                            NULL AS [Avg Order Value],
                            'PayFront' AS [Report Type]
                        FROM (
                            SELECT
                                CAST(Paydate AS DATE) AS [Date],
                                COUNT(pfs.PayfID) AS [PayFront Orders],
                                SUM(pfd.Quality) AS [PayFront Quality],
                                SUM(p.Price * pfd.Quality) AS [PayFront Sales]
                            FROM
                                PayFrontStore pfs
                            INNER JOIN PayFrontStoreDetails pfd ON pfs.PayfID = pfd.PayfID  
                            INNER JOIN Products p ON pfd.ProductID = p.ProductID
                            WHERE pfs.Paydate BETWEEN @startDate AND @endDate
                            GROUP BY CAST(Paydate AS DATE)
                        ) PayFrontData  -- Removed AS here, just closing parenthesis

                        UNION ALL

                        SELECT 
                            [Date],
                            NULL AS [Total PayFront Orders],
                            NULL AS [Total Quality],
                            NULL AS [Total Sales],
                            [Total Orders],
                            [Items Sold],
                            [Order Sales] AS [Total Sales],
                            [Avg Order Value],
                            'Online' AS [Report Type]
                        FROM (
                            SELECT 
                                CAST(o.OrderDate AS DATE) AS [Date], 
                                COUNT(DISTINCT o.OrderID) AS [Total Orders],
                                SUM(od.Quantity) AS [Items Sold],
                                SUM(p.Price * od.Quantity) AS [Order Sales],
                                AVG(p.Price * od.Quantity) AS [Avg Order Value]
                            FROM Orders o
                            INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                            INNER JOIN Products p ON od.ProductID = p.ProductID
                            WHERE o.OrderDate BETWEEN @startDate AND @endDate
                            GROUP BY CAST(o.OrderDate AS DATE)
                        ) OnlineOrdersData  -- Removed AS here, just closing parenthesis

                        ORDER BY [Date], [Report Type]";
                case 1: // Monthly
                    return @"
                    -- Monthly Combined Sales Report
                    SELECT 
                        FORMAT([Date], 'yyyy-MM') AS [Month],
                        SUM([Total PayFront Orders]) AS [Total PayFront Orders],
                        SUM([Total Quality]) AS [Total Quality],
                        SUM([Total Sales]) AS [Total PayFront Sales],
                        SUM([Total Orders]) AS [Total Online Orders],
                        SUM([Items Sold]) AS [Total Items Sold],
                        SUM([Order Sales]) AS [Total Online Sales],
                        CASE 
                            WHEN SUM([Total Orders]) > 0 
                            THEN SUM([Order Sales])/SUM([Total Orders]) 
                            ELSE 0 
                        END AS [Avg Order Value],
                        'Monthly' AS [Report Period]
                    FROM (
                        -- PayFront data
                        SELECT
                            CAST(Paydate AS DATE) AS [Date],
                            COUNT(pfs.PayfID) AS [Total PayFront Orders],
                            SUM(pfd.Quality) AS [Total Quality],
                            SUM(p.Price * pfd.Quality) AS [Total Sales],
                            0 AS [Total Orders],
                            0 AS [Items Sold],
                            0 AS [Order Sales],
                            0 AS [Avg Order Value]
                        FROM PayFrontStore pfs
                        INNER JOIN PayFrontStoreDetails pfd ON pfs.PayfID = pfd.PayfID  
                        INNER JOIN Products p ON pfd.ProductID = p.ProductID
                        WHERE pfs.Paydate BETWEEN @startDate AND @endDate
                        GROUP BY CAST(Paydate AS DATE)
    
                        UNION ALL
    
                        -- Online orders data
                        SELECT 
                            CAST(o.OrderDate AS DATE) AS [Date], 
                            0 AS [Total PayFront Orders],
                            0 AS [Total Quality],
                            0 AS [Total Sales],
                            COUNT(DISTINCT o.OrderID) AS [Total Orders],
                            SUM(od.Quantity) AS [Items Sold],
                            SUM(p.Price * od.Quantity) AS [Order Sales],
                            AVG(p.Price * od.Quantity) AS [Avg Order Value]
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @startDate AND @endDate
                        GROUP BY CAST(o.OrderDate AS DATE)
                    ) CombinedData
                    GROUP BY FORMAT([Date], 'yyyy-MM')
                    ORDER BY [Month]
                        ";
                case 2: // Yearly
                    return @"
                        -- Yearly Combined Sales Report
                    SELECT 
                        YEAR([Date]) AS [Year],
                        SUM([Total PayFront Orders]) AS [Total PayFront Orders],
                        SUM([Total Quality]) AS [Total Quality],
                        SUM([Total Sales]) AS [Total PayFront Sales],
                        SUM([Total Orders]) AS [Total Online Orders],
                        SUM([Items Sold]) AS [Total Items Sold],
                        SUM([Order Sales]) AS [Total Online Sales],
                        CASE 
                            WHEN SUM([Total Orders]) > 0 
                            THEN SUM([Order Sales])/SUM([Total Orders]) 
                            ELSE 0 
                        END AS [Avg Order Value],
                        'Yearly' AS [Report Period]
                    FROM (
                        -- PayFront data
                        SELECT
                            CAST(Paydate AS DATE) AS [Date],
                            COUNT(pfs.PayfID) AS [Total PayFront Orders],
                            SUM(pfd.Quality) AS [Total Quality],
                            SUM(p.Price * pfd.Quality) AS [Total Sales],
                            0 AS [Total Orders],
                            0 AS [Items Sold],
                            0 AS [Order Sales],
                            0 AS [Avg Order Value]
                        FROM PayFrontStore pfs
                        INNER JOIN PayFrontStoreDetails pfd ON pfs.PayfID = pfd.PayfID  
                        INNER JOIN Products p ON pfd.ProductID = p.ProductID
                        WHERE pfs.Paydate BETWEEN @startDate AND @endDate
                        GROUP BY CAST(Paydate AS DATE)
    
                        UNION ALL
    
                        -- Online orders data
                        SELECT 
                            CAST(o.OrderDate AS DATE) AS [Date], 
                            0 AS [Total PayFront Orders],
                            0 AS [Total Quality],
                            0 AS [Total Sales],
                            COUNT(DISTINCT o.OrderID) AS [Total Orders],
                            SUM(od.Quantity) AS [Items Sold],
                            SUM(p.Price * od.Quantity) AS [Order Sales],
                            AVG(p.Price * od.Quantity) AS [Avg Order Value]
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @startDate AND @endDate
                        GROUP BY CAST(o.OrderDate AS DATE)
                    ) CombinedData
                    GROUP BY YEAR([Date])
                    ORDER BY [Year]
";
                default:
                    return string.Empty;
            }
        }
        private void buttonRedate_Click(object sender, EventArgs e)
        {
            try
            {
                // ตั้งค่าขอบเขตวันที่ให้กับ DateTimePicker
                ConfigureDateRangeControls();

                // โหลดข้อมูลรายงานใหม่
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการตั้งค่าวันที่: {ex.Message}", "ข้อผิดพลาด",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureDateRangeControls()
        {
            dateTimeStart.Value = DateTime.Now.AddDays(-30);
            dateTimeStart.MaxDate = DateTime.Now;
            dateTimeEnd.MaxDate = DateTime.Now;
            dateTimeEnd.MinDate = dateTimeStart.Value;
            dateTimeEnd.Value = DateTime.Now;



            // ตั้งค่า Event เมื่อวันที่เริ่มต้นเปลี่ยนแปลง
            dateTimeStart.ValueChanged += (s, ev) =>
            {
                dateTimeEnd.MinDate = dateTimeStart.Value;
            };
        }
        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการตั้งค่าวันที่: {ex.Message}", "ข้อผิดพลาด",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการตั้งค่าวันที่: {ex.Message}", "ข้อผิดพลาด",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonprint_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการสร้างรายงาน: {ex.Message}",
                              "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateReport()
        {
            // ตรวจสอบว่ามีข้อมูลที่จะรายงานหรือไม่
            var reportData = GetReportData();
            if (reportData == null || reportData.Count == 0)
            {
                MessageBox.Show("ไม่พบข้อมูลที่จะแสดงในรายงาน", "แจ้งเตือน",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // สร้างและตั้งค่า ReportViewer
            ReportViewer reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                WaitControlDisplayAfter = 500 // หน่วงเวลาแสดง loading 500 มิลลิวินาที
            };

            // ตรวจสอบว่าไฟล์รายงานมีอยู่จริง
            string reportPath = "Reports/Report1.rdlc";
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("ไม่พบไฟล์รายงานที่กำหนด", "ข้อผิดพลาด",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ตั้งค่า ReportViewer
            reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData));

            // ตั้งค่าพารามิเตอร์เพิ่มเติม (ถ้ามี)
            // reportViewer.LocalReport.SetParameters(new ReportParameter("Parameter1", value));

            // สร้างฟอร์มสำหรับแสดงรายงาน
            Form reportForm = new Form
            {
                WindowState = FormWindowState.Maximized,
                Text = "รายงานการขาย",
                StartPosition = FormStartPosition.CenterScreen
            };

            // เพิ่ม ReportViewer ลงในฟอร์ม
            reportViewer.Dock = DockStyle.Fill;
            reportForm.Controls.Add(reportViewer);

            // ปุ่มพิมพ์และตัวเลือกอื่นๆ
            reportViewer.ShowPrintButton = true;
            reportViewer.ShowExportButton = true;
            reportViewer.ShowZoomControl = true;
            reportViewer.ShowPageNavigationControls = true;
            reportViewer.ShowRefreshButton = false;
            reportViewer.ShowBackButton = false;

            // โหลดรายงาน
            reportViewer.RefreshReport();

            // แสดงฟอร์ม
            reportForm.ShowDialog();
        }

        private List<ReportData> GetReportData()
        {
            // ตัวอย่างการดึงข้อมูลจากฐานข้อมูล
            List<ReportData> data = new List<ReportData>();

            try
            {
                string sql = @"SELECT * FROM Orders 
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
WHERE OrderDate BETWEEN @StartDate AND @EndDate";

                using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@StartDate", dateTimeStart.Value.Date);
                    cmd.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value.Date);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.Add(new ReportData
                            {
                                OrderID = reader["OrderID"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                SaleDate = Convert.ToDateTime(reader["SaleDate"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการดึงข้อมูล: {ex.Message}",
                              "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        // คลาสสำหรับเก็บข้อมูลรายงาน
        public class ReportData
        {
            public string OrderID { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public DateTime SaleDate { get; set; }
        }
    }
}
