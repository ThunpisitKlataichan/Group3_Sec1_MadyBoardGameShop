namespace MadyBoardGame_Shop
{
    partial class formEmployeeManage
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
            this.btnBack = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_LName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_Phone_Emp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_location = new System.Windows.Forms.TextBox();
            this.dataGrid_Emp = new System.Windows.Forms.DataGridView();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_DOB = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.text_Salary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Emp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 103);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBack.Location = new System.Drawing.Point(17, 38);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(82, 38);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(779, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "ค้นหา : ";
            // 
            // textSearch
            // 
            this.textSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.textSearch.Location = new System.Drawing.Point(854, 66);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(226, 29);
            this.textSearch.TabIndex = 5;
            this.textSearch.Text = "Search";
            this.textSearch.Click += new System.EventHandler(this.textSearch_Click);
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(108, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "การจัดการพนักงาน";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_edit);
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_del);
            this.panel2.Location = new System.Drawing.Point(-5, 499);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1102, 64);
            this.panel2.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_cancel.Location = new System.Drawing.Point(281, 12);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(82, 38);
            this.btn_cancel.TabIndex = 20;
            this.btn_cancel.Text = "ยกเลิก";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_edit.Location = new System.Drawing.Point(193, 12);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(82, 38);
            this.btn_edit.TabIndex = 21;
            this.btn_edit.Text = "เเก้ไข";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_Add.Location = new System.Drawing.Point(17, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(82, 38);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.Text = "เพิ่ม";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_save.Location = new System.Drawing.Point(105, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(82, 38);
            this.btn_save.TabIndex = 18;
            this.btn_save.Text = "บันทึก";
            this.btn_save.UseVisualStyleBackColor = false;
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_del.Location = new System.Drawing.Point(369, 12);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(82, 38);
            this.btn_del.TabIndex = 19;
            this.btn_del.Text = "ลบ";
            this.btn_del.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(12, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 176);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "ชื่อ :";
            // 
            // text_Name
            // 
            this.text_Name.Location = new System.Drawing.Point(276, 109);
            this.text_Name.Name = "text_Name";
            this.text_Name.Size = new System.Drawing.Size(300, 29);
            this.text_Name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(654, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "นามสกุล :";
            // 
            // text_LName
            // 
            this.text_LName.Location = new System.Drawing.Point(775, 106);
            this.text_LName.Name = "text_LName";
            this.text_LName.Size = new System.Drawing.Size(280, 29);
            this.text_LName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "วันเกิด :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "ตำเเหน่ง :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "เบอร์โทร : ";
            // 
            // text_Phone_Emp
            // 
            this.text_Phone_Emp.Location = new System.Drawing.Point(285, 213);
            this.text_Phone_Emp.Name = "text_Phone_Emp";
            this.text_Phone_Emp.Size = new System.Drawing.Size(291, 29);
            this.text_Phone_Emp.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "ที่อยู่ : ";
            // 
            // text_location
            // 
            this.text_location.Location = new System.Drawing.Point(257, 253);
            this.text_location.Multiline = true;
            this.text_location.Name = "text_location";
            this.text_location.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_location.Size = new System.Drawing.Size(319, 108);
            this.text_location.TabIndex = 15;
            // 
            // dataGrid_Emp
            // 
            this.dataGrid_Emp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Emp.Location = new System.Drawing.Point(594, 187);
            this.dataGrid_Emp.Name = "dataGrid_Emp";
            this.dataGrid_Emp.Size = new System.Drawing.Size(461, 267);
            this.dataGrid_Emp.TabIndex = 16;
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Items.AddRange(new object[] {
            "เจ้าหน้าที่ขนส่ง",
            "เจ้าหน้าที่บัญชี",
            "เจ้าหน้าที่คลังสินค้า",
            "เจ้าหน้าที่บริการลูกค้า",
            "ผู้จัดการ",
            "เจ้าหน้าที่จัดส่งสินค้า"});
            this.comboBoxPosition.Location = new System.Drawing.Point(775, 141);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(280, 32);
            this.comboBoxPosition.TabIndex = 17;
            // 
            // dateTimePicker_DOB
            // 
            this.dateTimePicker_DOB.Location = new System.Drawing.Point(276, 141);
            this.dateTimePicker_DOB.Name = "dateTimePicker_DOB";
            this.dateTimePicker_DOB.Size = new System.Drawing.Size(299, 29);
            this.dateTimePicker_DOB.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "เงินเดือน :";
            // 
            // text_Salary
            // 
            this.text_Salary.Location = new System.Drawing.Point(286, 178);
            this.text_Salary.Name = "text_Salary";
            this.text_Salary.Size = new System.Drawing.Size(160, 29);
            this.text_Salary.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "Username :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(149, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 24);
            this.label11.TabIndex = 21;
            this.label11.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(256, 428);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 29);
            this.txtPassword.TabIndex = 23;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(256, 383);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 29);
            this.txtUsername.TabIndex = 24;
            // 
            // formEmployeeManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 560);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.text_Salary);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxPosition);
            this.Controls.Add(this.dataGrid_Emp);
            this.Controls.Add(this.text_location);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text_Phone_Emp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_DOB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_LName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formEmployeeManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formEmployeeManage";
            this.Load += new System.EventHandler(this.formEmployeeManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Emp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_LName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_Phone_Emp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_location;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.DataGridView dataGrid_Emp;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DOB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_Salary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.ComboBox comboBoxPosition;
    }
}