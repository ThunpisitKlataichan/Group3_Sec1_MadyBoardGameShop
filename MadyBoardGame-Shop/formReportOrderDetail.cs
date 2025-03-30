using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportOrderDetail : Form
    {
        public formReportOrderDetail()
        {
            InitializeComponent();
        }

        SqlConnection orderconnection;
        SqlCommand ordercommand;
        SqlDataAdapter orderadapter;
        DataTable ordertable;

        private void formReportOrders_Load(object sender, EventArgs e)
        {
            LoadDataGridview();
        }

        private void LoadDataGridview()
        {
            using (orderconnection = new SqlConnection(InitializeUser._key_con))
            {
                orderconnection.Open();
                string qry = BuildBaseQuery();

                using (ordercommand = new SqlCommand(qry, orderconnection))
                {
                    orderadapter = new SqlDataAdapter(ordercommand);
                    ordertable = new DataTable();
                    orderadapter.Fill(ordertable);
                    dataGridResult.DataSource = ordertable;
                }
            }
        }

        private string BuildBaseQuery()
        {
            return @"
                SELECT 
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Orders.OrderID ORDER BY OrderDetailID) = 1 
                         THEN CAST(Orders.OrderID AS VARCHAR) 
                         ELSE '' 
                    END AS OrderID,
                    OrderDetailID,
                    memName,
                    memLName,
                    CASE WHEN ROW_NUMBER() OVER (PARTITION BY Orders.OrderID ORDER BY OrderDetailID) = 1 
                         THEN OrderDate 
                         ELSE NULL 
                    END AS OrderDate,
                    ProductName,
                    OrderDetails.Quantity,
                    (Price * OrderDetails.Quantity) as TotalPrice
                FROM Orders 
                INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
                INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID 
                INNER JOIN Member ON Orders.memID = Member.memID";
        }

        private void ApplyFilters()
        {
            string whereClause = "";
            bool hasFilter = false;

            // เงื่อนไขการค้นหาด้วย OrderID
            if (!string.IsNullOrEmpty(txtOrderFind.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "Orders.OrderID LIKE @OrderID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วย MemberID
            if (!string.IsNullOrEmpty(txtmemIDFind.Text))
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "Orders.memID LIKE @memID";
                hasFilter = true;
            }

            // เงื่อนไขการค้นหาด้วยช่วงราคา
            decimal minPrice, maxPrice;
            bool hasMin = decimal.TryParse(textTotalPricemin.Text, out minPrice);
            bool hasMax = decimal.TryParse(textTotalPricemac.Text, out maxPrice);

            if (hasMin && hasMax)
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "(Price * OrderDetails.Quantity) BETWEEN @MinPrice AND @MaxPrice";
                hasFilter = true;
            }
            else if (hasMin)
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "(Price * OrderDetails.Quantity) >= @MinPrice";
                hasFilter = true;
            }
            else if (hasMax)
            {
                whereClause += (whereClause == "" ? "WHERE " : " AND ") +
                              "(Price * OrderDetails.Quantity) <= @MaxPrice";
                hasFilter = true;
            }

            string orderByClause = "ORDER BY Orders.OrderID, OrderDetailID";

            using (orderconnection = new SqlConnection(InitializeUser._key_con))
            {
                orderconnection.Open();
                string qry = BuildBaseQuery() + " " + whereClause + " " + orderByClause;

                using (ordercommand = new SqlCommand(qry, orderconnection))
                {
                    // เพิ่มพารามิเตอร์ตามเงื่อนไข
                    if (!string.IsNullOrEmpty(txtOrderFind.Text))
                    {
                        ordercommand.Parameters.AddWithValue("@OrderID", "%" + txtOrderFind.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(txtmemIDFind.Text))
                    {
                        ordercommand.Parameters.AddWithValue("@memID", "%" + txtmemIDFind.Text + "%");
                    }

                    if (hasMin)
                    {
                        ordercommand.Parameters.AddWithValue("@MinPrice", minPrice);
                    }

                    if (hasMax)
                    {
                        ordercommand.Parameters.AddWithValue("@MaxPrice", maxPrice);
                    }

                    orderadapter = new SqlDataAdapter(ordercommand);
                    ordertable = new DataTable();
                    orderadapter.Fill(ordertable);
                    dataGridResult.DataSource = ordertable;
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        // ลบ Event TextChanged ที่ไม่จำเป็นแล้ว
        private void txtOrderFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กด Enter เพื่อค้นหา
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void txtmemIDFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void textTotalPricemin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กรอกเฉพาะตัวเลขและจุด
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // อนุญาตให้กด Enter เพื่อค้นหา
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            // เคลียร์ค่ากรองทั้งหมด
            txtOrderFind.Text = "";
            txtmemIDFind.Text = "";
            textTotalPricemin.Text = "";
            textTotalPricemac.Text = "";

            // โหลดข้อมูลทั้งหมดใหม่
            LoadDataGridview();
        }

        private void textTotalPricemac_KeyPress(object sender, KeyPressEventArgs e)
        {
            // อนุญาตให้กรอกเฉพาะตัวเลขและจุด
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // อนุญาตให้กด Enter เพื่อค้นหา
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyFilters();
                e.Handled = true;
            }
        }
    }
}