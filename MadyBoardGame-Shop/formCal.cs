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
    public partial class formCal : Form
    {
        public formCal()
        {
            InitializeComponent();
            
        }
        SqlConnection productcon;
        SqlCommand productcommand;
        SqlDataAdapter productdataadapter;
        DataTable productdatatable;

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textQRcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textQRcode.Text))
                {
                    productcon = new SqlConnection(InitializeUser._key_con);
                    productcommand = new SqlCommand();
                    productdatatable = new DataTable();
                    productdataadapter = new SqlDataAdapter();
                    productcon.Open();
                    
                    string qry = "SELECT ProductID , ProductName , Price FROM Products WHERE ProductID = @proid";
                    productcommand = new SqlCommand(qry , productcon);
                    productcommand.Parameters.AddWithValue("@proid", textQRcode.Text);
                    productdataadapter.SelectCommand = productcommand;
                    productdataadapter.Fill(productdatatable);
                    if (productdatatable.Rows.Count <= 0)
                    {
                        MessageBox.Show("ไม่เจอสินค้า");
                        return;
                    }
                    Panel panel = new Panel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(586, 69);
                    panel.BackColor = Color.White;

                    Label labelProID = new Label();
                    labelProID.Text = productdatatable.Rows[0]["ProductID"].ToString();
                    labelProID.AutoSize = false;
                    labelProID.Size = new Size(50, 20);
                    labelProID.Location = new Point(5 , (panel.Height -labelProID.Height) / 2 );
                    labelProID.BackColor = Color.Gray;
                    labelProID.TextAlign = ContentAlignment.MiddleLeft;
                    

                    Label labelproname = new Label();
                    labelproname.Text = productdatatable.Rows[0]["ProductName"].ToString();
                    labelproname.AutoSize = false;
                    labelproname.TextAlign = ContentAlignment.MiddleLeft;
                    labelproname.Size = new Size(320, 20);
                    labelproname.Location = new Point(70, (panel.Height - labelproname.Height) / 2);
                    labelproname.BackColor = Color.Green;
                    

                    Label labelQuality = new Label();
                    labelQuality.Text = "X 1";
                    labelQuality.AutoSize = false;
                    labelQuality.Size = new Size(70, 20);
                    labelQuality.Location = new Point(panel.Width - labelQuality.Width, (panel.Height - labelQuality.Height) / 2);
                    labelQuality.BackColor = Color.Blue;
                    labelQuality.TextAlign = ContentAlignment.MiddleRight;
                    labelQuality.Tag = "Quality";


                    Label labelprice = new Label();
                    labelprice.Text = Convert.ToDecimal(productdatatable.Rows[0]["Price"]).ToString("F2") + " ฿";
                    labelprice.AutoSize = false;
                    labelprice.Size = new Size(150, 20);
                    labelprice.Location = new Point(panel.Width - labelQuality.Width - labelprice.Width, (panel.Height - labelprice.Height) / 2);
                    labelprice.BackColor = Color.Orange;
                    
                    labelprice.TextAlign = ContentAlignment.MiddleRight;
                    

                    

                    panel.Controls.Add(labelQuality);
                    panel.Controls.Add(labelprice);
                    panel.Controls.Add(labelProID);
                    panel.Controls.Add(labelproname);

                    flowLayoutProduct.Controls.Add(panel);
                    textQRcode.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message );
            }
        }

        private void formCal_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
        }
    }
}
