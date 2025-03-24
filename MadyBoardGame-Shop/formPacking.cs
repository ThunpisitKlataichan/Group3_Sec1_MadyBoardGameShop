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
    public partial class formPacking : Form
    {
        public formPacking()
        {
            InitializeComponent();
        }
        SqlConnection packingconnection;
        SqlCommand packingcommand;
        SqlDataAdapter packingadapter;
        DataTable packingTable;
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formPacking_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            packingconnection = new SqlConnection(InitializeUser._key_con);
            packingconnection.Open();
            string query = "SELECT * FROM Packing WHERE PackStatus = @packStatus ORDER BY PackDate";
            packingcommand = new SqlCommand(query, packingconnection);
            packingadapter = new SqlDataAdapter(packingcommand);
            packingcommand.Parameters.AddWithValue("@packStatus", "รอจัดส่ง");
            packingTable = new DataTable();
            packingadapter.Fill(packingTable);

            for (int i = 0; i < packingTable.Rows.Count; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(400, 80);
                panel.BackColor = Color.AliceBlue;
                panel.Click += Panel_Click;

                Label labelordertitle = new Label();
                labelordertitle.Text = "ออเดอร์ที่ : ";
                labelordertitle.Location = new Point(3, 15);
                labelordertitle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                labelordertitle.AutoSize = true;

                Label labelorder = new Label();
                labelorder.Text = packingTable.Rows[i]["OrderID"].ToString();
                labelorder.Location = new Point(90, 12);
                labelorder.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
                labelordertitle.AutoSize = true;

                Label labelDatetitle = new Label();
                labelDatetitle.Text = "วันที่ : ";
                labelDatetitle.Location = new Point(3, 50);
                labelDatetitle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                labelDatetitle.AutoSize = true; 

                Label labelDate = new Label();
                labelDate.Text = packingTable.Rows[i]["PackDate"].ToString();
                labelDate.Location = new Point(52, 47);
                labelDate.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
                labelDate.AutoSize = true;

                Label labelstatusTitle = new Label();
                labelstatusTitle.Text = "สถานะ : ";
                labelstatusTitle.Location = new Point(230, 50);
                labelstatusTitle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                labelstatusTitle.AutoSize = true;

                Label labelstatus = new Label();
                labelstatus.Text = packingTable.Rows[i]["PackStatus"].ToString();
                labelstatus.Location = new Point(290, 50);
                labelstatus.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                labelstatus.AutoSize = true;

                Button btnconfirm = new Button();
                btnconfirm.Text = "ยืนยันจัดส่ง";
                btnconfirm.Location = new Point(300, 12);
                btnconfirm.Size = new Size(100, 34);

                panel.Controls.Add(labelordertitle);
                panel.Controls.Add(labelorder);
                panel.Controls.Add(labelDatetitle);
                panel.Controls.Add(labelDate);
                panel.Controls.Add(labelDate);
                panel.Controls.Add(labelstatusTitle);
                panel.Controls.Add(labelstatus);
                panel.Controls.Add(btnconfirm);
                flowLayoutPackOrder.Controls.Add(panel);
            }

        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            string orderID = panel.Controls[1].Text;
            MessageBox.Show(orderID);
            using (SqlConnection orderdetailsConnection = new SqlConnection(InitializeUser._key_con))
            {
                orderdetailsConnection.Open();
                string query = @"
                SELECT 
                    OrderDetails.ProductID, 
                    Products.ProductName, 
                    OrderDetails.Quantity 
                FROM 
                    OrderDetails 
                INNER JOIN 
                    Products ON OrderDetails.ProductID = Products.ProductID 
                INNER JOIN 
                    Orders ON OrderDetails.OrderID = Orders.OrderID 
                WHERE 
                    OrderDetails.OrderID = @orderID;";
                using (SqlCommand orderdetailsCommand = new SqlCommand(query, orderdetailsConnection))
                {
                    orderdetailsCommand.Parameters.AddWithValue("@orderID", orderID);
                    SqlDataAdapter orderdetailsAdapter = new SqlDataAdapter(orderdetailsCommand);
                    DataTable orderdetailsTable = new DataTable();
                    orderdetailsAdapter.Fill(orderdetailsTable);
                    dataGridOrderDetails.DataSource = orderdetailsTable;
                    dataGridOrderDetails.Columns[0].HeaderText = "รหัสสินค้า";
                    dataGridOrderDetails.Columns[1].HeaderText = "ชื่อสินค้า";
                    dataGridOrderDetails.Columns[2].HeaderText = "จำนวน";
                    dataGridOrderDetails.Columns[0].Width = 100;
                    dataGridOrderDetails.Columns[1].Width = 390;
                    dataGridOrderDetails.Columns[2].Width = 100;
                }
            }
        }
    }
}
