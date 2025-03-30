namespace MadyBoardGame_Shop
{
    partial class formReportTotalPur
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSumPur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonRedate = new System.Windows.Forms.Button();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDateTypeSelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(-3, -5);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 114);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "รายงานค่าใช้จ่ายในการซื้อสินค้า";
            // 
            // dataGridResult
            // 
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Location = new System.Drawing.Point(20, 260);
            this.dataGridResult.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.Size = new System.Drawing.Size(1098, 260);
            this.dataGridResult.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 560);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "ค่าใช้จ่ายในการซื้อทั้งหมด :";
            // 
            // textBoxSumPur
            // 
            this.textBoxSumPur.Location = new System.Drawing.Point(802, 557);
            this.textBoxSumPur.Name = "textBoxSumPur";
            this.textBoxSumPur.Size = new System.Drawing.Size(261, 29);
            this.textBoxSumPur.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1077, 560);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "บาท";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dateTimeEnd);
            this.panel2.Controls.Add(this.buttonFind);
            this.panel2.Controls.Add(this.buttonRedate);
            this.panel2.Controls.Add(this.dateTimeStart);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboDateTypeSelect);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(20, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 143);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "วันที่สิ้นสุด";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(271, 100);
            this.dateTimeEnd.MaxDate = new System.DateTime(2025, 3, 30, 0, 0, 0, 0);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(205, 29);
            this.dateTimeEnd.TabIndex = 8;
            this.dateTimeEnd.Value = new System.DateTime(2025, 3, 27, 0, 0, 0, 0);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(590, 102);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(135, 29);
            this.buttonFind.TabIndex = 7;
            this.buttonFind.Text = "ค้นหา";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonRedate
            // 
            this.buttonRedate.Location = new System.Drawing.Point(590, 67);
            this.buttonRedate.Name = "buttonRedate";
            this.buttonRedate.Size = new System.Drawing.Size(135, 29);
            this.buttonRedate.TabIndex = 6;
            this.buttonRedate.Text = "Refrash Date";
            this.buttonRedate.UseVisualStyleBackColor = true;
            this.buttonRedate.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(17, 100);
            this.dateTimeStart.MaxDate = new System.DateTime(2025, 3, 30, 0, 0, 0, 0);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(205, 29);
            this.dateTimeStart.TabIndex = 3;
            this.dateTimeStart.Value = new System.DateTime(2025, 3, 27, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "วันที่เริ่มต้น";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "ช่วงเวลาที่ต้องการ";
            // 
            // formReportTotalPur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 593);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSumPur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridResult);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "formReportTotalPur";
            this.Text = "formReportPur";
            this.Load += new System.EventHandler(this.formReportPur_Load);
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
        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSumPur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRedate;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDateTypeSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label4;
    }
}