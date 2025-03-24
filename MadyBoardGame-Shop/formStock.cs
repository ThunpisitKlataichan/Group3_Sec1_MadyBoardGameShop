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
    using System.Xml.Linq;

    namespace MadyBoardGame_Shop
        {
            public partial class formProduct : Form
            {
                public formProduct()
                {
                    InitializeComponent();
                    InitializeUser.Confic();
                }
            // ประกาศตัวแปรสำหรับเชื่อมต่อฐานข้อมูล
            SqlConnection productsconnection;
            SqlCommand productcommand;
            SqlDataAdapter productadapter;
            DataTable productdatatable;
            CurrencyManager productmanager;
            string immage = ""; // เก็บชื่อไฟล์รูปภาพ
            int Productmark;
            string mystate = ""; // ใช้เพื่อระบุสถานะ (insert, update, view)

            // เมื่อโหลดฟอร์มสินค้า
            private void formStock_Load(object sender, EventArgs e)
            {
            try
            {
                // เชื่อมต่อฐานข้อมูล
                productsconnection = new SqlConnection(InitializeUser._key_con);
                productcommand = new SqlCommand();
                productadapter = new SqlDataAdapter();
                productdatatable = new DataTable();
                productsconnection.Open();

                // ดึงข้อมูลสินค้าจากฐานข้อมูล
                string query = "SELECT * FROM Products";
                productcommand = new SqlCommand(query, productsconnection);
                productadapter.SelectCommand = productcommand;
                productadapter.Fill(productdatatable);

                // ผูกข้อมูลกับตัวควบคุมในฟอร์ม
                txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
                txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                txtSuppilersID.DataBindings.Add("Text", productdatatable, "SuppilersID");
                txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");

                // เช็คสถานะการแสดงผลสินค้า
                productcommand.Parameters.AddWithValue("@productsShelf", checkBoxShowonShelf.Checked ? "True" : "False");

                // แสดงข้อมูลใน DataGrid
                dataGridStock.DataSource = productdatatable;
                dataGridStock.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                dataGridStock.Columns["ProductType"].HeaderText = "ชนิดสินค้า";
                dataGridStock.Columns["CostPrice"].HeaderText = "ต้นทุน";
                dataGridStock.Columns["Price"].HeaderText = "ราคา";
                dataGridStock.Columns["Quality"].HeaderText = "จำนวน";
                dataGridStock.Columns["ProductDetail"].HeaderText = "รายละเอียด";
                dataGridStock.Columns["LatestDate"].HeaderText = "อัปเดต";
                dataGridStock.Columns["SuppilersID"].Visible = false;
                dataGridStock.Columns["ProductImg"].Visible = false;
                dataGridStock.Columns["ProductsShelf"].Visible = false;

                // ตรวจสอบว่าไม่มีข้อมูลสินค้า
                if (productdatatable.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่มีข้อมูลสินค้า");
                }
                else
                {
                    byte[] imageBytes = (byte[])productdatatable.Rows[0]["ProductImg"];
                    if (imageBytes != null)
                    {
                        MemoryStream ms = new MemoryStream(imageBytes);
                        pictureBoxProduct.Image = Image.FromStream(ms);
                        pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBoxProduct.Image = null;
                    }
                }

                // ตั้งค่า CurrencyManager สำหรับการจัดการการแสดงข้อมูล
                productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                SetState("view"); // ตั้งสถานะเป็น "view"
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
             // เมื่อฟอร์มปิด
            private void formStock_FormClosing(object sender, FormClosingEventArgs e)
            {
                productsconnection.Close();
                productsconnection.Dispose();
                productcommand.Dispose();
                productadapter.Dispose();
                productdatatable.Dispose();
            }
             // ปุ่มไปยังข้อมูลถัดไป
            private void btn_Next_Click(object sender, EventArgs e)
            {
                productmanager.Position ++;
                ChangeImage();
            }
             // ปุ่มไปยังข้อมูลก่อนหน้า
            private void btn_Previous_Click(object sender, EventArgs e)
            {
                productmanager.Position --;
                ChangeImage();
            }
            // ปุ่มไปยังข้อมูลล่าสุด
            private void btn_Last_Click(object sender, EventArgs e)
            {
                productmanager.Position = productmanager.Count - 1;
                ChangeImage();
            }
            // ปุ่มไปยังข้อมูลแรกสุด
            private void btn_Frist_Click(object sender, EventArgs e)
            {
                productmanager.Position = 0;
                ChangeImage();
            }
            // ฟังก์ชันเปลี่ยนภาพสินค้า
            private void ChangeImage()
            {
                
                if (productmanager.Position >= 0 && productmanager.Position < productdatatable.Rows.Count)
                {   
                    if (productdatatable.Rows[productmanager.Position]["ProductImg"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])productdatatable.Rows[productmanager.Position]["ProductImg"];
                        if (imageBytes != null)
                        {
                            MemoryStream ms = new MemoryStream(imageBytes);
                            pictureBoxProduct.Image = Image.FromStream(ms);
                            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            pictureBoxProduct.Image = null;
                        }
                    }
                    else
                    {
                        pictureBoxProduct.Image = null;
                    }
                }
                else
                {
                    pictureBoxProduct.Image = null;
                }
            }
            private void btn_Save_Click(object sender, EventArgs e)
            {
                try
                {
                    using (SqlConnection productsconnection = new SqlConnection(InitializeUser._key_con))
                    {
                        productsconnection.Open();

                        if (mystate == "update") // ถ้าสถานะเป็นการอัพเดท   
                    {
                            string updateQuery = "UPDATE Products SET ProductName = @ProductName, CostPrice = @CostPrice, Price = @Price, ProductType = @ProductType, ProductsShelf = @ProductsShelf, ProductImg = @ProductImg WHERE ProductID = @ProductID";
                            using (SqlCommand productcommand = new SqlCommand(updateQuery, productsconnection))
                            {
                                productcommand.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                                productcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                                productcommand.Parameters.AddWithValue("@costPrice", Convert.ToDecimal(txtCostPrice.Text));
                                productcommand.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                                productcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                                productcommand.Parameters.AddWithValue("@productsShelf", checkBoxShowonShelf.Checked);
                                byte[] imageBytes = null;

                                // ตรวจสอบและบันทึกรูปภาพ
                                if (!string.IsNullOrEmpty(immage))
                                {
                                    Image image = Image.FromFile(immage);
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        image.Save(ms, image.RawFormat);
                                        imageBytes = ms.ToArray();
                                    }
                                }

                                else
                                {
                                    if (productdatatable.Rows[productmanager.Position]["ProductImg"] != DBNull.Value)
                                    {
                                        imageBytes = (byte[])productdatatable.Rows[productmanager.Position]["ProductImg"];
                                    }
                                }
                                productcommand.Parameters.AddWithValue("@ProductImg", imageBytes == null ? DBNull.Value : (object)imageBytes);
                                productcommand.ExecuteNonQuery(); 
                            }
                            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (mystate == "insert") // ถ้าสถานะเป็นการเพิ่ม
                    {
                            string insertQuery = "INSERT INTO Products(ProductName, CostPrice, Price, Quality, ProductType, ProductsShelf, LatestDate, SuppilersID, ProductImg, ProductDetail) " +
                                "VALUES(@productName, @costPrice, @price, @quality, @productType, @productsShelf, @latestDate, @suppilersID, @productImg, @productDetail)";

                            productcommand = new SqlCommand(insertQuery, productsconnection);
                            productcommand.Parameters.AddWithValue("@productName", txtproductName.Text);
                            productcommand.Parameters.AddWithValue("@costPrice", Convert.ToDecimal(txtCostPrice.Text)); 
                            productcommand.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text)); 
                            productcommand.Parameters.AddWithValue("@quality", Convert.ToInt32(txtAmountremain.Text)); 
                            productcommand.Parameters.AddWithValue("@productType", txtProductType.Text);
                            productcommand.Parameters.AddWithValue("@productsShelf", checkBoxShowonShelf.Checked ? "True" : "False");
                            productcommand.Parameters.AddWithValue("@latestDate", DateTime.Now);
                            productcommand.Parameters.AddWithValue("@suppilersID", Convert.ToInt32(txtSuppilersID.Text));
                            productcommand.Parameters.AddWithValue("@productDetail", txtDetails.Text);
                            byte[] imageBytes = null;
                            
                            // ตรวจสอบและบันทึกรูปภาพ
                            if (!string.IsNullOrEmpty(immage) && File.Exists(immage)) 
                            {
                                Image image = Image.FromFile(immage);
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    image.Save(ms, image.RawFormat);
                                    imageBytes = ms.ToArray();
                                }
                            }
                            else
                            {
                                MessageBox.Show("กรุณาเลือกรูปภาพ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            productcommand.Parameters.AddWithValue("@productImg", imageBytes == null ? DBNull.Value : (object)imageBytes);
                            productcommand.ExecuteNonQuery();
                            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        SetState("view");

                        // อัปเดตข้อมูลใน DataTable
                        using (SqlCommand productcommand = new SqlCommand("SELECT * FROM Products", productsconnection))
                        using (SqlDataAdapter productadapter = new SqlDataAdapter(productcommand))
                        {
                            productdatatable.Clear();
                            productadapter.Fill(productdatatable);
                        }
                        ChangeImage();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // ฟังก์ชันจัดการสถานะการแสดงผลของฟอร์ม
            private void SetState(string AddState)
                {
                    mystate = AddState; // กำหนดสถานะการทำงาน
                    switch (AddState)
                    {
                        // สถานะการแสดงผลข้อมูล (view)
                        case "view":
                        txtProductID.BackColor = Color.White;
                        txtAmountremain.BackColor = Color.White;
                            txtCostPrice.BackColor = Color.White;   
                            txtleastUpdate.BackColor = Color.White;
                            txtPrice.BackColor = Color.White;
                            btn_Add.Enabled = true;
                            btn_Add.BackColor = Color.White;
                            btn_Close.Enabled = true;
                            btn_Close.BackColor = Color.White;
                            btn_Update.Enabled = true;
                            btn_Update.BackColor = Color.White;
                            btn_delete.Enabled = true;
                            btn_delete.BackColor = Color.White;
                            btn_Save.Enabled = false;
                            btn_Save.BackColor = Color.Gray;
                            btn_Cancle.Enabled = false;
                            btn_Cancle.BackColor = Color.Gray;
                            button_browse.Enabled = false;
                            button_browse.BackColor = Color.Gray;
                            txtproductName.BackColor = Color.White;
                            txtProductType.BackColor = Color.White;
                            txtAmountremain.ReadOnly = true;
                            txtCostPrice.ReadOnly = true;
                            txtleastUpdate.ReadOnly = true;
                            txtPrice.ReadOnly = true;
                            txtproductName.ReadOnly = true;
                            txtProductType.ReadOnly = true;
                            // ดึงข้อมูลสินค้าจากฐานข้อมูลและอัปเดต
                            productcommand = new SqlCommand("SELECT * FROM Products", productsconnection);
                            productadapter = new SqlDataAdapter(productcommand);
                            productdatatable.Clear(); // เคลียร์ข้อมูลเดิมใน DataTable
                            productadapter.Fill(productdatatable);
                        break;
                        case "update": // สถานะการอัปเดตข้อมูล (update)
                            txtProductID.BackColor = Color.Red;
                            txtAmountremain.BackColor = Color.Orange;
                            txtCostPrice.BackColor = Color.Orange;
                            txtleastUpdate.BackColor = Color.Orange;
                            txtPrice.BackColor = Color.Orange;
                            txtproductName.BackColor = Color.Orange;
                            txtProductType.BackColor = Color.Orange;
                            txtProductID.ReadOnly = true;
                            txtAmountremain.ReadOnly = false;
                            txtCostPrice.ReadOnly = false;
                            txtleastUpdate.ReadOnly = false;
                            txtPrice.ReadOnly = false;
                            txtproductName.ReadOnly = false;
                            txtProductType.ReadOnly = false;
                            btn_Add.Enabled = false;
                            btn_Add.BackColor = Color.Gray;
                            btn_Close.Enabled = false;
                            btn_Close.BackColor = Color.Gray;
                            btn_Update.Enabled = false;
                            btn_Update.BackColor = Color.Gray;
                            btn_delete.Enabled = false;
                            btn_delete.BackColor = Color.Gray;
                            btn_Save.Enabled = true;
                            btn_Save.BackColor = Color.White;
                            btn_Cancle.Enabled = true;
                            btn_Cancle.BackColor = Color.White;
                            button_browse.Enabled = true;
                            button_browse.BackColor = Color.White;
                        break;
                        default: // สถานะการเพิ่มข้อมูลใหม่ (insert)
                            txtProductID.ReadOnly = false;
                            txtProductID.BackColor = Color.Green;
                            txtAmountremain.BackColor = Color.Green;
                            txtCostPrice.BackColor = Color.Green;
                            txtleastUpdate.BackColor = Color.Green;
                            txtPrice.BackColor = Color.Green;
                            txtproductName.BackColor = Color.Green;
                            txtProductType.BackColor = Color.Green;
                            txtAmountremain.Clear();
                            txtProductID.Clear();
                            txtCostPrice.Clear();
                            txtleastUpdate.Clear();
                            txtPrice.Clear();
                            txtproductName.Clear();
                            txtProductType.Clear();
                            txtAmountremain.ReadOnly = false;
                            txtCostPrice.ReadOnly = false;
                            txtleastUpdate.ReadOnly = false;
                            txtPrice.ReadOnly = false;
                            txtproductName.ReadOnly = false;
                            txtProductType.ReadOnly = false;
                            btn_Add.Enabled = false;
                            btn_Add.BackColor = Color.Gray;
                            btn_Close.Enabled = false;
                            btn_Close.BackColor = Color.Gray;
                            btn_Update.Enabled = false;
                            btn_Update.BackColor = Color.Gray;
                            btn_delete.Enabled = false;
                            btn_delete.BackColor = Color.Gray;
                            btn_Save.Enabled = true;
                            btn_Save.BackColor = Color.White;
                            btn_Cancle.Enabled = true;
                            btn_Cancle.BackColor = Color.White;
                            button_browse.Enabled = true;
                            button_browse.BackColor = Color.White;      
                        break;
                    }
                }
            private void btn_Update_Click(object sender, EventArgs e)
            {
                SetState("update"); // เปลี่ยนสถานะเป็น "update"
            }

            private void btn_Add_Click(object sender, EventArgs e)
            {      
                SetState("insert"); // เปลี่ยนสถานะเป็น "insert"
            }

            // ฟังก์ชันสำหรับยกเลิกการแก้ไขและคืนสถานะเป็น "view"
            private void btn_Cancle_Click(object sender, EventArgs e)
            {
                productmanager.CancelCurrentEdit(); // ยกเลิกการแก้ไข
                if (mystate.Equals("insert")) 
                {
                    productmanager.Position = Productmark; // คืนตำแหน่งเดิมในกรณีที่เป็นการเพิ่มข้อมูล
                }
                SetState("view");
            }
            // ฟังก์ชันสำหรับเลือกไฟล์รูปภาพ
            private void button_browse_Click(object sender, EventArgs e)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    immage = ofd.FileName.ToString();
                    pictureBoxProduct.ImageLocation = immage;
                }
            }
            
            // ฟังก์ชันสำหรับลบข้อมูลสินค้า
            private void btn_delete_Click(object sender, EventArgs e) 
            {
                try
                {   // ตรวจสอบว่ามีการเลือกสินค้าเพื่อจะลบหรือไม่
                    if (string.IsNullOrEmpty(txtProductID.Text))
                    {
                        MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการลบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("คุณต้องการลบสินค้านี้หรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) // ยืนยันการลบข้อมูลสินค้า
                    {
                        using (SqlConnection productsconnection = new SqlConnection(InitializeUser._key_con))
                        {
                            productsconnection.Open();
                            string deleteQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                            using (SqlCommand productcommand = new SqlCommand(deleteQuery, productsconnection))
                            {
                                productcommand.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                                int rowsAffected = productcommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("ลบข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    pictureBoxProduct.Image = null;
                                    productdatatable.Clear();
                                    productadapter.Fill(productdatatable);
                                    ChangeImage(); // เปลี่ยนภาพ
                                }
                                else
                                {
                                    MessageBox.Show("ไม่พบสินค้าที่ต้องการลบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
            private void btn_Close_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
        }
