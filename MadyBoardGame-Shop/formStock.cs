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
        private Color headerColor = Color.FromArgb(34, 34, 59);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);
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
                    string query = "SELECT p.ProductID, p.ProductName, p.ProductType,p.CostPrice, p.Price, p.Quality, p.ProductDetail, p.LatestDate, p.ProductImg, p.ProductsShelf, s.SuppilerID, s.SuppilerName FROM Products p JOIN Suppilers s ON p.SuppilersID = s.SuppilerID;";
                    productcommand = new SqlCommand(query, productsconnection);
                    productadapter.SelectCommand = productcommand;
                    productadapter.Fill(productdatatable);
                    DataTable supplierTable = new DataTable();
                    string supplierQuery = "SELECT SuppilerID, SuppilerName FROM Suppilers";
                    SqlCommand supplierCmd = new SqlCommand(supplierQuery, productsconnection);
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierCmd);
                    supplierAdapter.Fill(supplierTable);

                    // ตั้งค่า ComboBox
                    cbb_Suppiler.DataSource = supplierTable;
                    cbb_Suppiler.DisplayMember = "SuppilerName";
                    cbb_Suppiler.ValueMember = "SuppilerID";

                //
                txtProductID.DataBindings.Clear();
                txtproductName.DataBindings.Clear();
                txtCostPrice.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtAmountremain.DataBindings.Clear();
                txtProductType.DataBindings.Clear();
                txtleastUpdate.DataBindings.Clear();
                txtDetails.DataBindings.Clear();
                checkBoxShowonShelf.DataBindings.Clear();
                cbb_Suppiler.DataBindings.Clear();

                // Binding SelectedValue
                if (productdatatable.Rows.Count > 0)
                    {
                        cbb_Suppiler.DataBindings.Add("SelectedValue", productdatatable, "SuppilerID");
                    }

                    // ผูกข้อมูลกับตัวควบคุมในฟอร์ม
                    txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                    txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                    txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                    txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                    txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
                    txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                    txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                    txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
                    checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");
                cbb_Suppiler.DataBindings.Add("Text", productdatatable, "SuppilerName");

                // แก้ไขการเข้าถึง Columns
                dataGridStock.DataSource = productdatatable;
                    if (dataGridStock.Columns.Contains("ProductName"))
                    {
                        dataGridStock.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                    }
                    if (dataGridStock.Columns.Contains("ProductType"))
                    {
                        dataGridStock.Columns["ProductType"].HeaderText = "ชนิดสินค้า";
                    }
                    if (dataGridStock.Columns.Contains("CostPrice"))
                    {
                        dataGridStock.Columns["CostPrice"].HeaderText = "ต้นทุน";
                    }
                    if (dataGridStock.Columns.Contains("Price"))
                    {
                        dataGridStock.Columns["Price"].HeaderText = "ราคา";
                    }
                    if (dataGridStock.Columns.Contains("Quality"))
                    {
                        dataGridStock.Columns["Quality"].HeaderText = "จำนวน";
                    }
                    if (dataGridStock.Columns.Contains("ProductDetail"))
                    {
                        dataGridStock.Columns["ProductDetail"].HeaderText = "รายละเอียด";
                    }
                    if (dataGridStock.Columns.Contains("LatestDate"))
                    {
                        dataGridStock.Columns["LatestDate"].HeaderText = "อัปเดต";
                    }
                    if (dataGridStock.Columns.Contains("SuppilersID"))
                    {
                        dataGridStock.Columns["SuppilersID"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("SuppilerID"))
                    {
                        dataGridStock.Columns["SuppilerID"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("ProductImg"))
                    {
                        dataGridStock.Columns["ProductImg"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("ProductsShelf"))
                    {
                        dataGridStock.Columns["ProductsShelf"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("SuppilerName"))
                    {
                        dataGridStock.Columns["SuppilerName"].Visible = false;
                    }

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
                    // ตั้งค่า CurrencyManager
                    productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                    SetState("view");
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            dataGridStock.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["ProductType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["CostPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["Quality"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["ProductDetail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridStock.Columns["LatestDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ApplyDataGridViewStyling();
        }
        private void ApplyDataGridViewStyling()
        {
            // Basic Grid Styling
            dataGridStock.BorderStyle = BorderStyle.None;
            dataGridStock.EnableHeadersVisualStyles = false;
            dataGridStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridStock.RowHeadersVisible = false;
            dataGridStock.AllowUserToAddRows = false;
            dataGridStock.ReadOnly = true;
            dataGridStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridStock.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridStock.ColumnHeadersHeight = 40;
            dataGridStock.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridStock.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;
            dataGridStock.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridStock.GridColor = Color.FromArgb(221, 221, 221);

            // Add some padding to cells
            dataGridStock.DefaultCellStyle.Padding = new Padding(5);
            dataGridStock.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
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
            if (productmanager.Position < 0 || productmanager.Position >= productdatatable.Rows.Count)
            {
                pictureBoxProduct.Image = null;
                return;
            }

            var row = productdatatable.Rows[productmanager.Position];
            if (row["ProductImg"] == DBNull.Value)
            {
                pictureBoxProduct.Image = null;
                return;
            }

            byte[] imageBytes = (byte[])row["ProductImg"];
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                pictureBoxProduct.Image = Image.FromStream(ms);
                pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            }
        private void btn_Save_Click(object sender, EventArgs e)
            {
            try
            {
                
                using (SqlConnection productsconnection = new SqlConnection(InitializeUser._key_con))
                {


                    if (mystate == "update") // ถ้าสถานะเป็นการอัพเดท   
                    {
                        string updateQuery = "UPDATE Products SET ProductName = @ProductName, ProductType = @ProductType, CostPrice = @CostPrice, Price = @Price, Quality = @Quality, ProductDetail = @ProductDetail, LatestDate = @LatestDate, ProductsShelf = @ProductsShelf, SuppilersID = @SuppilerID {0} WHERE ProductID = @ProductID;";

                        byte[] imageBytes = null;
                        bool isNewImage = !string.IsNullOrEmpty(immage) && File.Exists(immage);

                        if (isNewImage)
                        {
                            // แปลงรูปเป็น byte[]
                            Image image = Image.FromFile(immage);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                imageBytes = ms.ToArray();
                            }
                            updateQuery = string.Format(updateQuery, ", ProductImg = @ProductImg"); // เพิ่ม ProductImg ใน UPDATE
                        }
                        else
                        {
                            updateQuery = string.Format(updateQuery, ""); // ไม่อัปเดตรูปภาพ
                        }

                        using (SqlCommand productcommand = new SqlCommand(updateQuery, productsconnection))
                        {
                            productcommand.Parameters.AddWithValue("@ProductID", Convert.ToInt32(txtProductID.Text));
                            productcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                            productcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                            productcommand.Parameters.AddWithValue("@CostPrice", Convert.ToDecimal(txtCostPrice.Text));
                            productcommand.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                            productcommand.Parameters.AddWithValue("@Quality", Convert.ToInt32(txtAmountremain.Text));
                            productcommand.Parameters.AddWithValue("@ProductDetail", txtDetails.Text);
                            productcommand.Parameters.AddWithValue("@LatestDate", DateTime.Now);
                            productcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked ? "True" : "False");
                            productcommand.Parameters.AddWithValue("@SuppilerID", Convert.ToInt32(cbb_Suppiler.SelectedValue));

                            // ถ้าเป็นรูปใหม่ให้เพิ่มพารามิเตอร์ภาพ
                            if (isNewImage)
                            {
                                productcommand.Parameters.AddWithValue("@ProductImg", (object)imageBytes ?? DBNull.Value);
                            }

                            // เปิดการเชื่อมต่อและรันคำสั่ง SQL
                            if (productsconnection.State == ConnectionState.Closed)
                            {
                                productsconnection.Open();
                            }

                            int rowsAffected = productcommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("อัปเดตสินค้าสำเร็จ!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            SetState("view");
                            ChangeImage();
                        }
                    }
                    else if (mystate == "insert") // ถ้าสถานะเป็นการเพิ่ม
                    {

                        string insertQuery = "INSERT INTO Products (ProductName,ProductType,CostPrice,Price,Quality,ProductDetail,LatestDate,ProductImg,ProductsShelf,SuppilersID) VALUES (@ProductName,@ProductType,@CostPrice,@Price,@Quality,@ProductDetail,@LatestDate,@ProductImg,@ProductsShelf,@SuppilerID);";

                        productcommand = new SqlCommand(insertQuery, productsconnection);
                        productcommand.Parameters.AddWithValue("@ProductName", txtproductName.Text);
                        productcommand.Parameters.AddWithValue("@ProductType", txtProductType.Text);
                        productcommand.Parameters.AddWithValue("@CostPrice", Convert.ToDecimal(txtCostPrice.Text));
                        productcommand.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                        productcommand.Parameters.AddWithValue("@Quality", Convert.ToInt32(0));
                        productcommand.Parameters.AddWithValue("@ProductDetail", txtDetails.Text);
                        productcommand.Parameters.AddWithValue("@LatestDate", DateTime.Now);
                        productcommand.Parameters.AddWithValue("@ProductsShelf", checkBoxShowonShelf.Checked ? "True" : "False");

                        // ตรวจสอบและบันทึกรูปภาพ
                        byte[] imageBytes = null;
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
                        productcommand.Parameters.AddWithValue("@ProductImg", imageBytes == null ? DBNull.Value : (object)imageBytes);

                        // ตรวจสอบและบันทึก SupplierID
                        if (cbb_Suppiler.SelectedValue != null)
                        {
                            productcommand.Parameters.AddWithValue("@SuppilerID", Convert.ToInt32(cbb_Suppiler.SelectedValue));
                        }
                        else
                        {
                            MessageBox.Show("กรุณาเลือกซัพพลายเออร์", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            productsconnection.Open();
                            productcommand.ExecuteNonQuery();
                            MessageBox.Show("บันทึกข้อมูลสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        SetState("view");

                        // อัปเดตข้อมูลใน DataTable
                        using (SqlCommand productcommand = new SqlCommand("SELECT a.ProductID, a.ProductName, a.CostPrice,   " +
                            "a.Price,  a.Quality, a.ProductType,a.LatestDate,a.ProductDetail, b.SuppilerName,  b.SuppilerID AS SuppilerID ," +
                            "a.ProductsShelf , a.ProductImg FROM Products a INNER JOIN Suppilers b ON a.SuppilersID = b.SuppilerID", productsconnection))
                        using (SqlDataAdapter productadapter = new SqlDataAdapter(productcommand))
                        {
                            productdatatable.Clear();
                            productadapter.Fill(productdatatable);
                        }
                        txtProductID.DataBindings.Clear();
                        txtproductName.DataBindings.Clear();
                        txtCostPrice.DataBindings.Clear();
                        txtPrice.DataBindings.Clear();
                        txtAmountremain.DataBindings.Clear();
                        txtProductType.DataBindings.Clear();
                        txtleastUpdate.DataBindings.Clear();
                        txtDetails.DataBindings.Clear();
                        checkBoxShowonShelf.DataBindings.Clear();
                        cbb_Suppiler.DataBindings.Clear();// 9

                        txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                        txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                        txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                        txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                        txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
                        txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                        txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                        txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
                        checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");//9
                        cbb_Suppiler.DataBindings.Add("Text", productdatatable, "SuppilerName");
                        ChangeImage();
                    }
                }
                ChangeImage();
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
                    txtProductID.DataBindings.Clear();
                    txtproductName.DataBindings.Clear();
                    txtCostPrice.DataBindings.Clear();
                    txtPrice.DataBindings.Clear();
                    txtAmountremain.DataBindings.Clear();
                    txtProductType.DataBindings.Clear();
                    txtleastUpdate.DataBindings.Clear();
                    txtDetails.DataBindings.Clear();
                    checkBoxShowonShelf.DataBindings.Clear();
                    cbb_Suppiler.DataBindings.Clear();// 9

                    txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                    txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                    txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                    txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                    txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
                    txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                    txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                    txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
                    checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");//9
                    cbb_Suppiler.DataBindings.Add("Text", productdatatable, "SuppilerName");
                    ChangeImage();



                    dataGridStock.Enabled = true;
                        checkBoxShowonShelf.Enabled = false;
                        txtSearch.Enabled = true;
                        txtSearch.BackColor = Color.White;
                        txtProductID.BackColor = Color.White;
                        txtProductID.ReadOnly = true;
                        txtAmountremain.BackColor = Color.White;
                        txtAmountremain.Enabled = true;
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
                        txtDetails.ReadOnly = true;
                        txtproductName.ReadOnly = true;
                        txtProductType.ReadOnly = true;
                        cbb_Suppiler.Enabled = false;
                        btn_Next.Enabled = true;
                        btn_Next.BackColor = Color.White;
                        btn_Frist.BackColor = Color.White;
                        btn_Previous.BackColor = Color.White;
                        btn_Last.BackColor = Color.White;
                        btn_Last.Enabled = true;
                        btn_Previous.Enabled = true;
                        btn_Frist.Enabled = true;
                        btn_Find.Enabled = true;
                        btn_Find.BackColor = Color.White;
                        txtDetails.BackColor = Color.White;

                    // ดึงข้อมูลสินค้าจากฐานข้อมูลและอัปเดต
                    productcommand = new SqlCommand("SELECT p.ProductID, p.ProductName, p.ProductType,p.CostPrice, p.Price, p.Quality, p.ProductDetail, p.LatestDate, p.ProductImg, p.ProductsShelf, s.SuppilerID, s.SuppilerName FROM Products p JOIN Suppilers s ON p.SuppilersID = s.SuppilerID;", productsconnection);
                        productadapter = new SqlDataAdapter(productcommand);
                        productdatatable.Clear(); // เคลียร์ข้อมูลเดิมใน DataTable
                        productadapter.Fill(productdatatable);
                        ChangeImage();
                    break;
                    case "update": // สถานะการอัปเดตข้อมูล (update)
                    dataGridStock.Enabled = false;
                    checkBoxShowonShelf.Enabled = true;
                        txtAmountremain.Enabled = true;
                        txtSearch.Enabled = false;
                        txtSearch.BackColor = Color.Gray;
                        txtProductID.BackColor = Color.White;
                        txtAmountremain.BackColor = Color.Orange;
                        txtCostPrice.BackColor = Color.Orange;
                        txtleastUpdate.BackColor = Color.White;
                        txtPrice.BackColor = Color.Orange;
                        txtproductName.BackColor = Color.Orange;
                        txtProductType.BackColor = Color.Orange;
                        txtProductID.ReadOnly = true;
                        txtAmountremain.ReadOnly = false;
                        txtCostPrice.ReadOnly = false;
                        txtleastUpdate.Text = DateTime.Now.ToString();
                        txtPrice.ReadOnly = false;
                        txtDetails.ReadOnly = false;
                        txtproductName.ReadOnly = false;
                        txtProductType.ReadOnly = false;
                        btn_Add.Enabled = false;
                        btn_Next.Enabled = false;
                        btn_Next.BackColor = Color.Gray;
                        btn_Frist.BackColor = Color.Gray;
                        btn_Previous.BackColor = Color.Gray;
                        btn_Last.BackColor = Color.Gray;
                        btn_Last.Enabled = false;
                        btn_Previous.Enabled = false;
                        btn_Frist.Enabled = false;
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
                        cbb_Suppiler.Enabled = true;
                        cbb_Suppiler.BackColor = Color.Orange;
                        btn_Find.Enabled = false;
                        btn_Find.BackColor = Color.Gray;
                        txtDetails.BackColor = Color.Orange;
                        break;

                    default: // สถานะการเพิ่มข้อมูลใหม่ (insert)
                    dataGridStock.Enabled = false;
                    checkBoxShowonShelf.Enabled = true;
                        txtAmountremain.Enabled = false;
                        txtDetails.ReadOnly = false;
                        txtSearch.Enabled = false;
                        txtSearch.BackColor = Color.Gray;
                        txtProductID.ReadOnly = true;
                        txtProductID.BackColor = Color.White;
                        txtAmountremain.BackColor = Color.White;
                        txtCostPrice.BackColor = Color.GreenYellow;
                        txtleastUpdate.BackColor = Color.White;
                        txtPrice.BackColor = Color.GreenYellow;
                        txtproductName.BackColor = Color.GreenYellow;
                        txtProductType.BackColor = Color.GreenYellow;
                        txtDetails.BackColor = Color.GreenYellow;
                    txtAmountremain.Clear();
                        txtProductID.Clear();
                        txtCostPrice.Clear();
                        txtleastUpdate.Clear();
                        txtPrice.Clear();
                        txtproductName.Clear();
                        txtProductType.Clear();
                    txtDetails.Clear();
                    txtPrice.Clear();
                    txtCostPrice.Clear();

                    txtProductID.DataBindings.Clear();
                    txtproductName.DataBindings.Clear();
                    txtCostPrice.DataBindings.Clear();
                    txtPrice.DataBindings.Clear();
                    txtAmountremain.DataBindings.Clear();
                    txtProductType.DataBindings.Clear();
                    txtleastUpdate.DataBindings.Clear();
                    txtDetails.DataBindings.Clear();
                    checkBoxShowonShelf.DataBindings.Clear();
                    cbb_Suppiler.DataBindings.Clear();// 9

                    cbb_Suppiler.SelectedIndex = -1;
                    txtleastUpdate.Text = DateTime.Now.ToString();
                    pictureBoxProduct.Image = null;
                        txtAmountremain.ReadOnly = false;
                        txtCostPrice.ReadOnly = false;
                        txtleastUpdate.Text = DateTime.Now.ToString();
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
                        btn_Find.Enabled = false;
                        btn_Find.BackColor = Color.Gray;
                        cbb_Suppiler.Enabled = true;
                        cbb_Suppiler.BackColor = Color.GreenYellow;
                        txtproductName.ReadOnly = false;
                        txtProductType.ReadOnly = false;
                        btn_Next.Enabled = false;
                        btn_Next.BackColor = Color.Gray;
                        btn_Frist.BackColor = Color.Gray;
                        btn_Previous.BackColor = Color.Gray;
                        btn_Last.BackColor = Color.Gray;
                        btn_Last.Enabled = false;
                        btn_Previous.Enabled = false;
                        btn_Frist.Enabled = false;
                        txtDetails.BackColor = Color.GreenYellow;
                    break;
                    }
                }
            private void btn_Update_Click(object sender, EventArgs e)
            {
                SetState("update"); // เปลี่ยนสถานะเป็น "update"
            }

            private void btn_Add_Click(object sender, EventArgs e)
            {
            
            int lastRowIndex = dataGridStock.Rows.Count - 1;
            dataGridStock.CurrentCell = dataGridStock.Rows[lastRowIndex].Cells[0];
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
            
            private void btn_Find_Click(object sender, EventArgs e)
            {
                string searchText = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadAllProducts(); // โหลดข้อมูลสินค้าทั้งหมด
                SearchProducts(searchText); // ค้นหาสินค้า
                txtProductID.DataBindings.Clear();
                txtproductName.DataBindings.Clear();
                txtCostPrice.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtAmountremain.DataBindings.Clear();
                txtProductType.DataBindings.Clear();
                txtleastUpdate.DataBindings.Clear();
                txtDetails.DataBindings.Clear();
                checkBoxShowonShelf.DataBindings.Clear();
                cbb_Suppiler.DataBindings.Clear();// 9

                txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
                txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", productdatatable, "Price");
                txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
                txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
                txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
                txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
                checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");//9
                cbb_Suppiler.DataBindings.Add("Text", productdatatable, "SuppilerName");
                return;
                }

                SearchProducts(searchText); // ค้นหาสินค้า
            txtProductID.DataBindings.Clear();
            txtproductName.DataBindings.Clear();
            txtCostPrice.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtAmountremain.DataBindings.Clear();
            txtProductType.DataBindings.Clear();
            txtleastUpdate.DataBindings.Clear();
            txtDetails.DataBindings.Clear();
            checkBoxShowonShelf.DataBindings.Clear();
            cbb_Suppiler.DataBindings.Clear();// 9

            txtProductID.DataBindings.Add("Text", productdatatable, "ProductID");
            txtproductName.DataBindings.Add("Text", productdatatable, "ProductName");
            txtCostPrice.DataBindings.Add("Text", productdatatable, "CostPrice");
            txtPrice.DataBindings.Add("Text", productdatatable, "Price");
            txtAmountremain.DataBindings.Add("Text", productdatatable, "Quality");
            txtProductType.DataBindings.Add("Text", productdatatable, "ProductType");
            txtleastUpdate.DataBindings.Add("Text", productdatatable, "LatestDate");
            txtDetails.DataBindings.Add("Text", productdatatable, "ProductDetail");
            checkBoxShowonShelf.DataBindings.Add("Checked", productdatatable, "ProductsShelf");//9
            cbb_Suppiler.DataBindings.Add("Text", productdatatable, "SuppilerName");
        }

            // ฟังก์ชันค้นหาสินค้า
            private void SearchProducts(string searchText)
            {
                try
                {
                    string searchQuery = @" SELECT p.ProductID, p.ProductName, p.ProductType, p.CostPrice, p.Price, p.Quality,  p.ProductDetail, p.LatestDate, p.ProductImg, p.ProductsShelf,  s.SuppilerID, s.SuppilerName FROM Products p JOIN Suppilers s ON p.SuppilersID = s.SuppilerID WHERE p.ProductName LIKE @SearchText";

                    using (SqlConnection productsconnection = new SqlConnection(InitializeUser._key_con))
                    using (SqlCommand productcommand = new SqlCommand(searchQuery, productsconnection))
                    {
                        productcommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                        using (SqlDataAdapter productadapter = new SqlDataAdapter(productcommand))
                        {
                            productdatatable = new DataTable();
                            productadapter.Fill(productdatatable);

                        }
                    }

                    if (productdatatable.Rows.Count > 0)
                    {
                        dataGridStock.DataSource = productdatatable;
                        dataGridStock.DataSource = productdatatable;
                        if (dataGridStock.Columns.Contains("ProductName"))
                        {
                            dataGridStock.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                        }
                        if (dataGridStock.Columns.Contains("ProductType"))
                        {
                            dataGridStock.Columns["ProductType"].HeaderText = "ชนิดสินค้า";
                        }
                        if (dataGridStock.Columns.Contains("CostPrice"))
                        {
                            dataGridStock.Columns["CostPrice"].HeaderText = "ต้นทุน";
                        }
                        if (dataGridStock.Columns.Contains("Price"))
                        {
                            dataGridStock.Columns["Price"].HeaderText = "ราคา";
                        }
                        if (dataGridStock.Columns.Contains("Quality"))
                        {
                            dataGridStock.Columns["Quality"].HeaderText = "จำนวน";
                        }
                        if (dataGridStock.Columns.Contains("ProductDetail"))
                        {
                            dataGridStock.Columns["ProductDetail"].HeaderText = "รายละเอียด";
                        }
                        if (dataGridStock.Columns.Contains("LatestDate"))
                        {
                            dataGridStock.Columns["LatestDate"].HeaderText = "อัปเดต";
                        }
                        if (dataGridStock.Columns.Contains("SuppilersID"))
                        {
                            dataGridStock.Columns["SuppilersID"].Visible = false;
                        }
                        if (dataGridStock.Columns.Contains("SuppilerID"))
                        {
                            dataGridStock.Columns["SuppilerID"].Visible = false;
                        }
                        if (dataGridStock.Columns.Contains("ProductImg"))
                        {
                            dataGridStock.Columns["ProductImg"].Visible = false;
                        }
                        if (dataGridStock.Columns.Contains("ProductsShelf"))
                        {
                            dataGridStock.Columns["ProductsShelf"].Visible = false;
                        }
                        if (dataGridStock.Columns.Contains("SuppilerName"))
                        {
                            dataGridStock.Columns["SuppilerName"].Visible = false;
                        }
                        productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                        productmanager.Refresh();
                        ChangeImage();
                    }
                    else
                    {
                        dataGridStock.DataSource = null;
                        pictureBoxProduct.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void LoadAllProducts()
            {
                try
                {
                    string query = @" SELECT p.ProductID, p.ProductName, p.ProductType, p.CostPrice, p.Price, p.Quality,  p.ProductDetail, p.LatestDate, p.ProductImg, p.ProductsShelf,  s.SuppilerID, s.SuppilerName FROM Products p JOIN Suppilers s ON p.SuppilersID = s.SuppilerID";

                    using (SqlConnection productsconnection = new SqlConnection(InitializeUser._key_con))
                    using (SqlCommand productcommand = new SqlCommand(query, productsconnection))
                    using (SqlDataAdapter productadapter = new SqlDataAdapter(productcommand))
                    {
                        productdatatable = new DataTable();
                        productadapter.Fill(productdatatable);
                    }

                    dataGridStock.DataSource = productdatatable;
                    if (dataGridStock.Columns.Contains("ProductName"))
                    {
                        dataGridStock.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                    }
                    if (dataGridStock.Columns.Contains("ProductType"))
                    {
                        dataGridStock.Columns["ProductType"].HeaderText = "ชนิดสินค้า";
                    }
                    if (dataGridStock.Columns.Contains("CostPrice"))
                    {
                        dataGridStock.Columns["CostPrice"].HeaderText = "ต้นทุน";
                    }
                    if (dataGridStock.Columns.Contains("Price"))
                    {
                        dataGridStock.Columns["Price"].HeaderText = "ราคา";
                    }
                    if (dataGridStock.Columns.Contains("Quality"))
                    {
                        dataGridStock.Columns["Quality"].HeaderText = "จำนวน";
                    }
                    if (dataGridStock.Columns.Contains("ProductDetail"))
                    {
                        dataGridStock.Columns["ProductDetail"].HeaderText = "รายละเอียด";
                    }
                    if (dataGridStock.Columns.Contains("LatestDate"))
                    {
                        dataGridStock.Columns["LatestDate"].HeaderText = "อัปเดต";
                    }
                    if (dataGridStock.Columns.Contains("SuppilersID"))
                    {
                        dataGridStock.Columns["SuppilersID"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("SuppilerID"))
                    {
                        dataGridStock.Columns["SuppilerID"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("ProductImg"))
                    {
                        dataGridStock.Columns["ProductImg"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("ProductsShelf"))
                    {
                        dataGridStock.Columns["ProductsShelf"].Visible = false;
                    }
                    if (dataGridStock.Columns.Contains("SuppilerName"))
                    {
                        dataGridStock.Columns["SuppilerName"].Visible = false;
                    }
                    productmanager = (CurrencyManager)this.BindingContext[productdatatable];
                    productmanager.Refresh();
                    ChangeImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void dataGridStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeImage();
        }
    }
}


