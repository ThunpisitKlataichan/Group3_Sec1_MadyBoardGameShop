using System;
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
    public partial class formRegis : Form
    {
        public formRegis()
        {
            InitializeComponent();
        }
        SqlConnection regisconnection;
        SqlCommand regiscommand;
        SqlDataAdapter regisadapter;
        DataTable regisdatatable;
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TextBoxNotNullRight())
                {
                    return;
                }
                //ดึงค่าจาก TextBox และ Trim ช่องว่าง
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string confirmPassword = txtConPassword.Text;

                //เช็ครหัสผ่านว่าตรงกันหรือไม่
                if (password != confirmPassword)
                {
                    MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    return;
                }

                //ตรวจสอบว่า Username ซ้ำหรือไม่
                if (!ValidateData(username))
                {
                    MessageBox.Show("Username นี้ถูกใช้ไปแล้ว กรุณาใช้ชื่ออื่น");
                    return;
                }
                //ตรวจสอบว่า ข้อความช่องต่าง ๆ กรอกได้ถูกต้อง
                
                using (regisconnection = new SqlConnection(InitializeUser._key_con))
                {
                    regisconnection.Open();
                    
                    //ส่งข้อมูลไป Table MemberUsername
                    string commandprom = "INSERT INTO MemberUsername (Username, Password) VALUES (@username, @password)"; 
                    using (regiscommand = new SqlCommand(commandprom, regisconnection))
                    {
                        regiscommand.Parameters.AddWithValue("@username", username);
                        regiscommand.Parameters.AddWithValue("@password", password);
                        regiscommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("ลงทะเบียนสำเร็จ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ส่งข้อมูลไม่สำเร็จ: " + ex.Message);
            }
        }
        private bool TextBoxNotNullRight()
        {
            string warningstring = "";
            bool checklist = false;
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                warningstring += "กรุณากรอกชื่อจริง\n";
            }
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                warningstring += "กรุณากรอกนามสกุล\n";
            }
            if (string.IsNullOrEmpty(txtPhoneNum.Text.Trim()))
            {
                warningstring += "กรุณากรอกเบอร์โทรศัพท์\n";
            }
            if (string.IsNullOrEmpty(txtIdentityNum.Text.Trim()))
            {
                warningstring += "กรุณากรอกรหัสบัตรประชาชน\n";
            }
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                warningstring += "กรุณากรอก Username";
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                warningstring += "กรุณากรอกรหัสผ่าน\n";
            }
            if (string.IsNullOrEmpty(txtConPassword.Text))
            {
                warningstring += "กรุณายืนยันรหัสผ่าน\n";
            }
            if (!checklist)
            {
                MessageBox.Show(warningstring);
            }
            return checklist;
        }
        private bool ValidateData(string username)
        {
            try
            {
                string commandprom = "SELECT Username FROM MemberUsername WHERE Username = @username;";

                using (regisconnection = new SqlConnection(InitializeUser._key_con))
                {
                    regisconnection.Open();

                    using (regiscommand = new SqlCommand(commandprom, regisconnection))
                    {
                        regiscommand.Parameters.AddWithValue("@username", username);

                        using (SqlDataAdapter regisadapter = new SqlDataAdapter(regiscommand))
                        {
                            DataTable regisdatatable = new DataTable();
                            regisadapter.Fill(regisdatatable);

                            if (regisdatatable.Rows.Count > 0)
                            {
                                return false; //Username ซ้ำ
                            }
                        }
                    }
                }

                return true; //Username ใช้ได้
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                return false;
            }
        }

        private void formRegis_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
        }
        
    }
}
