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
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.pictureUserPic = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.groupBoxCashier = new System.Windows.Forms.GroupBox();
            this.buttonCashierCal = new System.Windows.Forms.Button();
            this.groupBoxmanager = new System.Windows.Forms.GroupBox();
            this.buttonStoreInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonformEmpmange = new System.Windows.Forms.Button();
            this.btnReportTotalOrder = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupMember = new System.Windows.Forms.GroupBox();
            this.groupPacking = new System.Windows.Forms.GroupBox();
            this.buttonPacking = new System.Windows.Forms.Button();
            this.groupShipping = new System.Windows.Forms.GroupBox();
            this.buttonShippingPur = new System.Windows.Forms.Button();
            this.buttonShippingOrder = new System.Windows.Forms.Button();
            this.groupboxStock = new System.Windows.Forms.GroupBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTotalPur = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUserPic)).BeginInit();
            this.groupBoxCashier.SuspendLayout();
            this.groupBoxmanager.SuspendLayout();
            this.groupMember.SuspendLayout();
            this.groupPacking.SuspendLayout();
            this.groupShipping.SuspendLayout();
            this.groupboxStock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_stock
            // 
            this.btn_stock.Location = new System.Drawing.Point(3, 31);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(6);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(163, 45);
            this.btn_stock.TabIndex = 3;
            this.btn_stock.Text = "จัดการสินค้าสินค้า";
            this.btn_stock.UseVisualStyleBackColor = true;
            this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
            // 
            // btn_member
            // 
            this.btn_member.Location = new System.Drawing.Point(5, 31);
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
            this.btn_exit.Location = new System.Drawing.Point(633, 94);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(96, 45);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "ออก";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(193, 25);
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
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.pictureUserPic);
            this.groupBoxUser.Controls.Add(this.labelUsername);
            this.groupBoxUser.Location = new System.Drawing.Point(25, 67);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(485, 73);
            this.groupBoxUser.TabIndex = 6;
            this.groupBoxUser.TabStop = false;
            // 
            // pictureUserPic
            // 
            this.pictureUserPic.Location = new System.Drawing.Point(429, 16);
            this.pictureUserPic.Name = "pictureUserPic";
            this.pictureUserPic.Size = new System.Drawing.Size(50, 50);
            this.pictureUserPic.TabIndex = 1;
            this.pictureUserPic.TabStop = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 16);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(59, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "User :";
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.LightCoral;
            this.btn_LogOut.Location = new System.Drawing.Point(633, 47);
            this.btn_LogOut.Margin = new System.Windows.Forms.Padding(6);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(96, 45);
            this.btn_LogOut.TabIndex = 7;
            this.btn_LogOut.Text = "ล็อกเอ้าร์";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // groupBoxCashier
            // 
            this.groupBoxCashier.Controls.Add(this.buttonCashierCal);
            this.groupBoxCashier.Controls.Add(this.btn_member);
            this.groupBoxCashier.Location = new System.Drawing.Point(194, 144);
            this.groupBoxCashier.Name = "groupBoxCashier";
            this.groupBoxCashier.Size = new System.Drawing.Size(177, 207);
            this.groupBoxCashier.TabIndex = 8;
            this.groupBoxCashier.TabStop = false;
            this.groupBoxCashier.Text = "Cashier";
            // 
            // buttonCashierCal
            // 
            this.buttonCashierCal.Location = new System.Drawing.Point(5, 88);
            this.buttonCashierCal.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCashierCal.Name = "buttonCashierCal";
            this.buttonCashierCal.Size = new System.Drawing.Size(163, 45);
            this.buttonCashierCal.TabIndex = 4;
            this.buttonCashierCal.Text = "คิดเงิน";
            this.buttonCashierCal.UseVisualStyleBackColor = true;
            this.buttonCashierCal.Click += new System.EventHandler(this.buttonCashierCal_Click);
            // 
            // groupBoxmanager
            // 
            this.groupBoxmanager.Controls.Add(this.buttonStoreInfo);
            this.groupBoxmanager.Controls.Add(this.buttonformEmpmange);
            this.groupBoxmanager.Location = new System.Drawing.Point(377, 144);
            this.groupBoxmanager.Name = "groupBoxmanager";
            this.groupBoxmanager.Size = new System.Drawing.Size(171, 207);
            this.groupBoxmanager.TabIndex = 9;
            this.groupBoxmanager.TabStop = false;
            this.groupBoxmanager.Text = "Manager";
            // 
            // buttonStoreInfo
            // 
            this.buttonStoreInfo.Location = new System.Drawing.Point(3, 88);
            this.buttonStoreInfo.Margin = new System.Windows.Forms.Padding(6);
            this.buttonStoreInfo.Name = "buttonStoreInfo";
            this.buttonStoreInfo.Size = new System.Drawing.Size(163, 45);
            this.buttonStoreInfo.TabIndex = 5;
            this.buttonStoreInfo.Text = "ข้อมูลร้านค้า";
            this.buttonStoreInfo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "รายงานพนักงาน";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonformEmpmange
            // 
            this.buttonformEmpmange.Location = new System.Drawing.Point(3, 31);
            this.buttonformEmpmange.Margin = new System.Windows.Forms.Padding(6);
            this.buttonformEmpmange.Name = "buttonformEmpmange";
            this.buttonformEmpmange.Size = new System.Drawing.Size(163, 45);
            this.buttonformEmpmange.TabIndex = 3;
            this.buttonformEmpmange.Text = "จัดการพนักงาน";
            this.buttonformEmpmange.UseVisualStyleBackColor = true;
            this.buttonformEmpmange.Click += new System.EventHandler(this.buttonformEmpmange_Click);
            // 
            // btnReportTotalOrder
            // 
            this.btnReportTotalOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnReportTotalOrder.Location = new System.Drawing.Point(5, 145);
            this.btnReportTotalOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnReportTotalOrder.Name = "btnReportTotalOrder";
            this.btnReportTotalOrder.Size = new System.Drawing.Size(163, 45);
            this.btnReportTotalOrder.TabIndex = 2;
            this.btnReportTotalOrder.Text = "รายงานยอดสั่งซื้อ";
            this.btnReportTotalOrder.UseVisualStyleBackColor = true;
            this.btnReportTotalOrder.Click += new System.EventHandler(this.btnReportFrontStore_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.Location = new System.Drawing.Point(0, 31);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 45);
            this.button3.TabIndex = 1;
            this.button3.Text = "รายงานสินค้า";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupMember
            // 
            this.groupMember.Controls.Add(this.btn_Order);
            this.groupMember.Location = new System.Drawing.Point(10, 144);
            this.groupMember.Name = "groupMember";
            this.groupMember.Size = new System.Drawing.Size(173, 207);
            this.groupMember.TabIndex = 4;
            this.groupMember.TabStop = false;
            this.groupMember.Text = "Member";
            // 
            // groupPacking
            // 
            this.groupPacking.Controls.Add(this.buttonPacking);
            this.groupPacking.Location = new System.Drawing.Point(10, 357);
            this.groupPacking.Name = "groupPacking";
            this.groupPacking.Size = new System.Drawing.Size(173, 196);
            this.groupPacking.TabIndex = 10;
            this.groupPacking.TabStop = false;
            this.groupPacking.Text = "Packing";
            // 
            // buttonPacking
            // 
            this.buttonPacking.Location = new System.Drawing.Point(9, 31);
            this.buttonPacking.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPacking.Name = "buttonPacking";
            this.buttonPacking.Size = new System.Drawing.Size(163, 45);
            this.buttonPacking.TabIndex = 0;
            this.buttonPacking.Text = "จัดส่งสินค้า";
            this.buttonPacking.UseVisualStyleBackColor = true;
            this.buttonPacking.Click += new System.EventHandler(this.buttonPacking_Click);
            // 
            // groupShipping
            // 
            this.groupShipping.Controls.Add(this.buttonShippingPur);
            this.groupShipping.Controls.Add(this.buttonShippingOrder);
            this.groupShipping.Location = new System.Drawing.Point(194, 357);
            this.groupShipping.Name = "groupShipping";
            this.groupShipping.Size = new System.Drawing.Size(177, 196);
            this.groupShipping.TabIndex = 11;
            this.groupShipping.TabStop = false;
            this.groupShipping.Text = "Shipping";
            // 
            // buttonShippingPur
            // 
            this.buttonShippingPur.Location = new System.Drawing.Point(5, 88);
            this.buttonShippingPur.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShippingPur.Name = "buttonShippingPur";
            this.buttonShippingPur.Size = new System.Drawing.Size(163, 45);
            this.buttonShippingPur.TabIndex = 1;
            this.buttonShippingPur.Text = "การขนส่ง (Store)";
            this.buttonShippingPur.UseVisualStyleBackColor = true;
            this.buttonShippingPur.Click += new System.EventHandler(this.buttonShippingPur_Click);
            // 
            // buttonShippingOrder
            // 
            this.buttonShippingOrder.Location = new System.Drawing.Point(5, 31);
            this.buttonShippingOrder.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShippingOrder.Name = "buttonShippingOrder";
            this.buttonShippingOrder.Size = new System.Drawing.Size(163, 45);
            this.buttonShippingOrder.TabIndex = 0;
            this.buttonShippingOrder.Text = "การขนส่ง (Order)";
            this.buttonShippingOrder.UseVisualStyleBackColor = true;
            this.buttonShippingOrder.Click += new System.EventHandler(this.buttonShippingOrder_Click);
            // 
            // groupboxStock
            // 
            this.groupboxStock.Controls.Add(this.btnAddProduct);
            this.groupboxStock.Controls.Add(this.btnAddSupplier);
            this.groupboxStock.Controls.Add(this.btn_stock);
            this.groupboxStock.Location = new System.Drawing.Point(377, 357);
            this.groupboxStock.Name = "groupboxStock";
            this.groupboxStock.Size = new System.Drawing.Size(171, 196);
            this.groupboxStock.TabIndex = 12;
            this.groupboxStock.TabStop = false;
            this.groupboxStock.Text = "Stock";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(3, 142);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(163, 45);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "สั่งซื้อเติมสินค้า";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(3, 88);
            this.btnAddSupplier.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(163, 45);
            this.btnAddSupplier.TabIndex = 4;
            this.btnAddSupplier.Text = "เพิ่มผู้จัดจำหน่าย";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBoxUser);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_LogOut);
            this.panel1.Location = new System.Drawing.Point(-6, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 150);
            this.panel1.TabIndex = 13;
            // 
            // btnTotalPur
            // 
            this.btnTotalPur.FlatAppearance.BorderSize = 2;
            this.btnTotalPur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTotalPur.Location = new System.Drawing.Point(5, 202);
            this.btnTotalPur.Margin = new System.Windows.Forms.Padding(6);
            this.btnTotalPur.Name = "btnTotalPur";
            this.btnTotalPur.Size = new System.Drawing.Size(163, 45);
            this.btnTotalPur.TabIndex = 6;
            this.btnTotalPur.Text = "รายงานยอดซื้อของเข้า";
            this.btnTotalPur.UseVisualStyleBackColor = true;
            this.btnTotalPur.Click += new System.EventHandler(this.btnTotalPur_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnTotalPur);
            this.groupBox1.Controls.Add(this.btnReportTotalOrder);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(552, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 409);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(739, 570);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupboxStock);
            this.Controls.Add(this.groupShipping);
            this.Controls.Add(this.groupPacking);
            this.Controls.Add(this.groupMember);
            this.Controls.Add(this.groupBoxmanager);
            this.Controls.Add(this.groupBoxCashier);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mady Boardgame Store ( Employees )";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUserPic)).EndInit();
            this.groupBoxCashier.ResumeLayout(false);
            this.groupBoxmanager.ResumeLayout(false);
            this.groupMember.ResumeLayout(false);
            this.groupPacking.ResumeLayout(false);
            this.groupShipping.ResumeLayout(false);
            this.groupboxStock.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_member;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Order;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.GroupBox groupBoxCashier;
        private System.Windows.Forms.GroupBox groupBoxmanager;
        private System.Windows.Forms.Button buttonformEmpmange;
        private System.Windows.Forms.Button btnReportTotalOrder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupMember;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCashierCal;
        private System.Windows.Forms.GroupBox groupPacking;
        private System.Windows.Forms.Button buttonPacking;
        private System.Windows.Forms.GroupBox groupShipping;
        private System.Windows.Forms.Button buttonShippingOrder;
        private System.Windows.Forms.GroupBox groupboxStock;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button buttonShippingPur;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button buttonStoreInfo;
        private System.Windows.Forms.PictureBox pictureUserPic;
        private System.Windows.Forms.Button btnTotalPur;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

