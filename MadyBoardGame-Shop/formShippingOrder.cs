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
                "\r\ns.ShipingID , s.ShipingStatus , s.ShipingDate FROM Member as m , Orders as o , ShippingOrder as s, Packing as p Where " +
                "\r\ns.PackID = p.PackID AND p.OrderID = o.OrderID AND \r\no.mem_ID = m.memID Order BY PostalCode";
            SqlCommand shippingcommand = new SqlCommand(sql, shippingconection);
            SqlDataAdapter shippingadapter = new SqlDataAdapter(shippingcommand);
            DataTable shippingtable = new DataTable();
            shippingadapter.Fill(shippingtable);

            string PostalCode = "";
            string ShipingID = "";
            string ShipingStatus = "";
            string ShipingDate = "";

            for (int i = 0; i < shippingtable.Rows.Count; i++)
            {
                PostalCode = shippingtable.Rows[i]["PostalCode"].ToString();
                ShipingID = shippingtable.Rows[i]["ShipingID"].ToString();
                ShipingStatus = shippingtable.Rows[i]["ShipingStatus"].ToString();
                ShipingDate = shippingtable.Rows[i]["ShipingDate"].ToString();

                Panel panel = new Panel();
                panel.Size = new Size(530, 85);
                panel.BackColor = Color.AliceBlue;
                panel.BorderStyle = BorderStyle.FixedSingle;

                Label labelOrderIDtitle = new Label();
                labelOrderIDtitle.Text = "เลขการขนส่ง : ";
                labelOrderIDtitle.Location = new Point(3, 3);
                labelOrderIDtitle.AutoSize = true;
                labelOrderIDtitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelOrderID = new Label();
                labelOrderID.Text = ShipingID;
                labelOrderID.Location = new Point(120, 3);
                labelOrderID.AutoSize = true;

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

                panel.Controls.Add(labelOrderIDtitle);
                panel.Controls.Add(labelOrderID);
                panel.Controls.Add(labelPostalCodeTitle);
                panel.Controls.Add(labelPostalCode);
                panel.Controls.Add(labelDateTitle);
                panel.Controls.Add(labelDate);
                panel.Controls.Add(labelStatusTitle);
                panel.Controls.Add(comboBoxStatus);

                flowLayoutShipList.Controls.Add(panel);
            }

        }
    }
}
