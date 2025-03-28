using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formOrder : Form
    {
        SqlConnection productconnection;
        SqlCommand productcommand;
        SqlDataAdapter productdataadapter;
        DataTable producttable;

        SqlConnection paymentconnection;
        SqlCommand paymentcommand;

        SqlConnection orderconnection;
        SqlCommand ordercommand;

        SqlConnection orderdetailconnection;
        SqlCommand orderdetailcommand;

        List<Panel> panelProduct = new List<Panel>();
        List<Panel> panelscart = new List<Panel>();
        List<Panel> panelsearch = new List<Panel>();

        string empIDmanager = "3";

        private decimal totalPrice = 0;
        public formOrder()
        {
            InitializeComponent();
            InitializeUser.Confic();
        }

        private void formOrder_Load(object sender, EventArgs e)
        {
            try 
            {
                InitializeUser.Confic();
                productconnection = new SqlConnection(InitializeUser._key_con);
                productconnection.Open();
                productcommand = new SqlCommand();

                paymentconnection = new SqlConnection(InitializeUser._key_con);
                paymentconnection.Open();
                paymentcommand = new SqlCommand();

                orderconnection = new SqlConnection(InitializeUser._key_con);
                orderconnection.Open();
                ordercommand = new SqlCommand();

                orderdetailconnection = new SqlConnection(InitializeUser._key_con);
                orderdetailconnection.Open();
                orderdetailcommand = new SqlCommand();


                string command = "SELECT ProductID , ProductName , Price , ProductType , ProductImg , ProductsShelf , ProductImg , Quality FROM Products Where ProductsShelf = 1";
                productcommand = new SqlCommand(command, productconnection);
                productdataadapter = new SqlDataAdapter(productcommand);
                producttable = new DataTable();
                productdataadapter.Fill(producttable);
                for (int i = 0; i< producttable.Rows.Count; i++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(150, 220);
                    panel.BackColor = Color.Yellow;
                    panel.Tag = producttable.Rows[i]["ProductID"].ToString();

                    PictureBox pic = new PictureBox();
                    pic.BackColor = Color.Red;
                    pic.Size = new Size(100, 100); // กำหนดขนาดก่อน
                    pic.Location = new Point((panel.Width - pic.Width) / 2, 10); // คำนวณตำแหน่งใหม่
                    pic.Tag = "ProductImg";
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    byte[] imageBytes = (byte[])producttable.Rows[i]["ProductImg"]; //ใน database จะเก็บรูปภาพเป็น byte จึงต้องแปลงกลับเป็นรูปภาพ
                    MemoryStream ms = new MemoryStream(imageBytes);
                    pic.Image = Image.FromStream(ms);

                    Button btn = new Button();
                    btn.Text = "Add";
                    btn.Size = new Size(70, 30); // ปรับขนาดให้ดูดีขึ้น
                    btn.Location = new Point(panel.Width - btn.Width - 2, panel.Height - btn.Height - 2); // อยู่ขวาล่าง

                    Label lblprodName = new Label();
                    lblprodName.Text = producttable.Rows[i]["ProductName"].ToString();
                    lblprodName.Tag = "ProductName";
                    lblprodName.BackColor = Color.White;
                    lblprodName.AutoSize = false;
                    lblprodName.Size = new Size(150, 70);
                    lblprodName.Location = new Point((panel.Width - lblprodName.Width) / 2, ((panel.Height - lblprodName.Height) / 2) + 37);

                    Label lblprodID = new Label();
                    lblprodID.Text = producttable.Rows[i]["ProductID"].ToString();
                    lblprodID.Tag = "ProductID";
                    lblprodID.Visible = false;
                    lblprodID.Location = new Point(0, 0);

                    Label lblPrice = new Label();
                    lblPrice.Text = Convert.ToDecimal(producttable.Rows[i]["Price"]).ToString("N2") + "฿";
                    lblPrice.Tag = "Price";
                    lblPrice.Visible = true;
                    lblPrice.BackColor = Color.Transparent;
                    lblPrice.Size = new Size(70, 25);
                    lblPrice.AutoSize = false;
                    lblPrice.Location = new Point(0, panel.Height - lblPrice.Height);
                    

                    panel.MouseMove += Panel_MouseMove;
                    panel.MouseLeave += Panel_Leave;
                    panel.Click += Panel_Click;
                    btn.Click += Addtocart_click;

                    panel.Controls.Add(lblPrice); // เพิ่ม Control ลงใน Panel
                    panel.Controls.Add(lblprodID);
                    panel.Controls.Add(lblprodName);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(btn);

                    lblprodName.MouseMove += lbl_MouseMove; // เกี่ยวกับการเปลี่ยนสีเมื่อเมาส์เข้าไป
                    lblprodName.MouseLeave += lbl_Leave;
                    lblprodID.MouseMove += lbl_MouseMove;
                    lblprodID.MouseLeave += lbl_Leave;
                    lblPrice.MouseMove += lbl_MouseMove;
                    lblPrice.MouseLeave += lbl_Leave;
                    pic.MouseMove += PictureBox_MouseMove;
                    pic.MouseLeave += PictureBox_Leave;
                    btn.MouseMove += btn_MouseMove;
                    btn.MouseLeave += btn_Leave;
                    lblprodID.Click += lbl_Click;
                    lblprodName.Click += lbl_Click;
                    pic.Click += PictureBox_Click;

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
            productconnection.Close();

            productcommand.Dispose();
            productconnection.Dispose();
            productdataadapter.Dispose();
            producttable.Dispose();

            paymentcommand.Dispose();
            paymentconnection.Dispose();
        }

        private void Addtocart_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel originalPanel = (Panel)btn.Parent; // ดึง Panel ต้นฉบับ 
            Panel cartPanel = new Panel();
            if (panelscart.Any(p => p.Tag == originalPanel.Tag))
            {
                MessageBox.Show("คุณเลือกสินค้านี้ไปเเล้ว");
                return;
            }
            else
            {
                panelscart.Add(cartPanel);
            }

            // สร้าง Panel ใหม่ ที่เป็นสำเนาของ originalPanel 
            cartPanel.Size = originalPanel.Size;
            cartPanel.BackColor = Color.Yellow;
            cartPanel.Tag = originalPanel.Tag; // กำหนด Tag ให้กับ Panel ใหม่

            // คัดลอก PictureBox จาก Panel ต้นฉบับ
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.BackColor = Color.Red;
            pic.Location = new Point((cartPanel.Width - pic.Width) / 2, 10);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Tag = "ProductImg";
            pic.Image = originalPanel.Controls.OfType<PictureBox>().FirstOrDefault().Image;


            // สร้าง NumericUpDown ใหม่
            NumericUpDown numericUpDown = new NumericUpDown(); // ปุ่มเพิ่มลดจำนวนสินค้า
            numericUpDown.Minimum = 1;
            numericUpDown.Size = new Size(50, 25);
            numericUpDown.Location = new Point((cartPanel.Width - numericUpDown.Width) - 50, cartPanel.Height - 30);
            numericUpDown.Tag = "NumericUpDown";

            // สร้างปุ่มลบสินค้า
            Button removebtn = new Button();// ปุ่มลบสินค้า
            removebtn.Text = "X";
            removebtn.Size = new Size(25, 25);
            removebtn.Location = new Point(cartPanel.Width - removebtn.Width, 0);
            removebtn.BackColor = Color.Red;
            removebtn.Font = new Font("Arial", 10, FontStyle.Bold);
            removebtn.ForeColor = Color.White;
            removebtn.Click += RemoveformCart_click;// กำหนด Event ให้ปุ่มลบ

            // คัดลอก Label จาก Panel ต้นฉบับ
            Label lblName = new Label();
            lblName.Text = originalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "ProductName").Text;
            lblName.BackColor = Color.White;
            lblName.AutoSize = false;
            lblName.Size = new Size(150, 70);
            lblName.Location = new Point((cartPanel.Width - lblName.Width) / 2, ((cartPanel.Height - lblName.Height) / 2) + 37);
            lblName.Tag = "ProductName";

            // คัดลอก Label จาก Panel ต้นฉบับ
            Label lblproductID = new Label();
            lblproductID.Text = originalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "ProductID").Text;
            lblproductID.Tag = "ProductID";
            lblproductID.Visible = false;
            lblproductID.Location = new Point(0, 0);

            // คัดลอก Label จาก Panel ต้นฉบับ
            Label lblPrice = new Label();
            lblPrice.Text = originalPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "Price").Text;
            lblPrice.Tag = "Price";
            lblPrice.Visible = true;
            lblPrice.AutoSize = false;
            lblPrice.Size = new Size(100, 25);
            lblPrice.Location = new Point(0, cartPanel.Height - lblPrice.Height);

            cartPanel.Tag = originalPanel.Tag; // กำหนด Tag ให้กับ Panel ใหม่

            // เพิ่ม Control ลงใน Panel ใหม่
            cartPanel.Controls.Add(numericUpDown);
            cartPanel.Controls.Add(lblName);
            cartPanel.Controls.Add(removebtn);
            cartPanel.Controls.Add(lblproductID);
            cartPanel.Controls.Add(lblPrice);
            cartPanel.Controls.Add(pic);

            cartPanel.MouseMove += Panel_MouseMove;
            cartPanel.MouseLeave += Panel_Leave;
            cartPanel.Click += Panel_Click;

            lblproductID.MouseMove += lbl_MouseMove;
            lblproductID.MouseLeave += lbl_Leave;
            lblproductID.Click += lbl_Click;

            lblName.MouseMove += lbl_MouseMove;
            lblName.MouseLeave += lbl_Leave;
            lblName.Click += lbl_Click;

            pic.MouseMove += PictureBox_MouseMove;
            pic.MouseLeave += PictureBox_Leave;
            pic.Click += PictureBox_Click;

            removebtn.MouseMove += btn_MouseMove;
            removebtn.MouseLeave += btn_Leave;

            numericUpDown.MouseMove += Numuric_MouseMove;
            numericUpDown.MouseLeave += Numuric_Leave;
            CallDetailData(originalPanel);
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
        private void Button_Click(object sender, EventArgs e)
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
                else if (sender is Button)
                {
                    panel = (Panel)((Button)sender).Parent;
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
                productconnection = new SqlConnection(InitializeUser._key_con);
                productconnection.Open();
                string command = "SELECT ProductID , ProductName , Price , ProductType, ProductDetail , ProductImg , ProductsShelf , Quality FROM Products Where ProductsShelf = 1 And ProductID = @key_ProductID";
                productcommand = new SqlCommand(command, productconnection);
                productcommand.Parameters.AddWithValue("@key_ProductID", key_ProductID);
                productdataadapter = new SqlDataAdapter(productcommand);
                producttable = new DataTable();
                productdataadapter.Fill(producttable);

                txtProductname.Text = producttable.Rows[0]["ProductName"].ToString();
                txtPrice.Text = producttable.Rows[0]["Price"].ToString();
                txtPrice.Text = Convert.ToDecimal(txtPrice.Text).ToString("N2") + " ฿";
                txtProductType.Text = producttable.Rows[0]["ProductType"].ToString();
                txtDesription.Text = producttable.Rows[0]["ProductDetail"].ToString();
                textBoxProRemain.Text = producttable.Rows[0]["Quality"].ToString();
                byte[] imageBytes = (byte[])producttable.Rows[0]["ProductImg"];
                MemoryStream ms = new MemoryStream(imageBytes);
                picProduct.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Checkpayment()
        {
            if (string.IsNullOrEmpty(comboBoxmethonPayment.Text))
            {
                MessageBox.Show("โปรดเลือกวิธีชำระเงิน" , "เกิดข้อผิดพลาด" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            Checkpayment();
            CalculateTotalPrice();
            if (totalPrice == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าก่อนชำระเงิน");
                return;
            }
            if (InitializeUser.UserState is "Member")
            {
                string rechack = "ยืนยันการสั่งซื้อสินค้าหรือไม่";
                foreach (Panel pn in panelscart)
                {
                    rechack += "\n- " + pn.Controls.OfType<Label>().FirstOrDefault(l => l.Tag?.ToString() == "ProductName").Text;
                    rechack += " จำนวน " + pn.Controls.OfType<NumericUpDown>().FirstOrDefault(l => l.Tag?.ToString() == "NumericUpDown").Value + " ชิ้น";
                }
                rechack += "\nราคารวม " + totalPrice.ToString("N2") + " บาท";

                if (MessageBox.Show(rechack, "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                        foreach (Control control in flowLayoutCart.Controls)
                        {
                            if (control is Panel panel)
                            {
                                Label lblProductID = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag?.ToString() == "ProductID");
                                Label lblProductName = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag?.ToString() == "ProductName");
                                NumericUpDown quantityControl = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();

                                if (lblProductID != null && quantityControl != null && lblProductName != null)
                                {
                                    string command1 = "SELECT Quality FROM Products WHERE ProductID = @productID";

                                    using (SqlCommand orderdetailcommand = new SqlCommand(command1, orderdetailconnection))
                                    {
                                        orderdetailcommand.Parameters.AddWithValue("@productID", lblProductID.Text);
                                        int currentStock = (int)orderdetailcommand.ExecuteScalar();

                                        if (currentStock < quantityControl.Value)
                                        {
                                            MessageBox.Show($"สินค้า '{lblProductName.Text}' มีจำนวนไม่พอ\n" +
                                                          $"คงเหลือ: {currentStock} ชิ้น\n" +
                                                          $"ต้องการ: {quantityControl.Value} ชิ้น",
                                                          "สินค้าไม่เพียงพอ",
                                                          MessageBoxButtons.OK,
                                                          MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        // ส่งข้อมูลไปยังฐานข้อมูล Orders
                        orderconnection = new SqlConnection(InitializeUser._key_con);
                            orderconnection.Open();
                            paymentconnection = new SqlConnection(InitializeUser._key_con);
                            paymentconnection.Open();
                            int orderID = 0;
                            string command = "INSERT INTO Orders (memID, OrderDate) OUTPUT INSERTED.OrderID VALUES (@UserID, @OrderDate)";
                            ordercommand = new SqlCommand(command, orderconnection);
                            ordercommand.Parameters.AddWithValue("@UserID", InitializeUser.UserID);
                            ordercommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                            orderID = (int)ordercommand.ExecuteScalar();
                            orderconnection.Close();

                            // ส่งข้อมูลไปยังฐานข้อมูล OrderDetails
                            orderdetailconnection = new SqlConnection(InitializeUser._key_con);
                            orderdetailconnection.Open();
                            foreach (Control control in flowLayoutCart.Controls)
                            {
                                if (control is Panel panel)
                                {
                                    Label lblProductID = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag?.ToString() == "ProductID");
                                    NumericUpDown quantityControl = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                                    Label priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag?.ToString() == "Price");

                                    if (lblProductID != null && quantityControl != null && priceLabel != null)
                                    {
                                        string command1 = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                                        orderdetailcommand = new SqlCommand(command1, orderdetailconnection);
                                        orderdetailcommand.Parameters.AddWithValue("@OrderID", orderID);
                                        orderdetailcommand.Parameters.AddWithValue("@ProductID", lblProductID.Text);
                                        orderdetailcommand.Parameters.AddWithValue("@Quantity", quantityControl.Value);
                                        orderdetailcommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        
                        
                        orderdetailconnection.Close();
                        string command2 = "INSERT INTO Payments(Amount , Paydate , OrderID , Method) VALUES(@amount , @paydate , @orderid , @method)";
                        paymentcommand = new SqlCommand(command2, paymentconnection);
                        paymentcommand.Parameters.AddWithValue("@amount", totalPrice);
                        paymentcommand.Parameters.AddWithValue("@paydate", DateTime.Now);
                        paymentcommand.Parameters.AddWithValue("@orderid", orderID);
                        paymentcommand.Parameters.AddWithValue("@method", comboBoxmethonPayment.Text);
                        paymentcommand.ExecuteNonQuery();
                        paymentconnection.Close();

                        SqlConnection packconnection = new SqlConnection(InitializeUser._key_con);
                        packconnection.Open();
                        string command3 = "INSERT INTO Packing(PackStatus , PackDate , OrderID , empID) VALUES(@packstatus , @packDate , @orderID , @empID) ";
                        SqlCommand packcommand = new SqlCommand(command3, packconnection);
                        packcommand.Parameters.AddWithValue("@packstatus", "รอจัดส่ง");
                        packcommand.Parameters.AddWithValue("@packDate", DateTime.Now);
                        packcommand.Parameters.AddWithValue("@orderID", orderID);
                        packcommand.Parameters.AddWithValue("@empID", InitializeUser.ManagerID); //เซ็ตค่าเป็น 1 ก่อน
                        packcommand.ExecuteNonQuery();
                        packconnection.Close();

                        MessageBox.Show("สั่งซื้อสินค้าเรียบร้อย");

                            flowLayoutCart.Controls.Clear();
                            panelscart.Clear();
                    }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
            }
        }
        // ส่งข้อมูลไปยังฐานข้อมูล
        private void CalculateTotalPrice()
        {
            totalPrice = 0;
            foreach (Control control in flowLayoutCart.Controls)
            {
                if (control is Panel panel)
                {
                    NumericUpDown quantityControl = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                    Label priceLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Tag?.ToString() == "Price");

                    if (quantityControl != null && priceLabel != null)
                    {
                        decimal price = decimal.Parse(priceLabel.Text.Replace("฿", "").Trim());
                        totalPrice += price * quantityControl.Value;
                    }
                }
            }
        }

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
                            
                            if (Regex.IsMatch(label.Text.ToLower(), Productname.ToLower()))
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
