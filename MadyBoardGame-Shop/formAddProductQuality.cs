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

        SqlConnection suppconnection;
        SqlCommand suppcommand;
        SqlDataAdapter suppdataAdapter;
        DataTable suppdata;

        SqlConnection shippingconnect;
        SqlCommand shippingcommand;
        SqlDataAdapter shippingdataadapter;
        DataTable shippingdata;

        bool waitforload = false;
        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            

        }

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

            Panel panel = new Panel();
            panel.Size = new Size(168, 208);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.DarkGray;

            PictureBox pic = new PictureBox();
            pic.Size = new Size(116, 97);
            pic.Location = new Point((panel.Width-pic.Width)/2, 2);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            byte[] img = (byte[])productdata.Rows[0]["ProductImg"];
            MemoryStream ms = new MemoryStream(img);
            pic.Image = Image.FromStream(ms);

            Label labelNameTitle = new Label();
            labelNameTitle.Text = "ชื่อ";
            labelNameTitle.Location = new Point(3 , 103);
            labelNameTitle.AutoSize = true;
            labelNameTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);

            Label labelName = new Label();
            labelName.Text = productdata.Rows[0]["ProductName"].ToString();
            labelName.Location = new Point(26, 103);
            labelName.AutoSize = false;
            labelName.Size = new Size(116, 46);
            labelName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

            Label numtitle = new Label();
            numtitle.Text = "จำนวน";
            numtitle.Location = new Point(3, 158);
            numtitle.AutoSize = true;
            numtitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);

            NumericUpDown numQuality = new NumericUpDown();
            numQuality.Location = new Point(49, 158);
            numQuality.Size = new Size(34, 21);
            numQuality.Minimum = 1;
            numQuality.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

            Label labelCostTitle = new Label();
            labelCostTitle.Text = "ราคาซื้อ";
            labelCostTitle.Location = new Point(3, 189);
            labelCostTitle.AutoSize = true;
            labelCostTitle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);

            Label labelCost = new Label();
            labelCost.Text = productdata.Rows[0]["CostPrice"].ToString();
            labelCost.Location = new Point(49, 189);
            labelCost.AutoSize = false;
            labelCost.Size = new Size(93, 15);
            labelCost.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            labelCost.TextAlign = ContentAlignment.MiddleRight;

            Label bathsign = new Label();
            bathsign.Text = "฿";
            bathsign.Location = new Point(148, 189);
            bathsign.AutoSize = true;
            bathsign.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

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

            flowLayoutListProduct.Controls.Add(panel);
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
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProID.Text = comboBoxProduct.SelectedValue.ToString();
            textBoxProCost.Text = productdata.Rows[0]["CostPrice"].ToString();
        }
    }
}
