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
        public partial class formProduct : Form
        {
            public formProduct()
            {
                InitializeComponent();
                InitializeUser.Confic();
            }
            SqlConnection productsconnection;
            SqlCommand productcommand;
            SqlDataAdapter productadapter;
            DataTable productdatatable;
            CurrencyManager productmanager;
            string immage = "";
            int Productmark;
            string mystate = "";

            private void formStock_Load(object sender, EventArgs e)
            {
            try
            {
                productsconnection = new SqlConnection(InitializeUser._key_con);
                productsconnection.Open();
                string query = "SELECT * FROM Products";

                productcommand = new SqlCommand(query, productsconnection);
                productadapter = new SqlDataAdapter(productcommand);
                productdatatable = new DataTable();
                productadapter.Fill(productdatatable);

            if (productdatatable.Rows.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลสินค้าในฐานข้อมูล", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                // Bind ข้อมูลให้กับ Controls
                txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                // ผูกข้อมูลกับ checkbox และจัดการการแปลงค่า
                checkBoxShowonShelf.DataBindings.Add(new Binding("Checked", productdatatable, "ProductsShelf", true, DataSourceUpdateMode.Never, false));

                // เพิ่ม EventHandler สำหรับจัดการการแปลงค่าระหว่างฐานข้อมูลและ Checkbox
                checkBoxShowonShelf.DataBindings[0].Format += (s, ev) =>
                {
                    // ตรวจสอบว่าค่าเป็น DBNull หรือไม่
                    if (ev.Value == DBNull.Value)
                    {
                        ev.Value = false; // หากค่าเป็น NULL ให้ตั้งค่าเป็น false
                    }
                    else
                    {
                        try
                        {
                            // พยายามแปลงค่าให้เป็น Boolean
                            if (ev.Value is bool)
                            {
                                // ถ้าเป็น Boolean อยู่แล้ว ไม่ต้องทำอะไรเพิ่มเติม
                                return;
                            }
                            else if (ev.Value is int)
                            {
                                // หากค่าเป็นตัวเลข (0 หรือ 1) ให้แปลงเป็น Boolean
                                ev.Value = Convert.ToBoolean(ev.Value);
                            }
                            else
                            {
                                // หากค่าเป็นสตริง ให้ตรวจสอบและแปลงเป็น Boolean
                                string stringValue = ev.Value.ToString().ToLower(); // แปลงเป็นตัวพิมพ์เล็กเพื่อเปรียบเทียบง่ายขึ้น
                                if (stringValue == "true" || stringValue == "yes" || stringValue == "1")
                                {
                                    ev.Value = true;
                                }
                                else if (stringValue == "false" || stringValue == "no" || stringValue == "0")
                                {
                                    ev.Value = false;
                                }
                                else
                                {
                                    // กรณีที่ค่าผิดปกติ ให้ตั้งค่าเริ่มต้นเป็น false และแจ้งเตือนใน Console (สำหรับ Debugging)
                                    ev.Value = false;
                                    Console.WriteLine($"พบค่าที่ไม่คาดคิดใน ProductsShelf: {ev.Value}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // จัดการข้อผิดพลาดหากเกิดขึ้นระหว่างการแปลงค่า
                            Console.WriteLine($"เกิดข้อผิดพลาดในการแปลงค่า: {ex.Message}");
                            ev.Value = false; // ตั้งค่าเริ่มต้นเป็น false ในกรณีเกิดข้อผิดพลาด
                        }
                    }
                };

                Binding imgBinding = new Binding("Image", productdatatable, "ProductImg", true); // ผูกข้อมูลรูปภาพ
                imgBinding.Format += new ConvertEventHandler(ImageBinding_Format); // กำหนดเหตุการณ์เมื่อมีการแปลงค่า
                pictureBoxProduct.DataBindings.Add(imgBinding);
                
                txtAmountremain.DataBindings.Add("Text", productdatatable, "StockQuality");

                txtleastUpdate.DataBindings.Add(new Binding("Text", productdatatable, "StockDate", true, DataSourceUpdateMode.Never, ""));
                txtleastUpdate.DataBindings[0].Format += (s, ev) =>
                {
                    if (ev.Value == DBNull.Value)
                    {
                        ev.Value = ""; // หรือข้อความอื่น ๆ เช่น "ไม่ระบุ"
                    }
                    else
                    {
                        ev.Value = Convert.ToDateTime(ev.Value).ToString("dd/MM/yyyy"); // จัดรูปแบบวันที่
                    }
                };

                    // ตรวจสอบ BindingContext
                    if (this.BindingContext.Contains(productdatatable))
                    {
                        productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                    }
                    else
                    {
                        MessageBox.Show("BindingContext ยังไม่ได้ถูกกำหนด", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        productmanager = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("โหลดฟอร์มไม่สำเร็จ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    productsconnection.Close();
                }

                SetState("view");
            }

            private void formStock_FormClosing(object sender, FormClosingEventArgs e)
            {
                productsconnection.Close();
                productsconnection.Dispose();
                productcommand.Dispose();
                productadapter.Dispose();
                productdatatable.Dispose();
            }

            private void btn_Next_Click(object sender, EventArgs e)
            {
                    productmanager.Position ++;
            }

            private void btn_Previous_Click(object sender, EventArgs e)
            {
                productmanager.Position --;
            }

            private void btn_Last_Click(object sender, EventArgs e)
            {
                productmanager.Position = productmanager.Count - 1;
            }

            private void btn_Frist_Click(object sender, EventArgs e)
            {
                productmanager.Position = 0;
            }

            private void pictureBoxProduct_Click(object sender, EventArgs e)
            {

            }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (mystate == "update") // <-จัดการกับฐานข้อมูล
                {
                    // สร้าง query สำหรับ update ข้อมูล
                    string updateQuery = "UPDATE Products SET ProductName = @ProductName, CostPrice = @CostPrice, Price = @Price, ProductType = @ProductType, ProductsShelf = @ProductsShelf, ProductImg = @ProductImg WHERE ProductID = @ProductID";

                    productcommand = new SqlCommand(updateQuery, productsconnection);
                    productcommand.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    productcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                    productcommand.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                    productcommand.Parameters.AddWithValue("@Price", txtPrice.Text);
                    productcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                    productcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked);

                    // จัดการรูปภาพ
                    byte[] imageBytes = null;
                    if (!string.IsNullOrEmpty(immage))
                    {
                        Image image = Image.FromFile(immage);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, image.RawFormat);
                            imageBytes = ms.ToArray();
                        }
                    }
                    productcommand.Parameters.AddWithValue("@ProductImg", imageBytes == null ? DBNull.Value : (object)imageBytes);

                    productsconnection.Open();
                    productcommand.ExecuteNonQuery(); // execute query
                    productsconnection.Close();

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (mystate == "insert")
                {
                    string insertQuery = "INSERT INTO Products (ProductName, CostPrice, Price, ProductType, ProductsShelf, ProductImg,SuppilersID) " +
                                "VALUES (@ProductName, @CostPrice, @Price, @ProductType, @ProductsShelf, @ProductImg,1);" +
                                "INSERT INTO Stock (ProductID, StockDate, StockQuality) " +
                                "VALUES ((SELECT ProductID FROM Products WHERE ProductName = @ProductName), @StockDate, @StockQuality)";

                    productcommand = new SqlCommand(insertQuery, productsconnection);

                    // กำหนดค่า parameters
                    productcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                    productcommand.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                    productcommand.Parameters.AddWithValue("@Price", txtPrice.Text);
                    productcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                    productcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked);

                    // จัดการรูปภาพ
                    byte[] imageBytes = null;
                    if (!string.IsNullOrEmpty(immage))
                    {
                        Image image = Image.FromFile(immage);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, image.RawFormat);
                            imageBytes = ms.ToArray();
                        }
                    }
                    productcommand.Parameters.AddWithValue("@ProductImg", imageBytes == null ? DBNull.Value : (object)imageBytes);

                    // กำหนดค่า parameters สำหรับ Stock table
                    productcommand.Parameters.AddWithValue("@StockDate", DateTime.Now); // หรือ txtleastUpdate.Text หากต้องการให้ผู้ใช้กำหนด
                    productcommand.Parameters.AddWithValue("@StockQuality", txtAmountremain.Text); // ปริมาณคงเหลือ

                    productsconnection.Open();
                    productcommand.ExecuteNonQuery(); // execute query

                    productsconnection.Close();

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                SetState("view");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                productsconnection.Close();
            }
        }

        private void SetState(string AddState)
            {
                mystate = AddState;
                switch (AddState)
                {
                    case "view":
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

                        txtproductName.BackColor = Color.White;
                        txtProductType.BackColor = Color.White;
                        txtAmountremain.ReadOnly = true;
                        txtCostPrice.ReadOnly = true;
                        txtleastUpdate.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        txtproductName.ReadOnly = true;
                        txtProductType.ReadOnly = true;

                        break;
                    case "update":
                        txtAmountremain.BackColor = Color.Orange;
                        txtCostPrice.BackColor = Color.Orange;
                        txtleastUpdate.BackColor = Color.Orange;
                        txtPrice.BackColor = Color.Orange;
                        txtproductName.BackColor = Color.Orange;
                        txtProductType.BackColor = Color.Orange;
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

                        break;
                    default:
                        txtProductID.BackColor = Color.Green;
                        txtAmountremain.BackColor = Color.Green;
                        txtCostPrice.BackColor = Color.Green;
                        txtleastUpdate.BackColor = Color.Green  ;
                        txtPrice.BackColor = Color.Green;
                        txtproductName.BackColor = Color.Green;
                        txtProductType.BackColor = Color.Green;
                        txtAmountremain.Clear();
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
                        break;
                }
            
            }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SetState("update");
            
            
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
            SetState("insert");
            
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            productmanager.CancelCurrentEdit();
            if (mystate.Equals("insert"))
            {
                productmanager.Position = Productmark;
            }
            SetState("view");
        }

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
        private Image ByteArrayToImage(byte[] byteArray) // แปลงข้อมูลรูปภาพจาก byte[] เป็น Image
        {
            if (byteArray == null)
            {
                // จัดการกรณีที่ byteArray เป็น null
                // อาจจะ return รูปเริ่มต้น หรือ throw exception
                return new Bitmap(1, 1); // สร้างรูปว่างเปล่า (หรือโหลดรูปเริ่มต้น)
            }
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private void ImageBinding_Format(object sender, ConvertEventArgs e) // แปลงข้อมูลรูปภาพจาก byte[] เป็น Image
        {

            if (e.Value == DBNull.Value)
            {
                e.Value = immage; // ใช้รูปเปล่าขนาด 1x1 pixel
            }
            else
            {
                e.Value = ByteArrayToImage((byte[])e.Value);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult response;
            response = MessageBox.Show("คุณแน่ใจมั้ยว่าจะลบข้อมูลนี้" , "ลบ",MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (response == DialogResult.Yes)
            {
                return;
            }
            try
            {
                productmanager.RemoveAt(productmanager.Position);
            }
            catch(Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดข้อมูลในการลบ","ข้อผิดพลาด",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
