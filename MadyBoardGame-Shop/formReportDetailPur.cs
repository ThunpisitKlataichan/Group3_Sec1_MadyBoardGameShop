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
    public partial class formReportDetailPur : Form
    {
        public formReportDetailPur()
        {
            InitializeComponent();
        }
        SqlConnection detailpurconnection;
        SqlCommand detailpurcommand;
        SqlDataAdapter detailpuradapter;
        DataTable detailpurtable;
        private void formReportDetailPur_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDatatoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadDatatoGrid()
        {
            using (detailpurconnection = new SqlConnection(InitializeUser._key_con))
            {
                detailpurconnection.Open();
                string qry = BuildBaseQuery();

                using (detailpurcommand = new SqlCommand(qry, detailpurconnection))
                {
                    detailpuradapter = new SqlDataAdapter(detailpurcommand);
                    detailpurtable = new DataTable();
                    detailpuradapter.Fill(detailpurtable);
                    dataGridResult.DataSource = detailpurtable;
                }
            }
        }
        private string BuildBaseQuery()
        {
            return @"
                    SELECT * FROM PurchaseDetail
                    INNER JOIN Purchasing ON PurchaseDetail.PurID = Purchasing.PurID
                    INNER JOIN Products ON PurchaseDetail.ProductID = Products.ProductID
                    INNER JOIN Employees ON Purchasing.empID = Employees.empID
";
        }
        
    }
}
