namespace MadyBoardGame_Shop
{
    partial class formCal
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
            this.textQRcode = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.flowLayoutProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.labelAmount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.comboMethodPay = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textQRcode
            // 
            this.textQRcode.Location = new System.Drawing.Point(384, 96);
            this.textQRcode.Margin = new System.Windows.Forms.Padding(6);
            this.textQRcode.Name = "textQRcode";
            this.textQRcode.Size = new System.Drawing.Size(237, 29);
            this.textQRcode.TabIndex = 0;
            this.textQRcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textQRcode.TextChanged += new System.EventHandler(this.textQRcode_TextChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonBack.Location = new System.Drawing.Point(27, 38);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(99, 44);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "กลับ";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // flowLayoutProduct
            // 
            this.flowLayoutProduct.AutoScroll = true;
            this.flowLayoutProduct.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutProduct.Location = new System.Drawing.Point(11, 193);
            this.flowLayoutProduct.Name = "flowLayoutProduct";
            this.flowLayoutProduct.Size = new System.Drawing.Size(610, 242);
            this.flowLayoutProduct.TabIndex = 5;
            // 
            // labelAmount
            // 
            this.labelAmount.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelAmount.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelAmount.Location = new System.Drawing.Point(11, 132);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(610, 59);
            this.labelAmount.TabIndex = 6;
            this.labelAmount.Text = "0.00$";
            this.labelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.Controls.Add(this.buttonBack);
            this.panel2.Location = new System.Drawing.Point(-15, -15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 108);
            this.panel2.TabIndex = 7;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.buttonConfirm.Location = new System.Drawing.Point(491, 441);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(130, 44);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "ยืนยันการซื้อ";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // comboMethodPay
            // 
            this.comboMethodPay.FormattingEnabled = true;
            this.comboMethodPay.Items.AddRange(new object[] {
            "เงินสด",
            "Truewallet",
            "Prompay"});
            this.comboMethodPay.Location = new System.Drawing.Point(327, 448);
            this.comboMethodPay.Name = "comboMethodPay";
            this.comboMethodPay.Size = new System.Drawing.Size(158, 32);
            this.comboMethodPay.TabIndex = 8;
            // 
            // formCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(653, 497);
            this.Controls.Add(this.comboMethodPay);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.flowLayoutProduct);
            this.Controls.Add(this.textQRcode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formCal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formCal";
            this.Load += new System.EventHandler(this.formCal_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textQRcode;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProduct;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.ComboBox comboMethodPay;
    }
}