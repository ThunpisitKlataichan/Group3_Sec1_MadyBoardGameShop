using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace MadyBoardGame_Shop
{
    public partial class formAddSuppiler : Form
    {
        public formAddSuppiler()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        DataTable dt = new DataTable();
        string myState;
        CurrencyManager Sup_Manager;
        private Dictionary<string, string> backupData = new Dictionary<string, string>();
        private void formAddSuppiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void formAddSuppiler_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            
            loadDataIntoGrid();
            Bind_DATA();
            SetState("view");
            ApplyDataGridViewStyling();
        }
        private Color headerColor = Color.FromArgb(34, 34, 59);
        private Color alternateRowColor = Color.FromArgb(240, 240, 250);
        private void ApplyDataGridViewStyling()
        {
            // Basic Grid Styling
            dataGrid_Suppiler.BorderStyle = BorderStyle.None;
            dataGrid_Suppiler.EnableHeadersVisualStyles = false;
            dataGrid_Suppiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid_Suppiler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid_Suppiler.RowHeadersVisible = false;
            dataGrid_Suppiler.AllowUserToAddRows = false;
            dataGrid_Suppiler.ReadOnly = true;
            dataGrid_Suppiler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid_Suppiler.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGrid_Suppiler.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGrid_Suppiler.ColumnHeadersHeight = 40;
            dataGrid_Suppiler.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGrid_Suppiler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid_Suppiler.AlternatingRowsDefaultCellStyle.BackColor = alternateRowColor;
            dataGrid_Suppiler.RowsDefaultCellStyle.BackColor = Color.White;
            dataGrid_Suppiler.GridColor = Color.FromArgb(221, 221, 221);

            // Add some padding to cells
            dataGrid_Suppiler.DefaultCellStyle.Padding = new Padding(5);
            dataGrid_Suppiler.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
        }
        private void Bind_DATA()
        {
            // เคลียร์ DataBindings 
            textBoxSupID.DataBindings.Clear();
            textBoxSupName.DataBindings.Clear();
            textBoxSupContry.DataBindings.Clear();

            textBoxSupID.DataBindings.Add("Text", dt.DefaultView, "SuppilerID");
            textBoxSupName.DataBindings.Add("Text", dt.DefaultView, "SuppilerName");
            textBoxSupContry.DataBindings.Add("Text", dt.DefaultView, "SuppilerCoutry");

        }
        private void loadDataIntoGrid()
        {
            InitializeUser.Confic();
            using (SqlConnection conn = new SqlConnection(InitializeUser._key_con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Suppilers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);

                    // ใช้ DefaultView แทน DataTable ตรงๆ
                    dataGrid_Suppiler.DataSource = dt.DefaultView;

                    // ซ่อน Columns ที่ไม่ต้องการ
                    //dataGrid_Suppiler.Columns["SuppilerID"].Visible = false;

                    dataGrid_Suppiler.Columns["SuppilerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGrid_Suppiler.Columns["SuppilerCoutry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //
                    dataGrid_Suppiler.Columns["SuppilerID"].HeaderText = "ID";
                    dataGrid_Suppiler.Columns["SuppilerName"].HeaderText = "ชื่อผู้จัดจำหน่าย";
                    dataGrid_Suppiler.Columns["SuppilerCoutry"].HeaderText = "ประเทศ";


                    //  ใช้ DefaultView เพื่อให้สามารถกรองข้อมูลได้
                    Sup_Manager = (CurrencyManager)this.BindingContext[dt.DefaultView];

                    //  รีเซ็ตตำแหน่งไปที่แถวแรก
                    if (Sup_Manager.Count > 0)
                    {
                        Sup_Manager.Position = 0;
                        dataGrid_Suppiler.CurrentCell = dataGrid_Suppiler.Rows[0].Cells[1];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void SetState(string AddState)
        {
            myState = AddState;
            switch (AddState)
            {
                case "view":
                    dataGrid_Suppiler.Enabled = true;
                    textBoxSupID.ReadOnly = true;
                    textBoxSupName.ReadOnly = true;
                    textBoxSupContry.ReadOnly = true;
                    btn_Add.Enabled = true;
                    btn_Add.BackColor = Color.YellowGreen;
                    btn_edit.Enabled = true;
                    btn_edit.BackColor = Color.Orange;
                    btn_save.Enabled = false;
                    btn_save.BackColor = Color.Gray;
                    btn_cancel.Enabled = false;
                    btn_cancel.BackColor = Color.Gray;
                    btn_del.Enabled = false;
                    btn_del.BackColor = Color.Gray;
                    //----------------------------------
                    textBoxSupContry.BackColor = Color.White;
                    textBoxSupName.BackColor = Color.White;
                    textBoxSupContry.BackColor = Color.White;

                    break;
                case "update":
                    dataGrid_Suppiler.Enabled = false;
                    textBoxSupID.ReadOnly = true;
                    textBoxSupName.ReadOnly = false;
                    textBoxSupContry.ReadOnly = false;
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
                    textBoxSupContry.BackColor = Color.White;
                    textBoxSupName.BackColor = Color.Orange;
                    textBoxSupContry.BackColor = Color.Orange;
                    break;
                case "add":
                    dataGrid_Suppiler.Enabled = false;
                    textBoxSupID.ReadOnly = true;
                    textBoxSupName.ReadOnly = false;
                    textBoxSupContry.ReadOnly = false;
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
                    //----------------------------------
                    textBoxSupContry.BackColor = Color.White;
                    textBoxSupName.BackColor = Color.SpringGreen;
                    textBoxSupContry.BackColor = Color.SpringGreen;
                    break;

                default:
                    break;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGrid_Suppiler.CurrentRow != null)
            {
                BackupDATA();
                SetState("update");
            }
        }
        private void BackupDATA()
        {
            // สำรองข้อมูลก่อนแก้ไข
            backupData["SuppilerID"] = textBoxSupID.Text;
            backupData["SuppilerName"] = textBoxSupName.Text;
            backupData["SuppilerCoutry"] = textBoxSupContry.Text;
 
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            BackupDATA();
            // เลือกแถวสุดท้าย
            int lastRowIndex = dataGrid_Suppiler.Rows.Count - 1;
            dataGrid_Suppiler.CurrentCell = dataGrid_Suppiler.Rows[lastRowIndex].Cells[0];
            SetState("add");

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            textBoxSupName.Text = backupData["SuppilerName"];
            textBoxSupContry.Text = backupData["SuppilerCoutry"];
            dt.Clear();
            dataGrid_Suppiler.DataSource = null;
            loadDataIntoGrid();
            SetState("view");
        }
        private bool TextBoxNotNullRight()
        {
            StringBuilder warningstring = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBoxSupName.Text))
            {
                warningstring.AppendLine("กรุณากรอกชื่อผู้จัดจำหน่าย");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(textBoxSupContry.Text))
            {
                warningstring.AppendLine("กรุณากรอกประเทศ");
                isValid = false;
            }

            return isValid;
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
                    string SupName = textBoxSupName.Text.Trim();
                    string Country = textBoxSupContry.Text.Trim(); 
                    using (connection = new SqlConnection(InitializeUser._key_con))
                    {
                        connection.Open();


                        string commandprom1 = "INSERT INTO Suppilers (SuppilerName, SuppilerCoutry) VALUES (@SuppilerName, @SuppilerCoutry)";

                        
                        using (command = new SqlCommand(commandprom1, connection))
                        {
                            command.Parameters.AddWithValue("@SuppilerName", SupName);
                            command.Parameters.AddWithValue("@SuppilerCoutry", Country);
                            command.ExecuteNonQuery();
                        }

                    }
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                    dt.Clear();
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
                        string SupName = textBoxSupName.Text.Trim();
                        string Country = textBoxSupContry.Text.Trim();
                        string query = "UPDATE Suppilers SET SuppilerName = @SuppilerName, SuppilerCoutry = @SuppilerCoutry WHERE SuppilerID = @SuppilerID";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@SuppilerName", SupName);
                            command.Parameters.AddWithValue("@SuppilerCoutry", Country);
                            
                       
                            command.Parameters.AddWithValue("@SuppilerID", dataGrid_Suppiler.CurrentRow.Cells["SuppilerID"].Value);
                            command.ExecuteNonQuery();

                        }
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อย!");
                        dt.Clear();
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
            if (dataGrid_Suppiler.CurrentRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวที่ต้องการลบ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGrid_Suppiler.CurrentRow != null)
            {
                
                
                string ID = dataGrid_Suppiler.CurrentRow.Cells["SuppilerID"].Value.ToString();

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
                            string query = "DELETE FROM Suppilers WHERE SuppilerID = @SuppilerID";
                           
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@SuppilerID", ID);
                                cmd.ExecuteNonQuery();
                            }
         
                        }
                        MessageBox.Show("ลบข้อมูลสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dt.Clear();
                        loadDataIntoGrid();
                        
                        SetState("view");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                dt.DefaultView.RowFilter = ""; // แสดงข้อมูลทั้งหมดถ้าช่องค้นหาว่าง
            }
            else
            {
                dt.DefaultView.RowFilter = $"SuppilerName LIKE '%{searchText}%'";
            }
        }
    }
}
