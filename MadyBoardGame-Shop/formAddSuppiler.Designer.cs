namespace MadyBoardGame_Shop
{
    partial class formAddSuppiler
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.textBoxSupContry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSupName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSupID = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dataGrid_Suppiler = new System.Windows.Forms.DataGridView();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Suppiler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-65, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 112);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(114, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "ผู้จัดจำหน่าย";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(41, 424);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(99, 48);
            this.btn_save.TabIndex = 21;
            this.btn_save.Text = "บันทึก";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(237, 356);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(99, 48);
            this.btn_edit.TabIndex = 20;
            this.btn_edit.Text = "เเก้ไข";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(294, 424);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(99, 48);
            this.btn_del.TabIndex = 19;
            this.btn_del.Text = "ลบ";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // textBoxSupContry
            // 
            this.textBoxSupContry.Location = new System.Drawing.Point(146, 262);
            this.textBoxSupContry.Name = "textBoxSupContry";
            this.textBoxSupContry.Size = new System.Drawing.Size(247, 29);
            this.textBoxSupContry.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "ประเทศ";
            // 
            // textBoxSupName
            // 
            this.textBoxSupName.Location = new System.Drawing.Point(146, 214);
            this.textBoxSupName.Name = "textBoxSupName";
            this.textBoxSupName.Size = new System.Drawing.Size(247, 29);
            this.textBoxSupName.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "ชื่อผู้จัดจำหน่าย";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "รหัสผู้จำหน่าย";
            // 
            // textBoxSupID
            // 
            this.textBoxSupID.Location = new System.Drawing.Point(146, 164);
            this.textBoxSupID.Name = "textBoxSupID";
            this.textBoxSupID.Size = new System.Drawing.Size(100, 29);
            this.textBoxSupID.TabIndex = 13;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(98, 356);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(99, 48);
            this.btn_Add.TabIndex = 12;
            this.btn_Add.Text = "เพิ่ม";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dataGrid_Suppiler
            // 
            this.dataGrid_Suppiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Suppiler.Location = new System.Drawing.Point(451, 139);
            this.dataGrid_Suppiler.Name = "dataGrid_Suppiler";
            this.dataGrid_Suppiler.Size = new System.Drawing.Size(409, 333);
            this.dataGrid_Suppiler.TabIndex = 22;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(167, 424);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(99, 48);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "ยกเลิก";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "ค้นหาชื่อผู้จัดจำหน่าย : ";
            // 
            // textSearch
            // 
            this.textSearch.ForeColor = System.Drawing.Color.Black;
            this.textSearch.Location = new System.Drawing.Point(689, 43);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(226, 29);
            this.textSearch.TabIndex = 20;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // formAddSuppiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 500);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.dataGrid_Suppiler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.textBoxSupContry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSupName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSupID);
            this.Controls.Add(this.btn_Add);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "formAddSuppiler";
            this.Text = "formAddSuppiler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAddSuppiler_FormClosing);
            this.Load += new System.EventHandler(this.formAddSuppiler_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Suppiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.TextBox textBoxSupContry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSupID;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dataGrid_Suppiler;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textSearch;
    }
}