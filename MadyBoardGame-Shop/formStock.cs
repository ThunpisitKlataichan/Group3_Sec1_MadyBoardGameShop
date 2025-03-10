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
    public partial class formStock : Form
    {
        public formStock()
        {
            InitializeComponent();
            InitializeUser.Confic();
        }
        SqlConnection stockconnection;
        SqlCommand stockcommand;
        SqlDataAdapter stockadapter;
        DataTable stockdatatable;
        CurrencyManager stockmanager;
        

        private void formStock_Load(object sender, EventArgs e)
        {
            try
            {
                //โหลดข้อมูลจากฐานข้อมูล
                stockconnection = new SqlConnection(InitializeUser._key_con);
                stockconnection.Open();

                string query = "SELECT p.ProductName , p.CostPrice , p.Price , p.ProductType , p.Productshelf ," +
                    "s.StockDate , s.StockQuality FROM Products as p , Stock as s WHERE p.ProductID = s.ProductID"; //<---, p.ProductImg  เอาก็อปไปวางงด้วยถ้าทำต่อ
                stockcommand = new SqlCommand(query, stockconnection);
                stockadapter = new SqlDataAdapter();
                stockadapter.SelectCommand = stockcommand;
                stockdatatable = new DataTable();
                stockadapter.Fill(stockdatatable);

                txtproductName.DataBindings.Add("Text", stockdatatable, "ProductName");
                txtCostPrice.DataBindings.Add("Text", stockdatatable, "CostPrice");
                txtPrice.DataBindings.Add("Text", stockdatatable, "Price");
                txtProductType.DataBindings.Add("Text", stockdatatable, "ProductType");
                //4
                //pictureBoxProduct.DataBindings.Add("Image", stockdatatable, "ProductImg"); <--- มาทำต่อด้วยตัง มันเพิ่มรูปยาก
                txtAmountremain.DataBindings.Add("Text", stockdatatable, "StockQuality");
                txtleastUpdate.DataBindings.Add("Text", stockdatatable, "StockDate");
                checkBoxShowonShelf.DataBindings.Add("Checked", stockdatatable, "Productshelf");
                //8


            }
            catch (Exception ex)
            {
                MessageBox.Show("โหลดฟอร์มไม่สำเร็จ" + ex.Message);
            }
        }

        private void formStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            stockconnection.Dispose();
            stockcommand.Dispose();
            stockadapter.Dispose();
            stockdatatable.Dispose();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            stockmanager.Position ++;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            stockmanager.Position --;
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            stockmanager.Position = stockmanager.Count - 1;
        }

        private void btn_Frist_Click(object sender, EventArgs e)
        {
            stockmanager.Position = 0;
        }
    }
}
