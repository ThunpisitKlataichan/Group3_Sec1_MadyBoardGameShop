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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
        SqlConnection loginConnection;
        SqlCommand loginCommand;
        SqlDataAdapter loginAdapter;
        DataTable logintable;
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (loginConnection = new SqlConnection(InitializeUser._key_con))
                {
                    loginConnection.Open();

                    // Check employee login first
                    string employeeQuery = @"SELECT EmpUsername.Username, Password, empID, empName, empLName, empPosition 
                                                FROM EmpUsername
                                                INNER JOIN Employees ON Employees.Username = EmpUsername.Username
                                                WHERE EmpUsername.Username = @username 
                                                AND Password = @password";

                    using (loginCommand = new SqlCommand(employeeQuery, loginConnection))
                    {
                        loginCommand.Parameters.AddWithValue("@username", txt_Username.Text.Trim().ToLower());
                        loginCommand.Parameters.AddWithValue("@password", txt_Password.Text.Trim());


                        using (loginAdapter = new SqlDataAdapter(loginCommand))
                        {
                            DataTable loginTable = new DataTable();
                            loginAdapter.Fill(loginTable);

                            if (loginTable.Rows.Count > 0)
                            {
                                InitializeUser.UserState = loginTable.Rows[0]["empPosition"].ToString();
                                InitializeUser.UserNameLogin = loginTable.Rows[0]["empName"].ToString();
                                InitializeUser.UserLastNameLogin = loginTable.Rows[0]["empLName"].ToString();
                                InitializeUser.UserID = loginTable.Rows[0]["empID"].ToString();
                                InitializeUser.Userusername = loginTable.Rows[0]["Username"].ToString();


                                formMain mainForm = new formMain();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Dispose();
                                return;
                            }
                        }
                    }

                    // Check member login if employee login failed
                    string memberQuery = @"SELECT MemberUsername.Username, memID, memName, memLName, memLock 
                              FROM MemberUsername, Member 
                              WHERE MemberUsername.Username = @username 
                              AND Password = @password 
                              AND MemberUsername.Username = Member.Username";

                    using (loginCommand = new SqlCommand(memberQuery, loginConnection))
                    {
                        loginCommand.Parameters.AddWithValue("@username", txt_Username.Text.Trim().ToLower());
                        loginCommand.Parameters.AddWithValue("@password", txt_Password.Text.Trim());

                        using (loginAdapter = new SqlDataAdapter(loginCommand))
                        {
                            DataTable memberTable = new DataTable();
                            loginAdapter.Fill(memberTable);

                            if (memberTable.Rows.Count > 0)
                            {
                                // Check if account is locked
                                bool isLocked = Convert.ToBoolean(memberTable.Rows[0]["memLock"]);

                                if (isLocked)
                                {
                                    MessageBox.Show("บัญชีผู้ใช้นี้ถูกระงับการใช้งาน กรุณาติดต่อผู้ดูแลระบบ");
                                    return;
                                }

                                InitializeUser.UserState = "Member";
                                InitializeUser.Userusername = memberTable.Rows[0]["Username"].ToString();
                                InitializeUser.UserNameLogin = memberTable.Rows[0]["memName"].ToString();
                                InitializeUser.UserLastNameLogin = memberTable.Rows[0]["memLName"].ToString();
                                InitializeUser.UserID = memberTable.Rows[0]["memID"].ToString();

                                formMain mainForm = new formMain();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Dispose();
                                return;
                            }
                        }
                    }

                    // If neither employee nor member login succeeded
                    MessageBox.Show("Username หรือ Password ไม่ถูกต้อง");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเข้าสู่ระบบ: " + ex.Message);
            }
        }


         

        private void formLogin_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            /*formMember testmem = new formMember();
            testmem.Show();*/
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void lableregis_Click(object sender, EventArgs e)
        {
            formRegis a = new formRegis();
            a.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
