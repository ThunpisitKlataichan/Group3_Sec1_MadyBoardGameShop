using System;
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
    public partial class formReportPur : Form
    {
        public formReportPur()
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
                InitializeUser.Confic();
                comboDateTypeSelect.SelectedIndex = 0; // Set default selection
                LoadDataToDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataToDataGrid()
        {
            try
            {
                using (purconnection = new SqlConnection(InitializeUser._key_con))
                {
                    string query = @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN CONVERT(VARCHAR, PurlDate, 103) 
                         ELSE '' 
                    END AS [Purchase Date],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN CAST(Purchasing.PurID AS VARCHAR) 
                         ELSE '' 
                    END AS [Purchase ID],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN empName 
                         ELSE '' 
                    END AS [Employee Name],
                    Products.ProductID,
                    ProductName,
                    (PurchaseDetail.Quality * CostPrice) as [Total Spend]
                FROM Purchasing
                INNER JOIN PurchaseDetail ON Purchasing.PurID = PurchaseDetail.PurID
                INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
                INNER JOIN Employees ON Purchasing.empID = Employees.empID
                ORDER BY PurlDate, Purchasing.PurID, Products.ProductID;";

                    purcommand = new SqlCommand(query, purconnection);
                    puradapter = new SqlDataAdapter(purcommand);
                    purtable = new DataTable();
                    puradapter.Fill(purtable);
                    dataGridReusalt.DataSource = purtable;

                    CalculateAndDisplayTotal();
                    CustomizeDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void CalculateAndDisplayTotal()
        {
            decimal totalSpend = 0;
            foreach (DataRow row in purtable.Rows)
            {
                if (row["Total Spend"] != DBNull.Value)
                {
                    totalSpend += Convert.ToDecimal(row["Total Spend"]);
                }
            }
            textBoxSumPur.Text = totalSpend.ToString("N2");
        }

        private void CustomizeDataGridView()
        {
            // ตั้งค่าความกว้างของคอลัมน์
            dataGridReusalt.Columns["Purchase Date"].Width = 100;
            dataGridReusalt.Columns["Purchase ID"].Width = 80;
            dataGridReusalt.Columns["Employee Name"].Width = 120;
            dataGridReusalt.Columns["ProductID"].Width = 80;
            dataGridReusalt.Columns["ProductName"].Width = 150;
            dataGridReusalt.Columns["Total Spend"].Width = 100;

            // จัดรูปแบบคอลัมน์ตัวเลข
            dataGridReusalt.Columns["Total Spend"].DefaultCellStyle.Format = "N2";
            dataGridReusalt.Columns["Total Spend"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ตั้งค่าการจัดตำแหน่งของคอลัมน์อื่นๆ
            dataGridReusalt.Columns["ProductID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // เปลี่ยนสีพื้นหลังของแถวเมื่อเปลี่ยน PurID
            string currentPurID = "";
            for (int i = 0; i < dataGridReusalt.Rows.Count; i++)
            {
                var row = dataGridReusalt.Rows[i];
                if (row.Cells["Purchase ID"].Value?.ToString() != "")
                {
                    currentPurID = row.Cells["Purchase ID"].Value?.ToString();
                }

                // สลับสีพื้นหลังทุกกลุ่ม
                if (i % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            // ตั้งค่าให้เลือกทั้งแถว
            dataGridReusalt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReusalt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboDateTypeSelect.SelectedItem == null)
                {
                    MessageBox.Show("Please select a date type first.");
                    return;
                }

                string dateType = comboDateTypeSelect.SelectedItem.ToString();
                DateTime selectedDate = dateTimeStart.Value;

                using (purconnection = new SqlConnection(InitializeUser._key_con))
                {
                    string query = @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN CONVERT(VARCHAR, PurlDate, 103) 
                         ELSE '' 
                    END AS [Purchase Date],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN CAST(Purchasing.PurID AS VARCHAR) 
                         ELSE '' 
                    END AS [Purchase ID],
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Purchasing.PurID ORDER BY Products.ProductID) = 1 
                         THEN empName 
                         ELSE '' 
                    END AS [Employee Name],
                    Products.ProductID,
                    ProductName,
                    (PurchaseDetail.Quality * CostPrice) as [Total Spend]
                FROM Purchasing
                INNER JOIN PurchaseDetail ON Purchasing.PurID = PurchaseDetail.PurID
                INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
                INNER JOIN Employees ON Purchasing.empID = Employees.empID
                WHERE " + GetDateFilterCondition(dateType, selectedDate) + @"
                ORDER BY PurlDate, Purchasing.PurID, Products.ProductID;";

                    purcommand = new SqlCommand(query, purconnection);
                    puradapter = new SqlDataAdapter(purcommand);
                    purtable = new DataTable();
                    puradapter.Fill(purtable);
                    dataGridReusalt.DataSource = purtable;

                    CalculateAndDisplayTotal();
                    CustomizeDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering data: " + ex.Message);
            }
        }

        private string GetDateFilterCondition(string dateType, DateTime selectedDate)
        {
            switch (dateType)
            {
                case "รายวัน":
                    return $"CONVERT(DATE, PurlDate) = '{selectedDate.ToString("yyyy-MM-dd")}'";
                case "รายเดือน":
                    return $"MONTH(PurlDate) = {selectedDate.Month} AND YEAR(PurlDate) = {selectedDate.Year}";
                case "รายปี":
                    return $"YEAR(PurlDate) = {selectedDate.Year}";
                default:
                    return "1=1"; // Return all records if no valid selection
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboDateTypeSelect.SelectedIndex = 0;
            dateTimeStart.Value = DateTime.Today;
            LoadDataToDataGrid();
        }

        private void comboDateTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add any specific logic here when the selection changes
            // For example, update the label or format of the date picker
            if (comboDateTypeSelect.SelectedItem != null)
            {
                string selection = comboDateTypeSelect.SelectedItem.ToString();
                dateTimeStart.Format = DateTimePickerFormat.Long;

                if (selection == "รายเดือน")
                {
                    dateTimeStart.Format = DateTimePickerFormat.Custom;
                    dateTimeStart.CustomFormat = "MMMM yyyy";
                    dateTimeStart.ShowUpDown = true;
                }
                else if (selection == "รายปี")
                {
                    dateTimeStart.Format = DateTimePickerFormat.Custom;
                    dateTimeStart.CustomFormat = "yyyy";
                    dateTimeStart.ShowUpDown = true;
                }
                else
                {
                    dateTimeStart.Format = DateTimePickerFormat.Long;
                    dateTimeStart.ShowUpDown = false;
                }
            }
        }
    }
}