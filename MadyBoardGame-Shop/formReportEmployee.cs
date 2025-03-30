using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formReportEmployee : Form
    {
        public formReportEmployee()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        private int currentRowIndex = 0; // ใช้เก็บ index ของแถวที่พิมพ์ล่าสุด
        private void btn_print_to_pdf_Click(object sender, EventArgs e)
        {
            currentRowIndex = 0; // รีเซ็ตค่าเมื่อเริ่มพิมพ์ใหม่
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            printDocument.PrinterSettings.PrintFileName = "C:\\Users\\Public\\Documents\\DataGridView_AutoFit.pdf";
            printDocument.DefaultPageSettings.Landscape = true; // พิมพ์แนวนอน
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            printDocument.Print();
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int pageWidth = e.PageBounds.Width - 100;  // เหลือขอบซ้าย/ขวา 50px
            int pageHeight = e.PageBounds.Height - 100; // เหลือขอบบน/ล่าง 50px
            int columnCount = dataGridResult.ColumnCount;
            int rowCount = dataGridResult.RowCount;

            int cellHeight = 50; // ความสูงของแต่ละเซลล์
            int startX = 50; // จุดเริ่มต้น X
            int startY = 50; // จุดเริ่มต้น Y

            int cellWidth = pageWidth / columnCount;
            using (Pen blackPen = new Pen(Color.Black, 1))
            using (Font font = new Font("Arial", 12))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                //  วาด Header
                for (int i = 0; i < columnCount; i++)
                {
                    e.Graphics.DrawRectangle(blackPen, startX + (i * cellWidth), startY, cellWidth, cellHeight);
                    e.Graphics.DrawString(
                        dataGridResult.Columns[i].HeaderText, font, brush,
                        new RectangleF(startX + (i * cellWidth), startY, cellWidth, cellHeight),
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                    );
                }

                // วาดข้อมูลตาราง เริ่มจาก currentRowIndex
                int rowY = startY + cellHeight;
                for (int i = currentRowIndex; i < rowCount - 1; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        string cellText = dataGridResult.Rows[i].Cells[j].Value?.ToString() ?? "";
                        e.Graphics.DrawRectangle(blackPen, startX + (j * cellWidth), rowY, cellWidth, cellHeight);
                        e.Graphics.DrawString(
                            cellText, font, brush,
                            new RectangleF(startX + (j * cellWidth), rowY, cellWidth, cellHeight),
                            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
                        );
                    }

                    rowY += cellHeight;

                    // ถ้าเกินหน้ากระดาษให้หยุดพิมพ์และขึ้นหน้าใหม่
                    if (rowY + cellHeight > pageHeight)
                    {
                        currentRowIndex = i + 1; // บันทึกแถวสุดท้ายที่พิมพ์
                        e.HasMorePages = true;
                        return;
                    }
                }

                //ถ้าพิมพ์ครบทุกแถวแล้วให้ปิด HasMorePages
                e.HasMorePages = false;
                currentRowIndex = 0; // รีเซ็ตค่า
            }
        }

        private void formReportEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                LoadIntoDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIntoDataGrid()
        {
            try
            {
                connection = new SqlConnection(InitializeUser._key_con);
                connection.Open();

                // แก้ไข query ให้ตรงกับชื่อคอลัมน์จริงในฐานข้อมูล
                string query = "SELECT empID, empName, empPosition, empEmail, empSalary FROM Employees WHERE 1=1";

                // เพิ่มเงื่อนไขการค้นหาตามที่ระบุในฟอร์ม
                if (!string.IsNullOrEmpty(textBoxempID.Text))
                {
                    query += " AND empID LIKE @EmployeeID";
                }

                if (!string.IsNullOrEmpty(textBoxempName.Text))
                {
                    query += " AND empName LIKE @EmployeeName";
                }

                command = new SqlCommand(query, connection);

                // เพิ่ม parameters เพื่อป้องกัน SQL Injection
                if (!string.IsNullOrEmpty(textBoxempID.Text))
                {
                    command.Parameters.AddWithValue("@EmployeeID", "%" + textBoxempID.Text + "%");
                }

                if (!string.IsNullOrEmpty(textBoxempName.Text))
                {
                    command.Parameters.AddWithValue("@EmployeeName", "%" + textBoxempName.Text + "%");
                }

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                dataGridResult.DataSource = table;

                // ปรับแต่งการแสดงผลใน DataGridView
                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการโหลดข้อมูล: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void CustomizeDataGridView()
        {
            // จัดรูปแบบคอลัมน์ต่างๆ
            if (dataGridResult.Columns.Contains("empSalary"))
            {
                dataGridResult.Columns["empSalary"].DefaultCellStyle.Format = "N2";
            }

            // ตั้งค่าความกว้างคอลัมน์อัตโนมัติ
            dataGridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // ตั้งชื่อหัวคอลัมน์ให้อ่านง่าย (ใช้ชื่อคอลัมน์ตามที่ query มา)
            if (dataGridResult.Columns.Contains("empID"))
            {
                dataGridResult.Columns["empID"].HeaderText = "รหัสพนักงาน";
            }
            if (dataGridResult.Columns.Contains("empName"))
            {
                dataGridResult.Columns["empName"].HeaderText = "ชื่อพนักงาน";
            }
            if (dataGridResult.Columns.Contains("empPosition"))
            {
                dataGridResult.Columns["empPosition"].HeaderText = "ตำแหน่ง";
            }
            if (dataGridResult.Columns.Contains("empEmail"))
            {
                dataGridResult.Columns["empEmail"].HeaderText = "อีเมล";
            }
            if (dataGridResult.Columns.Contains("empSalary"))
            {
                dataGridResult.Columns["empSalary"].HeaderText = "เงินเดือน";
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            LoadIntoDataGrid();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // ล้างข้อมูลใน TextBox ทั้งหมด
            textBoxempID.Text = "";
            textBoxempName.Text = "";

            // โหลดข้อมูลทั้งหมดใหม่
            LoadIntoDataGrid();
        }
    }
}
