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
            BindTextBox();
            buttonState();
            // เพิ่ม Event เพื่อให้เมื่อเลือกแถวใหม่ใน DataGridView ปุ่มจะอัปเดตสถานะ
            dataGridMem.SelectionChanged += DataGridMem_SelectionChanged;
        }
        private void loadDataIntoGrid()
        {
            InitializeUser.Confic();
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Member";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);

                    // ✅ ใช้ DefaultView แทน DataTable ตรงๆ
                    dataGridMem.DataSource = dt.DefaultView;

                    // ซ่อน Columns ที่ไม่ต้องการ
                    dataGridMem.Columns["mem_ID"].Visible = false;
                    dataGridMem.Columns["mem_BornDate"].Visible = false;
                    dataGridMem.Columns["mem_RegisDate"].Visible = false;
                    dataGridMem.Columns["mem_IdentityNum"].Visible = false;
                    dataGridMem.Columns["mem_Phone"].Visible = false;
                    dataGridMem.Columns["emp_IDregis"].Visible = false;
                    dataGridMem.Columns["mem_Location"].Visible = false;
                    dataGridMem.Columns["Username"].Visible = false;
                    

                    dataGridMem.Columns["mem_Name"].HeaderText = "ชื่อ";
                    dataGridMem.Columns["mem_LName"].HeaderText = "นามสกุล";

                    //  ใช้ DefaultView เพื่อให้สามารถกรองข้อมูลได้
                    mem_Manager = (CurrencyManager)this.BindingContext[dt.DefaultView];

                    //  รีเซ็ตตำแหน่งไปที่แถวแรก
                    if (mem_Manager.Count > 0)
                    {
                        mem_Manager.Position = 0;
                        dataGridMem.CurrentCell = dataGridMem.Rows[0].Cells[1];
                    }
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
            if (mem_Manager.Count > 0)
            {
                mem_Manager.Position = 0;
                dataGridMem.CurrentCell = dataGridMem.Rows[0].Cells[1]; // เลือกแถวแรก
            }
            BindTextBox(); // ✅ อัปเดตข้อมูลใน Textbox
            buttonState();
            /*mem_Manager.Position = 0;
            buttonState();*/
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (mem_Manager.Position > 0)
            {
                mem_Manager.Position--;
                dataGridMem.CurrentCell = dataGridMem.Rows[mem_Manager.Position].Cells[1]; // อัปเดตแถว
            }
            BindTextBox(); //อัปเดตข้อมูลใน Textbox
            buttonState();
            //Codeเก่าก่อนแก้---------------------
            /*mem_Manager.Position--;
            buttonState();*/
            //--------------------------------
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (mem_Manager.Position < mem_Manager.Count - 1)
            {
                mem_Manager.Position++;
                dataGridMem.CurrentCell = dataGridMem.Rows[mem_Manager.Position].Cells[1]; // อัปเดตแถว
            }
            BindTextBox(); //อัปเดตข้อมูลใน Textbox
            buttonState();
            //Codeเก่าก่อนแก้---------------------
            /*mem_Manager.Position++;
            buttonState();*/
            //--------------------------------
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            if (mem_Manager.Count > 0)
            {
                mem_Manager.Position = mem_Manager.Count - 1;
                dataGridMem.CurrentCell = dataGridMem.Rows[mem_Manager.Position].Cells[1]; // เลือกแถวสุดท้าย
            }
            BindTextBox(); //อัปเดตข้อมูลใน Textbox
            buttonState();
            //Codeเก่าก่อนแก้---------------------
            /*mem_Manager.Position = mem_Manager.Count - 1;
            buttonState();*/
        }
        private void buttonState() 
        {
            int count = mem_Manager.Count; // จำนวนข้อมูลที่แสดงอยู่

            // ถ้าไม่มีข้อมูล ให้ปิดปุ่มทั้งหมด
            if (count == 0)
            {
                btn_Frist.Enabled = false;
                btn_Previous.Enabled = false;
                btn_Next.Enabled = false;
                btn_Last.Enabled = false;
                return;
            }

            // อัปเดตสถานะปุ่มตามตำแหน่งข้อมูลที่ถูกกรอง
            btn_Frist.Enabled = mem_Manager.Position > 0;
            btn_Previous.Enabled = mem_Manager.Position > 0;
            btn_Next.Enabled = mem_Manager.Position < count - 1;
            btn_Last.Enabled = mem_Manager.Position < count - 1;
            //Codeเก่าก่อนแก้---------------------
            /*if (mem_Manager.Position == 0) 
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
            }*/
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
            /// เปลี่ยน DataSource ของ DataGridView ให้ใช้ข้อมูลที่ถูกกรอง
            dataGridMem.DataSource = dt.DefaultView;

            // อัปเดต CurrencyManager ให้ใช้ DefaultView
            mem_Manager = (CurrencyManager)dataGridMem.BindingContext[dt.DefaultView];

            // รีเซ็ตตำแหน่งไปที่รายการแรกสุดของข้อมูลที่ถูกกรอง
            if (mem_Manager.Count > 0)
            {
                mem_Manager.Position = 0;
                dataGridMem.CurrentCell = dataGridMem.Rows[0].Cells[1]; // เลือกแถวแรก
            }

            // เคลียร์ & รีเซ็ต DataBindings ใหม่
            BindTextBox();

            // อัปเดตปุ่มควบคุม
            buttonState();
        }
        private void BindTextBox()
        {
            // เคลียร์ DataBindings 
            textMen_LName.DataBindings.Clear();
            textMen_Name.DataBindings.Clear();
            textIdentityNum.DataBindings.Clear();
            textPhoneNum.DataBindings.Clear();
            dateTimePicker_Born.DataBindings.Clear();
            textLocation.DataBindings.Clear();

            // ใช้ DefaultView แทน DataTable ตรงๆ
            textMen_Name.DataBindings.Add("Text", dt.DefaultView, "mem_Name");
            textMen_LName.DataBindings.Add("Text", dt.DefaultView, "mem_LName");
            textIdentityNum.DataBindings.Add("Text", dt.DefaultView, "mem_IdentityNum");
            textPhoneNum.DataBindings.Add("Text", dt.DefaultView, "mem_Phone");
            dateTimePicker_Born.DataBindings.Add("Value", dt.DefaultView, "mem_BornDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textLocation.DataBindings.Add("Text", dt.DefaultView, "mem_Location");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataGridMem_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridMem.CurrentRow != null)
            {
                mem_Manager.Position = dataGridMem.CurrentRow.Index;
                buttonState(); // อัปเดตปุ่มตามตำแหน่งใหม่
            }
        }
    }
}
