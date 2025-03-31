namespace MadyBoardGame_Shop
{
    partial class formReportProfit
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
            this.btn_print_to_pdf = new System.Windows.Forms.Button();
            this.dataGridResult = new System.Windows.Forms.DataGridView();
            this.textBoxProfit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboDateTypeSelect = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_print_to_pdf);
            this.panel1.Location = new System.Drawing.Point(-11, -23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 135);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(47, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "รายงานกำไรสุทธิ";
            // 
            // btn_print_to_pdf
            // 
            this.btn_print_to_pdf.Location = new System.Drawing.Point(833, 54);
            this.btn_print_to_pdf.Name = "btn_print_to_pdf";
            this.btn_print_to_pdf.Size = new System.Drawing.Size(122, 70);
            this.btn_print_to_pdf.TabIndex = 5;
            this.btn_print_to_pdf.Text = "print";
            this.btn_print_to_pdf.UseVisualStyleBackColor = true;
            this.btn_print_to_pdf.Click += new System.EventHandler(this.btn_print_to_pdf_Click);
            // 
            // dataGridResult
            // 
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Location = new System.Drawing.Point(12, 267);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.Size = new System.Drawing.Size(1088, 272);
            this.dataGridResult.TabIndex = 6;
            // 
            // textBoxProfit
            // 
            this.textBoxProfit.Location = new System.Drawing.Point(889, 574);
            this.textBoxProfit.Name = "textBoxProfit";
            this.textBoxProfit.Size = new System.Drawing.Size(211, 29);
            this.textBoxProfit.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(779, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "กำไรสุทธิ :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonFind);
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Controls.Add(this.dateTimeEnd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimeStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboDateTypeSelect);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 143);
            this.panel2.TabIndex = 9;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(550, 111);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(135, 29);
            this.buttonFind.TabIndex = 7;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(550, 68);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(135, 29);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(279, 100);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 29);
            this.dateTimeEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "วันที่สิ้นสุด";
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(17, 100);
            this.dateTimeStart.MaxDate = new System.DateTime(2025, 3, 27, 0, 0, 0, 0);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 29);
            this.dateTimeStart.TabIndex = 3;
            this.dateTimeStart.Value = new System.DateTime(2025, 3, 27, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "วันที่เริ่มต้น";
            // 
            // comboDateTypeSelect
            // 
            this.comboDateTypeSelect.FormattingEnabled = true;
            this.comboDateTypeSelect.Items.AddRange(new object[] {
            "รายวัน",
            "รายเดือน",
            "รายปี"});
            this.comboDateTypeSelect.Location = new System.Drawing.Point(17, 38);
            this.comboDateTypeSelect.Name = "comboDateTypeSelect";
            this.comboDateTypeSelect.Size = new System.Drawing.Size(205, 32);
            this.comboDateTypeSelect.TabIndex = 1;
            this.comboDateTypeSelect.SelectedIndexChanged += new System.EventHandler(this.comboDateTypeSelect_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "ช่วงเวลาที่ต้องการ";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.IndianRed;
            this.buttonExit.Location = new System.Drawing.Point(961, 54);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(126, 70);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "ปิด";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // formReportProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 615);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProfit);
            this.Controls.Add(this.dataGridResult);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formReportProfit";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formReportProfit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_print_to_pdf;
        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.TextBox textBoxProfit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDateTypeSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonExit;
    }
}