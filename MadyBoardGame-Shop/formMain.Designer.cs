﻿namespace MadyBoardGame_Shop
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
            this.buttonformEmpmange = new System.Windows.Forms.Button();
            this.buttonReportEmp = new System.Windows.Forms.Button();
            this.btnReportTotalOrder = new System.Windows.Forms.Button();
            this.buttonReportProduct = new System.Windows.Forms.Button();
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
            this.groupBoxReportStore = new System.Windows.Forms.GroupBox();
            this.buttonReportSuppiler = new System.Windows.Forms.Button();
            this.buttonReportOrders = new System.Windows.Forms.Button();
            this.buttonReportProfit = new System.Windows.Forms.Button();
            this.groupBoxReportProfit = new System.Windows.Forms.GroupBox();
            this.buttonReportDetailPur = new System.Windows.Forms.Button();
            this.groupBoxUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUserPic)).BeginInit();
            this.groupBoxCashier.SuspendLayout();
            this.groupBoxmanager.SuspendLayout();
            this.groupMember.SuspendLayout();
            this.groupPacking.SuspendLayout();
            this.groupShipping.SuspendLayout();
            this.groupboxStock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxReportStore.SuspendLayout();
            this.groupBoxReportProfit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_stock
            // 
            this.btn_stock.BackColor = System.Drawing.Color.Transparent;
            this.btn_stock.Location = new System.Drawing.Point(3, 31);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(6);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(163, 45);
            this.btn_stock.TabIndex = 3;
            this.btn_stock.Text = "จัดการสินค้าสินค้า";
            this.btn_stock.UseVisualStyleBackColor = false;
            this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
            // 
            // btn_member
            // 
            this.btn_member.BackColor = System.Drawing.Color.Transparent;
            this.btn_member.Location = new System.Drawing.Point(5, 31);
            this.btn_member.Margin = new System.Windows.Forms.Padding(6);
            this.btn_member.Name = "btn_member";
            this.btn_member.Size = new System.Drawing.Size(163, 45);
            this.btn_member.TabIndex = 2;
            this.btn_member.Text = "จัดการสมาชิค";
            this.btn_member.UseVisualStyleBackColor = false;
            this.btn_member.Click += new System.EventHandler(this.btn_member_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.LightCoral;
            this.btn_exit.Location = new System.Drawing.Point(630, 106);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(6);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(96, 40);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "ออก";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(162, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mady Store";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_Order
            // 
            this.btn_Order.BackColor = System.Drawing.Color.Transparent;
            this.btn_Order.Location = new System.Drawing.Point(9, 31);
            this.btn_Order.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Order.Name = "btn_Order";
            this.btn_Order.Size = new System.Drawing.Size(163, 45);
            this.btn_Order.TabIndex = 0;
            this.btn_Order.Text = "สั่งซื้อสินค้า";
            this.btn_Order.UseVisualStyleBackColor = false;
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
            this.pictureUserPic.Click += new System.EventHandler(this.pictureUserPic_Click);
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
            this.btn_LogOut.Location = new System.Drawing.Point(630, 54);
            this.btn_LogOut.Margin = new System.Windows.Forms.Padding(6);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(96, 40);
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
            this.buttonCashierCal.BackColor = System.Drawing.Color.Transparent;
            this.buttonCashierCal.Location = new System.Drawing.Point(5, 88);
            this.buttonCashierCal.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCashierCal.Name = "buttonCashierCal";
            this.buttonCashierCal.Size = new System.Drawing.Size(163, 45);
            this.buttonCashierCal.TabIndex = 4;
            this.buttonCashierCal.Text = "คิดเงิน";
            this.buttonCashierCal.UseVisualStyleBackColor = false;
            this.buttonCashierCal.Click += new System.EventHandler(this.buttonCashierCal_Click);
            // 
            // groupBoxmanager
            // 
            this.groupBoxmanager.Controls.Add(this.buttonformEmpmange);
            this.groupBoxmanager.Location = new System.Drawing.Point(377, 144);
            this.groupBoxmanager.Name = "groupBoxmanager";
            this.groupBoxmanager.Size = new System.Drawing.Size(171, 207);
            this.groupBoxmanager.TabIndex = 9;
            this.groupBoxmanager.TabStop = false;
            this.groupBoxmanager.Text = "Manager";
            // 
            // buttonformEmpmange
            // 
            this.buttonformEmpmange.BackColor = System.Drawing.Color.Transparent;
            this.buttonformEmpmange.Location = new System.Drawing.Point(3, 31);
            this.buttonformEmpmange.Margin = new System.Windows.Forms.Padding(6);
            this.buttonformEmpmange.Name = "buttonformEmpmange";
            this.buttonformEmpmange.Size = new System.Drawing.Size(163, 45);
            this.buttonformEmpmange.TabIndex = 3;
            this.buttonformEmpmange.Text = "จัดการพนักงาน";
            this.buttonformEmpmange.UseVisualStyleBackColor = false;
            this.buttonformEmpmange.Click += new System.EventHandler(this.buttonformEmpmange_Click);
            // 
            // buttonReportEmp
            // 
            this.buttonReportEmp.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportEmp.Location = new System.Drawing.Point(9, 31);
            this.buttonReportEmp.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportEmp.Name = "buttonReportEmp";
            this.buttonReportEmp.Size = new System.Drawing.Size(163, 45);
            this.buttonReportEmp.TabIndex = 4;
            this.buttonReportEmp.Text = "รายงานพนักงาน";
            this.buttonReportEmp.UseVisualStyleBackColor = false;
            this.buttonReportEmp.Click += new System.EventHandler(this.buttonReportEmp_Click);
            // 
            // btnReportTotalOrder
            // 
            this.btnReportTotalOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnReportTotalOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnReportTotalOrder.Location = new System.Drawing.Point(201, 31);
            this.btnReportTotalOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnReportTotalOrder.Name = "btnReportTotalOrder";
            this.btnReportTotalOrder.Size = new System.Drawing.Size(163, 45);
            this.btnReportTotalOrder.TabIndex = 2;
            this.btnReportTotalOrder.Text = "รายงานยอดสั่งซื้อ";
            this.btnReportTotalOrder.UseVisualStyleBackColor = false;
            this.btnReportTotalOrder.Click += new System.EventHandler(this.btnReportFrontStore_Click);
            // 
            // buttonReportProduct
            // 
            this.buttonReportProduct.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportProduct.FlatAppearance.BorderSize = 2;
            this.buttonReportProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportProduct.Location = new System.Drawing.Point(9, 88);
            this.buttonReportProduct.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportProduct.Name = "buttonReportProduct";
            this.buttonReportProduct.Size = new System.Drawing.Size(163, 45);
            this.buttonReportProduct.TabIndex = 1;
            this.buttonReportProduct.Text = "รายงานสินค้า";
            this.buttonReportProduct.UseVisualStyleBackColor = false;
            this.buttonReportProduct.Click += new System.EventHandler(this.buttonReportProduct_Click);
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
            this.groupPacking.Size = new System.Drawing.Size(173, 222);
            this.groupPacking.TabIndex = 10;
            this.groupPacking.TabStop = false;
            this.groupPacking.Text = "Packing";
            // 
            // buttonPacking
            // 
            this.buttonPacking.BackColor = System.Drawing.Color.Transparent;
            this.buttonPacking.Location = new System.Drawing.Point(9, 31);
            this.buttonPacking.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPacking.Name = "buttonPacking";
            this.buttonPacking.Size = new System.Drawing.Size(163, 45);
            this.buttonPacking.TabIndex = 0;
            this.buttonPacking.Text = "จัดส่งสินค้า";
            this.buttonPacking.UseVisualStyleBackColor = false;
            this.buttonPacking.Click += new System.EventHandler(this.buttonPacking_Click);
            // 
            // groupShipping
            // 
            this.groupShipping.Controls.Add(this.buttonShippingPur);
            this.groupShipping.Controls.Add(this.buttonShippingOrder);
            this.groupShipping.Location = new System.Drawing.Point(194, 357);
            this.groupShipping.Name = "groupShipping";
            this.groupShipping.Size = new System.Drawing.Size(177, 222);
            this.groupShipping.TabIndex = 11;
            this.groupShipping.TabStop = false;
            this.groupShipping.Text = "Shipping";
            // 
            // buttonShippingPur
            // 
            this.buttonShippingPur.BackColor = System.Drawing.Color.Transparent;
            this.buttonShippingPur.Location = new System.Drawing.Point(5, 88);
            this.buttonShippingPur.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShippingPur.Name = "buttonShippingPur";
            this.buttonShippingPur.Size = new System.Drawing.Size(163, 45);
            this.buttonShippingPur.TabIndex = 1;
            this.buttonShippingPur.Text = "การขนส่ง (Store)";
            this.buttonShippingPur.UseVisualStyleBackColor = false;
            this.buttonShippingPur.Click += new System.EventHandler(this.buttonShippingPur_Click);
            // 
            // buttonShippingOrder
            // 
            this.buttonShippingOrder.BackColor = System.Drawing.Color.Transparent;
            this.buttonShippingOrder.Location = new System.Drawing.Point(5, 31);
            this.buttonShippingOrder.Margin = new System.Windows.Forms.Padding(6);
            this.buttonShippingOrder.Name = "buttonShippingOrder";
            this.buttonShippingOrder.Size = new System.Drawing.Size(163, 45);
            this.buttonShippingOrder.TabIndex = 0;
            this.buttonShippingOrder.Text = "การขนส่ง (Order)";
            this.buttonShippingOrder.UseVisualStyleBackColor = false;
            this.buttonShippingOrder.Click += new System.EventHandler(this.buttonShippingOrder_Click);
            // 
            // groupboxStock
            // 
            this.groupboxStock.Controls.Add(this.btnAddProduct);
            this.groupboxStock.Controls.Add(this.btnAddSupplier);
            this.groupboxStock.Controls.Add(this.btn_stock);
            this.groupboxStock.Location = new System.Drawing.Point(377, 357);
            this.groupboxStock.Name = "groupboxStock";
            this.groupboxStock.Size = new System.Drawing.Size(171, 222);
            this.groupboxStock.TabIndex = 12;
            this.groupboxStock.TabStop = false;
            this.groupboxStock.Text = "Stock";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnAddProduct.Location = new System.Drawing.Point(3, 142);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(163, 45);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "สั่งซื้อเติมสินค้า";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSupplier.Location = new System.Drawing.Point(3, 88);
            this.btnAddSupplier.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(163, 45);
            this.btnAddSupplier.TabIndex = 4;
            this.btnAddSupplier.Text = "เพิ่มผู้จัดจำหน่าย";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBoxUser);
            this.panel1.Controls.Add(this.btn_LogOut);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Location = new System.Drawing.Point(-6, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 150);
            this.panel1.TabIndex = 13;
            // 
            // btnTotalPur
            // 
            this.btnTotalPur.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalPur.FlatAppearance.BorderSize = 2;
            this.btnTotalPur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTotalPur.Location = new System.Drawing.Point(9, 32);
            this.btnTotalPur.Margin = new System.Windows.Forms.Padding(6);
            this.btnTotalPur.Name = "btnTotalPur";
            this.btnTotalPur.Size = new System.Drawing.Size(163, 45);
            this.btnTotalPur.TabIndex = 6;
            this.btnTotalPur.Text = "รายงานการสั่งซื้อสินค้าร้าน";
            this.btnTotalPur.UseVisualStyleBackColor = false;
            this.btnTotalPur.Click += new System.EventHandler(this.btnTotalPur_Click);
            // 
            // groupBoxReportStore
            // 
            this.groupBoxReportStore.Controls.Add(this.buttonReportProduct);
            this.groupBoxReportStore.Controls.Add(this.buttonReportSuppiler);
            this.groupBoxReportStore.Controls.Add(this.buttonReportEmp);
            this.groupBoxReportStore.Location = new System.Drawing.Point(552, 144);
            this.groupBoxReportStore.Name = "groupBoxReportStore";
            this.groupBoxReportStore.Size = new System.Drawing.Size(197, 207);
            this.groupBoxReportStore.TabIndex = 14;
            this.groupBoxReportStore.TabStop = false;
            this.groupBoxReportStore.Text = "Report Store";
            // 
            // buttonReportSuppiler
            // 
            this.buttonReportSuppiler.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportSuppiler.FlatAppearance.BorderSize = 2;
            this.buttonReportSuppiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportSuppiler.Location = new System.Drawing.Point(9, 145);
            this.buttonReportSuppiler.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportSuppiler.Name = "buttonReportSuppiler";
            this.buttonReportSuppiler.Size = new System.Drawing.Size(163, 45);
            this.buttonReportSuppiler.TabIndex = 8;
            this.buttonReportSuppiler.Text = "รายงานผู้จัดจำหน่าย";
            this.buttonReportSuppiler.UseVisualStyleBackColor = false;
            this.buttonReportSuppiler.Click += new System.EventHandler(this.buttonReportSuppiler_Click);
            // 
            // buttonReportOrders
            // 
            this.buttonReportOrders.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportOrders.FlatAppearance.BorderSize = 2;
            this.buttonReportOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportOrders.Location = new System.Drawing.Point(201, 88);
            this.buttonReportOrders.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportOrders.Name = "buttonReportOrders";
            this.buttonReportOrders.Size = new System.Drawing.Size(163, 45);
            this.buttonReportOrders.TabIndex = 9;
            this.buttonReportOrders.Text = "รายงานรายละเอียดยอดสั่งซื้อ";
            this.buttonReportOrders.UseVisualStyleBackColor = false;
            this.buttonReportOrders.Click += new System.EventHandler(this.buttonReportOrders_Click);
            // 
            // buttonReportProfit
            // 
            this.buttonReportProfit.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportProfit.FlatAppearance.BorderSize = 2;
            this.buttonReportProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportProfit.Location = new System.Drawing.Point(201, 142);
            this.buttonReportProfit.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportProfit.Name = "buttonReportProfit";
            this.buttonReportProfit.Size = new System.Drawing.Size(163, 45);
            this.buttonReportProfit.TabIndex = 7;
            this.buttonReportProfit.Text = "รายงานกำไรสุทธิ";
            this.buttonReportProfit.UseVisualStyleBackColor = false;
            this.buttonReportProfit.Click += new System.EventHandler(this.buttonReportProfit_Click);
            // 
            // groupBoxReportProfit
            // 
            this.groupBoxReportProfit.Controls.Add(this.buttonReportDetailPur);
            this.groupBoxReportProfit.Controls.Add(this.btnTotalPur);
            this.groupBoxReportProfit.Controls.Add(this.btnReportTotalOrder);
            this.groupBoxReportProfit.Controls.Add(this.buttonReportProfit);
            this.groupBoxReportProfit.Controls.Add(this.buttonReportOrders);
            this.groupBoxReportProfit.Location = new System.Drawing.Point(552, 357);
            this.groupBoxReportProfit.Name = "groupBoxReportProfit";
            this.groupBoxReportProfit.Size = new System.Drawing.Size(395, 222);
            this.groupBoxReportProfit.TabIndex = 15;
            this.groupBoxReportProfit.TabStop = false;
            this.groupBoxReportProfit.Text = "Report Profit And Spend";
            // 
            // buttonReportDetailPur
            // 
            this.buttonReportDetailPur.BackColor = System.Drawing.Color.Transparent;
            this.buttonReportDetailPur.FlatAppearance.BorderSize = 2;
            this.buttonReportDetailPur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonReportDetailPur.Location = new System.Drawing.Point(9, 88);
            this.buttonReportDetailPur.Margin = new System.Windows.Forms.Padding(6);
            this.buttonReportDetailPur.Name = "buttonReportDetailPur";
            this.buttonReportDetailPur.Size = new System.Drawing.Size(163, 45);
            this.buttonReportDetailPur.TabIndex = 10;
            this.buttonReportDetailPur.Text = "รายงานรายละเอัยดสั่งซื้อสินค้าร้าน";
            this.buttonReportDetailPur.UseVisualStyleBackColor = false;
            this.buttonReportDetailPur.Click += new System.EventHandler(this.buttonReportDetailPur_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(960, 593);
            this.Controls.Add(this.groupBoxReportProfit);
            this.Controls.Add(this.groupBoxReportStore);
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
            this.groupBoxReportStore.ResumeLayout(false);
            this.groupBoxReportProfit.ResumeLayout(false);
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
        private System.Windows.Forms.Button buttonReportProduct;
        private System.Windows.Forms.GroupBox groupMember;
        private System.Windows.Forms.Button buttonReportEmp;
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
        private System.Windows.Forms.PictureBox pictureUserPic;
        private System.Windows.Forms.Button btnTotalPur;
        private System.Windows.Forms.GroupBox groupBoxReportStore;
        private System.Windows.Forms.Button buttonReportProfit;
        private System.Windows.Forms.Button buttonReportSuppiler;
        private System.Windows.Forms.Button buttonReportOrders;
        private System.Windows.Forms.GroupBox groupBoxReportProfit;
        private System.Windows.Forms.Button buttonReportDetailPur;
    }
}

