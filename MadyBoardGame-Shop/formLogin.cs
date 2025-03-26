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
                    
                    //เช็ค Usernamw และ Password ใน MemberUsername
                    string query = "SELECT MemberUsername.Username , memID , memName , memLName FROM MemberUsername , Member WHERE MemberUsername.Username = @username and Password = @password and MemberUsername.Username = Member.Username";
                    using (loginCommand = new SqlCommand(query, loginConnection))
                    {
                        loginCommand.Parameters.AddWithValue("@username", txt_Username.Text.Trim().ToLower());
                        loginCommand.Parameters.AddWithValue("@password", txt_Password.Text.Trim());
                        using (loginAdapter = new SqlDataAdapter(loginCommand))
                        {
                            logintable = new DataTable();
                            loginAdapter.Fill(logintable);

                            if (logintable.Rows.Count > 0)
                            {
                                InitializeUser.UserState = "Member";
                                InitializeUser.Userusername = logintable.Rows[0]["Username"].ToString();
                                InitializeUser.UserNameLogin = logintable.Rows[0]["memName"].ToString();
                                InitializeUser.UserLastNameLogin = logintable.Rows[0]["memLName"].ToString();
                                InitializeUser.UserID = logintable.Rows[0]["memID"].ToString();
                                formMain mainForm = new formMain();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Dispose();
                            }
                            else
                            {
                                query = "SELECT EmpUsername.Username , Password , empID , empName , empLName , empPosition FROM EmpUsername , Employees WHERE EmpUsername.Username = @username and Password = @password";
                                using (loginCommand = new SqlCommand(query , loginConnection))
                                {
                                    loginCommand.Parameters.AddWithValue("@username", txt_Username.Text.Trim().ToLower());
                                    loginCommand.Parameters.AddWithValue("@password", txt_Password.Text.Trim());
                                    using (loginAdapter = new SqlDataAdapter(loginCommand))
                                    {
                                        logintable = new DataTable();
                                        loginAdapter.Fill(logintable);
                                        if (logintable.Rows.Count > 0)
                                        {
                                            InitializeUser.UserState = logintable.Rows[0]["empPosition"].ToString();
                                            InitializeUser.UserNameLogin = logintable.Rows[0]["empName"].ToString();
                                            InitializeUser.UserLastNameLogin = logintable.Rows[0]["empLName"].ToString();
                                            InitializeUser.UserID = logintable.Rows[0]["empID"].ToString();
                                            InitializeUser.Userusername = logintable.Rows[0]["Username"].ToString();
                                            formMain mainForm = new formMain();
                                            this.Hide();
                                            mainForm.ShowDialog();
                                            this.Dispose();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Username หรือ Password ไม่ถูกต้อง");
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
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
