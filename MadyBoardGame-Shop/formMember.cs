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
        string All_customer = "select mem_Name,mem_LName from Member ";

        
        public formMember()
        {
            InitializeComponent();
        }

        private void formMember_Load(object sender, EventArgs e)
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
                    DataTable dt = new DataTable();
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
                    //dataGridMem.Columns["SSMA_TimeStamp"].Visible = false; // ซ่อน
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
                    dateTimePicker_Born.DataBindings.Add("Value",dt, "mem_BornDate", true, DataSourceUpdateMode.OnPropertyChanged);
                    textLocation.DataBindings.Add("Text", dt, "mem_Location");

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
    }
}
