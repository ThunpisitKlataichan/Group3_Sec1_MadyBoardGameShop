namespace MadyBoardGame_Shop
{
    partial class formProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtproductName = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_Suppiler = new System.Windows.Forms.ComboBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.checkBoxShowonShelf = new System.Windows.Forms.CheckBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtleastUpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmountremain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Frist = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridStock = new System.Windows.Forms.DataGridView();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.madyStoreDBDataSet = new MadyBoardGame_Shop.MadyStoreDBDataSet();
            this.suppilersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.suppilersTableAdapter = new MadyBoardGame_Shop.MadyStoreDBDataSetTableAdapters.SuppilersTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.madyStoreDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppilersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อบอร์ดเกม";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ราคาต้นทุน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "ประเภทของบอร์ดเกม";
            // 
            // txtproductName
            // 
            this.txtproductName.Location = new System.Drawing.Point(164, 94);
            this.txtproductName.Name = "txtproductName";
            this.txtproductName.Size = new System.Drawing.Size(396, 29);
            this.txtproductName.TabIndex = 3;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(164, 130);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(396, 29);
            this.txtProductType.TabIndex = 4;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(164, 165);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(128, 29);
            this.txtCostPrice.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_Suppiler);
            this.groupBox1.Controls.Add(this.txtDetails);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.checkBoxShowonShelf);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtleastUpdate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAmountremain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtProductType);
            this.groupBox1.Controls.Add(this.txtCostPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtproductName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 395);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดสินค้า";
            // 
            // cbb_Suppiler
            // 
            this.cbb_Suppiler.FormattingEnabled = true;
            this.cbb_Suppiler.Location = new System.Drawing.Point(164, 270);
            this.cbb_Suppiler.Name = "cbb_Suppiler";
            this.cbb_Suppiler.Size = new System.Drawing.Size(128, 32);
            this.cbb_Suppiler.TabIndex = 29;
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(164, 306);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(396, 83);
            this.txtDetails.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 24);
            this.label10.TabIndex = 27;
            this.label10.Text = "รายละเอียดสินค้า";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 24);
            this.label9.TabIndex = 25;
            this.label9.Text = "ผู้จำหน่าย";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "รหัสบอร์ดเกม";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(164, 54);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(396, 29);
            this.txtProductID.TabIndex = 24;
            // 
            // checkBoxShowonShelf
            // 
            this.checkBoxShowonShelf.AutoSize = true;
            this.checkBoxShowonShelf.Location = new System.Drawing.Point(318, 201);
            this.checkBoxShowonShelf.Name = "checkBoxShowonShelf";
            this.checkBoxShowonShelf.Size = new System.Drawing.Size(180, 28);
            this.checkBoxShowonShelf.TabIndex = 22;
            this.checkBoxShowonShelf.Text = "แสดงในรายการสินค้า";
            this.checkBoxShowonShelf.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(377, 165);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(128, 29);
            this.txtPrice.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "ราคาขาย";
            // 
            // txtleastUpdate
            // 
            this.txtleastUpdate.Location = new System.Drawing.Point(164, 235);
            this.txtleastUpdate.Name = "txtleastUpdate";
            this.txtleastUpdate.Size = new System.Drawing.Size(128, 29);
            this.txtleastUpdate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "วันที่อัพเดตล่าสุด";
            // 
            // txtAmountremain
            // 
            this.txtAmountremain.Location = new System.Drawing.Point(164, 200);
            this.txtAmountremain.Name = "txtAmountremain";
            this.txtAmountremain.Size = new System.Drawing.Size(128, 29);
            this.txtAmountremain.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "จำนวนคงเหลือ";
            // 
            // btn_Frist
            // 
            this.btn_Frist.Location = new System.Drawing.Point(638, 296);
            this.btn_Frist.Name = "btn_Frist";
            this.btn_Frist.Size = new System.Drawing.Size(45, 45);
            this.btn_Frist.TabIndex = 7;
            this.btn_Frist.Text = "<<";
            this.btn_Frist.UseVisualStyleBackColor = true;
            this.btn_Frist.Click += new System.EventHandler(this.btn_Frist_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Location = new System.Drawing.Point(691, 296);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(45, 45);
            this.btn_Previous.TabIndex = 8;
            this.btn_Previous.Text = "<=";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(742, 296);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(45, 45);
            this.btn_Next.TabIndex = 9;
            this.btn_Next.Text = "=>";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.Location = new System.Drawing.Point(793, 296);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(45, 45);
            this.btn_Last.TabIndex = 10;
            this.btn_Last.Text = ">>";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(607, 347);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(82, 38);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "เพิ่ม";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(695, 391);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(82, 38);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.Text = "ลบ";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(607, 391);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(82, 38);
            this.btn_Update.TabIndex = 13;
            this.btn_Update.Text = "แก้ไข";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(783, 347);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(82, 38);
            this.btn_Cancle.TabIndex = 14;
            this.btn_Cancle.Text = "ยกเลิก";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(783, 391);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(82, 38);
            this.btn_Close.TabIndex = 15;
            this.btn_Close.Text = "ปิด";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(695, 347);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(82, 38);
            this.btn_Save.TabIndex = 16;
            this.btn_Save.Text = "บันทึก";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Find);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(638, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 182);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ค้นหา";
            // 
            // btn_Find
            // 
            this.btn_Find.Location = new System.Drawing.Point(45, 138);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(111, 38);
            this.btn_Find.TabIndex = 18;
            this.btn_Find.Text = "ค้นหา";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 94);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 29);
            this.txtSearch.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 63);
            this.label6.TabIndex = 0;
            this.label6.Text = "พิมพ์ชื่อบอร์ดเกม\r\n(ไม่จำเป็นต้องเขียนเต็ม)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridStock
            // 
            this.dataGridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStock.Location = new System.Drawing.Point(12, 513);
            this.dataGridStock.Name = "dataGridStock";
            this.dataGridStock.RowHeadersWidth = 51;
            this.dataGridStock.Size = new System.Drawing.Size(1185, 188);
            this.dataGridStock.TabIndex = 18;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(883, 108);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(321, 321);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProduct.TabIndex = 19;
            this.pictureBoxProduct.TabStop = false;
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(997, 459);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(103, 38);
            this.button_browse.TabIndex = 20;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 100);
            this.panel1.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 55);
            this.label11.TabIndex = 0;
            this.label11.Text = "คลังสินค้า";
            // 
            // madyStoreDBDataSet
            // 
            this.madyStoreDBDataSet.DataSetName = "MadyStoreDBDataSet";
            this.madyStoreDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // suppilersBindingSource
            // 
            this.suppilersBindingSource.DataMember = "Suppilers";
            this.suppilersBindingSource.DataSource = this.madyStoreDBDataSet;
            // 
            // suppilersTableAdapter
            // 
            this.suppilersTableAdapter.ClearBeforeFill = true;
            // 
            // formProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 738);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_browse);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.dataGridStock);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Last);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.btn_Frist);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formProduct";
            this.Text = "สินค้าในร้าน";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formStock_FormClosing);
            this.Load += new System.EventHandler(this.formStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.madyStoreDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppilersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtproductName;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtleastUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmountremain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Frist;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.CheckBox checkBoxShowonShelf;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbb_Suppiler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private MadyStoreDBDataSet madyStoreDBDataSet;
        private System.Windows.Forms.BindingSource suppilersBindingSource;
        private MadyStoreDBDataSetTableAdapters.SuppilersTableAdapter suppilersTableAdapter;
    }
}