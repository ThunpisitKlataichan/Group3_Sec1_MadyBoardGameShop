using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formAddProductQuality : Form
    {
        public formAddProductQuality()
        {
            InitializeComponent();
        }
        SqlConnection productconnect;
        SqlCommand productcommand;
        SqlDataAdapter productadapter;
        DataTable productdata;
        DataTable productdata2;

        SqlConnection suppconnection;
        SqlCommand suppcommand;
        SqlDataAdapter suppdataAdapter;
        DataTable suppdata;

        SqlConnection shippingconnect;
        SqlCommand shippingcommand;

        List<Panel> listpanel = new List<Panel>();

        bool waitforload = false;

        private void formAddProductQuality_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeUser.Confic();
                suppconnection = new SqlConnection(InitializeUser._key_con);
                suppcommand = new SqlCommand("SELECT * FROM Suppilers", suppconnection);
                suppconnection.Open();
                suppdata = new DataTable();
                suppdataAdapter = new SqlDataAdapter(suppcommand);
                suppdataAdapter.Fill(suppdata);
                comboBoxSupp.DataSource = suppdata;
                comboBoxSupp.DisplayMember = "SuppilerName";
                comboBoxSupp.ValueMember = "SuppilerID";

                productconnect = new SqlConnection(InitializeUser._key_con);
                productconnect.Open();
                string qry = "Select ProductID , ProductName , CostPrice , ProductImg , Quality , SuppilersID FROM Products Where SuppilersID = @suppilersID";
                productcommand = new SqlCommand(qry, productconnect);
                productcommand.Parameters.AddWithValue("@suppilersID", comboBoxSupp.SelectedValue);
                productadapter = new SqlDataAdapter(productcommand);
                productdata = new DataTable();
                productadapter.Fill(productdata);
                comboBoxProduct.DataSource = productdata;
                comboBoxProduct.DisplayMember = "ProductName";
                comboBoxProduct.ValueMember = "ProductID";

                textBoxProID.Text = comboBoxProduct.SelectedValue.ToString();
                textBoxProCost.Text = productdata.Rows[0]["CostPrice"].ToString();
                waitforload = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void formAddProductQuality_FormClosing(object sender, FormClosingEventArgs e)
        {
            productconnect.Dispose();
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddlist_Click(object sender, EventArgs e)
        {
            string qry = "Select ProductID , ProductName , CostPrice , ProductImg , Quality , SuppilersID FROM Products Where ProductID = @productID";
            productcommand = new SqlCommand(qry, productconnect);
            productcommand.Parameters.AddWithValue("@productID", comboBoxProduct.SelectedValue);
            productadapter = new SqlDataAdapter(productcommand);
            productdata = new DataTable();
            productadapter.Fill(productdata);

            if (productdata.Rows.Count == 0)
            {
                MessageBox.Show("ไม่พบสินค้า");
                return;
            }
            

            Panel panel = new Panel();
            panel.Size = new Size(168, 208);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.DarkGray;
            panel.Tag = comboBoxProduct.SelectedValue.ToString();
            panel.Tag = productdata.Rows[0]["ProductID"].ToString();
            if (listpanel.Any(x => x.Tag.ToString() == panel.Tag.ToString()))
            {
                MessageBox.Show("มีสินค้านี้อยู่แล้ว");
                return;
            }
            else 
            {
                listpanel.Add(panel);
            }


            PictureBox pic = new PictureBox();
            pic.Size = new Size(116, 97);
            pic.Location = new Point((panel.Width-pic.Width)/2, 2);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            byte[] img = (byte[])productdata.Rows[0]["ProductImg"];
            MemoryStream ms = new MemoryStream(img);
            pic.Image = Image.FromStream(ms);
            pic.Click += PictureBox_Click;

            Label labelNameTitle = new Label();
            labelNameTitle.Text = "ชื่อ";
            labelNameTitle.Location = new Point(3 , 103);
            labelNameTitle.AutoSize = true;
            labelNameTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            labelNameTitle.Click += Label_Click;

            Label labelName = new Label();
            labelName.Text = productdata.Rows[0]["ProductName"].ToString();
            labelName.Location = new Point(26, 103);
            labelName.AutoSize = false;
            labelName.Size = new Size(116, 46);
            labelName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            labelName.Click += Label_Click;

            Label numtitle = new Label();
            numtitle.Text = "จำนวน";
            numtitle.Location = new Point(3, 158);
            numtitle.AutoSize = true;
            numtitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            numtitle.Click += Label_Click;

            NumericUpDown numQuality = new NumericUpDown();
            numQuality.Location = new Point(49, 158);
            numQuality.Size = new Size(34, 21);
            numQuality.Minimum = 1;
            numQuality.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            numQuality.Tag = "Quality";
            numQuality.Click += Label_Click;

            Label labelCostTitle = new Label();
            labelCostTitle.Text = "ราคาซื้อ";
            labelCostTitle.Location = new Point(3, 189);
            labelCostTitle.AutoSize = true;
            labelCostTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            labelCostPrice.Click += Label_Click;

            Label labelCost = new Label();
            labelCost.Text = Convert.ToDecimal(productdata.Rows[0]["CostPrice"]).ToString("N2");
            labelCost.Location = new Point(49, 189);
            labelCost.AutoSize = false;
            labelCost.Size = new Size(93, 15);
            labelCost.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            labelCost.TextAlign = ContentAlignment.MiddleRight;
            labelCost.Click += Label_Click;

            Label bathsign = new Label();
            bathsign.Text = "฿";
            bathsign.Location = new Point(148, 189);
            bathsign.AutoSize = true;
            bathsign.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            bathsign.Click += Label_Click;

            Button buttonDelete = new Button();
            buttonDelete.Text = "X";
            buttonDelete.BackColor = Color.IndianRed;
            buttonDelete.Location = new Point(142, 3);
            buttonDelete.AutoSize = false;
            buttonDelete.Size = new Size(26, 26);
            buttonDelete.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            buttonDelete.Click += buttondelete_Click;

            panel.Controls.Add(pic);
            panel.Controls.Add(labelNameTitle);
            panel.Controls.Add(labelName);
            panel.Controls.Add(labelCostTitle);
            panel.Controls.Add(labelCost);
            panel.Controls.Add(bathsign);
            panel.Controls.Add(numtitle);
            panel.Controls.Add(numQuality);
            panel.Controls.Add(buttonDelete);
            panel.Click += Panel_Click;

            flowLayoutListProduct.Controls.Add(panel);
            SetDetail(panel.Tag.ToString());
        }

        private void comboBoxSupp_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (waitforload)
            {
                string qry = "Select ProductID , ProductName , CostPrice , ProductImg , Quality , SuppilersID FROM Products Where SuppilersID = @suppilersID";
                productcommand = new SqlCommand(qry, productconnect);
                productcommand.Parameters.AddWithValue("@suppilersID", comboBoxSupp.SelectedValue);
                productadapter = new SqlDataAdapter(productcommand);
                productdata = new DataTable();
                productadapter.Fill(productdata);
                comboBoxProduct.DataSource = productdata;
                comboBoxProduct.DisplayMember = "ProductName"; 
                comboBoxProduct.ValueMember = "ProductID";
            }
            
        }
        private void buttondelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Panel panel = (Panel)btn.Parent;
            flowLayoutListProduct.Controls.Remove(panel);
            listpanel.Remove(panel);
            CallDetailData(sender);
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProID.Text = comboBoxProduct.SelectedValue.ToString();
            textBoxProCost.Text = productdata.Rows[0]["CostPrice"].ToString();
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }
        private void Label_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            CallDetailData(sender);
        }

        private void CallDetailData(object sender)
        {
            try
            {
                string key_ProductID = "";
                Panel panel = null;
                if (sender is Panel)
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
                else if (sender is NumericUpDown)
                {
                    panel = (Panel)((NumericUpDown)sender).Parent;
                }
                key_ProductID = panel.Tag.ToString();
                SetDetail(key_ProductID);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void SetDetail(string key_ProductID)
        {
            productconnect = new SqlConnection(InitializeUser._key_con);
            productconnect.Open();
            string command = "SELECT ProductID , ProductName ,CostPrice , Price , ProductImg , SuppilerName , Quality FROM Products , Suppilers Where ProductID = @key_ProductID";
            productcommand = new SqlCommand(command, productconnect);
            productcommand.Parameters.AddWithValue("@key_ProductID", key_ProductID);
            productadapter = new SqlDataAdapter(productcommand);
            productdata2 = new DataTable();
            productadapter.Fill(productdata2);

            labelProname.Text = productdata2.Rows[0]["ProductName"].ToString();
            labelCostPrice.Text = Convert.ToDecimal(productdata2.Rows[0]["CostPrice"]).ToString("N2");
            labelPrice.Text = Convert.ToDecimal(productdata2.Rows[0]["Price"]).ToString("N2");
            labelSupName.Text = productdata2.Rows[0]["SuppilerName"].ToString();
            labelQuality.Text = productdata2.Rows[0]["Quality"].ToString();
            byte[] img = (byte[])productdata2.Rows[0]["ProductImg"];
            MemoryStream ms = new MemoryStream(img);
            pictureBoxProduct.Image = Image.FromStream(ms);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void buttonPur_Click(object sender, EventArgs e)
        {
            try
            {
                if (listpanel.Count == 0)
                {
                    MessageBox.Show("ไม่มีสินค้าในรายการ");
                    return;
                }
                string qry = @"
                INSERT INTO Purchasing (PurlDate, empID) 
                VALUES (@purlDate, @empID); 
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
                productcommand = new SqlCommand(qry, productconnect);
                productcommand.Parameters.AddWithValue("@purlDate", DateTime.Now);
                productcommand.Parameters.AddWithValue("@empID", InitializeUser.UserID);
                int purID = Convert.ToInt32(productcommand.ExecuteScalar());

                shippingconnect = new SqlConnection(InitializeUser._key_con);
                shippingconnect.Open();
                qry = "INSERT INTO ShippingPur (ShippingStatus , ShippingDate , PurID) VALUES(@shippingStatus , @shippingDate , @purID)";
                shippingcommand = new SqlCommand(qry, shippingconnect);
                shippingcommand.Parameters.AddWithValue("@shippingStatus", "กำลังขับไปรับสินค้า");
                shippingcommand.Parameters.AddWithValue("@shippingDate", DateTime.Now);
                shippingcommand.Parameters.AddWithValue("@purID", purID);
                shippingcommand.ExecuteNonQuery();

                string ID = "";
                int Quality = 0;
                foreach (Control c in flowLayoutListProduct.Controls)
                {
                    if (c is Panel)
                    {
                        ID = c.Tag.ToString();
                        foreach (Control c2 in c.Controls)
                        {
                            if (c2 is NumericUpDown)
                            {
                                Quality = Convert.ToInt32(((NumericUpDown)c2).Value);
                            }
                        }
                        qry = "INSERT INTO PurchaseDetail ( PurID , ProductID , Quality ) VALUES(@purID , @productID , @quality)";
                        productcommand = new SqlCommand(qry, productconnect);
                        productcommand.Parameters.AddWithValue("@purID", purID);
                        productcommand.Parameters.AddWithValue("@productID", ID);
                        productcommand.Parameters.AddWithValue("@quality", Quality);
                        productcommand.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("ทำรายการสั่งซื้อสำเร็จ", "สั่งซื้อ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flowLayoutListProduct.Controls.Clear();
                listpanel.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           
        }
    }
}
