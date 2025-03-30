using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportTotalPur : Form
    {
        public formReportTotalPur()
        {
            InitializeComponent();
        }

        SqlConnection purconnection;
        SqlCommand purcommand;
        SqlDataAdapter puradapter;
        DataTable purtable;

        private void formReportPur_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize connection string (replace with your actual connection string)
                purconnection = new SqlConnection(InitializeUser._key_con);

                dateTimeEnd.MaxDate = DateTime.Now.AddDays(1);
                dateTimeEnd.Value = DateTime.Now;
                dateTimeStart.Value = DateTime.Now.AddMonths(-1);
                dateTimeStart.MaxDate = DateTime.Now;
                comboDateTypeSelect.SelectedIndex = 0;

                LoadDataToDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้: {ex.Message}");
            }
        }

        private string GetReportQuery()
        {
            string baseQuery = @"
        SELECT 
            {0} AS [Purchase Date],
            COUNT(DISTINCT Purchasing.PurID) AS [Purchase Count],
            COUNT(Products.ProductID) AS [Product Items],
            SUM(TRY_CAST(PurchaseDetail.Quality AS INT)) AS [Total Quantity],
            SUM(TRY_CAST(PurchaseDetail.Quality AS DECIMAL(18,2)) * CostPrice) AS [Total Spend]
        FROM Purchasing
        INNER JOIN PurchaseDetail ON Purchasing.PurID = PurchaseDetail.PurID
        INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
        INNER JOIN Employees ON Purchasing.empID = Employees.empID
        WHERE PurlDate BETWEEN @StartDate AND @EndDate
        GROUP BY {1}
        ORDER BY {2}";

            switch (comboDateTypeSelect.SelectedItem.ToString())
            {
                case "รายวัน":
                    return string.Format(baseQuery,
                        "FORMAT(PurlDate, 'dd/MM/yyyy')",
                        "FORMAT(PurlDate, 'dd/MM/yyyy')",
                        "MIN(PurlDate)");

                case "รายเดือน":
                    return string.Format(baseQuery,
                        "'Month ' + CAST(DATEPART(MONTH, PurlDate) AS VARCHAR) + ' ' + CAST(DATEPART(YEAR, PurlDate) AS VARCHAR)",
                        "DATEPART(MONTH, PurlDate), DATEPART(YEAR, PurlDate)",
                        "DATEPART(YEAR, PurlDate), DATEPART(MONTH, PurlDate)");

                case "รายปี":
                    return string.Format(baseQuery,
                        "CAST(DATEPART(YEAR, PurlDate) AS VARCHAR)",
                        "DATEPART(YEAR, PurlDate)",
                        "DATEPART(YEAR, PurlDate)");

                default:
                    return "";
            }
        }

        private void LoadDataToDataGrid()
        {
            try
            {
                if (purconnection.State != ConnectionState.Open)
                    purconnection.Open();

                string query = GetReportQuery();

                purcommand = new SqlCommand(query, purconnection);

                // Add parameters with values
                purcommand.Parameters.AddWithValue("@StartDate", dateTimeStart.Value.Date);
                purcommand.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value.Date.AddDays(1).AddSeconds(-1));

                puradapter = new SqlDataAdapter(purcommand);
                purtable = new DataTable();
                puradapter.Fill(purtable);

                dataGridReusalt.DataSource = purtable;
                dataGridReusalt.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูล: {ex.Message}");
            }
            finally
            {
                if (purconnection.State == ConnectionState.Open)
                    purconnection.Close();
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                MessageBox.Show("วันที่เริ่มต้นต้องไม่มากกว่าวันที่สิ้นสุด");
                return;
            }

            LoadDataToDataGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Now.AddMonths(-1);
            dateTimeEnd.Value = DateTime.Now;
            comboDateTypeSelect.SelectedIndex = 0;
            LoadDataToDataGrid();
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToDataGrid();
        }
    }
}