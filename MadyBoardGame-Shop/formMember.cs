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
                    dataGridMem.Columns["mem_ID"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_BornDate"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_BornDate"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_RegisDate"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_IdentityNum"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_Phone"].Visible = false; // ซ่อน
                    dataGridMem.Columns["emp_IDregis"].Visible = false; // ซ่อน
                    dataGridMem.Columns["mem_Location"].Visible = false; // ซ่อน
                    dataGridMem.Columns["Username"].Visible = false; // ซ่อน
                    dataGridMem.Columns["SSMA_TimeStamp"].Visible = false; // ซ่อน
                    //------------------------------------------------------------------//


                    //เปลี่ยนชื่อcolumnsใน dataGridView ให้เข้าใจง่ายขึ้น-----------------------------//
                    dataGridMem.Columns["mem_Name"].HeaderText = "ชื่อ";
                    dataGridMem.Columns["mem_LName"].HeaderText = "นามสกุล";
                    //เคลียข้อมูลก่อนหน้า
                    textMen_LName.DataBindings.Clear();
                    textMen_Name.DataBindings.Clear();
                    textIdentityNum.DataBindings.Clear();
                    textPhoneNum.DataBindings.Clear();
                    dateTimePicker_Born.DataBindings.Clear();
                    textLocation.DataBindings.Clear();
                    //ผูกข้อมูล
                    textMen_Name.DataBindings.Add("Text", dt, "mem_Name");
                    textMen_LName.DataBindings.Add("Text", dt, "mem_LName");
                    textIdentityNum.DataBindings.Add("Text", dt, "mem_IdentityNum");
                    textPhoneNum.DataBindings.Add("Text", dt, "mem_Phone");
                    dateTimePicker_Born.DataBindings.Add("Value", dt, "mem_BornDate", true, DataSourceUpdateMode.OnPropertyChanged);
                    textLocation.DataBindings.Add("Text", dt, "mem_Location");
                    //ตำแหน่งปัจจุบันของข้อมูล
                    mem_Manager = (CurrencyManager)this.BindingContext[dt];
                    

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
                dt.DefaultView.RowFilter = $"mem_Name LIKE '%{searchText}%'";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
