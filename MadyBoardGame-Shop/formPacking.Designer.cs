namespace MadyBoardGame_Shop
{
    partial class formPacking
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPackOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxOrderdetail = new System.Windows.Forms.GroupBox();
            this.dataGridOrderDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBoxOrderdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-22, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 119);
            this.panel1.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.IndianRed;
            this.buttonBack.Location = new System.Drawing.Point(44, 53);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(69, 39);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "กลับ";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(141, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "ยืนยันจัดส่ง";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPackOrder
            // 
            this.flowLayoutPackOrder.AutoScroll = true;
            this.flowLayoutPackOrder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.flowLayoutPackOrder.Location = new System.Drawing.Point(12, 123);
            this.flowLayoutPackOrder.Name = "flowLayoutPackOrder";
            this.flowLayoutPackOrder.Size = new System.Drawing.Size(417, 379);
            this.flowLayoutPackOrder.TabIndex = 1;
            // 
            // groupBoxOrderdetail
            // 
            this.groupBoxOrderdetail.Controls.Add(this.dataGridOrderDetails);
            this.groupBoxOrderdetail.Location = new System.Drawing.Point(435, 112);
            this.groupBoxOrderdetail.Name = "groupBoxOrderdetail";
            this.groupBoxOrderdetail.Size = new System.Drawing.Size(625, 390);
            this.groupBoxOrderdetail.TabIndex = 2;
            this.groupBoxOrderdetail.TabStop = false;
            this.groupBoxOrderdetail.Text = "รายละเอียดคำสั่งซื้อ";
            this.groupBoxOrderdetail.Enter += new System.EventHandler(this.groupBoxOrderdetail_Enter);
            // 
            // dataGridOrderDetails
            // 
            this.dataGridOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderDetails.Location = new System.Drawing.Point(6, 28);
            this.dataGridOrderDetails.Name = "dataGridOrderDetails";
            this.dataGridOrderDetails.Size = new System.Drawing.Size(613, 281);
            this.dataGridOrderDetails.TabIndex = 0;
            // 
            // formPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 514);
            this.Controls.Add(this.groupBoxOrderdetail);
            this.Controls.Add(this.flowLayoutPackOrder);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formPacking";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formPacking_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxOrderdetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPackOrder;
        private System.Windows.Forms.GroupBox groupBoxOrderdetail;
        private System.Windows.Forms.DataGridView dataGridOrderDetails;
    }
}