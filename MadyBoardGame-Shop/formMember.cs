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
    public partial class formMember : Form
    {
        CurrencyManager mem_Manager;
        DataTable dt = new DataTable();
        public formMember()
        {
            InitializeComponent();
        }

        private void formMember_Load(object sender, EventArgs e)
        {
            loadDataIntoGrid();
            
            buttonState();
        }
        private void loadDataIntoGrid()
        {
            //เช็คว่ามีไฟล์ไหม
            InitializeUser.Confic();
            
            //แสดงรายชื่อสมาชิกทั้งหมดในฐานข้อมูล-------------------------------------------------------//
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Member";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    
                    adapter.Fill(dt);
                    dataGridMem.DataSource = dt;
                    //ซ่่อนcolumsที่ไม่จำเป็นออก ให้แสดงเฉพาะ ชื่อ-นามสกุล
                    dataGridMem.Columns["memID"].Visible = false; // ซ่อน
                    dataGridMem.Columns["memBornDate"].Visible = false; // ซ่อน
                    dataGridMem.Columns["memRegisDate"].Visible = false; // ซ่อน
                    dataGridMem.Columns["memIdentityNum"].Visible = false; // ซ่อน
                    dataGridMem.Columns["memPhoneNum"].Visible = false; // ซ่อน
                    dataGridMem.Columns["memLocation"].Visible = false; // ซ่อน
                    dataGridMem.Columns["Username"].Visible = false; // ซ่อน
                    dataGridMem.Columns["SSMA_TimeStamp"].Visible = false; // ซ่อน
                    //------------------------------------------------------------------//


                    // ซ่อน Columns ที่ไม่ต้องการ
                    dataGridMem.Columns["memID"].Visible = false;
                    dataGridMem.Columns["mem_BornDate"].Visible = false;
                    dataGridMem.Columns["mem_RegisDate"].Visible = false;
                    dataGridMem.Columns["mem_IdentityNum"].Visible = false;
                    dataGridMem.Columns["mem_Phone"].Visible = false;
                    dataGridMem.Columns["emp_IDregis"].Visible = false;
                    dataGridMem.Columns["mem_Location"].Visible = false;
                    dataGridMem.Columns["Username"].Visible = false;
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void formMember_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Frist_Click(object sender, EventArgs e)
        {
            mem_Manager.Position = 0;
            buttonState();
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            mem_Manager.Position--;
            buttonState();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            mem_Manager.Position++;
            buttonState();
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            mem_Manager.Position = mem_Manager.Count - 1;
            buttonState();
        }
        private void buttonState() 
        {
            if (mem_Manager.Position == 0) 
            {
                btn_Frist.Enabled = false;
                btn_Previous.Enabled = false;
            }
            if (mem_Manager.Position != 0) 
            {
                btn_Frist.Enabled = true;
                btn_Previous.Enabled = true;
                
            }
            if(mem_Manager.Position != mem_Manager.Count - 1)
            {
                btn_Next.Enabled = true;
                btn_Last.Enabled = true;
            }
            if (mem_Manager.Position == mem_Manager.Count - 1)
            {
                btn_Next.Enabled = false;
                btn_Last.Enabled = false;
            }
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string searchText = text_find.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                dt.DefaultView.RowFilter = ""; // แสดงข้อมูลทั้งหมดถ้าช่องค้นหาว่าง
            }
            else
            {
                dt.DefaultView.RowFilter = $"memName LIKE '%{searchText}%'";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
