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

namespace TestFlowlayoutpanal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        List<Panel> panelProduct = new List<Panel>();
        List<Panel> panelscart = new List<Panel>();
        List<Panel> panelsearch = new List<Panel>();

        string[] arrstring = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(150, 220);
                panel.BackColor = Color.Yellow;

                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Red;
                pic.Size = new Size(100, 100); // กำหนดขนาดก่อน
                pic.Location = new Point((panel.Width - pic.Width) / 2, 10); // คำนวณตำแหน่งใหม่

                Button btn = new Button();
                btn.Text = arrstring[i];
                btn.Size = new Size(50, 25); // ปรับขนาดให้ดูดีขึ้น
                btn.Location = new Point(panel.Width - btn.Width - 5, panel.Height - btn.Height - 5); // อยู่ขวาล่าง

                panel.MouseMove += b_holder_Move;
                panel.MouseLeave += b_leave;
                btn.Click += Addtocart_click;

                panel.Controls.Add(pic);
                panel.Controls.Add(btn);

                panelProduct.Add(panel);

                flowLayoutProduct.Controls.Add(panel);
            }
        }
        private void Addtocart_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel originalPanel = (Panel)btn.Parent; // Panel ต้นฉบับ
            originalPanel.Tag = btn.Text;

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
            numericUpDown.Location = new Point((cartPanel.Width - numericUpDown.Width) -50, cartPanel.Height - 30);

            Button removebtn = new Button();
            removebtn.Text = "X";
            removebtn.Size = new Size(25, 25);
            removebtn.Location = new Point(cartPanel.Width - removebtn.Width, 0);
            removebtn.BackColor = Color.Red;
            removebtn.Font = new Font("Arial", 10, FontStyle.Bold);
            removebtn.ForeColor = Color.White;
            removebtn.Click += RemoveformCart_click;// กำหนด Event ให้ปุ่มลบ

            Label lbl = new Label();
            lbl.Text = btn.Text;
            lbl.BackColor = Color.White;
            lbl.AutoSize = false;
            lbl.Size = new Size(150, 70);
            lbl.Location = new Point((cartPanel.Width-lbl.Width)/2, ((cartPanel.Height - lbl.Height) / 2 )+37);


            cartPanel.Tag = originalPanel.Tag; // เชื่อมโยงกับ Panel ต้นฉบับ
            cartPanel.Controls.Add(numericUpDown);
            cartPanel.Controls.Add(lbl);
            cartPanel.Controls.Add(removebtn);

            // เพิ่ม Panel ที่สร้างใหม่เข้าไปใน flowLayoutCart
            flowLayoutCart.Controls.Add(cartPanel);
        }

        private void b_holder_Move(object sender, MouseEventArgs e)
        {
            Panel pn = (Panel)sender;
            if (pn.BackColor != Color.Blue) // เช็คก่อนเปลี่ยน ลดการเรียกซ้ำ
            {
                pn.BackColor = Color.Blue;
            }
        }
        private void b_leave(object sender, EventArgs e)
        {
            ((Panel)sender).BackColor = Color.Yellow;
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FindPanelByButtonText(flowLayoutProduct , textBox1.Text);
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                foreach (Panel panel in panelProduct)
                {
                    flowLayoutProduct.Controls.Add(panel);
                }
            }
            else 
            {
                flowLayoutProduct.Controls.Clear();
                foreach (Panel panel in panelsearch)
                {
                    flowLayoutProduct.Controls.Add(panel);
                }
                panelsearch.Clear();
            }
        }
        private Panel FindPanelByButtonText(FlowLayoutPanel flowLayout, string buttonText)
        {
            foreach (Control control in flowLayout.Controls)
            {
                if (control is Panel panel) // ตรวจสอบว่าเป็น Panel หรือไม่
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is Button btn && btn.Text == buttonText) // เช็คปุ่มใน Panel
                        {
                            panelsearch.Add((Panel)control);
                        }
                    }
                }
            }
            return null; // ถ้าไม่เจอจะคืนค่าเป็น null
        }
    }
}
