﻿namespace MadyBoardGame_Shop
{
    partial class formShippingOrder
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
            this.flowLayoutShipList = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxShipID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxmemFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOrderID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPostCode = new System.Windows.Forms.TextBox();
            this.dataGridDetail = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxOIDSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSIDSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSIDSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxOIDSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-12, -16);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1429, 112);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "การขนส่งสินค้า";
            // 
            // flowLayoutShipList
            // 
            this.flowLayoutShipList.AutoScroll = true;
            this.flowLayoutShipList.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutShipList.Location = new System.Drawing.Point(12, 120);
            this.flowLayoutShipList.Name = "flowLayoutShipList";
            this.flowLayoutShipList.Size = new System.Drawing.Size(548, 356);
            this.flowLayoutShipList.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(516, 307);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(305, 62);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "บันทึกสถานะจัดส่ง";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.dataGridDetail);
            this.groupBox1.Controls.Add(this.textBoxPostCode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxOrderID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxShipID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxmemFullName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(566, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 369);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดการขนส่ง";
            // 
            // textBoxShipID
            // 
            this.textBoxShipID.BackColor = System.Drawing.Color.White;
            this.textBoxShipID.Location = new System.Drawing.Point(110, 41);
            this.textBoxShipID.Name = "textBoxShipID";
            this.textBoxShipID.ReadOnly = true;
            this.textBoxShipID.Size = new System.Drawing.Size(84, 29);
            this.textBoxShipID.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "รหัสขนส่ง :";
            // 
            // textBoxmemFullName
            // 
            this.textBoxmemFullName.BackColor = System.Drawing.Color.White;
            this.textBoxmemFullName.Location = new System.Drawing.Point(78, 115);
            this.textBoxmemFullName.Name = "textBoxmemFullName";
            this.textBoxmemFullName.ReadOnly = true;
            this.textBoxmemFullName.Size = new System.Drawing.Size(290, 29);
            this.textBoxmemFullName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "ชื่อผู้รับ :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 24);
            this.label8.TabIndex = 10;
            this.label8.Text = "เลขที่ออร์เดอร์ :";
            // 
            // textBoxOrderID
            // 
            this.textBoxOrderID.BackColor = System.Drawing.Color.White;
            this.textBoxOrderID.Location = new System.Drawing.Point(127, 76);
            this.textBoxOrderID.Name = "textBoxOrderID";
            this.textBoxOrderID.ReadOnly = true;
            this.textBoxOrderID.Size = new System.Drawing.Size(241, 29);
            this.textBoxOrderID.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "รหัสไปรษณีย์ :";
            // 
            // textBoxPostCode
            // 
            this.textBoxPostCode.BackColor = System.Drawing.Color.White;
            this.textBoxPostCode.Location = new System.Drawing.Point(127, 150);
            this.textBoxPostCode.Name = "textBoxPostCode";
            this.textBoxPostCode.ReadOnly = true;
            this.textBoxPostCode.Size = new System.Drawing.Size(170, 29);
            this.textBoxPostCode.TabIndex = 13;
            // 
            // dataGridDetail
            // 
            this.dataGridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDetail.Location = new System.Drawing.Point(374, 41);
            this.dataGridDetail.Name = "dataGridDetail";
            this.dataGridDetail.Size = new System.Drawing.Size(447, 260);
            this.dataGridDetail.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "รายละเอียดออร์เดอร์ :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 62);
            this.button1.TabIndex = 17;
            this.button1.Text = "ปิด";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxOIDSearch
            // 
            this.textBoxOIDSearch.Location = new System.Drawing.Point(641, 80);
            this.textBoxOIDSearch.Name = "textBoxOIDSearch";
            this.textBoxOIDSearch.Size = new System.Drawing.Size(180, 29);
            this.textBoxOIDSearch.TabIndex = 1;
            this.textBoxOIDSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "เลขที่ออร์เดอร์ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "เลขที่ออร์เดอร์ :";
            // 
            // textBoxSIDSearch
            // 
            this.textBoxSIDSearch.Location = new System.Drawing.Point(366, 80);
            this.textBoxSIDSearch.Name = "textBoxSIDSearch";
            this.textBoxSIDSearch.Size = new System.Drawing.Size(148, 29);
            this.textBoxSIDSearch.TabIndex = 10;
            this.textBoxSIDSearch.TextChanged += new System.EventHandler(this.textBoxSIDSearch_TextChanged);
            // 
            // formShippingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutShipList);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formShippingOrder";
            this.Text = "formShippingOrder";
            this.Load += new System.EventHandler(this.formShippingOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutShipList;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxmemFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxShipID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOrderID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPostCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridDetail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOIDSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSIDSearch;
    }
}