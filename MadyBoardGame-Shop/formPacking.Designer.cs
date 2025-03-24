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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxOrderdetail = new System.Windows.Forms.GroupBox();
            this.dataGridOrderDetail = new System.Windows.Forms.DataGridView();
            this.Productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxOrderdetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-22, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 119);
            this.panel1.TabIndex = 0;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.IndianRed;
            this.buttonBack.Location = new System.Drawing.Point(46, 41);
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
            this.label1.Location = new System.Drawing.Point(300, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "ยืนยันจัดส่ง";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 123);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(417, 379);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 49);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ออร์เดอร์ที่ 11 วันที่ 22/03/2568";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "ยืนยันจัดส่ง";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrderdetail
            // 
            this.groupBoxOrderdetail.Controls.Add(this.dataGridOrderDetail);
            this.groupBoxOrderdetail.Location = new System.Drawing.Point(435, 112);
            this.groupBoxOrderdetail.Name = "groupBoxOrderdetail";
            this.groupBoxOrderdetail.Size = new System.Drawing.Size(402, 390);
            this.groupBoxOrderdetail.TabIndex = 2;
            this.groupBoxOrderdetail.TabStop = false;
            this.groupBoxOrderdetail.Text = "รายละเอียดคำสั่งซื้อ";
            // 
            // dataGridOrderDetail
            // 
            this.dataGridOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Productname,
            this.Quality});
            this.dataGridOrderDetail.Location = new System.Drawing.Point(6, 28);
            this.dataGridOrderDetail.Name = "dataGridOrderDetail";
            this.dataGridOrderDetail.Size = new System.Drawing.Size(387, 150);
            this.dataGridOrderDetail.TabIndex = 0;
            // 
            // Productname
            // 
            this.Productname.HeaderText = "ชื่อสินค้า";
            this.Productname.Name = "Productname";
            this.Productname.Width = 250;
            // 
            // Quality
            // 
            this.Quality.HeaderText = "จำนวน";
            this.Quality.Name = "Quality";
            // 
            // formPacking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 514);
            this.Controls.Add(this.groupBoxOrderdetail);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formPacking";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxOrderdetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxOrderdetail;
        private System.Windows.Forms.DataGridView dataGridOrderDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quality;
    }
}