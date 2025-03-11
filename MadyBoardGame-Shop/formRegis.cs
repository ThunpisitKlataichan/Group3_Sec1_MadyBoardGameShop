using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formRegis : Form

    {  
        private string[] _arProvinces = null;
        private string[][] _arDistricts = null;
        private string[][][] _arSubDistricts = null;
        private string[][][] _arPostcodes = null;
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
                string location = "เลขที่อยู่" + textCusHouseNumber.Text + "หมู่ที่" + textCusMoo.Text + "ซอย" + textCusSoi.Text
                                   + "ถนน" + textCusRoad.Text + "จังหวัด" + comboBoxProvince.Text + "อำเภอ/เขต" + comboBoxDistrict.Text
                                   + "ตำบล/แขวง" + comboBoxSubDistrict.Text + "รหัสไปรษณีย์" + textCusPostalCode.Text;
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
            if (string.IsNullOrWhiteSpace(textCusHouseNumber.Text))
            {
                warningstring.AppendLine("กรุณากรอกเลขที่อยู่");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(textCusMoo.Text))
            {
                warningstring.AppendLine("กรุณากรอกหมู่");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(textCusSoi.Text))
            {
                warningstring.AppendLine("กรุณากรอกซอย");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(textCusRoad.Text))
            {
                warningstring.AppendLine("กรุณากรอกชื่อถนน");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxProvince.Text))
            {
                warningstring.AppendLine("กรุณาเลือกจังหวัด");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxDistrict.Text))
            {
                warningstring.AppendLine("กรุณาเลือกอำเภอ/เขต");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxSubDistrict.Text))
            {
                warningstring.AppendLine("กรุณาเลือกตำบล/แขวง");
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
                string commandprom = "SELECT MemberUsername.Username , EmpUsername.Username FROM MemberUsername , EmpUsername " +
                    "WHERE MemberUsername.Username = @username or EmpUsername.Username = @username;";

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
            AddressUtil.ReadAddressInfoFromCSVFile("ProvinceDistrictSubDis.csv", ref _arProvinces, ref _arDistricts, ref _arSubDistricts, ref _arPostcodes);
            if (_arProvinces != null)
            {
                comboBoxProvince.Items.AddRange(_arProvinces);
            }
            //addItemProvince();
            if (File.Exists("ProvinceDistrictSubDis.csv"))
                MessageBox.Show("found");
            else
                MessageBox.Show("Not found");

        }

        private void comboBoxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            int provinceIndex = comboBoxProvince.SelectedIndex;
            if (provinceIndex >= 0 && _arDistricts != null)
            {
                comboBoxDistrict.Text = "";
                comboBoxSubDistrict.Text = "";
                textCusPostalCode.Text = "";
                // อัปเดตรายการอำเภอใน ComboBox

                comboBoxDistrict.Items.Clear();
                comboBoxDistrict.Items.AddRange(_arDistricts[provinceIndex]);


                // ล้างข้อมูลใน ComboBox 

            }
        }

        private void comboBoxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int provinceIndex = comboBoxProvince.SelectedIndex;
            int districtIndex = comboBoxDistrict.SelectedIndex;
            if (provinceIndex >= 0 && districtIndex >= 0 && _arSubDistricts != null)
            {
                // อัปเดตรายการตำบลใน ComboBox

                comboBoxSubDistrict.Items.Clear();
                comboBoxSubDistrict.Items.AddRange(_arSubDistricts[provinceIndex][districtIndex]);

            }
        }

        private void comboBoxSubDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int provinceIndex = comboBoxProvince.SelectedIndex;
            int districtIndex = comboBoxDistrict.SelectedIndex;
            int subDistrictIndex = comboBoxSubDistrict.SelectedIndex;
            if (provinceIndex >= 0 && districtIndex >= 0 && subDistrictIndex >= 0 && _arPostcodes != null)
            {
                // อัปเดตรายการรหัสไปรษณีย์ใน ComboBox
                textCusPostalCode.Text = _arPostcodes[provinceIndex][districtIndex][subDistrictIndex];
            }
        }
    }
}
