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
        List<Panel> panelsearch = new List<Panel>();
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
                    panel.Tag = ordertable.Rows[i]["ProductName"].ToString();

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
                    lblprodID.Tag = "ProductID";
                    lblprodID.Visible = true;
                    lblprodID.Location = new Point(0, 0);

                    Label lblPrice = new Label();
                    lblPrice.Text = Convert.ToDecimal(ordertable.Rows[i]["Price"]).ToString("N2") + "฿";
                    lblPrice.Tag = "Price";
                    lblPrice.Visible = true;
                    lblPrice.Size = new Size(100, 25);
                    lblPrice.AutoSize = false;
                    lblPrice.Location = new Point(0, panel.Height - lblPrice.Height);
                    

                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseLeave += Panel_Leave;
                    panel.Click += Panel_Click;
                    btn.Click += Addtocart_click;

                    panel.Controls.Add(lblPrice);
                    panel.Controls.Add(lblprodID);
                    panel.Controls.Add(lblprodName);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(btn);
                    foreach(Control control in panel.Controls)
                    {
                        lblprodName.MouseMove += lbl_MouseMove;
                        lblprodName.MouseLeave += lbl_Leave;
                        lblprodID.MouseMove += lbl_MouseMove;
                        lblprodID.MouseLeave += lbl_Leave;
                        pic.MouseMove += PictureBox_MouseMove;
                        pic.MouseLeave += PictureBox_Leave;
                        btn.MouseMove += btn_MouseMove;
                        btn.MouseLeave += btn_Leave;
                        lblprodID.Click += lbl_Click;
                        lblprodName.Click += lbl_Click;
                        pic.Click += PictureBox_Click;

                    }

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

            originalPanel.Tag = originalPanel.Tag?.ToString(); // กำหนด Tag ให้กับ Panel ต้นฉบับ

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
            cartPanel.BackColor = Color.Yellow;

            // คัดลอก PictureBox จาก Panel ต้นฉบับ
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.BackColor = Color.Red;
            pic.Location = new Point((cartPanel.Width - pic.Width) / 2, 10);
            cartPanel.Controls.Add(pic);

            NumericUpDown numericUpDown = new NumericUpDown(); // ปุ่มเพิ่มลดจำนวนสินค้า
            numericUpDown.Minimum = 1;
            numericUpDown.Size = new Size(50, 25);
            numericUpDown.Location = new Point((cartPanel.Width - numericUpDown.Width) - 50, cartPanel.Height - 30);

            Button removebtn = new Button();// ปุ่มลบสินค้า
            removebtn.Text = "X";
            removebtn.Size = new Size(25, 25);
            removebtn.Location = new Point(cartPanel.Width - removebtn.Width, 0);
            removebtn.BackColor = Color.Red;
            removebtn.Font = new Font("Arial", 10, FontStyle.Bold);
            removebtn.ForeColor = Color.White;
            removebtn.Click += RemoveformCart_click;// กำหนด Event ให้ปุ่มลบ

            Label lblName = new Label();
            lblName.Text = originalPanel.Tag?.ToString();
            lblName.BackColor = Color.White;
            lblName.AutoSize = false;
            lblName.Size = new Size(150, 70);
            lblName.Location = new Point((cartPanel.Width - lblName.Width) / 2, ((cartPanel.Height - lblName.Height) / 2) + 37);

            cartPanel.Tag = originalPanel.Tag; // เชื่อมโยงกับ Panel ต้นฉบับ
            cartPanel.Controls.Add(numericUpDown);
            cartPanel.Controls.Add(lblName);
            cartPanel.Controls.Add(removebtn);
            cartPanel.MouseMove += Panel_MouseMove;
            cartPanel.MouseLeave += Panel_Leave;
            foreach (Control control in cartPanel.Controls)
            {
                lblName.MouseMove += lbl_MouseMove;
                lblName.MouseLeave += lbl_Leave;
                pic.MouseMove += PictureBox_MouseMove;
                pic.MouseLeave += PictureBox_Leave;
                removebtn.MouseMove += btn_MouseMove;
                removebtn.MouseLeave += btn_Leave;
                numericUpDown.MouseMove += Numuric_MouseMove;
                numericUpDown.MouseLeave += Numuric_Leave;
            }
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
        }// ลบสินค้าออกจากตะกร้า



        // ส่วนของการเปลี่ยนสีเมื่อเมาส์เข้าไป
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
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Panel pn = (Panel)btn.Parent;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void btn_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel pn = (Panel)btn.Parent;
            pn.BackColor = Color.Yellow;
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            Panel pn = (Panel)pic.Parent;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void PictureBox_Leave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            Panel pn = (Panel)pic.Parent;
            pn.BackColor = Color.Yellow;
        }
        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            Panel pn = (Panel)lbl.Parent;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void lbl_Leave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            Panel pn = (Panel)lbl.Parent;
            pn.BackColor = Color.Yellow;
        }
        private void Numuric_MouseMove(object sender, MouseEventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            Panel pn = (Panel)num.Parent;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void Numuric_Leave(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            Panel pn = (Panel)num.Parent;
            pn.BackColor = Color.Yellow;
        }
        //-------------------------------------------------------------------------------------

        private void Panel_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }

        private void CallDetailData(object sender)
        {
            try
            {
                string key_ProductID = "";
                Panel panel = null;
                if(sender is Panel)
                {
                    panel = (Panel)sender;
                }
                else if (sender is PictureBox)
                {
                    panel = (Panel)((PictureBox)sender).Parent;
                }
                else if (sender is Label)
                {
                    panel = (Panel)((Label)sender).Parent;
                }
                foreach (Control control in panel.Controls)
                {
                    if (control is Label label)
                    {
                        if (label.Tag?.ToString() == "ProductID")
                        {
                            key_ProductID = label.Text;
                        }
                    }
                }
                orderconnection = new SqlConnection(InitializeUser._key_con);
                orderconnection.Open();
                string command = "SELECT ProductID , ProductName , Price , ProductType , ProductImg , Productshelf FROM Products Where Productshelf = 1 And ProductID = @key_ProductID";
                ordercommand = new SqlCommand(command, orderconnection);
                ordercommand.Parameters.AddWithValue("@key_ProductID", key_ProductID);
                orderadapter = new SqlDataAdapter(ordercommand);
                ordertable = new DataTable();
                orderadapter.Fill(ordertable);
                txtProductname.Text = ordertable.Rows[0]["ProductName"].ToString();
                txtPrice.Text = ordertable.Rows[0]["Price"].ToString();
                txtProductType.Text = ordertable.Rows[0]["ProductType"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnpayment_Click(object sender, EventArgs e)
        {
            // string command = "SELECT ProductName , Price , "
        }// ส่งข้อมูลไปยังฐานข้อมูล

        private void txtFindProduct_TextChanged(object sender, EventArgs e)
        {
            panelsearch.Clear();
            FindPanelByButtonText(flowLayoutProduct, txtFindProduct.Text.Trim());
            if (string.IsNullOrEmpty(txtFindProduct.Text.Trim()))// ถ้าไม่มีข้อความให้โชว์สินค้าทั้งหมด
            {
                foreach (Panel panel in panelProduct)
                {
                    flowLayoutProduct.Controls.Add(panel);
                }
            }
            else // ถ้ามีข้อความให้ค้นหา
            {
                flowLayoutProduct.Controls.Clear();
                foreach (Panel panel in panelsearch)
                {
                    flowLayoutProduct.Controls.Add(panel);
                }
                panelsearch.Clear();
            }
        } // ค้นหาสินค้า
        private void FindPanelByButtonText(FlowLayoutPanel flowLayout, string Productname)
        {
            foreach (Control control in panelProduct)
            {
                if (control is Panel panel) // ตรวจสอบว่าเป็น Panel หรือไม่
                {
                    foreach (Control control1 in panel.Controls)
                    {
                        if (control1 is Label label && label.Tag?.ToString()== "ProductName")
                        {
                            if (label.Text.Contains(Productname))
                            {
                                panelsearch.Add(panel);
                            }
                        }
                    }
                }
            }
        } // ค้นหา Panel จากชื่อสินค้า
    }
}
