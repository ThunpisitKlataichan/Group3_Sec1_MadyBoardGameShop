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
    public partial class formOrder : Form
    {
        SqlConnection orderconnection;
        SqlCommand ordercommand;
        SqlDataAdapter orderadapter;
        DataTable ordertable;
        CurrencyManager ordermanager;

        public formOrder()
        {
            InitializeComponent();
            InitializeUser.Confic();
        }

        private void formOrder_Load(object sender, EventArgs e)
        {
            try 
            { 

                orderconnection = new SqlConnection(InitializeUser._key_con);
                orderconnection.Open();

                string command = "SELECT ProductName , Price , ProductType FROM Products Where Productshelf = 1";
                ordercommand = new SqlCommand(command, orderconnection);
            
                using (SqlDataReader reader = ordercommand.ExecuteReader())
                {
                    listBoxProduct.Items.Clear();
                    while (reader.Read())
                    {
                        listBoxProduct.Items.Add(reader["ProductName"].ToString());
                    }
                }
                if (listBoxProduct.Items.Count > 0)
                {
                    listBoxProduct.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
                {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void formOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderconnection.Close();
            ordercommand.Dispose();
            orderconnection.Dispose();
        }

        private void listBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Beep();
        }
    }
}
