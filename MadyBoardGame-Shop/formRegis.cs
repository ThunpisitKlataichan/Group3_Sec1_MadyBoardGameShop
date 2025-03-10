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
                string name = txtName.Text.Trim();
                string lname = txtLastName.Text.Trim();
                string idennum = txtIdentityNum.Text.Trim();
                string phone = txtPhoneNum.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string confirmPassword = txtConPassword.Text;
                DateTime dateregis = DateTime.Now;

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
                    string commandprom1 = "INSERT INTO MemberUsername (Username, Password) VALUES (@username, @password)";
                    string commandprom2 = "INSERT INTO Member (mem_Name, mem_LName, mem_IdentityNum, Username, mem_Phone , emp_IDregis , mem_RegisDate) " +
                        "VALUES (@name, @lastname, @idennum, @username, @phonenum , 1 , @dateregis)";
                    using (regiscommand = new SqlCommand(commandprom1, regisconnection)) 
                    {
                        regiscommand.Parameters.AddWithValue("@username", username);
                        regiscommand.Parameters.AddWithValue("@password", password);
                        regiscommand.ExecuteNonQuery();
                    }
                    //ส่งข้อมูลไป Table Member
                    using (regiscommand = new SqlCommand(commandprom2 , regisconnection))
                    {
                        regiscommand.Parameters.AddWithValue("@name" , name);
                        regiscommand.Parameters.AddWithValue("@lastname" , lname);
                        regiscommand.Parameters.AddWithValue("@idennum", idennum);
                        regiscommand.Parameters.AddWithValue("@username" , username);
                        regiscommand.Parameters.AddWithValue("@phonenum" , phone);
                        regiscommand.Parameters.AddWithValue("@dateregis", dateregis);
                        
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
            StringBuilder warningstring = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                warningstring.AppendLine("กรุณากรอกชื่อจริง");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                warningstring.AppendLine("กรุณากรอกนามสกุล");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNum.Text))
            {
                warningstring.AppendLine("กรุณากรอกเบอร์โทรศัพท์");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtIdentityNum.Text))
            {
                warningstring.AppendLine("กรุณากรอกรหัสบัตรประชาชน");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                warningstring.AppendLine("กรุณากรอก Username");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                warningstring.AppendLine("กรุณากรอกรหัสผ่าน");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtConPassword.Text))
            {
                warningstring.AppendLine("กรุณายืนยันรหัสผ่าน");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(warningstring.ToString());
            }

            return isValid;
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
