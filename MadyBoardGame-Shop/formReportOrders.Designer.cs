namespace MadyBoardGame_Shop
{
    partial class formReportOrders
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
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textTotalPricemac = new System.Windows.Forms.TextBox();
            this.textTotalPricemin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmemIDFind = new System.Windows.Forms.TextBox();
            this.txtOrderFind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridResult
            // 
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Location = new System.Drawing.Point(12, 305);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.Size = new System.Drawing.Size(1122, 231);
            this.dataGridResult.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-15, -14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 125);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(702, 73);
            this.label2.TabIndex = 1;
            this.label2.Text = "รายงานรายละเอียดคำสั่งซื้อ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(84, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 42);
            this.label1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textTotalPricemac);
            this.groupBox1.Controls.Add(this.textTotalPricemin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtmemIDFind);
            this.groupBox1.Controls.Add(this.txtOrderFind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(19, 145);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(96, 31);
            this.buttonFind.TabIndex = 11;
            this.buttonFind.Text = "ค้นหา";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "-";
            // 
            // textTotalPricemac
            // 
            this.textTotalPricemac.Location = new System.Drawing.Point(371, 101);
            this.textTotalPricemac.Name = "textTotalPricemac";
            this.textTotalPricemac.Size = new System.Drawing.Size(156, 29);
            this.textTotalPricemac.TabIndex = 9;
            this.textTotalPricemac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalPricemac_KeyPress);
            // 
            // textTotalPricemin
            // 
            this.textTotalPricemin.Location = new System.Drawing.Point(166, 101);
            this.textTotalPricemin.Name = "textTotalPricemin";
            this.textTotalPricemin.Size = new System.Drawing.Size(156, 29);
            this.textTotalPricemin.TabIndex = 8;
            this.textTotalPricemin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTotalPricemin_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "ช่วงราคาคำสั่งซื้อ :";
            // 
            // txtmemIDFind
            // 
            this.txtmemIDFind.Location = new System.Drawing.Point(166, 63);
            this.txtmemIDFind.Name = "txtmemIDFind";
            this.txtmemIDFind.Size = new System.Drawing.Size(156, 29);
            this.txtmemIDFind.TabIndex = 6;
            this.txtmemIDFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmemIDFind_KeyPress);
            // 
            // txtOrderFind
            // 
            this.txtOrderFind.Location = new System.Drawing.Point(166, 28);
            this.txtOrderFind.Name = "txtOrderFind";
            this.txtOrderFind.Size = new System.Drawing.Size(156, 29);
            this.txtOrderFind.TabIndex = 3;
            this.txtOrderFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderFind_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "ค้นหาเลขที่สมาชิค :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ค้นหาเลขที่คำสั่งซื้อ :";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(144, 145);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(96, 31);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "รีเซ็ท";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // formReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formReportOrders";
            this.Text = "formReportOrders";
            this.Load += new System.EventHandler(this.formReportOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOrderFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmemIDFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textTotalPricemac;
        private System.Windows.Forms.TextBox textTotalPricemin;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonReset;
    }
}