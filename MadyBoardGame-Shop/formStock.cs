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
            SqlConnection stockconnection;
            SqlCommand stockcommand;
            SqlDataAdapter stockadapter;
            DataTable stockdatatable;
            CurrencyManager stockmanager;
            string immage = "";
            int Productmark;
            string mystate = "";

            private void formStock_Load(object sender, EventArgs e)
            {
                try
                {
                // โหลดข้อมูลจากฐานข้อมูล
                stockconnection = new SqlConnection(InitializeUser._key_con);
                stockconnection.Open();

                string query = "SELECT p.ProductID, p.ProductName, p.CostPrice, p.Price, p.ProductType, p.ProductsShelf, " +
                               "s.StockDate, s.StockQuality, p.ProductImg FROM Products AS p " +
                               "JOIN Stock AS s ON p.ProductID = s.ProductID";

                stockcommand = new SqlCommand(query, stockconnection);
                stockadapter = new SqlDataAdapter(stockcommand);
                stockdatatable = new DataTable();
                stockadapter.Fill(stockdatatable);
                if (checkBoxShowonShelf.Checked == true)
                {
                        dataGridStock.DataSource = stockdatatable;
                        Dictionary<string, string> columnMappings = new Dictionary<string, string>
                        {
                            { "ProductName", "ชื่อสินค้า" },
                            { "ProductsShelf", "วางบนชั้น" },
                            { "Price", "ราคา" },
                            {"CostPrice","ต้นทุน" },
                            {"ProductType","ประเภทสินค้า"},
                            {"StockQuality","จำนวนสินค้า"},
                            {"StockDate","อัพเดท"},
                            {"ProductImg","รูปสินค้า" },
                            {"ProductID","รหัสสินค้า" }
                        };

                        // วนลูปเปลี่ยนชื่อคอลัมน์
                        foreach (DataGridViewColumn column in dataGridStock.Columns)
                        {
                            if (columnMappings.ContainsKey(column.Name))
                            {
                                column.HeaderText = columnMappings[column.Name];
                            }
                        }
                    
                }


                // เคลียร์ DataBindings ก่อนเพิ่มใหม่เพื่อป้องกันข้อผิดพลาด
                txtProductID.DataBindings.Clear();
                txtproductName.DataBindings.Clear();
                txtCostPrice.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtProductType.DataBindings.Clear();
                txtAmountremain.DataBindings.Clear();
                txtleastUpdate.DataBindings.Clear();
                checkBoxShowonShelf.DataBindings.Clear();
                pictureBoxProduct.DataBindings.Clear();

                // Bind ข้อมูลให้กับ Controls
                txtProductID.DataBindings.Add("Text", stockdatatable, "ProductID");
                txtproductName.DataBindings.Add("Text", stockdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", stockdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", stockdatatable, "Price");
                txtProductType.DataBindings.Add("Text", stockdatatable, "ProductType");

                // ผูกข้อมูลกับ checkbox และตรวจสอบค่า null
                checkBoxShowonShelf.DataBindings.Add(new Binding("Checked", stockdatatable, "ProductsShelf", true, DataSourceUpdateMode.Never, false));
                checkBoxShowonShelf.DataBindings[0].Format += (s, ev) =>
                {
                    if (ev.Value == DBNull.Value)
                    {
                        ev.Value = false;
                    }
                    else
                    {
                        bool result;
                        ev.Value = bool.TryParse(ev.Value.ToString(), out result) ? result : false;
                    }
                };

                // Binding รูปภาพ
                Binding imgBinding = new Binding("Image", stockdatatable, "ProductImg", true);
                imgBinding.Format += ImageBinding_Format;
                pictureBoxProduct.DataBindings.Add(imgBinding);

                txtAmountremain.DataBindings.Add("Text", stockdatatable, "StockQuality");

                txtleastUpdate.DataBindings.Add(new Binding("Text", stockdatatable, "StockDate", true, DataSourceUpdateMode.Never, ""));
                txtleastUpdate.DataBindings[0].Format += (s, ev) =>
                {
                    ev.Value = ev.Value == DBNull.Value ? "" : Convert.ToDateTime(ev.Value).ToString("dd/MM/yyyy");
                };
                
                stockmanager = (CurrencyManager)this.BindingContext[stockdatatable];
                stockconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("โหลดฟอร์มไม่สำเร็จ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            SetState("view");
        }
            

            private void formStock_FormClosing(object sender, FormClosingEventArgs e)
            {
                stockconnection.Close();
                stockconnection.Dispose();
                stockcommand.Dispose();
                stockadapter.Dispose();
                stockdatatable.Dispose();
                if(mystate.Equals("update") || mystate.Equals("add"))  
                {
                    MessageBox.Show("คุณแน่ใจหรอว่าต้องการปิดโปรแกรม", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                 
                }
                else
                {
                     try 
                     {
                        SqlCommandBuilder StockAdaptorCommands = new SqlCommandBuilder(stockadapter);
                        stockadapter.Update(stockdatatable);
                     }
                     catch(Exception ex)
                     {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกฐานข้อมูล\r\n"+ex.Message, "เกิดข้อผิดพลาดในการบันทึก" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                     }
                    
                
                }
            }

            private void btn_Next_Click(object sender, EventArgs e)
            {
                stockmanager.Position ++;
            }

            private void btn_Previous_Click(object sender, EventArgs e)
            {
                stockmanager.Position --;
            }

            private void btn_Last_Click(object sender, EventArgs e)
            {
                stockmanager.Position = stockmanager.Count - 1;
            }

            private void btn_Frist_Click(object sender, EventArgs e)
            {
                stockmanager.Position = 0;
            }

            private void pictureBoxProduct_Click(object sender, EventArgs e)
            {

            }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (mystate == "update")
                {
                    stockconnection.Open();
                    string updateQuery = "UPDATE Products SET ProductName = @ProductName, CostPrice = @CostPrice, Price = @Price, " +
                                         "ProductType = @ProductType, ProductsShelf = @ProductsShelf, ProductImg = @ProductImg " +
                                         "WHERE ProductID = @ProductID";
                    stockcommand = new SqlCommand(updateQuery, stockconnection);
                    stockcommand.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    stockcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);

                    // แปลงค่าเป็นตัวเลข (decimal) ก่อนบันทึก
                    if (decimal.TryParse(txtCostPrice.Text, out decimal costPrice))
                        stockcommand.Parameters.AddWithValue("@CostPrice", costPrice);
                    else
                        throw new FormatException("CostPrice ไม่ใช่ตัวเลขที่ถูกต้อง");

                    if (decimal.TryParse(txtPrice.Text, out decimal price))
                        stockcommand.Parameters.AddWithValue("@Price", price);
                    else
                        throw new FormatException("Price ไม่ใช่ตัวเลขที่ถูกต้อง");

                    stockcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                    stockcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked);

                    // แปลงรูปภาพเป็น byte[] ก่อนบันทึก
                    byte[] imageBytes = null;
                    if (!string.IsNullOrEmpty(immage))
                    {
                        using (FileStream fs = new FileStream(immage, FileMode.Open, FileAccess.Read))
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                imageBytes = br.ReadBytes((int)fs.Length);
                            }
                        }
                    }
                    if (imageBytes == null)
                    {
                        imageBytes= new byte[0];
                    }
                    stockcommand.Parameters.Add("@ProductImg", SqlDbType.VarBinary).Value = (object)imageBytes ?? DBNull.Value;

                    stockcommand.ExecuteNonQuery();
                    MessageBox.Show("อัปเดตข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formStock_Load(null, null);
                    stockmanager.Position = stockmanager.Count - 1; // ไปที่รายการล่าสุด
                    SetState("view");
                    stockconnection.Close();
                }

                else if (mystate == "insert")
                {
                    stockconnection.Open();
                    string insertQuery = "INSERT INTO Products (ProductName, CostPrice, Price, ProductType, ProductsShelf, ProductImg,SuppilersID) " +
                                "VALUES (@ProductName, @CostPrice, @Price, @ProductType, @ProductsShelf, @ProductImg,1);" +
                                "INSERT INTO Stock (ProductID, StockDate, StockQuality) " +
                                "VALUES ((SELECT ProductID FROM Products WHERE ProductName = @ProductName), @StockDate, @StockQuality)";

                    stockcommand = new SqlCommand(insertQuery, stockconnection);

                    // กำหนดค่า parameters
                    stockcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                    stockcommand.Parameters.AddWithValue("@CostPrice", txtCostPrice.Text);
                    stockcommand.Parameters.AddWithValue("@Price", txtPrice.Text);
                    stockcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                    stockcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked);

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
                    stockcommand.Parameters.AddWithValue("@ProductImg", imageBytes == null ? DBNull.Value : (object)imageBytes);

                    // กำหนดค่า parameters สำหรับ Stock table
                    stockcommand.Parameters.AddWithValue("@StockDate", DateTime.Now); // หรือ txtleastUpdate.Text หากต้องการให้ผู้ใช้กำหนด
                    stockcommand.Parameters.AddWithValue("@StockQuality", txtAmountremain.Text); // ปริมาณคงเหลือ

                    
                    stockcommand.ExecuteNonQuery(); // execute query

                    

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                formStock_Load(null, null);
                stockmanager.Position = stockmanager.Count - 1; // ไปที่รายการล่าสุด
                
                stockconnection.Close();
                SetState("view");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        txtProductID.BackColor = Color.White;
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
                        btn_browse.Enabled = false;
                        btn_browse.BackColor = Color.Gray;

                        txtproductName.BackColor = Color.White;
                        txtProductType.BackColor = Color.White;
                        txtAmountremain.ReadOnly = true;
                        txtCostPrice.ReadOnly = true;
                        txtleastUpdate.ReadOnly = true;
                        txtPrice.ReadOnly = true;
                        txtproductName.ReadOnly = true;
                        txtProductType.ReadOnly = true;
                        txtProductID.ReadOnly = true;

                        break;
                    case "update":
                         stockconnection.Close();
                        txtAmountremain.BackColor = Color.Orange;
                        txtCostPrice.BackColor = Color.Orange;
                        txtleastUpdate.BackColor = Color.Orange;
                        txtPrice.BackColor = Color.Orange;
                        txtproductName.BackColor = Color.Orange;
                        txtProductType.BackColor = Color.Orange;
                        txtProductID.BackColor = Color.Red;
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
                        btn_browse.Enabled = true;
                        btn_browse.BackColor = Color.White;

                    break;
                    default:
                        stockconnection.Close();
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
                        txtProductID.Clear();
                        pictureBoxProduct.InitialImage = null;
                        txtProductID.ReadOnly = false;
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
                        btn_browse.Enabled = true;
                        btn_browse.BackColor = Color.White;
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
            stockmanager.CancelCurrentEdit();
            if (mystate.Equals("insert"))
            {
                stockmanager.Position = Productmark;
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
            DialogResult response = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูลนี้?", "ลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No)
                return;

            try
            {
                stockconnection.Open();
                string deleteQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                stockcommand = new SqlCommand(deleteQuery, stockconnection);
                stockcommand.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                stockcommand.ExecuteNonQuery();

                MessageBox.Show("ลบข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // รีโหลดข้อมูลใหม่
                formStock_Load(null, null);
                stockmanager.Position = stockmanager.Count - 1;
                stockconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxShowonShelf_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxShowonShelf_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowonShelf.Checked)
            {
                dataGridStock.Enabled = true;
                // เรียกใช้ฟังก์ชันการโหลดข้อมูลเมื่อเช็คบ็อกซ์ถูกเลือก
                formStock_Load(null, null);
            }
            else
            {
                dataGridStock.Enabled = false;
                // เคลียร์ข้อมูลหรือแสดงข้อมูลแบบอื่นตามความต้องการ
                dataGridStock.DataSource = null;

            }
        }
    }
    }
