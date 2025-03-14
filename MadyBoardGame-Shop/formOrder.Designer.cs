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
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.btnpayment = new System.Windows.Forms.Button();
            this.comboBoxmethonPayment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductname = new System.Windows.Forms.TextBox();
            this.flowLayoutProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutCart = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFindProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.Location = new System.Drawing.Point(21, 28);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(266, 228);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 43;
            this.picProduct.TabStop = false;
            // 
            // btnpayment
            // 
            this.btnpayment.Location = new System.Drawing.Point(827, 573);
            this.btnpayment.Name = "btnpayment";
            this.btnpayment.Size = new System.Drawing.Size(304, 46);
            this.btnpayment.TabIndex = 3;
            this.btnpayment.Text = "ชำระ";
            this.btnpayment.UseVisualStyleBackColor = true;
            this.btnpayment.Click += new System.EventHandler(this.btnpayment_Click);
            // 
            // comboBoxmethonPayment
            // 
            this.comboBoxmethonPayment.BackColor = System.Drawing.Color.White;
            this.comboBoxmethonPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxmethonPayment.FormattingEnabled = true;
            this.comboBoxmethonPayment.Items.AddRange(new object[] {
            "เงินสด",
            "ทรูวอเลท",
            "ธนาคาร",
            "พร้อมเพย์"});
            this.comboBoxmethonPayment.Location = new System.Drawing.Point(896, 535);
            this.comboBoxmethonPayment.Name = "comboBoxmethonPayment";
            this.comboBoxmethonPayment.Size = new System.Drawing.Size(218, 32);
            this.comboBoxmethonPayment.Sorted = true;
            this.comboBoxmethonPayment.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 46;
            this.label1.Text = "วิธีชำระ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDesription);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtProductType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProductname);
            this.groupBox2.Controls.Add(this.picProduct);
            this.groupBox2.Location = new System.Drawing.Point(827, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 510);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายละเอียดสินค้า";
            // 
            // txtDesription
            // 
            this.txtDesription.BackColor = System.Drawing.Color.White;
            this.txtDesription.Enabled = false;
            this.txtDesription.Location = new System.Drawing.Point(6, 397);
            this.txtDesription.Multiline = true;
            this.txtDesription.Name = "txtDesription";
            this.txtDesription.Size = new System.Drawing.Size(281, 110);
            this.txtDesription.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 24);
            this.label6.TabIndex = 56;
            this.label6.Text = "รายละเอียด";
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
            this.txtProductType.BackColor = System.Drawing.Color.White;
            this.txtProductType.Enabled = false;
            this.txtProductType.Location = new System.Drawing.Point(108, 334);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(179, 29);
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
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.Enabled = false;
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
            this.txtProductname.BackColor = System.Drawing.Color.White;
            this.txtProductname.Enabled = false;
            this.txtProductname.Location = new System.Drawing.Point(57, 262);
            this.txtProductname.Name = "txtProductname";
            this.txtProductname.Size = new System.Drawing.Size(230, 29);
            this.txtProductname.TabIndex = 44;
            // 
            // flowLayoutProduct
            // 
            this.flowLayoutProduct.AutoScroll = true;
            this.flowLayoutProduct.BackColor = System.Drawing.SystemColors.GrayText;
            this.flowLayoutProduct.Location = new System.Drawing.Point(12, 80);
            this.flowLayoutProduct.Name = "flowLayoutProduct";
            this.flowLayoutProduct.Size = new System.Drawing.Size(486, 539);
            this.flowLayoutProduct.TabIndex = 51;
            // 
            // flowLayoutCart
            // 
            this.flowLayoutCart.AutoScroll = true;
            this.flowLayoutCart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutCart.Location = new System.Drawing.Point(504, 80);
            this.flowLayoutCart.Name = "flowLayoutCart";
            this.flowLayoutCart.Size = new System.Drawing.Size(314, 539);
            this.flowLayoutCart.TabIndex = 52;
            // 
            // txtFindProduct
            // 
            this.txtFindProduct.Location = new System.Drawing.Point(72, 50);
            this.txtFindProduct.Name = "txtFindProduct";
            this.txtFindProduct.Size = new System.Drawing.Size(350, 29);
            this.txtFindProduct.TabIndex = 1;
            this.txtFindProduct.TextChanged += new System.EventHandler(this.txtFindProduct_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 55;
            this.label2.Text = "ค้นหา";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(206, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 24);
            this.label8.TabIndex = 57;
            this.label8.Text = "รายการ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(500, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 24);
            this.label10.TabIndex = 58;
            this.label10.Text = "ตะกร้า";
            // 
            // formOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 628);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFindProduct);
            this.Controls.Add(this.flowLayoutCart);
            this.Controls.Add(this.flowLayoutProduct);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxmethonPayment);
            this.Controls.Add(this.btnpayment);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formOrder_FormClosing);
            this.Load += new System.EventHandler(this.formOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Button btnpayment;
        private System.Windows.Forms.ComboBox comboBoxmethonPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProductname;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCart;
        private System.Windows.Forms.TextBox txtFindProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}