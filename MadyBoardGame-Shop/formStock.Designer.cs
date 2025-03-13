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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtproductName = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridStock = new System.Windows.Forms.DataGridView();
            this.columeProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumeCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columeProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columeStockquality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columeShowOnShelf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columeUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.button_browse = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อบอร์ดเกม";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "ราคาต้นทุน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "ประเภทของบอร์ดเกม";
            // 
            // txtproductName
            // 
            this.txtproductName.Location = new System.Drawing.Point(164, 94);
            this.txtproductName.Name = "txtproductName";
            this.txtproductName.Size = new System.Drawing.Size(396, 34);
            this.txtproductName.TabIndex = 3;
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(164, 130);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(396, 34);
            this.txtProductType.TabIndex = 4;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(164, 165);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(128, 34);
            this.txtCostPrice.TabIndex = 5;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 297);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดสินค้า";
            // 
            // checkBoxShowonShelf
            // 
            this.checkBoxShowonShelf.AutoSize = true;
            this.checkBoxShowonShelf.Location = new System.Drawing.Point(318, 201);
            this.checkBoxShowonShelf.Name = "checkBoxShowonShelf";
            this.checkBoxShowonShelf.Size = new System.Drawing.Size(235, 33);
            this.checkBoxShowonShelf.TabIndex = 22;
            this.checkBoxShowonShelf.Text = "แสดงในรายการสินค้า";
            this.checkBoxShowonShelf.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(377, 165);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(128, 34);
            this.txtPrice.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 29);
            this.label8.TabIndex = 20;
            this.label8.Text = "ราคาขาย";
            // 
            // txtleastUpdate
            // 
            this.txtleastUpdate.Location = new System.Drawing.Point(164, 235);
            this.txtleastUpdate.Name = "txtleastUpdate";
            this.txtleastUpdate.Size = new System.Drawing.Size(128, 34);
            this.txtleastUpdate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "วันที่อัพเดตล่าสุด";
            // 
            // txtAmountremain
            // 
            this.txtAmountremain.Location = new System.Drawing.Point(164, 200);
            this.txtAmountremain.Name = "txtAmountremain";
            this.txtAmountremain.Size = new System.Drawing.Size(128, 34);
            this.txtAmountremain.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "จำนวนคงเหลือ";
            // 
            // btn_Frist
            // 
            this.btn_Frist.Location = new System.Drawing.Point(644, 200);
            this.btn_Frist.Name = "btn_Frist";
            this.btn_Frist.Size = new System.Drawing.Size(45, 45);
            this.btn_Frist.TabIndex = 7;
            this.btn_Frist.Text = "<<";
            this.btn_Frist.UseVisualStyleBackColor = true;
            this.btn_Frist.Click += new System.EventHandler(this.btn_Frist_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Location = new System.Drawing.Point(697, 200);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(45, 45);
            this.btn_Previous.TabIndex = 8;
            this.btn_Previous.Text = "<=";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(748, 200);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(45, 45);
            this.btn_Next.TabIndex = 9;
            this.btn_Next.Text = "=>";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.Location = new System.Drawing.Point(799, 200);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(45, 45);
            this.btn_Last.TabIndex = 10;
            this.btn_Last.Text = ">>";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(613, 251);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(82, 38);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "เพิ่ม";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(701, 295);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(82, 38);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.Text = "ลบ";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(613, 295);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(82, 38);
            this.btn_Update.TabIndex = 13;
            this.btn_Update.Text = "แก้ไข";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(789, 251);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(82, 38);
            this.btn_Cancle.TabIndex = 14;
            this.btn_Cancle.Text = "ยกเลิก";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(789, 295);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(82, 38);
            this.btn_Close.TabIndex = 15;
            this.btn_Close.Text = "ปิด";
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(701, 251);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(82, 38);
            this.btn_Save.TabIndex = 16;
            this.btn_Save.Text = "บันทึก";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(644, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 182);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ค้นหา";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(45, 138);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 38);
            this.button5.TabIndex = 18;
            this.button5.Text = "ค้นหา";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 34);
            this.textBox1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 63);
            this.label6.TabIndex = 0;
            this.label6.Text = "พิมพ์ชื่อบอร์ดเกม\r\n(ไม่จำเป็นต้องเขียนเต็ม)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridStock
            // 
            this.dataGridStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columeProductName,
            this.columnProductType,
            this.ColumeCostPrice,
            this.columeProductPrice,
            this.columeStockquality,
            this.columeShowOnShelf,
            this.columeUpdateDate});
            this.dataGridStock.Location = new System.Drawing.Point(26, 388);
            this.dataGridStock.Name = "dataGridStock";
            this.dataGridStock.RowHeadersWidth = 51;
            this.dataGridStock.Size = new System.Drawing.Size(1185, 213);
            this.dataGridStock.TabIndex = 18;
            // 
            // columeProductName
            // 
            this.columeProductName.HeaderText = "ชื่อโปรดัค";
            this.columeProductName.MinimumWidth = 6;
            this.columeProductName.Name = "columeProductName";
            this.columeProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columeProductName.Width = 300;
            // 
            // columnProductType
            // 
            this.columnProductType.HeaderText = "ชนิดสินค้า";
            this.columnProductType.MinimumWidth = 6;
            this.columnProductType.Name = "columnProductType";
            this.columnProductType.Width = 200;
            // 
            // ColumeCostPrice
            // 
            this.ColumeCostPrice.HeaderText = "ราคาต้นทุน";
            this.ColumeCostPrice.MinimumWidth = 6;
            this.ColumeCostPrice.Name = "ColumeCostPrice";
            this.ColumeCostPrice.Width = 150;
            // 
            // columeProductPrice
            // 
            this.columeProductPrice.HeaderText = "ราคา";
            this.columeProductPrice.MinimumWidth = 6;
            this.columeProductPrice.Name = "columeProductPrice";
            this.columeProductPrice.Width = 150;
            // 
            // columeStockquality
            // 
            this.columeStockquality.HeaderText = "จำนวน";
            this.columeStockquality.MinimumWidth = 6;
            this.columeStockquality.Name = "columeStockquality";
            this.columeStockquality.Width = 150;
            // 
            // columeShowOnShelf
            // 
            this.columeShowOnShelf.HeaderText = "เเสดงรายการสินค้า";
            this.columeShowOnShelf.MinimumWidth = 6;
            this.columeShowOnShelf.Name = "columeShowOnShelf";
            this.columeShowOnShelf.Width = 50;
            // 
            // columeUpdateDate
            // 
            this.columeUpdateDate.HeaderText = "อัพเดต";
            this.columeUpdateDate.MinimumWidth = 6;
            this.columeUpdateDate.Name = "columeUpdateDate";
            this.columeUpdateDate.Width = 125;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(889, 12);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(321, 321);
            this.pictureBoxProduct.TabIndex = 19;
            this.pictureBoxProduct.TabStop = false;
            this.pictureBoxProduct.Click += new System.EventHandler(this.pictureBoxProduct_Click);
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(998, 344);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(103, 38);
            this.button_browse.TabIndex = 20;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 23;
            this.label7.Text = "รหัสบอร์ดเกม";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(164, 54);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(396, 34);
            this.txtProductID.TabIndex = 24;
            // 
            // formProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 613);
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.CheckBox checkBoxShowonShelf;
        private System.Windows.Forms.DataGridViewTextBoxColumn columeProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumeCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columeProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columeStockquality;
        private System.Windows.Forms.DataGridViewTextBoxColumn columeShowOnShelf;
        private System.Windows.Forms.DataGridViewTextBoxColumn columeUpdateDate;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductID;
    }
}