namespace MadyBoardGame_Shop
{
    partial class formAddProductQuality
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
            this.buttonPur = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.buttonAddlist = new System.Windows.Forms.Button();
            this.flowLayoutListProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxSupp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxProCost = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonexit = new System.Windows.Forms.Button();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelProname = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labelSupName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelCostPrice = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.labelQuality = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPur
            // 
            this.buttonPur.Location = new System.Drawing.Point(688, 664);
            this.buttonPur.Name = "buttonPur";
            this.buttonPur.Size = new System.Drawing.Size(150, 34);
            this.buttonPur.TabIndex = 1;
            this.buttonPur.Text = "ยืนยันสั่งซื้อสินค้า";
            this.buttonPur.UseVisualStyleBackColor = true;
            this.buttonPur.Click += new System.EventHandler(this.buttonPur_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "รหัสสินค้า";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ชื่อสินค้า";
            // 
            // textBoxProID
            // 
            this.textBoxProID.Location = new System.Drawing.Point(450, 139);
            this.textBoxProID.Name = "textBoxProID";
            this.textBoxProID.Size = new System.Drawing.Size(94, 29);
            this.textBoxProID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ผู้จัดจำหน่าย";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(720, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "สั่งซื้อเติมสินค้าเข้าร้านค้า MadyStore";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-18, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 112);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(114, 174);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(195, 32);
            this.comboBoxProduct.TabIndex = 13;
            this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // buttonAddlist
            // 
            this.buttonAddlist.Location = new System.Drawing.Point(184, 212);
            this.buttonAddlist.Name = "buttonAddlist";
            this.buttonAddlist.Size = new System.Drawing.Size(163, 33);
            this.buttonAddlist.TabIndex = 14;
            this.buttonAddlist.Text = "เพิ่มเข้ารายการ ++";
            this.buttonAddlist.UseVisualStyleBackColor = true;
            this.buttonAddlist.Click += new System.EventHandler(this.buttonAddlist_Click);
            // 
            // flowLayoutListProduct
            // 
            this.flowLayoutListProduct.AutoScroll = true;
            this.flowLayoutListProduct.Location = new System.Drawing.Point(12, 251);
            this.flowLayoutListProduct.Name = "flowLayoutListProduct";
            this.flowLayoutListProduct.Size = new System.Drawing.Size(551, 447);
            this.flowLayoutListProduct.TabIndex = 15;
            // 
            // comboBoxSupp
            // 
            this.comboBoxSupp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSupp.FormattingEnabled = true;
            this.comboBoxSupp.Location = new System.Drawing.Point(114, 136);
            this.comboBoxSupp.Name = "comboBoxSupp";
            this.comboBoxSupp.Size = new System.Drawing.Size(244, 32);
            this.comboBoxSupp.TabIndex = 14;
            this.comboBoxSupp.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupp_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "ราคาขาย";
            // 
            // textBoxProCost
            // 
            this.textBoxProCost.Location = new System.Drawing.Point(392, 177);
            this.textBoxProCost.Name = "textBoxProCost";
            this.textBoxProCost.Size = new System.Drawing.Size(152, 29);
            this.textBoxProCost.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 226);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 24);
            this.label19.TabIndex = 19;
            this.label19.Text = "รายการ";
            // 
            // buttonexit
            // 
            this.buttonexit.Location = new System.Drawing.Point(688, 622);
            this.buttonexit.Name = "buttonexit";
            this.buttonexit.Size = new System.Drawing.Size(150, 36);
            this.buttonexit.TabIndex = 10;
            this.buttonexit.Text = "ปิด";
            this.buttonexit.UseVisualStyleBackColor = true;
            this.buttonexit.Click += new System.EventHandler(this.buttonexit_Click);
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(6, 28);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(257, 176);
            this.pictureBoxProduct.TabIndex = 1;
            this.pictureBoxProduct.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(2, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "ชื่อ";
            // 
            // labelProname
            // 
            this.labelProname.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelProname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelProname.Location = new System.Drawing.Point(34, 220);
            this.labelProname.Name = "labelProname";
            this.labelProname.Size = new System.Drawing.Size(218, 23);
            this.labelProname.TabIndex = 7;
            this.labelProname.Text = "Lego a POP";
            this.labelProname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(2, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "ผู้จำหน่าย";
            // 
            // labelSupName
            // 
            this.labelSupName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelSupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelSupName.Location = new System.Drawing.Point(74, 250);
            this.labelSupName.Name = "labelSupName";
            this.labelSupName.Size = new System.Drawing.Size(189, 48);
            this.labelSupName.TabIndex = 9;
            this.labelSupName.Text = "Marvel Cop.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(0, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 10;
            this.label15.Text = "ราคาต้นทุน";
            // 
            // labelCostPrice
            // 
            this.labelCostPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelCostPrice.Location = new System.Drawing.Point(78, 319);
            this.labelCostPrice.Name = "labelCostPrice";
            this.labelCostPrice.Size = new System.Drawing.Size(135, 20);
            this.labelCostPrice.TabIndex = 11;
            this.labelCostPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.Location = new System.Drawing.Point(219, 319);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 20);
            this.label17.TabIndex = 6;
            this.label17.Text = "฿";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.labelQuality);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.labelPrice);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.labelCostPrice);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.labelSupName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.labelProname);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.pictureBoxProduct);
            this.groupBox1.Location = new System.Drawing.Point(569, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 479);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดสินค้า";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(219, 382);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(27, 20);
            this.label23.TabIndex = 17;
            this.label23.Text = "ชิ้น";
            // 
            // labelQuality
            // 
            this.labelQuality.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelQuality.Location = new System.Drawing.Point(115, 382);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(98, 20);
            this.labelQuality.TabIndex = 16;
            this.labelQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(13, 382);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 20);
            this.label21.TabIndex = 15;
            this.label21.Text = "จำนวนคงเหลือ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(219, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "฿";
            // 
            // labelPrice
            // 
            this.labelPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPrice.Location = new System.Drawing.Point(78, 353);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(135, 20);
            this.labelPrice.TabIndex = 14;
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(13, 353);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 20);
            this.label20.TabIndex = 13;
            this.label20.Text = "ราคาขาย";
            // 
            // formAddProductQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 710);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxProCost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxSupp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutListProduct);
            this.Controls.Add(this.buttonAddlist);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.buttonexit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxProID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPur);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formAddProductQuality";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formAddProductQuality";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAddProductQuality_FormClosing);
            this.Load += new System.EventHandler(this.formAddProductQuality_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Button buttonAddlist;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutListProduct;
        private System.Windows.Forms.ComboBox comboBoxSupp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxProCost;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button buttonexit;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelProname;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelSupName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelCostPrice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.Label label21;
    }
}