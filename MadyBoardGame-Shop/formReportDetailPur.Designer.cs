﻿namespace MadyBoardGame_Shop
{
    partial class formReportDetailPur
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textTotalPricemax = new System.Windows.Forms.TextBox();
            this.textTotalPricemin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtempIDFind = new System.Windows.Forms.TextBox();
            this.txtPurIDFind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_print_to_pdf = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_print_to_pdf);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-7, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 110);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(739, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "รายงานรายละเอียดการซื้อสินค้าในร้าน";
            // 
            // dataGridResult
            // 
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Location = new System.Drawing.Point(12, 296);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.Size = new System.Drawing.Size(1113, 272);
            this.dataGridResult.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textTotalPricemax);
            this.groupBox1.Controls.Add(this.textTotalPricemin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtempIDFind);
            this.groupBox1.Controls.Add(this.txtPurIDFind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 172);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(137, 133);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(96, 31);
            this.buttonReset.TabIndex = 12;
            this.buttonReset.Text = "รีเซ็ท";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(12, 133);
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
            this.label6.Location = new System.Drawing.Point(316, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "-";
            // 
            // textTotalPricemax
            // 
            this.textTotalPricemax.Location = new System.Drawing.Point(348, 98);
            this.textTotalPricemax.Name = "textTotalPricemax";
            this.textTotalPricemax.Size = new System.Drawing.Size(156, 29);
            this.textTotalPricemax.TabIndex = 9;
            // 
            // textTotalPricemin
            // 
            this.textTotalPricemin.Location = new System.Drawing.Point(146, 100);
            this.textTotalPricemin.Name = "textTotalPricemin";
            this.textTotalPricemin.Size = new System.Drawing.Size(156, 29);
            this.textTotalPricemin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "ช่วงราคาที่จ่าย :";
            // 
            // txtempIDFind
            // 
            this.txtempIDFind.Location = new System.Drawing.Point(169, 63);
            this.txtempIDFind.Name = "txtempIDFind";
            this.txtempIDFind.Size = new System.Drawing.Size(156, 29);
            this.txtempIDFind.TabIndex = 6;
            // 
            // txtPurIDFind
            // 
            this.txtPurIDFind.Location = new System.Drawing.Point(213, 28);
            this.txtPurIDFind.Name = "txtPurIDFind";
            this.txtPurIDFind.Size = new System.Drawing.Size(156, 29);
            this.txtPurIDFind.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "ค้นหารหัสพนักงาน :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ค้นหาเลขที่จ่ายซื้อเข้าร้าน :";
            // 
            // btn_print_to_pdf
            // 
            this.btn_print_to_pdf.Location = new System.Drawing.Point(885, 37);
            this.btn_print_to_pdf.Name = "btn_print_to_pdf";
            this.btn_print_to_pdf.Size = new System.Drawing.Size(122, 53);
            this.btn_print_to_pdf.TabIndex = 4;
            this.btn_print_to_pdf.Text = "print";
            this.btn_print_to_pdf.UseVisualStyleBackColor = true;
            this.btn_print_to_pdf.Click += new System.EventHandler(this.btn_print_to_pdf_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.IndianRed;
            this.buttonExit.Location = new System.Drawing.Point(1013, 37);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(119, 53);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "ปิด";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // formReportDetailPur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 580);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridResult);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formReportDetailPur";
            this.Text = "formReportDetailPur";
            this.Load += new System.EventHandler(this.formReportDetailPur_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textTotalPricemax;
        private System.Windows.Forms.TextBox textTotalPricemin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtempIDFind;
        private System.Windows.Forms.TextBox txtPurIDFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_print_to_pdf;
        private System.Windows.Forms.Button buttonExit;
    }
}