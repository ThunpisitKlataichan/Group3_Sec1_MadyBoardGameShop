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
    public partial class formShippingPur : Form
    {
        public formShippingPur()
        {
            InitializeComponent();
        }
        SqlConnection shippurconnection;
        SqlCommand shippurcommand;
        SqlDataAdapter shippuradapter;
        DataTable shippurtable;
        private void formShippingPur_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            shippurconnection = new SqlConnection(InitializeUser._key_con);
            shippurconnection.Open();
            LoadData();
        }
        private void LoadData()
        {
            string command = @"
                SELECT ShippingPurID , ShippingStatus , ShippingDate  , empID , PurID
                FROM ShippingPur 
                ORDER BY CASE ShippingStatus
                            WHEN 'เตรียมการไปรับสินค้า' THEN 1
                            WHEN 'เดินทางไปรับสินค้า' THEN 2
                            WHEN 'เติมสินค้าสำเร็จ' THEN 3 
                         ELSE 5
                        END ASC ,
                        empID;";
            shippurcommand = new SqlCommand(command, shippurconnection);
            shippuradapter = new SqlDataAdapter(shippurcommand);
            shippurtable = new DataTable();
            shippuradapter.Fill(shippurtable);

            for (int i = 0; i < shippurtable.Rows.Count; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(540, 85);
                panel.Tag = shippurtable.Rows[i]["PurID"];
                panel.BackColor = Color.White;

                Label labelshippingIDTitle = new Label();
                labelshippingIDTitle.Text = "รหัสขนส่งที่ : ";
                labelshippingIDTitle.Location = new Point(3, 3);
                labelshippingIDTitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelshippingIDTitle.AutoSize = true;

                Label labelshippingID = new Label();
                labelshippingID.Text = shippurtable.Rows[i]["ShippingPurID"].ToString();
                labelshippingID.Location = new Point(150, 3);
                labelshippingID.AutoSize = true;

                Label labelrespontitle = new Label();
                labelrespontitle.Text = "รหัสผู้ขนส่ง : ";
                labelrespontitle.Location = new Point(3, 30);
                labelrespontitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelrespontitle.AutoSize = true;

                Label labelrespon = new Label();
                labelrespon.Text = shippurtable.Rows[i]["empID"].ToString();
                labelrespon.Location = new Point(120, 30);
                labelrespon.AutoSize = true;
                if (labelrespon.Text == "" || labelrespon.Text == null)
                {
                    labelrespon.Text = "-";
                }

                Label labelDateTitle = new Label();
                labelDateTitle.Text = "สถานะอัพเดตล่าสุด : ";
                labelDateTitle.Location = new Point(3, 55);
                labelDateTitle.AutoSize = true;
                labelDateTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelDate = new Label();
                labelDate.Text = shippurtable.Rows[i]["ShippingDate"].ToString();
                labelDate.Location = new Point(170, 55);
                labelDate.AutoSize = true;

                Label labelStatusTitle = new Label();
                labelStatusTitle.Text = "สถานะขนส่ง : ";
                labelStatusTitle.Location = new Point(200, 3);
                labelStatusTitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelStatusTitle.AutoSize = true;

                ComboBox comboboxStasus = new ComboBox();
                comboboxStasus.Items.Add("เตรียมการไปรับสินค้า");
                comboboxStasus.Items.Add("เดินทางไปรับสินค้า");
                comboboxStasus.Items.Add("เติมสินค้าสำเร็จ");
                comboboxStasus.Location = new Point(310, 3);
                comboboxStasus.Size = new Size(200, 32);
                comboboxStasus.SelectedItem = shippurtable.Rows[i]["ShippingStatus"].ToString();

                panel.Controls.Add(labelshippingIDTitle);
                panel.Controls.Add(labelshippingID);
                panel.Controls.Add(labelDateTitle);
                panel.Controls.Add(labelDate);
                panel.Controls.Add(labelStatusTitle);
                panel.Controls.Add(comboboxStasus);
                panel.Controls.Add(labelrespontitle);
                panel.Controls.Add(labelrespon);
                panel.Click += Panal_click;

                flowLayoutShippur.Controls.Add(panel);
            }
        }
        private void LoadDetail()
        {
            
        }
        private void Panal_click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            string purID = panel.Tag.ToString();
            string shipID = panel.Controls[1].Text;
            string command = @"
                                	SELECT 
                                        sp.ShippingPurID, 
                                        p.ProductID, 
                                        p.ProductName, 
                                        pd.Quality, 
                                        s.SuppilerID, 
                                        s.SuppilerName, 
                                        s.SuppilerCoutry
                                    FROM 
                                        ShippingPur sp
                                        JOIN Purchasing pu ON sp.PurID = pu.PurID
                                        JOIN PurchaseDetail pd ON pu.PurID = pd.PurID
                                        JOIN Products p ON pd.ProductID = p.ProductID
                                        JOIN Suppilers s ON p.SuppilersID = s.SuppilerID
                                    WHERE sp.ShippingPurID = @shipID";
            using (SqlConnection detailconnection = new SqlConnection(InitializeUser._key_con))
            {
                detailconnection.Open();
                SqlCommand detailcommand = new SqlCommand(command, detailconnection);
                detailcommand.Parameters.AddWithValue("@shipID", shipID);
                SqlDataAdapter detailadapter = new SqlDataAdapter(detailcommand);
                DataTable detailtable = new DataTable();
                detailadapter.Fill(detailtable);

                dataGridDetails.DataSource = detailtable;
                dataGridDetails.Columns["ShippingPurID"].Visible = false;
                dataGridDetails.Columns["SuppilerID"].Visible = false;
                dataGridDetails.Columns["SuppilerName"].Visible = false;
                dataGridDetails.Columns["SuppilerCoutry"].Visible = false;

                dataGridDetails.Columns["ProductID"].HeaderText = "รหัสสินค้า";
                dataGridDetails.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                dataGridDetails.Columns["Quality"].HeaderText = "จำนวนสินค้า";

                dataGridDetails.Columns["ProductID"].Width = 100;
                dataGridDetails.Columns["ProductName"].Width = 280;
                dataGridDetails.Columns["Quality"].Width = 100;
            }
        }
    }
}
