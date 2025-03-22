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
            this.components = new System.ComponentModel.Container();
            this.textQRcode = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.labelAmount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textQRcode
            // 
            this.textQRcode.Location = new System.Drawing.Point(11, 102);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutProduct
            // 
            this.flowLayoutProduct.AutoScroll = true;
            this.flowLayoutProduct.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutProduct.Location = new System.Drawing.Point(11, 193);
            this.flowLayoutProduct.Name = "flowLayoutProduct";
            this.flowLayoutProduct.Size = new System.Drawing.Size(610, 234);
            this.flowLayoutProduct.TabIndex = 5;
            // 
            // labelAmount
            // 
            this.labelAmount.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelAmount.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelAmount.Location = new System.Drawing.Point(11, 131);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(610, 59);
            this.labelAmount.TabIndex = 6;
            this.labelAmount.Text = "1523899.35$";
            this.labelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.Controls.Add(this.buttonBack);
            this.panel2.Location = new System.Drawing.Point(-15, -15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 108);
            this.panel2.TabIndex = 7;
            // 
            // formCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(650, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.flowLayoutProduct);
            this.Controls.Add(this.textQRcode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formCal";
            this.Text = "formCal";
            this.Load += new System.EventHandler(this.formCal_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textQRcode;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutProduct;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Panel panel2;
    }
}