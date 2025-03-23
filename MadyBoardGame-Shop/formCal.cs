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

        List<string> checkTagCartpanalTag = new List<string>();

        decimal amount;

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
                        textQRcode.Text = "";
                        return;
                    }
                    string productID = productdatatable.Rows[0]["ProductID"].ToString();
                    string productName = productdatatable.Rows[0]["ProductName"].ToString();
                    decimal price = Convert.ToDecimal(productdatatable.Rows[0]["Price"]);


                    Panel panel = new Panel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Size = new Size(586, 69);
                    panel.BackColor = Color.White;
                    panel.Tag = productID;

                    if (checkTagCartpanalTag.Any(a => a == panel.Tag.ToString()))
                    {
                        Panel existPanal = new Panel();
                        foreach (Control control in flowLayoutProduct.Controls)
                        {
                            if (control is Panel)
                            {
                                if (control.Tag != null && control.Tag.ToString() == panel.Tag.ToString())
                                {
                                    existPanal = control as Panel;
                                }
                            }
                        }
                        Label existQuality = new Label();
                        Label existPrice = new Label();
                        foreach (Control control in existPanal.Controls)
                        {
                            if (control is Label)
                            {
                                if (control.Tag != null && control.Tag.ToString() == "Quality")
                                {
                                    existQuality = control as Label;
                                }
                                if (control.Text.Contains("฿"))
                                {
                                    existPrice = control as Label;
                                }
                            }
                        }
                        int count = Convert.ToInt32(existQuality.Text.Split(' ')[1]);
                        decimal dprice = Convert.ToDecimal(existPrice.Text.Split(' ')[0]);
                        amount += dprice;
                        labelAmount.Text = amount.ToString("F2") + " ฿";

                        existQuality.Text = "X " + (Convert.ToInt32(count + 1)).ToString();
                        textQRcode.Text = "";
                        return;
                    }
                    else
                    {
                        checkTagCartpanalTag.Add(panel.Tag.ToString());
                        textQRcode.Text = "";
                    }

                    Label labelProID = new Label();
                    labelProID.Text = productID;
                    labelProID.AutoSize = false;
                    labelProID.Size = new Size(50, 20);
                    labelProID.Location = new Point(5 , (panel.Height -labelProID.Height) / 2 );
                    labelProID.BackColor = Color.Gray;
                    labelProID.TextAlign = ContentAlignment.MiddleLeft;
                    labelProID.Tag = "ProductID";
                    
                    Label labelproname = new Label();
                    labelproname.Text = productName;
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
                    labelprice.Text = price.ToString("F2") + " ฿";
                    labelprice.AutoSize = false;
                    labelprice.Size = new Size(150, 20);
                    labelprice.Location = new Point(panel.Width - labelQuality.Width - labelprice.Width, (panel.Height - labelprice.Height) / 2);
                    labelprice.BackColor = Color.Orange;
                    labelprice.TextAlign = ContentAlignment.MiddleRight;

                    amount += Convert.ToDecimal(productdatatable.Rows[0]["Price"]);
                    labelAmount.Text = amount.ToString("F2") + " ฿";

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
            amount = 0m;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันการชำระเงินหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection PayfrontStoreConnection = new SqlConnection(InitializeUser._key_con);
                    string qry = "INSERT INTO PayFrontStore(Amount , empID , Paymethod) VALUES(@amount , @empID , @paymethod)";
                    SqlCommand PayfrontStoreCommand = new SqlCommand(qry , PayfrontStoreConnection);
                    PayfrontStoreConnection.Open();
                    PayfrontStoreCommand.Parameters.AddWithValue("@amount", amount);
                    PayfrontStoreCommand.Parameters.AddWithValue("@empID", InitializeUser.UserID);
                    PayfrontStoreCommand.Parameters.AddWithValue("@paymethod", comboMethodPay.Text);
                    DecressProductQuality(flowLayoutProduct);

                    PayfrontStoreCommand.ExecuteNonQuery();

                    MessageBox.Show("ทำรายการสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flowLayoutProduct.Controls.Clear();
                    labelAmount.Text = "0.00 ฿";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DecressProductQuality(FlowLayoutPanel flows)
        {
            int quality = 0;
            string productID = "0";
            foreach (Control control in flows.Controls) // ลบของตามจำนวณที่สั่ง
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is Label label)
                        {
                            if (label.Tag != null)
                            {
                                switch (label.Tag.ToString())
                                {
                                    case "Quality":
                                        string qual = label.Text.Split(' ')[1];
                                        if (int.TryParse(qual, out int parsedQuality))
                                        {
                                            quality = parsedQuality;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid quality value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return; 
                                        }
                                        break;

                                    case "ProductID":
                                        productID = label.Text;
                                        break;
                                }
                            }
                        }
                    }
                    if (productID != "0" && quality > 0)
                    {
                        UpdateProductQualityInDatabase(productID, quality);
                    }
                    else
                    {
                        MessageBox.Show("ไม่เขอ ID หรือ จำนวน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateProductQualityInDatabase(string productID, int quality)
        {
            using (productcon = new SqlConnection(InitializeUser._key_con))
            {
                int originQuality = 0;
                productcon.Open();

                string qry1 = "Select Quality FROM Products WHERE ProductID = @productID";
                using (productcommand = new SqlCommand(qry1, productcon))
                {
                    productcommand.Parameters.AddWithValue("@productID", productID);
                    productdataadapter.SelectCommand = productcommand;
                    productdatatable = new DataTable();
                    productdataadapter.Fill(productdatatable);
                    if (productdatatable.Rows.Count > 0)
                    {
                        originQuality = int.Parse(productdatatable.Rows[0][0].ToString());
                    }
                    productdatatable.Clear();
                }

                string qry2 = "UPDATE Products SET Quality = @qualityupdate WHERE ProductID = @productID";
                using (productcommand = new SqlCommand(qry2, productcon))
                {
                    productcommand.Parameters.AddWithValue("@productID", productID);
                    productcommand.Parameters.AddWithValue("@qualityupdate", originQuality - quality);
                    productcommand.ExecuteNonQuery();
                }
            }

        }
    }
}
