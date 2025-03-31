using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MadyBoardGame_Shop
{
    public partial class formEmployeeManage : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter credAdapter;
        string oldUsername;
        private Dictionary<string, string> backupData = new Dictionary<string, string>();
        string myState;
        public formEmployeeManage()
        {
            InitializeComponent();
        }
        private void loadDataIntoGrid()
        {
            InitializeUser.Confic();
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    ds.Clear(); // ล้าง DataSet ก่อนโหลดข้อมูลใหม่
                    ds.Relations.Clear(); // ล้างความสัมพันธ์ก่อนเพิ่มใหม่

                    string query = "SELECT empName, empLName, empPosition, empSalary, empBornDate, empLocation, empNumphone, Username, empID ,empEmail FROM Employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds, "Employees");

                    // โหลดข้อมูลรหัสผ่าน
                    credAdapter = new SqlDataAdapter("SELECT Username, Password FROM EmpUsername", conn);
                    credAdapter.Fill(ds, "EmpUsername");

                    // ตรวจสอบก่อนเพิ่ม DataRelation เพื่อป้องกันซ้ำ
                    if (!ds.Relations.Contains("EmpUserRelation"))
                    {
                        DataRelation relation = new DataRelation(
                            "EmpUserRelation",
                            ds.Tables["Employees"].Columns["Username"],
                            ds.Tables["EmpUsername"].Columns["Username"]
                        );

                        ds.Relations.Add(relation);
                    }

                    // ผูก Grid กับพนักงาน
                    dataGrid_Emp.DataSource = ds.Tables["Employees"];

                    // ซ่อน Columns ที่ไม่ต้องการ
                    dataGrid_Emp.Columns["empID"].Visible = false;
                    dataGrid_Emp.Columns["empSalary"].Visible = false;
                    dataGrid_Emp.Columns["empBornDate"].Visible = false;
                    dataGrid_Emp.Columns["empLocation"].Visible = false;
                    dataGrid_Emp.Columns["empNumphone"].Visible = false;
                    dataGrid_Emp.Columns["empEmail"].Visible = false;
                    dataGrid_Emp.Columns["Username"].Visible = false;
                    dataGrid_Emp.Columns["empName"].HeaderText = "ชื่อ";
                    dataGrid_Emp.Columns["empLName"].HeaderText = "นามสกุล";
                    dataGrid_Emp.Columns["empPosition"].HeaderText = "ตำแหน่ง";
                    dataGrid_Emp.Columns["empName"].AutoSizeMode  = DataGridViewAutoSizeColumnMode.Fill;
                    dataGrid_Emp.Columns["empLName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGrid_Emp.Columns["empPosition"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void Bind_DATA()
        {
            // เคลียร์ DataBindings 
            text_Name.DataBindings.Clear();
            text_LName.DataBindings.Clear();
            comboBoxPosition.DataBindings.Clear();
            text_Salary.DataBindings.Clear();
            dateTimePicker_DOB.DataBindings.Clear();
            text_Phone_Emp.DataBindings.Clear();
            text_location.DataBindings.Clear();
            text_Email.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            // Bind ข้อมูลพนักงาน
            text_Name.DataBindings.Add("Text", ds.Tables["Employees"], "empName");
            text_LName.DataBindings.Add("Text", ds.Tables["Employees"], "empLName");

     
            comboBoxPosition.DataBindings.Add("Text", ds.Tables["Employees"], "empPosition");

            text_Salary.DataBindings.Add("Text", ds.Tables["Employees"], "empSalary");
            dateTimePicker_DOB.DataBindings.Add("Value", ds.Tables["Employees"], "empBornDate", true, DataSourceUpdateMode.OnPropertyChanged);
            text_location.DataBindings.Add("Text", ds.Tables["Employees"], "empLocation");
            text_Phone_Emp.DataBindings.Add("Text", ds.Tables["Employees"], "empNumphone");
            text_Email.DataBindings.Add("Text",ds.Tables["Employees"], "empEmail");
            txtUsername.DataBindings.Add("Text", ds.Tables["Employees"], "Username");
            
            txtPassword.DataBindings.Add("Text", ds.Tables["EmpUsername"], "Password");
            
        }
        private void SetState(string AddState)
        {
            myState = AddState;
            switch (AddState)
            {
                case "view":
                    textSearch.Text = "";
                    textSearch.ReadOnly = false;
                    dataGrid_Emp.Enabled = true;
                    text_Name.ReadOnly = true;
                    text_Email.ReadOnly = true;
                    text_LName.ReadOnly = true;
                    comboBoxPosition.Enabled = false;
                    text_Salary.ReadOnly = true;
                    dateTimePicker_DOB.Enabled = false;
                    text_Phone_Emp.ReadOnly = true;
                    text_location.ReadOnly = true;
                    btn_Add.Enabled = true;
                    btn_Add.BackColor = Color.YellowGreen;
                    btn_edit.Enabled = true;
                    btn_edit.BackColor = Color.YellowGreen;
                    btn_save.Enabled = false;
                    btn_save.BackColor = Color.Gray;
                    btn_cancel.Enabled = false;
                    btn_cancel.BackColor = Color.Gray;
                    btn_del.Enabled = false;
                    btn_del.BackColor = Color.Gray;
                    txtUsername.ReadOnly = true;
                    txtPassword.ReadOnly = true;
                    //----------------------------------
                    text_Name.BackColor = Color.White;
                    text_Email.BackColor = Color.White;
                    text_LName.BackColor = Color.White;
                    comboBoxPosition.BackColor = Color.White;
                    text_Salary.BackColor = Color.White;
                    text_location.BackColor = Color.White;
                    text_Phone_Emp.BackColor = Color.White;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.White;
                    txtUsername.BackColor = Color.White;
                    txtPassword.BackColor = Color.White;
                    dataGrid_Emp.Enabled = true;
                    break;
                case "update":
                    text_Email.ReadOnly = false;
                    textSearch.ReadOnly = true;
                    dataGrid_Emp.Enabled = false;
                    text_Name.ReadOnly = false;
                    text_LName.ReadOnly = false;
                    comboBoxPosition.Enabled = true;
                    text_Salary.ReadOnly = false;
                    dateTimePicker_DOB.Enabled = true;
                    text_Phone_Emp.ReadOnly = false;
                    text_location.ReadOnly = false;
                    btn_Add.Enabled = false;
                    btn_Add.BackColor = Color.Gray;
                    btn_edit.Enabled = false;
                    btn_edit.BackColor = Color.Gray;
                    btn_save.Enabled = true;
                    btn_save.BackColor = Color.YellowGreen;
                    btn_cancel.Enabled = true;
                    btn_cancel.BackColor = Color.OrangeRed;
                    btn_del.Enabled = true;
                    btn_del.BackColor = Color.OrangeRed;
                    txtUsername.ReadOnly = false;
                    txtPassword.ReadOnly = false;
                    //----------------------------------
                    text_Email.BackColor = Color.Orange;
                    text_Name.BackColor = Color.Orange;
                    text_LName.BackColor = Color.Orange;
                    comboBoxPosition.BackColor = Color.Orange;
                    text_Salary.BackColor = Color.Orange;
                    text_location.BackColor = Color.Orange;
                    text_Phone_Emp.BackColor = Color.Orange;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.Orange;
                    txtUsername.BackColor = Color.Orange;
                    txtPassword.BackColor = Color.Orange;
                    dataGrid_Emp.Enabled = true;
                    break;
                case "add":
                    text_Email.ReadOnly = false;
                    textSearch.ReadOnly = true;
                    dataGrid_Emp.Enabled = true;
                    text_Name.ReadOnly = false;
                    text_LName.ReadOnly = false;
                    comboBoxPosition.Enabled = true;
                    text_Salary.ReadOnly = false;
                    dateTimePicker_DOB.Enabled = true;
                    text_Phone_Emp.ReadOnly = false;
                    text_location.ReadOnly = false;
                    btn_Add.Enabled = false;
                    btn_Add.BackColor = Color.Gray;
                    btn_edit.Enabled = false;
                    btn_edit.BackColor = Color.Gray;
                    btn_save.Enabled = true;
                    btn_save.BackColor = Color.YellowGreen;
                    btn_cancel.Enabled = true;
                    btn_cancel.BackColor = Color.OrangeRed;
                    btn_del.Enabled = false;
                    btn_del.BackColor = Color.Gray;
                    txtUsername.ReadOnly = false;
                    txtPassword.ReadOnly = false;
                    //----------------------------------
                    text_Email.BackColor = Color.SpringGreen;
                    text_Name.BackColor = Color.SpringGreen;
                    text_LName.BackColor = Color.SpringGreen;
                    comboBoxPosition.BackColor = Color.SpringGreen;
                    text_Salary.BackColor = Color.SpringGreen;
                    text_location.BackColor = Color.SpringGreen;
                    text_Phone_Emp.BackColor = Color.SpringGreen;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.SpringGreen;
                    txtUsername.BackColor = Color.SpringGreen;
                    txtPassword.BackColor = Color.SpringGreen;
                    dataGrid_Emp.Enabled = false;
                    break;

                default:
                    break;
            }
        }
        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text.Trim();
            
            if (string.IsNullOrEmpty(searchText))
            {
                ds.Tables[0].DefaultView.RowFilter = ""; // แสดงข้อมูลทั้งหมดถ้าช่องค้นหาว่าง
            }
            else
            {
                ds.Tables[0].DefaultView.RowFilter = $"empName LIKE '%{searchText}%'"; // กรองข้อมูลตามชื่อ
            }

        }

        private void textSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGrid_Emp.CurrentRow != null)
            {
                BackupDATA();
                oldUsername = txtUsername.Text;
                SetState("update");
            }
        }
        private Color headerColor = Color.FromArgb(34, 34, 59);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);
        private void formEmployeeManage_Load(object sender, EventArgs e)
        {
            
            loadDataIntoGrid();
            Bind_DATA();
            SetState("view");
            txtUsername.TextChanged += txtUsername_TextChanged;
            ApplyDataGridViewStyling();
        }
        private void ApplyDataGridViewStyling()
        {
            // Basic Grid Styling
            dataGrid_Emp.BorderStyle = BorderStyle.None;
            dataGrid_Emp.EnableHeadersVisualStyles = false;
            dataGrid_Emp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_Emp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid_Emp.RowHeadersVisible = false;
            dataGrid_Emp.AllowUserToAddRows = false;
            dataGrid_Emp.ReadOnly = true;
            dataGrid_Emp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_Emp.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGrid_Emp.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGrid_Emp.ColumnHeadersHeight = 40;
            dataGrid_Emp.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGrid_Emp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Emp.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;
            dataGrid_Emp.RowsDefaultCellStyle.BackColor = Color.White;
            dataGrid_Emp.GridColor = Color.FromArgb(221, 221, 221);

            // Add some padding to cells
            dataGrid_Emp.DefaultCellStyle.Padding = new Padding(5);
            dataGrid_Emp.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            BackupDATA();
            // เลือกแถวสุดท้าย
            int lastRowIndex = dataGrid_Emp.Rows.Count - 1;
            dataGrid_Emp.CurrentCell = dataGrid_Emp.Rows[lastRowIndex].Cells[0];
            SetState("add");

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
                // คืนค่าที่สำรองไว้
                text_Name.Text = backupData["empName"];
                text_LName.Text = backupData["empLName"];
                comboBoxPosition.Text = backupData["empPosition"];
                text_Salary.Text = backupData["empSalary"];
                dateTimePicker_DOB.Value = Convert.ToDateTime(backupData["empBornDate"]);
                text_Phone_Emp.Text = backupData["empNumphone"];
                text_location.Text = backupData["empLocation"];
                txtPassword.Text = backupData["Password"];
                txtUsername.Text = backupData["Username"];
                text_Email.Text = backupData["Email"];
            // โหลดข้อมูลเก่ากลับไปที่ DataGridView
            ds.Clear();
            loadDataIntoGrid(); // โหลดข้อมูลจาก Database อีกครั้ง

            // รีเฟรช DataGridView
            dataGrid_Emp.DataSource = null;

            loadDataIntoGrid();
            SetState("view");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (myState == "add")
            {
                try
                {
                    //ดูว่าใส่ข้อมูลครบทุกช่องไหม
                    if (!TextBoxNotNullRight())
                    {
                        return;
                    }
                    string Email = text_Email.Text.Trim();  
                    string name = text_Name.Text.Trim(); ;
                    string Lname = text_LName.Text.Trim(); ;
                    string position = comboBoxPosition.Text.Trim(); ;
                    decimal salary = decimal.Parse(text_Salary.Text.Trim());
                    string Phone = text_Phone_Emp.Text.Trim(); ;
                    string location = text_location.Text;
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    DateTime dateBorn = dateTimePicker_DOB.Value;
                    int storeID = 1;
                    if (!ValidateData(username))
                    {
                        MessageBox.Show("Username นี้ถูกใช้ไปแล้ว กรุณาใช้ชื่ออื่น");
                        return;
                    }
                    using (connection = new SqlConnection(InitializeUser._key_con))
                    {
                        connection.Open();


                        string commandprom1 = "INSERT INTO EmpUsername (Username, Password) VALUES (@username, @password)";

                        string commandprom2 = "INSERT INTO Employees (empName, empLName, empPosition, empSalary, empNumphone ,empLocation,empBornDate,Username,StoreID,empEmail) " +
                            "VALUES (@name, @lastname, @Position, @Salary, @phonenum , @location, @BornDate,@Username,@StoreID,@empEmail)";
                        using (command = new SqlCommand(commandprom1, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.ExecuteNonQuery();
                        }

                        using (command = new SqlCommand(commandprom2, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@lastname", Lname);
                            command.Parameters.AddWithValue("@Position", position);
                            command.Parameters.AddWithValue("@Salary", salary);
                            command.Parameters.AddWithValue("@phonenum", Phone);
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@location", location);
                            command.Parameters.AddWithValue("@BornDate", dateBorn);
                            command.Parameters.AddWithValue("@StoreID", storeID);
                            command.Parameters.AddWithValue("@empEmail", Email);


                            command.ExecuteNonQuery();
                        }

                    }
                    MessageBox.Show("เพิ่มข้อมูลพนักงานสำเร็จ" ,"Success" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    ds.Clear();
                    loadDataIntoGrid();
                    SetState("view");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ส่งข้อมูลไม่สำเร็จ: " + ex.Message);
                }

                
            }
            if (myState == "update")
            {
                using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
                {
                    try
                    {
                        conn.Open();
                        string queryUser = "UPDATE EmpUsername SET Username = @NewUsername, Password = @Password WHERE Username = @OldUsername";
                        using (SqlCommand cmdUser = new SqlCommand(queryUser, conn))
                        {
                            cmdUser.Parameters.AddWithValue("@NewUsername", txtUsername.Text);
                            cmdUser.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmdUser.Parameters.AddWithValue("@OldUsername", oldUsername);
                            cmdUser.ExecuteNonQuery();
                            //MessageBox.Show($"oldusername is {oldUsername}");
                        }

                        // Update ข้อมูลพนักงานใน Employees
                        string queryEmp = "UPDATE Employees SET empName = @Name, empLName = @LName, " +
                                          "empSalary = @Salary, empPosition = @Position, " +
                                          "empBornDate = @BornDate, empLocation = @Location, " +
                                          " empNumphone = @Phone ,empEmail = @empEmail " +
                                          "WHERE empID = @empID";

                        using (SqlCommand cmdEmp = new SqlCommand(queryEmp, conn))
                        {
                            cmdEmp.Parameters.AddWithValue("@Name", text_Name.Text.Trim());
                            cmdEmp.Parameters.AddWithValue("@LName", text_LName.Text.Trim());
                            cmdEmp.Parameters.AddWithValue("@Salary", decimal.Parse(text_Salary.Text.Trim()));
                            cmdEmp.Parameters.AddWithValue("@Position", comboBoxPosition.Text);
                            cmdEmp.Parameters.AddWithValue("@BornDate", dateTimePicker_DOB.Value);
                            cmdEmp.Parameters.AddWithValue("@Location", text_location.Text);
                            cmdEmp.Parameters.AddWithValue("@Phone", text_Phone_Emp.Text.Trim());
                            cmdEmp.Parameters.AddWithValue("@empID", dataGrid_Emp.CurrentRow.Cells["empID"].Value);
                            cmdEmp.Parameters.AddWithValue("@empEmail", text_Email.Text.Trim());
                            cmdEmp.ExecuteNonQuery();
                        }

                        MessageBox.Show("บันทึกข้อมูลเรียบร้อย!", "Success" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                        ds.Clear();
                        loadDataIntoGrid();
                        SetState("view");

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                    }
                }
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dataGrid_Emp.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวที่ต้องการลบ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGrid_Emp.CurrentRow != null)
            {
                // ดึงค่า Primary Key ของแถวที่เลือก
                //int empID = Convert.ToInt32(dataGrid_Emp.CurrentRow.Cells["empID"].Value);
                string username = dataGrid_Emp.CurrentRow.Cells["Username"].Value.ToString();

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
                            string query1 = "DELETE FROM EmpUsername WHERE Username = @username";
                            string query2 = "DELETE FROM Employees WHERE Username = @username";
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
                        ds.Clear();
                        loadDataIntoGrid();
                        //LoadData_AfterDelete();
                        SetState("view");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (ds.Tables["EmpUsername"] != null)
            {
                var password = ds.Tables["EmpUsername"].AsEnumerable()
                    .Where(row => row["Username"].ToString() == txtUsername.Text)
                    .Select(row => row["Password"].ToString())
                    .FirstOrDefault();

                txtPassword.Text = password ?? "";
            }
        }
        private void BackupDATA()
        {
            // สำรองข้อมูลก่อนแก้ไข
            backupData["empName"] = text_Name.Text;
            backupData["empLName"] = text_LName.Text;
            backupData["empPosition"] = comboBoxPosition.Text;
            backupData["empSalary"] = text_Salary.Text;
            backupData["empBornDate"] = dateTimePicker_DOB.Value.ToString(); // เก็บค่าเป็น string
            backupData["empNumphone"] = text_Phone_Emp.Text;
            backupData["empLocation"] = text_location.Text;
            backupData["Password"] = txtPassword.Text;
            backupData["Username"] = txtUsername.Text;
            backupData["Email"] = text_Email.Text;
        }
        private bool ValidateData(string username)
        {
            try
            {
                string commandprom = "SELECT MemberUsername.Username , EmpUsername.Username FROM MemberUsername , EmpUsername " +
                    "WHERE MemberUsername.Username = @username or EmpUsername.Username = @username;";

                using (connection = new SqlConnection(InitializeUser._key_con))
                {
                    connection.Open();

                    using (command = new SqlCommand(commandprom, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable datatable = new DataTable();
                            adapter.Fill(datatable);

                            if (datatable.Rows.Count > 0)
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

        private void button_All_Click(object sender, EventArgs e)
        {
            textSearch.Text = "";
        }

        private bool TextBoxNotNullRight()
        {
            StringBuilder warningstring = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(text_Name.Text))
            {
                warningstring.AppendLine("กรุณากรอกชื่อจริง");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(text_LName.Text))
            {
                warningstring.AppendLine("กรุณากรอกนามสกุล");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxPosition.Text))
            {
                warningstring.AppendLine("กรุณากรอกตำแหน่ง");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(text_Salary.Text))
            {
                warningstring.AppendLine("กรุณากรอกเงินเดือน");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(text_Email.Text))
            {
                warningstring.AppendLine("กรุณากรอกEmail");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(text_Phone_Emp.Text))
            {
                warningstring.AppendLine("กรุณากรอกเบอร์โทร");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(text_location.Text))
            {
                warningstring.AppendLine("กรุณากรอกที่อยู่");
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
            if (!isValid)
            {
                MessageBox.Show(warningstring.ToString());
            }

            return isValid;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
