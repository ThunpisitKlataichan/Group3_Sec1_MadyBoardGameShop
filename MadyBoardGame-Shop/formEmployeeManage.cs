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

namespace MadyBoardGame_Shop
{
    public partial class formEmployeeManage : Form
    {
        SqlConnection connection;
        SqlCommand command;
        CurrencyManager emp_Manager;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter empAdapter, credAdapter;
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

                    string query = "SELECT empName, empLName, empPosition, empSalary, empBornDate, empLocation, empNumphone, Username, empID FROM Employees";
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
                    dataGrid_Emp.Columns["Username"].Visible = false;
                    dataGrid_Emp.Columns["empName"].HeaderText = "ชื่อ";
                    dataGrid_Emp.Columns["empLName"].HeaderText = "นามสกุล";
                    dataGrid_Emp.Columns["empPosition"].HeaderText = "ตำแหน่ง";
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
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            // Bind ข้อมูลพนักงาน
            text_Name.DataBindings.Add("Text", ds.Tables["Employees"], "empName");
            text_LName.DataBindings.Add("Text", ds.Tables["Employees"], "empLName");

            /*comboBoxPosition.DataSource = ds.Tables["Employees"];
            comboBoxPosition.DisplayMember = "empPosition";
            comboBoxPosition.ValueMember = "empPosition";
            comboBoxPosition.DataBindings.Add("SelectedValue", ds.Tables["Employees"], "empPosition");*/
            comboBoxPosition.DataBindings.Add("Text", ds.Tables["Employees"], "empPosition");

            text_Salary.DataBindings.Add("Text", ds.Tables["Employees"], "empSalary");
            dateTimePicker_DOB.DataBindings.Add("Value", ds.Tables["Employees"], "empBornDate", true, DataSourceUpdateMode.OnPropertyChanged);
            text_location.DataBindings.Add("Text", ds.Tables["Employees"], "empLocation");
            text_Phone_Emp.DataBindings.Add("Text", ds.Tables["Employees"], "empNumphone");
            txtUsername.DataBindings.Add("Text", ds.Tables["Employees"], "Username");
            
            txtPassword.DataBindings.Add("Text", ds.Tables["EmpUsername"], "Password");
            /*// ค้นหารหัสผ่านจาก `EmpUsername`
            txtPassword.Text = ds.Tables["EmpUsername"].AsEnumerable()
                .Where(row => row["Username"].ToString() == txtUsername.Text)
                .Select(row => row["Password"].ToString())
                .FirstOrDefault() ?? "";*/
        }
        private void SetState(string AddState)
        {
            myState = AddState;
            switch (AddState)
            {
                case "view":
                    dataGrid_Emp.Enabled = true;
                    text_Name.ReadOnly = true;
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
                    text_LName.BackColor = Color.White;
                    comboBoxPosition.BackColor = Color.White;
                    text_Salary.BackColor = Color.White;
                    text_location.BackColor = Color.White;
                    text_Phone_Emp.BackColor = Color.White;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.White;
                    txtUsername.BackColor = Color.White;
                    txtPassword.BackColor = Color.White;
                    break;
                case "update":
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
                    text_Name.BackColor = Color.Orange;
                    text_LName.BackColor = Color.Orange;
                    comboBoxPosition.BackColor = Color.Orange;
                    text_Salary.BackColor = Color.Orange;
                    text_location.BackColor = Color.Orange;
                    text_Phone_Emp.BackColor = Color.Orange;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.Orange;
                    txtUsername.BackColor = Color.Orange;
                    txtPassword.BackColor = Color.Orange;
                    break;
                case "add":
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
                    text_Name.BackColor = Color.SpringGreen;
                    text_LName.BackColor = Color.SpringGreen;
                    comboBoxPosition.BackColor = Color.SpringGreen;
                    text_Salary.BackColor = Color.SpringGreen;
                    text_location.BackColor = Color.SpringGreen;
                    text_Phone_Emp.BackColor = Color.SpringGreen;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.SpringGreen;
                    txtUsername.BackColor = Color.SpringGreen;
                    txtPassword.BackColor = Color.SpringGreen;
                    break;

                default:
                    break;
            }
        }
        private void textSearch_TextChanged(object sender, EventArgs e)
        {

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
            BackupDATA();
            oldUsername  = txtUsername.Text;
            SetState("update");
        }

        private void formEmployeeManage_Load(object sender, EventArgs e)
        {
            
            loadDataIntoGrid();
            Bind_DATA();
            SetState("view");
            txtUsername.TextChanged += txtUsername_TextChanged;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            BackupDATA();
            SetState("add");
            /*// เพิ่มแถวใหม่ใน DataTable
            DataRow newRow = ds.Tables["Employees"].NewRow();
            ds.Tables["Employees"].Rows.Add(newRow);*/
            // เลือกแถวสุดท้าย
            int lastRowIndex = dataGrid_Emp.Rows.Count - 1;
            dataGrid_Emp.CurrentCell = dataGrid_Emp.Rows[lastRowIndex].Cells[0];

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
            // โหลดข้อมูลเก่ากลับไปที่ DataGridView
            ds.Clear();
            loadDataIntoGrid(); // โหลดข้อมูลจาก Database อีกครั้ง

            // รีเฟรช DataGridView
            dataGrid_Emp.DataSource = null;
            //dataGrid_Emp.DataSource = ds.Tables["Employees"];
            //dataGrid_Emp.Refresh();
            loadDataIntoGrid();
            SetState("view");

            //Bind_DATA();
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

                        string commandprom2 = "INSERT INTO Employees (empName, empLName, empPosition, empSalary, empNumphone ,empLocation,empBornDate,Username,StoreID) " +
                            "VALUES (@name, @lastname, @Position, @Salary, @phonenum , @location, @BornDate,@Username,@StoreID)";
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


                            command.ExecuteNonQuery();
                        }

                    }
                    MessageBox.Show("เพิ่มข้อมูลพนักงานสำเร็จ");
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
                                          " empNumphone = @Phone " +
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
                            cmdEmp.ExecuteNonQuery();
                        }

                        MessageBox.Show("บันทึกข้อมูลเรียบร้อย!");
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

    }
}
