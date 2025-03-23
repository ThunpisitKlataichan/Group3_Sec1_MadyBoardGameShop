namespace MadyBoardGame_Shop
{
    partial class formAddProductQuality
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSupID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSupName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSupContry = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "เพิ่ม";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxSupID
            // 
            this.textBoxSupID.Location = new System.Drawing.Point(158, 164);
            this.textBoxSupID.Name = "textBoxSupID";
            this.textBoxSupID.Size = new System.Drawing.Size(100, 29);
            this.textBoxSupID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "รหัสผู้จำหน่าย";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "ชื่อผู้จัดจำหน่าย";
            // 
            // textBoxSupName
            // 
            this.textBoxSupName.Location = new System.Drawing.Point(158, 199);
            this.textBoxSupName.Name = "textBoxSupName";
            this.textBoxSupName.Size = new System.Drawing.Size(299, 29);
            this.textBoxSupName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "ประเทศ";
            // 
            // textBoxSupContry
            // 
            this.textBoxSupContry.Location = new System.Drawing.Point(158, 234);
            this.textBoxSupContry.Name = "textBoxSupContry";
            this.textBoxSupContry.Size = new System.Drawing.Size(299, 29);
            this.textBoxSupContry.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "ลบ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(343, 443);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 48);
            this.button3.TabIndex = 9;
            this.button3.Text = "เเก้ไข";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(177, 389);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(160, 48);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "บันทึก";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-9, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 112);
            this.panel1.TabIndex = 0;
            // 
            // formAddProductQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 503);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxSupContry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSupName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSupID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "formAddProductQuality";
            this.Text = "formAddProductQuality";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAddProductQuality_FormClosing);
            this.Load += new System.EventHandler(this.formAddProductQuality_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSupID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSupName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSupContry;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}