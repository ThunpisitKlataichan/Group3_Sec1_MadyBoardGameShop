﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formShippingPur : Form
    {
        public formShippingPur()
        {
            InitializeComponent();
        }
        SqlConnection shippurconnection;
        SqlCommand shippurcommand;
        SqlDataAdapter shippuradapter;
        DataTable shippurtable;
        private void formShippingPur_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            shippurconnection = new SqlConnection(InitializeUser._key_con);
            shippurconnection.Open();
            LoadData();
        }
        private void LoadData()
        {
            string command = @"
                SELECT ShippingPurID , ShippingStatus , ShippingDate  , empID , PurID
                FROM ShippingPur WHERE ShippingStatus != 'เติมสินค้าสำเร็จ'
                ORDER BY CASE ShippingStatus
                            WHEN 'เตรียมการไปรับสินค้า' THEN 1
                            WHEN 'เดินทางไปรับสินค้า' THEN 2
                            WHEN 'เติมสินค้าสำเร็จ' THEN 3 
                         ELSE 5
                        END ASC ,
                        empID;";
            shippurcommand = new SqlCommand(command, shippurconnection);
            shippuradapter = new SqlDataAdapter(shippurcommand);
            shippurtable = new DataTable();
            shippuradapter.Fill(shippurtable);

            for (int i = 0; i < shippurtable.Rows.Count; i++)
            {
                Panel panel = new Panel();
                panel.Size = new Size(540, 85);
                panel.Tag = shippurtable.Rows[i]["PurID"];
                panel.BackColor = Color.White;

                Label labelshippingIDTitle = new Label();
                labelshippingIDTitle.Text = "รหัสขนส่งที่ : ";
                labelshippingIDTitle.Location = new Point(3, 3);
                labelshippingIDTitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelshippingIDTitle.AutoSize = true;

                Label labelshippingID = new Label();
                labelshippingID.Text = shippurtable.Rows[i]["ShippingPurID"].ToString();
                labelshippingID.Location = new Point(150, 3);
                labelshippingID.AutoSize = true;

                Label labelrespontitle = new Label();
                labelrespontitle.Text = "รหัสผู้ขนส่ง : ";
                labelrespontitle.Location = new Point(3, 30);
                labelrespontitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelrespontitle.AutoSize = true;

                Label labelrespon = new Label();
                labelrespon.Text = shippurtable.Rows[i]["empID"].ToString();
                labelrespon.Location = new Point(120, 30);
                labelrespon.AutoSize = true;
                if (labelrespon.Text == "" || labelrespon.Text == null || labelrespon.Text == "0")
                {
                    labelrespon.Text = "-";
                }

                Label labelDateTitle = new Label();
                labelDateTitle.Text = "สถานะอัพเดตล่าสุด : ";
                labelDateTitle.Location = new Point(3, 55);
                labelDateTitle.AutoSize = true;
                labelDateTitle.Font = new Font("Arial", 14, FontStyle.Bold);

                Label labelDate = new Label();
                labelDate.Text = shippurtable.Rows[i]["ShippingDate"].ToString();
                labelDate.Location = new Point(170, 55);
                labelDate.AutoSize = true;
                switch (labelDate.Text)
                {
                    case "":
                        labelDate.Text = "ยังไม่มีการอัพเดต";
                        break;
                    default:
                        labelDate.Text = Convert.ToDateTime(labelDate.Text).ToString("dd/MM/yyyy HH:mm:ss");
                        break;
                }

                Label labelStatusTitle = new Label();
                labelStatusTitle.Text = "สถานะขนส่ง : ";
                labelStatusTitle.Location = new Point(200, 3);
                labelStatusTitle.Font = new Font("Arial", 14, FontStyle.Bold);
                labelStatusTitle.AutoSize = true;

                ComboBox comboboxStasus = new ComboBox();
                comboboxStasus.Items.Add("เตรียมการไปรับสินค้า");
                comboboxStasus.Items.Add("เดินทางไปรับสินค้า");
                comboboxStasus.Items.Add("เติมสินค้าสำเร็จ");
                comboboxStasus.Location = new Point(310, 3);
                comboboxStasus.Size = new Size(200, 32);
                comboboxStasus.SelectedItem = shippurtable.Rows[i]["ShippingStatus"].ToString();
                switch (comboboxStasus.SelectedItem)
                {
                    case "เตรียมการไปรับสินค้า":
                        panel.BackColor = Color.AliceBlue;
                        break;
                    case "เดินทางไปรับสินค้า":
                        panel.BackColor = Color.LightYellow;
                        break;
                    case "เติมสินค้าสำเร็จ":
                        panel.BackColor = Color.LightGreen;
                        break;
                }

                panel.Controls.Add(labelshippingIDTitle);
                panel.Controls.Add(labelshippingID);
                panel.Controls.Add(labelDateTitle);
                panel.Controls.Add(labelDate);
                panel.Controls.Add(labelStatusTitle);
                panel.Controls.Add(comboboxStasus);
                panel.Controls.Add(labelrespontitle);
                panel.Controls.Add(labelrespon);
                panel.Click += Panal_click;

                flowLayoutShippur.Controls.Add(panel);
            }
        }
        private void Panal_click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            string purID = panel.Tag.ToString();
            string shipID = panel.Controls[1].Text;
            string command = @"
                                	SELECT 
                                        sp.ShippingPurID, 
                                        p.ProductID, 
                                        p.ProductName, 
                                        pd.Quality, 
                                        s.SuppilerID, 
                                        s.SuppilerName, 
                                        s.SuppilerCoutry
                                    FROM 
                                        ShippingPur sp
                                        JOIN Purchasing pu ON sp.PurID = pu.PurID
                                        JOIN PurchaseDetail pd ON pu.PurID = pd.PurID
                                        JOIN Products p ON pd.ProductID = p.ProductID
                                        JOIN Suppilers s ON p.SuppilersID = s.SuppilerID
                                    WHERE sp.ShippingPurID = @shipID";
            using (SqlConnection detailconnection = new SqlConnection(InitializeUser._key_con))
            {
                detailconnection.Open();
                SqlCommand detailcommand = new SqlCommand(command, detailconnection);
                detailcommand.Parameters.AddWithValue("@shipID", shipID);
                SqlDataAdapter detailadapter = new SqlDataAdapter(detailcommand);
                DataTable detailtable = new DataTable();
                detailadapter.Fill(detailtable);

                dataGridDetails.DataSource = detailtable;
                dataGridDetails.Columns["ShippingPurID"].Visible = false;
                dataGridDetails.Columns["SuppilerID"].Visible = false;
                dataGridDetails.Columns["SuppilerName"].Visible = false;
                dataGridDetails.Columns["SuppilerCoutry"].Visible = false;

                dataGridDetails.Columns["ProductID"].HeaderText = "รหัสสินค้า";
                dataGridDetails.Columns["ProductName"].HeaderText = "ชื่อสินค้า";
                dataGridDetails.Columns["Quality"].HeaderText = "จำนวนสินค้า";

                dataGridDetails.Columns["ProductID"].Width = 100;
                dataGridDetails.Columns["ProductName"].Width = 280;
                dataGridDetails.Columns["Quality"].Width = 100;

                dataGridDetails.RowTemplate.Height = 50;
                 
                dataGridDetails.Columns["ProductID"].ReadOnly = true;
                dataGridDetails.Columns["ProductName"].ReadOnly = true;
                dataGridDetails.Columns["Quality"].ReadOnly = true;
            }
        }
        private void dataGridDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridDetails.Rows[e.RowIndex];
                string suppilerID = row.Cells["SuppilerID"].Value.ToString();
                string suppilerName = row.Cells["SuppilerName"].Value.ToString();
                string suppilerCountry = row.Cells["SuppilerCoutry"].Value.ToString();

                textBoxShipID.Text = row.Cells["ShippingPurID"].Value.ToString();
                textBoxProductID.Text = row.Cells["ProductID"].Value.ToString();
                textBoxProductName.Text = row.Cells["ProductName"].Value.ToString();
                textBoxQuality.Text = row.Cells["Quality"].Value.ToString();
                textBoxSuppilerID.Text = suppilerID;
                textBoxSuppilerName.Text = suppilerName;
                textBoxSuppilerCountry.Text = suppilerCountry;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการบันทึกข้อมูลใช่หรือไม่", "ยืนยัน", MessageBoxButtons.YesNo , MessageBoxIcon.Question)== DialogResult.No)
            {   
                return;
            }
            try
            {
                foreach (Control control in flowLayoutShippur.Controls)
                {
                    Panel panel = (Panel)control;
                    ComboBox combobox = (ComboBox)panel.Controls[5];
                    string shipID = panel.Controls[1].Text;
                    string status = combobox.SelectedItem.ToString();
                    string command = @"
                                        UPDATE ShippingPur
                                        SET 
                                            ShippingStatus = @status , 
                                            empID = @empID , 
                                            ShippingDate = GETDATE()
                                        WHERE 
                                            ShippingPurID = @shipID AND
                                            (empID is NULL or empID = @empID)";
                    shippurcommand = new SqlCommand(command, shippurconnection);
                    shippurcommand.Parameters.AddWithValue("@status", status);
                    shippurcommand.Parameters.AddWithValue("@shipID", shipID);
                    shippurcommand.Parameters.AddWithValue("@empID", InitializeUser.UserID);
                    shippurcommand.ExecuteNonQuery();
                    int rowsAffected = shippurcommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        // Handle case where no rows were updated
                        throw new Exception("No records were updated. Possible reasons: Invalid ShippingPurID or empID mismatch.");
                    }
                    if (status == "เติมสินค้าสำเร็จ")
                    {
                        command = @"
                                    SELECT 
                                        sp.ShippingPurID, 
                                        p.ProductID, 
                                        p.ProductName, 
                                        pd.Quality, 
                                        s.SuppilerID, 
                                        s.SuppilerName, 
                                        s.SuppilerCoutry
                                    FROM 
                                        ShippingPur sp
                                        JOIN Purchasing pu ON sp.PurID = pu.PurID
                                        JOIN PurchaseDetail pd ON pu.PurID = pd.PurID
                                        JOIN Products p ON pd.ProductID = p.ProductID
                                        JOIN Suppilers s ON p.SuppilersID = s.SuppilerID
                                    WHERE 
                                        sp.ShippingPurID = @shipID AND
                                        (sp.empID is NULL or sp.empID = @empID)";
                        shippurcommand = new SqlCommand(command, shippurconnection);
                        shippurcommand.Parameters.AddWithValue("@shipID", shipID);
                        shippurcommand.Parameters.AddWithValue("@empID", InitializeUser.UserID);
                        shippuradapter = new SqlDataAdapter(shippurcommand);
                        DataTable dataTable = new DataTable();
                        shippuradapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string productID = dataTable.Rows[i]["ProductID"].ToString();
                            string quality = dataTable.Rows[i]["Quality"].ToString();

                            command = @"
                                    UPDATE Products
                                    SET Quality = Quality + @quality
                                    WHERE ProductID = @productID";

                            using (SqlCommand productupdatequality = new SqlCommand(command, shippurconnection))
                            {
                                productupdatequality.Parameters.AddWithValue("@productID", productID);
                                productupdatequality.Parameters.AddWithValue("@quality", quality);
                                productupdatequality.ExecuteNonQuery();
                            }
                        }
                    }
                }
                MessageBox.Show("บันทึกข้อมูลสำเร็จ" , "สำเร็จ" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                flowLayoutShippur.Controls.Clear();
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("บันทึกข้อมูลไม่สำเร็จ Error : " + ex , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
