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
    public partial class formOrder : Form
    {
        SqlConnection orderconnection;
        SqlCommand ordercommand;
        SqlDataAdapter orderadapter;
        DataTable ordertable;
        CurrencyManager ordermanager;

        List<Panel> panelProduct = new List<Panel>();
        List<Panel> panelscart = new List<Panel>();
        public formOrder()
        {
            InitializeComponent();
            InitializeUser.Confic();
        }

        private void formOrder_Load(object sender, EventArgs e)
        {
            try 
            {
                orderconnection = new SqlConnection(InitializeUser._key_con);
                orderconnection.Open();
                string command = "SELECT ProductID , ProductName , Price , ProductType , ProductImg , Productshelf FROM Products Where Productshelf = 1";
                ordercommand = new SqlCommand(command, orderconnection);
                orderadapter = new SqlDataAdapter(ordercommand);
                ordertable = new DataTable();
                orderadapter.Fill(ordertable);
                for (int i = 0; i< ordertable.Rows.Count; i++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(150, 220);
                    panel.BackColor = Color.Yellow;

                    PictureBox pic = new PictureBox();
                    pic.BackColor = Color.Red;
                    pic.Size = new Size(100, 100); // กำหนดขนาดก่อน
                    pic.Location = new Point((panel.Width - pic.Width) / 2, 10); // คำนวณตำแหน่งใหม่

                    Button btn = new Button();
                    btn.Text = "Add To Cart";
                    btn.Size = new Size(100, 25); // ปรับขนาดให้ดูดีขึ้น
                    btn.Location = new Point(panel.Width - btn.Width - 5, panel.Height - btn.Height - 5); // อยู่ขวาล่าง

                    Label lblprodName = new Label();
                    lblprodName.Text = ordertable.Rows[i]["ProductName"].ToString();
                    lblprodName.Tag = "ProductName";
                    lblprodName.BackColor = Color.White;
                    lblprodName.AutoSize = false;
                    lblprodName.Size = new Size(150, 70);
                    lblprodName.Location = new Point((panel.Width - lblprodName.Width) / 2, ((panel.Height - lblprodName.Height) / 2) + 37);

                    Label lblprodID = new Label();
                    lblprodID.Text = ordertable.Rows[i]["ProductID"].ToString();
                    lblprodID.Tag = ordertable.Rows[i]["ProductID"]?.ToString();
                    lblprodID.Visible = false;
                    lblprodID.Location = new Point(0, 0);

                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseLeave += Panel_Leave;
                    btn.Click += Addtocart_click;

                    panel.Controls.Add(lblprodID);
                    panel.Controls.Add(lblprodName);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(btn);

                    panelProduct.Add(panel);

                    flowLayoutProduct.Controls.Add(panel);
                }
            }
            catch (Exception ex)
                {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void formOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderconnection.Close();
            ordercommand.Dispose();
            orderconnection.Dispose();
        }

        private void Addtocart_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel originalPanel = (Panel)btn.Parent; // ดึง Panel ต้นฉบับ 

            Label lblProductID = originalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag != null);
            Label lblProductName = originalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "ProductName");

            originalPanel.Tag = lblProductID.Tag?.ToString();

            if (panelscart.Any(p => p.Tag == originalPanel.Tag))
            {
                MessageBox.Show("คุณเลือกสินค้านี้ไปเเล้ว");
                return;
            }
            else
            {
                panelscart.Add(originalPanel);
            }

            // สร้าง Panel ใหม่ ที่เป็นสำเนาของ originalPanel
            Panel cartPanel = new Panel();
            cartPanel.Size = originalPanel.Size;
            cartPanel.BackColor = originalPanel.BackColor;

            // คัดลอก PictureBox จาก Panel ต้นฉบับ
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.BackColor = Color.Red;
            pic.Location = new Point((cartPanel.Width - pic.Width) / 2, 10);
            cartPanel.Controls.Add(pic);

            // เพิ่มปุ่มควบคุมใน Panel (เฉพาะใน Cart)
            //Button plus = new Button();
            //plus.Text = "+";
            //plus.Size = new Size(25, 25);
            //plus.Location = new Point(cartPanel.Width - plus.Width - 5, cartPanel.Height - 30);

            //Button minus = new Button();
            //minus.Text = "-";
            //minus.Size = new Size(25, 25);
            //minus.Location = new Point(cartPanel.Width - minus.Width - 50, cartPanel.Height - 30);

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 1;
            numericUpDown.Size = new Size(50, 25);
            numericUpDown.Location = new Point((cartPanel.Width - numericUpDown.Width) - 50, cartPanel.Height - 30);

            Button removebtn = new Button();
            removebtn.Text = "X";
            removebtn.Size = new Size(25, 25);
            removebtn.Location = new Point(cartPanel.Width - removebtn.Width, 0);
            removebtn.BackColor = Color.Red;
            removebtn.Font = new Font("Arial", 10, FontStyle.Bold);
            removebtn.ForeColor = Color.White;
            removebtn.Click += RemoveformCart_click;// กำหนด Event ให้ปุ่มลบ

            Label lbl = new Label();
            lbl.Text = lblProductName.Text;
            lbl.BackColor = Color.White;
            lbl.AutoSize = false;
            lbl.Size = new Size(150, 70);
            lbl.Location = new Point((cartPanel.Width - lbl.Width) / 2, ((cartPanel.Height - lbl.Height) / 2) + 37);


            cartPanel.Tag = originalPanel.Tag; // เชื่อมโยงกับ Panel ต้นฉบับ
            cartPanel.Controls.Add(numericUpDown);
            cartPanel.Controls.Add(lbl);
            cartPanel.Controls.Add(removebtn);

            // เพิ่ม Panel ที่สร้างใหม่เข้าไปใน flowLayoutCart
            flowLayoutCart.Controls.Add(cartPanel);
        }
        private void RemoveformCart_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel cartPanel = (Panel)btn.Parent; // Panel ที่ถูกลบออกจากตะกร้า

            // หา Panel ต้นฉบับจาก panelscart
            Panel originalPanel = panelscart.FirstOrDefault(p => p.Tag == cartPanel.Tag);

            if (originalPanel != null)
            {
                panelscart.Remove(originalPanel); // ลบ Panel ต้นฉบับออกจาก panelscart
            }

            flowLayoutCart.Controls.Remove(cartPanel); // ลบ Panel ออกจากตะกร้า
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pn = (Panel)sender;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void Panel_Leave(object sender, EventArgs e)
        {
            ((Panel)sender).BackColor = Color.Yellow;
        }
        
        private void btnpayment_Click(object sender, EventArgs e)
        {
           // string command = "SELECT ProductName , Price , "
        }
    }
}
