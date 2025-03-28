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

                    Button buttonDelete = new Button();
                    buttonDelete.Text = "X";
                    buttonDelete.Size = new Size(20, 20);
                    buttonDelete.Location = new Point(panel.Width - buttonDelete.Width - 5, 3);
                    buttonDelete.BackColor = Color.Red;
                    buttonDelete.Font = new Font("Arial", 8, FontStyle.Bold);
                    buttonDelete.Click += buttonDelete_Click;

                    amount += Convert.ToDecimal(productdatatable.Rows[0]["Price"]);
                    labelAmount.Text = amount.ToString("F2") + " ฿";

                    panel.Controls.Add(labelQuality);
                    panel.Controls.Add(labelprice);
                    panel.Controls.Add(labelProID);
                    panel.Controls.Add(labelproname);
                    panel.Controls.Add(buttonDelete);

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove this item from cart?", "Confirm",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            // Get the button that was clicked and its parent panel
            if (!(sender is Button button) || !(button.Parent is Panel panel))
                return;

            try
            {
                // Find the quantity label and price label
                Label quantityLabel = null;
                Label priceLabel = null;
                decimal itemPrice = 0;
                int quantity = 0;

                foreach (Control control in panel.Controls)
                {
                    if (control is Label label)
                    {
                        // Find quantity label
                        if (label.Tag?.ToString() == "Quality")
                        {
                            quantityLabel = label;
                            if (int.TryParse(label.Text.Split(' ')[1], out int qty))
                                quantity = qty;
                        }
                        // Find price label
                        else if (label.Text.Contains("฿"))
                        {
                            priceLabel = label;
                            if (decimal.TryParse(label.Text.Replace("฿", "").Trim(), out decimal price))
                                itemPrice = price;
                        }
                    }
                }

                // Calculate and update total amount
                if (quantityLabel != null && priceLabel != null)
                {
                    decimal itemTotal = itemPrice * quantity;
                    amount -= itemTotal;
                    labelAmount.Text = amount.ToString("F2") + " ฿";
                }

                // Remove the panel from layout and tracking collection
                flowLayoutProduct.Controls.Remove(panel);

                if (panel.Tag != null)
                    checkTagCartpanalTag.Remove(panel.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e) // ยืนยันการชำระเงิน เเละ ลดจำนวณสินค้าเสร็จเเล้ว
        {
            string qry = "";
            SqlConnection PayfrontStoreConnection = new SqlConnection(InitializeUser._key_con);
            if (MessageBox.Show("ยืนยันการชำระเงินหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    foreach (Control c in flowLayoutProduct.Controls)
                    {
                        string productID = "";
                        string quality = "";
                        if (c is Panel)
                        {
                            Panel panel = c as Panel;
                            foreach (Control c2 in panel.Controls)
                            {
                                if (c2 is Label)
                                {
                                    if (c2.Tag != null && c2.Tag.ToString() == "ProductID")
                                    {
                                        productID = c2.Text;
                                        if (string.IsNullOrEmpty(productID))
                                        {
                                            MessageBox.Show("ไม่พบ ID สินค้า", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else if (c2.Tag != null && c2.Tag.ToString() == "Quality")
                                    {
                                        quality = c2.Text.Split(' ')[1];
                                        if (string.IsNullOrEmpty(quality))
                                        {
                                            MessageBox.Show("ไม่พบจำนวนสินค้า", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                                qry = "SELECT Quality FROM Products WHERE ProductID = @productID AND Quality < @quality";
                                using (SqlCommand command = new SqlCommand(qry, PayfrontStoreConnection))
                                {
                                    command.Parameters.AddWithValue("@productID", productID);
                                    command.Parameters.AddWithValue("@quality", quality);
                                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                                    DataTable dataTable = new DataTable();
                                    adapter.Fill(dataTable);
                                    if (dataTable.Rows.Count > 0)
                                    {
                                        MessageBox.Show("สินค้า " + productID + " มีจำนวนไม่พอ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }


                        qry = "INSERT INTO PayFrontStore(empID , Paymethod , Paydate) VALUES(@empID , @paymethod , @date)";
                        SqlCommand PayfrontStoreCommand = new SqlCommand(qry, PayfrontStoreConnection);
                        PayfrontStoreConnection.Open();
                        PayfrontStoreCommand.Parameters.AddWithValue("@empID", InitializeUser.UserID);
                        PayfrontStoreCommand.Parameters.AddWithValue("@paymethod", comboMethodPay.Text);
                        PayfrontStoreCommand.Parameters.AddWithValue("@date", DateTime.Now);


                        PayfrontStoreCommand.ExecuteNonQuery();
                        DecressProductQuality(flowLayoutProduct);

                        MessageBox.Show("ทำรายการสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flowLayoutProduct.Controls.Clear();
                        amount = 0;
                        checkTagCartpanalTag.Clear();

                        labelAmount.Text = "0.00 ฿";
                    }
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
            int PayfrontProductID = 0;
            using (SqlConnection PayfStore = new SqlConnection())
            {
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
                            UpdateProductQualityInDatabase(productID, quality, PayfrontProductID);
                        }
                        else
                        {
                            MessageBox.Show("ไม่เขอ ID หรือ จำนวน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void UpdateProductQualityInDatabase(string productID, int quality , int payfID)
        {
            using (productcon = new SqlConnection(InitializeUser._key_con))
            {
                productcon.Open();

                string qry2 = "UPDATE Products SET Quality = Quality - @qualityupdate WHERE ProductID = @productID";
                using (productcommand = new SqlCommand(qry2, productcon))
                {
                    productcommand.Parameters.AddWithValue("@productID", productID);
                    productcommand.Parameters.AddWithValue("@qualityupdate", quality);
                    productcommand.ExecuteNonQuery();
                }
                string qry = "SELECT TOP 1 * FROM PayFrontStore ORDER BY PayfID DESC ;";
                using (SqlCommand command = new SqlCommand(qry, productcon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        payfID = int.Parse(dataTable.Rows[0]["PayfID"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบ ID ของ PayFrontStore", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string qry3 = "INSERT INTO PayFrontStoreDetails(Quality , ProductID , PayfID) VALUES(@quality , @productID , @payfID)";
                using (productcommand = new SqlCommand(qry3, productcon))
                {
                    productcommand.Parameters.AddWithValue("@payfID", payfID);
                    productcommand.Parameters.AddWithValue("@productID", productID);
                    productcommand.Parameters.AddWithValue("@quality", quality);
                    productcommand.ExecuteNonQuery();
                }

                
            }

        }
    }
}
