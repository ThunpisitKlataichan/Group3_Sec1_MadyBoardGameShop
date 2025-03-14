namespace MadyBoardGame_Shop
{
    partial class formMain
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
            this.btn_stock = new System.Windows.Forms.Button();
            this.btn_member = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Order = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.groupBoxEmp = new System.Windows.Forms.GroupBox();
            this.groupBoxmanager = new System.Windows.Forms.GroupBox();
            this.buttonformEmpmange = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxEmp.SuspendLayout();
            this.groupBoxmanager.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_stock
            // 
            this.btn_stock.Location = new System.Drawing.Point(5, 31);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(6);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(163, 45);
            this.btn_stock.TabIndex = 3;
            this.btn_stock.Text = "คลังสินค้า";
            this.btn_stock.UseVisualStyleBackColor = true;
            this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
            // 
            // btn_member
            // 
            this.btn_member.Location = new System.Drawing.Point(5, 88);
            this.btn_member.Margin = new System.Windows.Forms.Padding(6);
            this.btn_member.Name = "btn_member";
            this.btn_member.Size = new System.Drawing.Size(163, 45);
            this.btn_member.TabIndex = 2;
            this.btn_member.Text = "จัดการสมาชิค";
            this.btn_member.UseVisualStyleBackColor = true;
            this.btn_member.Click += new System.EventHandler(this.btn_member_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.LightCoral;
            this.btn_exit.Location = new System.Drawing.Point(631, 307);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(94, 45);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "ออก";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mady BoradGame Store";
            // 
            // btn_Order
            // 
            this.btn_Order.Location = new System.Drawing.Point(9, 31);
            this.btn_Order.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Order.Name = "btn_Order";
            this.btn_Order.Size = new System.Drawing.Size(163, 45);
            this.btn_Order.TabIndex = 0;
            this.btn_Order.Text = "สั่งซื้อสินค้า";
            this.btn_Order.UseVisualStyleBackColor = true;
            this.btn_Order.Click += new System.EventHandler(this.btn_Order_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelUsername);
            this.groupBox1.Location = new System.Drawing.Point(456, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 73);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 15);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(59, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "User :";
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.LightCoral;
            this.btn_LogOut.Location = new System.Drawing.Point(525, 307);
            this.btn_LogOut.Margin = new System.Windows.Forms.Padding(6);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(94, 45);
            this.btn_LogOut.TabIndex = 7;
            this.btn_LogOut.Text = "ล็อกเอ้าร์";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // groupBoxEmp
            // 
            this.groupBoxEmp.Controls.Add(this.btn_stock);
            this.groupBoxEmp.Controls.Add(this.btn_member);
            this.groupBoxEmp.Location = new System.Drawing.Point(181, 94);
            this.groupBoxEmp.Name = "groupBoxEmp";
            this.groupBoxEmp.Size = new System.Drawing.Size(182, 204);
            this.groupBoxEmp.TabIndex = 8;
            this.groupBoxEmp.TabStop = false;
            this.groupBoxEmp.Text = "พนักงาน";
            // 
            // groupBoxmanager
            // 
            this.groupBoxmanager.Controls.Add(this.button1);
            this.groupBoxmanager.Controls.Add(this.buttonformEmpmange);
            this.groupBoxmanager.Controls.Add(this.button2);
            this.groupBoxmanager.Controls.Add(this.button3);
            this.groupBoxmanager.Location = new System.Drawing.Point(369, 94);
            this.groupBoxmanager.Name = "groupBoxmanager";
            this.groupBoxmanager.Size = new System.Drawing.Size(356, 204);
            this.groupBoxmanager.TabIndex = 9;
            this.groupBoxmanager.TabStop = false;
            this.groupBoxmanager.Text = "ผู้จัดการ";
            // 
            // buttonformEmpmange
            // 
            this.buttonformEmpmange.Location = new System.Drawing.Point(183, 145);
            this.buttonformEmpmange.Margin = new System.Windows.Forms.Padding(6);
            this.buttonformEmpmange.Name = "buttonformEmpmange";
            this.buttonformEmpmange.Size = new System.Drawing.Size(163, 45);
            this.buttonformEmpmange.TabIndex = 3;
            this.buttonformEmpmange.Text = "จัดการพนักงาน";
            this.buttonformEmpmange.UseVisualStyleBackColor = true;
            this.buttonformEmpmange.Click += new System.EventHandler(this.buttonformEmpmange_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 145);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "รายงานงบการเงิน";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.Location = new System.Drawing.Point(8, 31);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 45);
            this.button3.TabIndex = 1;
            this.button3.Text = "รายงานสินค้า";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Order);
            this.groupBox2.Location = new System.Drawing.Point(2, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 204);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "สมาชิค";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "รายงานพนักงาน";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 357);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_LogOut);
            this.Controls.Add(this.groupBoxmanager);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.groupBoxEmp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mady Boardgame Store ( Employees )";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxEmp.ResumeLayout(false);
            this.groupBoxmanager.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_member;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Order;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.GroupBox groupBoxEmp;
        private System.Windows.Forms.GroupBox groupBoxmanager;
        private System.Windows.Forms.Button buttonformEmpmange;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

