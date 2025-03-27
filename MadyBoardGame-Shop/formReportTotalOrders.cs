using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    //ตามตรงคคือกูให้ Chat เขียนเอาเเละหวังว่าจะไม่มี error ถ้ามีกูจะไปแก้ให้
    public partial class formReportTotalOrders : Form
    {
        private SqlConnection _connection;
        private bool waitingForLoad = false;
        public formReportTotalOrders()
        {
            InitializeComponent();
        }

        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimeEnd.MinDate = dateTimeStart.Value;
                dateTimeEnd.MaxDate = DateTime.Now;
                LoadReportData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating date range: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formReportTotalOrders_Load(object sender, EventArgs e)
        {
            dateTimeStart.MaxDate = DateTime.Now;
            dateTimeEnd.MaxDate = DateTime.Now;
            dateTimeEnd.MinDate = dateTimeStart.Value;
            comboDateTypeSelect.SelectedIndex = 0;

            // Set default date range (last 30 days)
            dateTimeStart.Value = DateTime.Now.AddDays(-30);
            LoadReportData();  // Add this line to load data initially
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
                    FormatDataGridViewColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetReportQuery()
        {
            switch (comboDateTypeSelect.SelectedIndex)
            {
                case 0: // Daily
                    return @"
                        SELECT 
                            CAST(o.OrderDate AS DATE) AS [Order Date], 
                            COUNT(DISTINCT o.OrderID) AS [Total Orders],
                            SUM(od.Quantity) AS [Items Sold],
                            SUM(p.Price * (od.Quantity)) AS [Total Sales],
                            AVG(p.Price * od.Quantity) AS [Avg Order Value]
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @startDate AND @endDate
                        GROUP BY CAST(o.OrderDate AS DATE)
                        ORDER BY [Order Date]";

                case 1: // Monthly
                    return @"
                        SELECT 
                            YEAR(o.OrderDate) AS [Year],
                            MONTH(o.OrderDate) AS [Month],
                            DATENAME(MONTH, o.OrderDate) AS [Month Name],
                            COUNT(DISTINCT o.OrderID) AS [Total Orders],
                            SUM(od.Quantity) AS [Items Sold],
                            SUM(p.Price * od.Quantity) AS [Total Sales],
                            AVG(p.Price * od.Quantity) AS [Avg Order Value]
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @startDate AND @endDate
                        GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate), DATENAME(MONTH, o.OrderDate)
                        ORDER BY [Year], [Month]";

                case 2: // Yearly
                    return @"
                        SELECT 
                            YEAR(o.OrderDate) AS [Year],
                            COUNT(DISTINCT o.OrderID) AS [Total Orders],
                            SUM(od.Quantity) AS [Items Sold],
                            SUM(p.Price * od.Quantity) AS [Total Sales],
                            AVG(p.Price * od.Quantity) AS [Avg Order Value],
                            SUM(p.Price * od.Quantity) / NULLIF(COUNT(DISTINCT o.OrderID), 0) AS [Avg Value Per Order],
                            SUM(p.Price * od.Quantity) / NULLIF(SUM(od.Quantity), 0) AS [Avg Price Per Item]
                        FROM Orders o
                        INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @startDate AND @endDate
                        GROUP BY YEAR(o.OrderDate)
                        ORDER BY [Year]";

                default:
                    return string.Empty;
            }
        }

        private void FormatDataGridViewColumns()
        {
            if (dataGridResult.Columns.Count == 0) return;

            // Format currency columns
            foreach (DataGridViewColumn column in dataGridResult.Columns)
            {
                if (column.Name.Contains("Sales") || column.Name.Contains("Value") || column.Name.Contains("Price"))
                {
                    column.DefaultCellStyle.Format = "N2";
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (column.Name.Contains("Quantity") || column.Name.Contains("Orders"))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // Auto-size columns
            dataGridResult.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            dateTimeEnd.MinDate = dateTimeStart.Value;
            dateTimeStart.MaxDate = dateTimeEnd.Value;
            LoadReportData();
        }

        private void buttonRedate_Click(object sender, EventArgs e)
        {
            dateTimeEnd.Value = DateTime.Now;
            dateTimeStart.Value = DateTime.Now.AddDays(-30);
        }
    }
}