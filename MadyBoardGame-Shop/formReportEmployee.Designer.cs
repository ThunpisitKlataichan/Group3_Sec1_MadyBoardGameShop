namespace MadyBoardGame_Shop
{
    partial class formReportEmployee
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
            this.btn_print_to_pdf = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxempID = new System.Windows.Forms.TextBox();
            this.textBoxempName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridResult
            // 
            this.dataGridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResult.Location = new System.Drawing.Point(8, 294);
            this.dataGridResult.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridResult.Name = "dataGridResult";
            this.dataGridResult.Size = new System.Drawing.Size(1314, 315);
            this.dataGridResult.TabIndex = 1;
            // 
            // btn_print_to_pdf
            // 
            this.btn_print_to_pdf.Location = new System.Drawing.Point(830, 146);
            this.btn_print_to_pdf.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_print_to_pdf.Name = "btn_print_to_pdf";
            this.btn_print_to_pdf.Size = new System.Drawing.Size(146, 62);
            this.btn_print_to_pdf.TabIndex = 4;
            this.btn_print_to_pdf.Text = "print";
            this.btn_print_to_pdf.UseVisualStyleBackColor = true;
            this.btn_print_to_pdf.Click += new System.EventHandler(this.btn_print_to_pdf_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-9, -17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 130);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxempName);
            this.groupBox1.Controls.Add(this.textBoxempID);
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // textBoxempID
            // 
            this.textBoxempID.Location = new System.Drawing.Point(150, 43);
            this.textBoxempID.Name = "textBoxempID";
            this.textBoxempID.Size = new System.Drawing.Size(123, 31);
            this.textBoxempID.TabIndex = 0;
            // 
            // textBoxempName
            // 
            this.textBoxempName.Location = new System.Drawing.Point(401, 43);
            this.textBoxempName.Name = "textBoxempName";
            this.textBoxempName.Size = new System.Drawing.Size(315, 31);
            this.textBoxempName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "รหัสพนักงาน :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "รายงานพนักงาน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "ชื่อพนักงาน :";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(478, 97);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(116, 47);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(600, 97);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(116, 47);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // formReportEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_print_to_pdf);
            this.Controls.Add(this.dataGridResult);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "formReportEmployee";
            this.Text = "formEmployeeReport";
            this.Load += new System.EventHandler(this.formReportEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridResult;
        private System.Windows.Forms.Button btn_print_to_pdf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxempName;
        private System.Windows.Forms.TextBox textBoxempID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReset;
    }
}