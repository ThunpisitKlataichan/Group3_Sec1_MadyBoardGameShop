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
                productcommand = new SqlCommand();
                productadapter = new SqlDataAdapter();
                productdatatable = new DataTable();
                
                productsconnection.Open();

                string query = "SELECT * FROM Products";

                productcommand = new SqlCommand(query, productsconnection);
                productadapter = new SqlDataAdapter();
                productadapter.SelectCommand = productcommand;

                productdatatable = new DataTable();
                productadapter.Fill(productdatatable);

                txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality"); //5
                txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                txtSuppilersID.DataBindings.Add("Text", productdatatable, "SuppilersID");
                txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
                checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");//10
                if (productdatatable.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่มีข้อมูลสินค้า");
                }
                else
                {
                    byte[] imageBytes = (byte[])productdatatable.Rows[0]["ProductImg"]; //1
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

                productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                SetState("view");
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            ChangeImage();
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            productmanager.Position --;
            ChangeImage();
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            productmanager.Position = productmanager.Count - 1;
            ChangeImage();
        }

        private void btn_Frist_Click(object sender, EventArgs e)
        {
            productmanager.Position = 0;
            ChangeImage();
        }

        private void pictureBoxProduct_Click(object sender, EventArgs e)
        {

        }
        private void ChangeImage()
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
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (mystate == "update") 
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
                    string insertQuery = "INSERT INTO Products(ProductName, CostPrice , Price , Quality , ProductType , ProductsShelf , LatestDate , SuppilersID , ProductImg , ProductDetail) " +
                        "VALUES(@productName , @costPrice , @price , @quality , @productType , @productsShelf , @latestDate , @suppilersID , @productImg , @productDetail)";
                    productcommand = new SqlCommand(insertQuery, productsconnection);

                    // กำหนดค่า parameters
                    //productcommand.Parameters.AddWithValue("@productID", txtProductID.Text);
                    productcommand.Parameters.AddWithValue("@productName", txtproductName.Text);
                    productcommand.Parameters.AddWithValue("@costPrice", txtCostPrice.Text);
                    productcommand.Parameters.AddWithValue("@price", txtPrice.Text);
                    productcommand.Parameters.AddWithValue("@quality", txtAmountremain.Text); //5
                    productcommand.Parameters.AddWithValue("@productType", txtProductType.Text);
                    productcommand.Parameters.AddWithValue("@productsShelf", checkBoxShowonShelf.Checked);
                    productcommand.Parameters.AddWithValue("@latestDate", DateTime.Now);
                    productcommand.Parameters.AddWithValue("@suppilersID", txtSuppilersID.Text);
                    productcommand.Parameters.AddWithValue("@productDetail", txtDetails.Text);
                    
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
                    else
                    {
                        MessageBox.Show("กรุณาเลือกรูปภาพ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    productcommand.Parameters.AddWithValue("@productImg", imageBytes == null ? DBNull.Value : (object)imageBytes); //11
                    productcommand.ExecuteNonQuery();
                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                SetState("view");
                productcommand = new SqlCommand("SELECT * FROM Products", productsconnection);
                productadapter = new SqlDataAdapter(productcommand);
                productadapter.Fill(productdatatable);
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
