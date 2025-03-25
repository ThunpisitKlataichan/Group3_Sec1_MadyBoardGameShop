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
    public partial class formShippingOrder : Form
    {
        public formShippingOrder()
        {
            InitializeComponent();
        }

        SqlConnection shippingconection;
        SqlCommand shippingcommand;
        SqlDataAdapter shippingadapter;
        DataTable shippingtable;


        private void formShippingOrder_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            SqlConnection shippingconection = new SqlConnection(InitializeUser._key_con);
            shippingconection.Open();

            string sql = "SELECT SUBSTRING(memLocation, PATINDEX('%[0-9][0-9][0-9][0-9][0-9]%', memLocation), 5) as PostalCode , " +
                "\r\ns.ShipingID , s.ShipingStatus , s.ShipingDate , s.empID , o.OrderID FROM Member as m , Orders as o , ShippingOrder as s, Packing as p Where " +
                "\r\ns.PackID = p.PackID AND p.OrderID = o.OrderID AND \r\no.memID = m.memID  Order BY empID";
            SqlCommand shippingcommand = new SqlCommand(sql, shippingconection);
            SqlDataAdapter shippingadapter = new SqlDataAdapter(shippingcommand);
            DataTable shippingtable = new DataTable();
            shippingadapter.Fill(shippingtable);

            string PostalCode = "";
            string ShipingID = "";
            string ShipingStatus = "";
            string ShipingDate = "";
            string empID = "";
            string OrderID = "";

            for (int i = 0; i < shippingtable.Rows.Count; i++)
            {
                
                PostalCode = shippingtable.Rows[i]["PostalCode"].ToString();
                ShipingID = shippingtable.Rows[i]["ShipingID"].ToString();
                ShipingStatus = shippingtable.Rows[i]["ShipingStatus"].ToString();
                ShipingDate = shippingtable.Rows[i]["ShipingDate"].ToString();
                empID = shippingtable.Rows[i]["empID"].ToString();
                OrderID = shippingtable.Rows[i]["OrderID"].ToString();
                if (empID == "" || empID == null)
                {
                    empID = "-";
                }

                Panel panel = new Panel();
                panel.Size = new Size(530, 85);
                panel.BackColor = Color.AliceBlue;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Tag = OrderID;

                Label labelShippingIDtitle = new Label();
                labelShippingIDtitle.Text = "เลขการขนส่ง : ";
                labelShippingIDtitle.Location = new Point(3, 3);
                labelShippingIDtitle.AutoSize = true;
                labelShippingIDtitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelShippingID = new Label();
                labelShippingID.Text = ShipingID;
                labelShippingID.Location = new Point(120, 3);
                labelShippingID.AutoSize = true;

                Label labelPostalCodeTitle = new Label();
                labelPostalCodeTitle.Text = "รหัสไปรษณีย์ : ";
                labelPostalCodeTitle.Location = new Point(3, 30);
                labelPostalCodeTitle.AutoSize = true;
                labelPostalCodeTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelPostalCode = new Label();
                labelPostalCode.Text = PostalCode;
                labelPostalCode.Location = new Point(110, 30);
                labelPostalCode.AutoSize = true;

                Label labelDateTitle = new Label();
                labelDateTitle.Text = "วันที่อัพเดตล่าสุด : ";
                labelDateTitle.Location = new Point(3, 60);
                labelDateTitle.AutoSize = true;
                labelDateTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelDate = new Label();
                labelDate.Text = ShipingDate;
                labelDate.Location = new Point(150, 60);
                labelDate.AutoSize = true;

                Label labelStatusTitle = new Label();
                labelStatusTitle.Text = "สถานะ : ";
                labelStatusTitle.Location = new Point(300, 3);
                labelStatusTitle.AutoSize = true;
                labelStatusTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                ComboBox comboBoxStatus = new ComboBox();
                comboBoxStatus.Items.Add("เตรียมขนส่ง");
                comboBoxStatus.Items.Add("กำลังนำสินค้าไปส่ง");
                comboBoxStatus.Items.Add("จัดส่งสำเร็จ");
                comboBoxStatus.SelectedItem = ShipingStatus;
                comboBoxStatus.Location = new Point(370, 3);
                comboBoxStatus.Size = new Size(156, 32);

                if (ShipingStatus == "จัดส่งสำเร็จ")
                {
                    comboBoxStatus.Enabled = false;
                    panel.BackColor = Color.LightGreen;
                }
                if (ShipingStatus == "กำลังนำสินค้าไปส่ง")
                {
                    panel.BackColor = Color.LightYellow;
                }
                if (ShipingStatus == "เตรียมขนส่ง")
                {
                    panel.BackColor = Color.AliceBlue;
                }

                Label labelresponEMPTitle = new Label();
                labelresponEMPTitle.Text = "ผู้รับผิดชอบ : ";
                labelresponEMPTitle.Location = new Point(300, 30);
                labelresponEMPTitle.AutoSize = true;
                labelresponEMPTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelresponEMPID = new Label();
                labelresponEMPID.Text = empID;
                labelresponEMPID.Location = new Point(400, 30);
                labelresponEMPID.AutoSize = true;

                panel.Controls.Add(labelShippingIDtitle); //0
                panel.Controls.Add(labelShippingID); //1
                panel.Controls.Add(labelPostalCodeTitle);//2
                panel.Controls.Add(labelPostalCode);//3
                panel.Controls.Add(labelDateTitle);//4
                panel.Controls.Add(labelDate);//5
                panel.Controls.Add(labelStatusTitle);//6
                panel.Controls.Add(comboBoxStatus);//7
                panel.Controls.Add(labelresponEMPTitle);//8
                panel.Controls.Add(labelresponEMPID);//9

                panel.Click += Panal_Click;

                flowLayoutShipList.Controls.Add(panel);
            }
        }
        private void Panal_Click(object sender, EventArgs e)
        {
            FilldatatoDetail(sender);
        }
        private void FilldatatoDetail(object sender)
        {
            Panel panel = (Panel)sender;
            ComboBox comboBox = (ComboBox)panel.Controls[7];

            string ShipingID = panel.Controls[1].Text;
            string OrderID = panel.Tag.ToString();
            string ShipingStatus = comboBox.SelectedItem.ToString();
            string memName = "";
            string memLastName = "";
            string memLocation = "";
            string PostalCode = "";

            string sql = @"SELECT 
                p.ProductName, 
                od.Quantity, 
                m.memName, 
                m.memLName,
                m.memLocation,
                SUBSTRING(m.memLocation, PATINDEX('%[0-9][0-9][0-9][0-9][0-9]%', m.memLocation), 5) AS PostalCode
               FROM Orders o
               INNER JOIN Member m ON o.memID = m.memID
               INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
               INNER JOIN Products p ON od.ProductID = p.ProductID
               WHERE o.OrderID = @orderID";
            using (SqlConnection detailconnection = new SqlConnection(InitializeUser._key_con))
            {
                detailconnection.Open();
                SqlCommand command = new SqlCommand(sql, detailconnection);
                command.Parameters.AddWithValue("@orderID", OrderID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridDetail.DataSource = table;
                dataGridDetail.Columns[0].HeaderText = "ชื่อสินค้า";
                dataGridDetail.Columns[1].HeaderText = "จำนวน";
                dataGridDetail.Columns[2].Visible = false;
                dataGridDetail.Columns[3].Visible = false;
                dataGridDetail.Columns[4].Visible = false;
                dataGridDetail.Columns[5].Visible = false;

                memName = table.Rows[0]["memName"].ToString();
                memLastName = table.Rows[0]["memLName"].ToString();
                memLocation = table.Rows[0]["memLocation"].ToString();
                PostalCode = table.Rows[0]["PostalCode"].ToString();

                textBoxOrderID.Text = OrderID;
                textBoxShipID.Text = ShipingID;
                textBoxmemFullName.Text = memName + " " + memLastName;
                textBoxShipID.Text = ShipingID;
                textBoxPostCode.Text = PostalCode;
            }
                
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOIDSearch.Text == "")
            {
                foreach (Control control in flowLayoutShipList.Controls)
                {
                    control.Visible = true;
                    textBoxOIDSearch.Enabled = true;
                }
            }
            else
            {
                foreach (Control control in flowLayoutShipList.Controls)
                {
                    if (control.Tag.ToString().Contains(textBoxOIDSearch.Text))
                    {
                        
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                        textBoxOIDSearch.Enabled = false
                    }
                }
            }
        }

        private void textBoxSIDSearch_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSIDSearch.Text == "")
            {
                foreach (Control control in flowLayoutShipList.Controls)
                {
                    control.Visible = true;
                }
            }
            else
            {
                foreach (Control control in flowLayoutShipList.Controls)
                {
                    if (control.Controls[1].Text.Contains(textBoxSIDSearch.Text))
                    {
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }
    }
}
