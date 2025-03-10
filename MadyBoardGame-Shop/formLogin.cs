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
        CurrencyManager loginmanager;
        DataTable logintable;

        

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                using (loginConnection = new SqlConnection(InitializeUser._key_con))
                {
                    loginConnection.Open();

                    string query = "SELECT * FROM MemberUsername WHERE Username = @username and Password = @password";
                    using (loginCommand = new SqlCommand(query, loginConnection))
                    {
                        loginCommand.Parameters.AddWithValue("@username", txt_Username.Text.Trim().ToLower());
                        loginCommand.Parameters.AddWithValue("@password", txt_Password.Text.Trim().ToLower());
                        using (loginAdapter = new SqlDataAdapter(loginCommand))
                        {
                            logintable = new DataTable();
                            loginAdapter.Fill(logintable);

                            if (logintable.Rows.Count > 0)
                            {
                                formMain mainForm = new formMain();
                                this.Hide();
                                mainForm.ShowDialog();
                                this.Dispose();
                            }

                            else
                            {
                                MessageBox.Show("ไม่พบผู้ใช้");
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
        }

        private void formLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void lableregis_Click(object sender, EventArgs e)
        {
            formRegis a = new formRegis();
            a.ShowDialog();
        }
    }
}
