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
        string myState;
        int Lock;
        private Dictionary<string, string> backupData = new Dictionary<string, string>();
        public formMember()
        {
            InitializeComponent();
        }

        private void formMember_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            loadDataIntoGrid();
            BindTextBox();
            buttonState();
            // เพิ่ม Event เพื่อให้เมื่อเลือกแถวใหม่ใน DataGridView ปุ่มจะอัปเดตสถานะ
            dataGridMem.SelectionChanged += DataGridMem_SelectionChanged;
            SetState("view");
            ApplyDataGridViewStyling();
        }
        private Color headerColor = Color.FromArgb(34, 34, 59);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);
        private void ApplyDataGridViewStyling()
        {
            // Basic Grid Styling
            dataGridMem.BorderStyle = BorderStyle.None;
            dataGridMem.EnableHeadersVisualStyles = false;
            dataGridMem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridMem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridMem.RowHeadersVisible = false;
            dataGridMem.AllowUserToAddRows = false;
            dataGridMem.ReadOnly = true;
            dataGridMem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridMem.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridMem.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridMem.ColumnHeadersHeight = 40;
            dataGridMem.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridMem.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridMem.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;
            dataGridMem.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridMem.GridColor = Color.FromArgb(221, 221, 221);

            // Add some padding to cells
            dataGridMem.DefaultCellStyle.Padding = new Padding(5);
            dataGridMem.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
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

                    // ใช้ DefaultView แทน DataTable ตรงๆ
                    dataGridMem.DataSource = dt.DefaultView;

                    // ซ่อน Columns ที่ไม่ต้องการ
                    dataGridMem.Columns["memID"].Visible = false;
                    dataGridMem.Columns["memBornDate"].Visible = false;
                    dataGridMem.Columns["memRegisDate"].Visible = false;
                    dataGridMem.Columns["memIdentityNum"].Visible = false;
                    dataGridMem.Columns["memPhonenum"].Visible = false;
                    dataGridMem.Columns["memLocation"].Visible = false;
                    dataGridMem.Columns["Username"].Visible = false;
                    dataGridMem.Columns["memLock"].Visible = false;
                    dataGridMem.Columns["memEmail"].Visible = false;
                    dataGridMem.Columns["memName"].HeaderText = "ชื่อ";
                    dataGridMem.Columns["memLName"].HeaderText = "นามสกุล";
                    dataGridMem.Columns["memName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridMem.Columns["memLName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    


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
            BindTextBox(); // อัปเดตข้อมูลใน Textbox
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
            text_Email.DataBindings.Clear();
            checkBox_Lock.DataBindings.Clear();

            // ใช้ DefaultView แทน DataTable ตรงๆ
            textMen_Name.DataBindings.Add("Text", dt.DefaultView, "memName");
            textMen_LName.DataBindings.Add("Text", dt.DefaultView, "memLName");
            textIdentityNum.DataBindings.Add("Text", dt.DefaultView, "memIdentityNum");
            textPhoneNum.DataBindings.Add("Text", dt.DefaultView, "memPhonenum");
            dateTimePicker_Born.DataBindings.Add("Value", dt.DefaultView, "memBornDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textLocation.DataBindings.Add("Text", dt.DefaultView, "memLocation");
            text_Email.DataBindings.Add("Text", dt.DefaultView, "memEmail");
            checkBox_Lock.DataBindings.Add("Checked", dt.DefaultView, "memLock");
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
        private void SetState(string AddState)
        {
            myState = AddState;
            switch (AddState)
            {
                case "view":
                    checkBox_Lock.Enabled = false;
                    textMen_Name.ReadOnly = true;
                    textMen_LName.ReadOnly = true;
                    textIdentityNum.ReadOnly = true;
                    textPhoneNum.ReadOnly = true;
                    dateTimePicker_Born.Enabled = false;
                    textLocation.ReadOnly = true;
                    btn_Add.Enabled = true;
                    btn_Edit.Enabled = true;
                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = false;
                    btn_Del.Enabled = false;
                    //----------------------------------
                    textMen_Name.BackColor = Color.White;
                    textMen_LName.BackColor = Color.White;
                    textIdentityNum.BackColor = Color.White;
                    text_Email.BackColor = Color.White;
                    textPhoneNum.BackColor = Color.White;
                    dateTimePicker_Born.BackColor = Color.White;
                    textLocation.BackColor = Color.White;
                    dateTimePicker_Born.CalendarTitleBackColor = Color.White;
                    break;
                case "update":
                    checkBox_Lock.Enabled = true;
                    textMen_Name.ReadOnly = false;
                    textMen_LName.ReadOnly = false;
                    textIdentityNum.ReadOnly = false;
                    textPhoneNum.ReadOnly = false;
                    dateTimePicker_Born.Enabled = true;
                    textLocation.ReadOnly = false;
                    btn_Add.Enabled = false;
                    btn_Edit.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    btn_Del.Enabled = true;
                    //----------------------------------
                    textMen_Name.BackColor = Color.Orange;
                    text_Email.BackColor = Color.Orange;
                    textMen_LName.BackColor = Color.Orange;
                    textIdentityNum.BackColor = Color.Orange;
                    textPhoneNum.BackColor = Color.Orange;
                    dateTimePicker_Born.BackColor = Color.Orange;
                    textLocation.BackColor = Color.Orange;
                    dateTimePicker_Born.CalendarTitleBackColor = Color.Orange;
                    break;
                default:

                    break;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridMem.CurrentRow != null)
            {
                // สำรองข้อมูลก่อนแก้ไข
                backupData["memName"] = textMen_Name.Text;
                backupData["memLName"] = textMen_LName.Text;
                backupData["memIdentityNum"] = textIdentityNum.Text;
                backupData["memPhoneNum"] = textPhoneNum.Text;
                backupData["memBornDate"] = dateTimePicker_Born.Value.ToString(); // เก็บค่าเป็น string
                backupData["memLocation"] = textLocation.Text;
                backupData["memEmail"] = text_Email.Text;
            }

            // เปลี่ยนไปโหมดแก้ไข
            SetState("update");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            formRegis form = new formRegis();
            form.ShowDialog();
            dt.Clear();
            InitializeUser.Confic();
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Member";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);

                    // ใช้ DefaultView แทน DataTable ตรงๆ
                    dataGridMem.DataSource = dt.DefaultView;

                    // ซ่อน Columns ที่ไม่ต้องการ
                    dataGridMem.Columns["memID"].Visible = false;
                    dataGridMem.Columns["memBornDate"].Visible = false;
                    dataGridMem.Columns["memRegisDate"].Visible = false;
                    dataGridMem.Columns["memIdentityNum"].Visible = false;
                    dataGridMem.Columns["memPhonenum"].Visible = false;
                    dataGridMem.Columns["memLocation"].Visible = false;
                    dataGridMem.Columns["Username"].Visible = false;
                    dataGridMem.Columns["memName"].HeaderText = "ชื่อ";
                    dataGridMem.Columns["memLName"].HeaderText = "นามสกุล";

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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (backupData.Count > 0)
            {
                // คืนค่าที่สำรองไว้
                textMen_Name.Text = backupData["memName"];
                textMen_LName.Text = backupData["memLName"];
                textIdentityNum.Text = backupData["memIdentityNum"];
                textPhoneNum.Text = backupData["memPhoneNum"];
                dateTimePicker_Born.Value = Convert.ToDateTime(backupData["memBornDate"]);
                textLocation.Text = backupData["memLocation"];
                text_Email.Text  = backupData["memEmail"];
            }

            // กลับสู่โหมดปกติ
            SetState("view");
        }
        
        private void btn_Save_Click(object sender, EventArgs e)
        {   
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    string query = "";

                    if (myState == "update")
                    {
                        if (checkBox_Lock.Checked)
                        {
                            Lock = 1; // Lock
                        }
                        if (!checkBox_Lock.Checked)
                        {
                            Lock = 0; // Unlock
                        }
                        // อัปเดตข้อมูลสมาชิกเดิม
                        query = "UPDATE Member SET memName = @Name, memLName = @LName, " +
                                "memIdentityNum = @IdentityNum, memPhoneNum = @Phone, " +
                                "memBornDate = @BornDate, memLocation = @Location , memEmail = @memEmail , memLock = @Lock " +
                                "WHERE memID = @MemID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // ใส่ค่าพารามิเตอร์
                        cmd.Parameters.AddWithValue("@Name", textMen_Name.Text);
                        cmd.Parameters.AddWithValue("@LName", textMen_LName.Text);
                        cmd.Parameters.AddWithValue("@IdentityNum", textIdentityNum.Text);
                        cmd.Parameters.AddWithValue("@Phone", textPhoneNum.Text);
                        cmd.Parameters.AddWithValue("@BornDate", dateTimePicker_Born.Value);
                        cmd.Parameters.AddWithValue("@Location", textLocation.Text);
                        cmd.Parameters.AddWithValue("@memEmail", text_Email.Text);
                        cmd.Parameters.AddWithValue("@Lock", Lock);

                        if (myState == "update")
                        {
                            cmd.Parameters.AddWithValue("@MemID", dataGridMem.CurrentRow.Cells["memID"].Value);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // โหลดข้อมูลใหม่และแสดงในตาราง
                    dt.Clear();
                    loadDataIntoGrid();

                    // กลับสู่โหมด view
                    SetState("view");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
        }
        private void LoadData_AfterDelete()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
                {
                    conn.Open();
                    string query = "SELECT * FROM Member";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridMem.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridMem.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวที่ต้องการลบ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridMem.CurrentRow != null)
            {
                // ดึงค่า Primary Key ของแถวที่เลือก
                //int memID = Convert.ToInt32(dataGridMem.CurrentRow.Cells["memID"].Value);
                string username = dataGridMem.CurrentRow.Cells["Username"].Value.ToString();
                // ยืนยันก่อนลบ
                DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูลนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // เชื่อมต่อฐานข้อมูล
                        using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
                        {
                            conn.Open();
                            string query1 = "DELETE FROM MemberUsername WHERE Username = @username";
                            string query2 = "DELETE FROM Member WHERE Username = @username";
                            using (SqlCommand cmd = new SqlCommand(query1, conn))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.ExecuteNonQuery();
                            }
                            using (SqlCommand cmd = new SqlCommand(query2, conn))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("ลบข้อมูลสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData_AfterDelete();
                        SetState("view");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox_Lock_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
