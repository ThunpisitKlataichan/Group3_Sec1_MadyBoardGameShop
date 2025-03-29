﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportFrontStore : Form
    {
        public formReportFrontStore()
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
