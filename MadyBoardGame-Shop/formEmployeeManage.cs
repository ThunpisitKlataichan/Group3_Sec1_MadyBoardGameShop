using System;
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
            SetState("view");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(myState == "add")
            {

            }
            if(myState == "update")
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
                            MessageBox.Show($"oldusername is {oldUsername}");
                        }

                        // Update ข้อมูลพนักงานใน Employees
                        string queryEmp = "UPDATE Employees SET empName = @Name, empLName = @LName, " +
                                          "empSalary = @Salary, empPosition = @Position, " +
                                          "empBornDate = @BornDate, empLocation = @Location, " +
                                          " empNumphone = @Phone " +
                                          "WHERE empID = @empID";

                        using (SqlCommand cmdEmp = new SqlCommand(queryEmp, conn))
                        {
                            cmdEmp.Parameters.AddWithValue("@Name", text_Name.Text);
                            cmdEmp.Parameters.AddWithValue("@LName", text_LName.Text);
                            cmdEmp.Parameters.AddWithValue("@Salary", double.Parse(text_Salary.Text));
                            cmdEmp.Parameters.AddWithValue("@Position", comboBoxPosition.Text);
                            cmdEmp.Parameters.AddWithValue("@BornDate", dateTimePicker_DOB.Value);
                            cmdEmp.Parameters.AddWithValue("@Location", text_location.Text);
                            cmdEmp.Parameters.AddWithValue("@Phone", text_Phone_Emp.Text);
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
    }
}
