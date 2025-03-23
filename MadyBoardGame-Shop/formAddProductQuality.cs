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
    public partial class formAddProductQuality : Form
    {
        public formAddProductQuality()
        {
            InitializeComponent();
        }
        SqlConnection productconnect;
        SqlCommand productcommand;
        SqlDataAdapter productadapter;
        DataTable productdata;

        SqlConnection shippingconnect;
        SqlCommand shippingcommand;
        SqlDataAdapter shippingdataadapter;
        DataTable shippingdata;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            

        }

        private void formAddProductQuality_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            productconnect = new SqlConnection(InitializeUser._key_con);
            productconnect.Open();
            string qry = "Select ProductID , ProductName , CostPrice";
            productcommand = new SqlCommand(qry , productconnect);
            productadapter.SelectCommand = productcommand;
            productdata = new DataTable();
            productadapter.Fill(productdata);

            
        }

        private void formAddProductQuality_FormClosing(object sender, FormClosingEventArgs e)
        {
            productconnect.Dispose();
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddlist_Click(object sender, EventArgs e)
        {

        }
    }
}
