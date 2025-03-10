namespace MadyBoardGame_Shop
{
    partial class formOrder
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
            this.listBoxProduct = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxCart = new System.Windows.Forms.ListBox();
            this.btnRemoveall = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBoxmethonPayment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductname = new System.Windows.Forms.TextBox();
            this.numericCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxProduct
            // 
            this.listBoxProduct.FormattingEnabled = true;
            this.listBoxProduct.ItemHeight = 24;
            this.listBoxProduct.Location = new System.Drawing.Point(6, 42);
            this.listBoxProduct.Name = "listBoxProduct";
            this.listBoxProduct.Size = new System.Drawing.Size(374, 148);
            this.listBoxProduct.TabIndex = 1;
            this.listBoxProduct.SelectedIndexChanged += new System.EventHandler(this.listBoxProduct_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "รายการสินค้า";
            // 
            // listBoxCart
            // 
            this.listBoxCart.FormattingEnabled = true;
            this.listBoxCart.ItemHeight = 24;
            this.listBoxCart.Location = new System.Drawing.Point(6, 326);
            this.listBoxCart.Name = "listBoxCart";
            this.listBoxCart.Size = new System.Drawing.Size(374, 148);
            this.listBoxCart.TabIndex = 37;
            this.listBoxCart.SelectedIndexChanged += new System.EventHandler(this.listBoxCart_SelectedIndexChanged);
            // 
            // btnRemoveall
            // 
            this.btnRemoveall.Location = new System.Drawing.Point(222, 213);
            this.btnRemoveall.Name = "btnRemoveall";
            this.btnRemoveall.Size = new System.Drawing.Size(46, 33);
            this.btnRemoveall.TabIndex = 38;
            this.btnRemoveall.Text = "⇈";
            this.btnRemoveall.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(170, 213);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(46, 33);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(118, 213);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(46, 33);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(21, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(266, 228);
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(415, 435);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(304, 46);
            this.button5.TabIndex = 44;
            this.button5.Text = "ชำระ";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // comboBoxmethonPayment
            // 
            this.comboBoxmethonPayment.FormattingEnabled = true;
            this.comboBoxmethonPayment.Items.AddRange(new object[] {
            "เงินสด",
            "พร้อมเพย์",
            "ธนาคาร",
            "ทรูวอเลท"});
            this.comboBoxmethonPayment.Location = new System.Drawing.Point(484, 397);
            this.comboBoxmethonPayment.Name = "comboBoxmethonPayment";
            this.comboBoxmethonPayment.Size = new System.Drawing.Size(205, 32);
            this.comboBoxmethonPayment.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 46;
            this.label1.Text = "วิธีชำระ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.numericCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.listBoxProduct);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.listBoxCart);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnRemoveall);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 525);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 24);
            this.label8.TabIndex = 50;
            this.label8.Text = "ตะกร้าของคุณ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtProductType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProductname);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(415, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 379);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายละเอียดสินค้า";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 55;
            this.label9.Text = "ต่อชิ้น";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(108, 334);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(166, 29);
            this.txtProductType.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 24);
            this.label7.TabIndex = 53;
            this.label7.Text = "ประเภทสินค้า";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(57, 299);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(67, 29);
            this.txtPrice.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 24);
            this.label5.TabIndex = 51;
            this.label5.Text = "ราคา";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "ชื่อ";
            // 
            // txtProductname
            // 
            this.txtProductname.Location = new System.Drawing.Point(57, 262);
            this.txtProductname.Name = "txtProductname";
            this.txtProductname.Size = new System.Drawing.Size(217, 29);
            this.txtProductname.TabIndex = 44;
            // 
            // numericCount
            // 
            this.numericCount.Location = new System.Drawing.Point(198, 254);
            this.numericCount.Name = "numericCount";
            this.numericCount.Size = new System.Drawing.Size(46, 29);
            this.numericCount.TabIndex = 51;
            this.numericCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 24);
            this.label10.TabIndex = 52;
            this.label10.Text = "เพิ่มจำนวน";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 24);
            this.label11.TabIndex = 53;
            this.label11.Text = "ชิ้น";
            // 
            // formOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 567);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxmethonPayment);
            this.Controls.Add(this.button5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formOrder";
            this.Text = "สั่งซื้อสินค้า";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formOrder_FormClosing);
            this.Load += new System.EventHandler(this.formOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxCart;
        private System.Windows.Forms.Button btnRemoveall;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBoxmethonPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProductname;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericCount;
    }
}