using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportSuppiler : Form
    {
        public formReportSuppiler()
        {
            InitializeComponent();
        }

        SqlConnection consuppilier;
        SqlCommand cmdsuppiler;
        SqlDataAdapter dasuppiler;
        DataTable dtsuppiler;

        private void formReportSuppiler_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
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
            using (consuppilier = new SqlConnection(InitializeUser._key_con))
            {
                consuppilier.Open();
                string qry = BuildBaseQuery() + " ORDER BY Suppilers.SuppilerID, ProductID";

                cmdsuppiler = new SqlCommand(qry, consuppilier);
                dasuppiler = new SqlDataAdapter(cmdsuppiler);
                dtsuppiler = new DataTable();
                dasuppiler.Fill(dtsuppiler);
                dataGridResult.DataSource = dtsuppiler;
            }
        }

        private void ApplyFilters()
        {
            string whereClause = "";
            bool hasFilter = false;

            // เงื่อนไขการค้นหาด้วย SupplierID
            if (!string.IsNullOrEmpty(txtSuppilerID.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "Suppilers.SuppilerID LIKE @SuppilerID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย SupplierName
            if (!string.IsNullOrEmpty(txtSuppilerName.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "SuppilerName LIKE @SuppilerName";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย ProductID
            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "ProductID LIKE @ProductID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย ProductName
            if (!string.IsNullOrEmpty(txtProductName.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "ProductName LIKE @ProductName";
                hasFilter = true;
            }

            string orderByClause = "ORDER BY Suppilers.SuppilerID, ProductID";

            using (consuppilier = new SqlConnection(InitializeUser._key_con))
            {
                consuppilier.Open();
                string qry = BuildBaseQuery() + " " + whereClause + " " + orderByClause;

                using (cmdsuppiler = new SqlCommand(qry, consuppilier))
                {
                    // เพิ่มพารามิเตอร์ตามเงื่อนไข
                    if (!string.IsNullOrEmpty(txtSuppilerID.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@SuppilerID", "%" + txtSuppilerID.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtSuppilerName.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@SuppilerName", "%" + txtSuppilerName.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtProductID.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@ProductID", "%" + txtProductID.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtProductName.Text))
                    {
                        cmdsuppiler.Parameters.AddWithValue("@ProductName", "%" + txtProductName.Text + "%");
                    }

                    dasuppiler = new SqlDataAdapter(cmdsuppiler);
                    dtsuppiler = new DataTable();
                    dasuppiler.Fill(dtsuppiler);
                    dataGridResult.DataSource = dtsuppiler;
                }
            }
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // เคลียร์ค่ากรองทั้งหมด
            txtSuppilerID.Text = "";
            txtSuppilerName.Text = "";
            txtProductID.Text = "";
            txtProductName.Text = "";

            // โหลดข้อมูลทั้งหมดใหม่
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
    }
}