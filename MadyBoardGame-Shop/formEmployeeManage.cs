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
    public partial class formEmployeeManage : Form
    {
        CurrencyManager emp_Manager;
        DataTable dt = new DataTable();
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
                    string query = "SELECT empName, empLName, empPosition, empSalary, empBornDate, empLocation, empNumphone FROM Employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);

                    // ใช้ DefaultView แทน DataTable ตรงๆ
                    dataGrid_Emp.DataSource = dt.DefaultView;
                    // ซ่อน Columns ที่ไม่ต้องการ
                    
                    dataGrid_Emp.Columns["empSalary"].Visible = false;
                    dataGrid_Emp.Columns["empBornDate"].Visible = false;
                    dataGrid_Emp.Columns["empLocation"].Visible = false;
                    dataGrid_Emp.Columns["empNumphone"].Visible = false;
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
            text_Location.DataBindings.Clear();

            // ใช้ DefaultView แทน DataTable ตรงๆ
            text_Name.DataBindings.Add("Text", dt.DefaultView, "empName");
            text_LName.DataBindings.Add("Text", dt.DefaultView, "empLName");
            comboBoxPosition.DataSource = dt;
            comboBoxPosition.DisplayMember = "empPosition";
            comboBoxPosition.ValueMember = "empPosition";
            comboBoxPosition.DataBindings.Add("SelectedValue", dt.DefaultView, "empPosition");
            text_Salary.DataBindings.Add("Text", dt.DefaultView, "empSalary");
            dateTimePicker_DOB.DataBindings.Add("Value", dt.DefaultView, "empBornDate", true, DataSourceUpdateMode.OnPropertyChanged);
            text_Location.DataBindings.Add("Text", dt.DefaultView, "empLocation");
            text_Phone_Emp.DataBindings.Add("Text", dt.DefaultView, "empNumphone");
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
                    text_Location.ReadOnly = true;
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
                    //----------------------------------
                    text_Name.BackColor = Color.White;
                    text_LName.BackColor = Color.White;
                    comboBoxPosition.BackColor = Color.White;
                    text_Salary.BackColor = Color.White;
                    text_Location.BackColor = Color.White;
                    text_Phone_Emp.BackColor = Color.White;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.White;
                    break;
                case "update":
                    text_Name.ReadOnly = false;
                    text_LName.ReadOnly = false;
                    comboBoxPosition.Enabled = true;
                    text_Salary.ReadOnly = false;
                    dateTimePicker_DOB.Enabled = false;
                    text_Phone_Emp.ReadOnly = false;
                    text_Location.ReadOnly = false;
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
                    //----------------------------------
                    text_Name.BackColor = Color.Orange;
                    text_LName.BackColor = Color.Orange;
                    comboBoxPosition.BackColor = Color.Orange;
                    text_Salary.BackColor = Color.Orange;
                    text_Location.BackColor = Color.Orange;
                    text_Phone_Emp.BackColor = Color.Orange;
                    dateTimePicker_DOB.CalendarTitleBackColor = Color.Orange;
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

        private void formEmployeeManage_Load(object sender, EventArgs e)
        {
            loadDataIntoGrid();
            Bind_DATA();
            SetState("view");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGrid_Emp.CurrentRow != null)
            {
                // สำรองข้อมูลก่อนแก้ไข
                backupData["empName"] = text_Name.Text;
                backupData["empLName"] = text_LName.Text;
                backupData["empPosition"] = comboBoxPosition.Text;
                backupData["empSalary"] = text_Salary.Text;
                backupData["empBornDate"] = dateTimePicker_DOB.Value.ToString(); // เก็บค่าเป็น string
                backupData["empNumphone"] = text_Phone_Emp.Text;
                backupData["empLocation"] = text_Location.Text;
            }

            // เปลี่ยนไปโหมดแก้ไข
            SetState("update");
            InitializeUser.Confic();
        }
    }
}
