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
    public partial class formStoreINFO : Form
    {
        public formStoreINFO()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        private void formStoreINFO_Load(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(InitializeUser._key_con))
            {
                connection.Open();
                string qry = "SELECT * FROM MadyStore";
                using (command = new SqlCommand(qry, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lableTitleStore.Text = reader["StoreName"].ToString();
                            textBoxLocation.Text = reader["StoreLocation"].ToString();
                            textBoxStoreBalance.Text = reader["StoreBalance"].ToString();
                            textBoxStorePhone.Text = reader["StorePhone"].ToString();
                            textBoxStoreEmail.Text = reader["StoreEmail"].ToString();
                            textBoxLeastDate.Text = reader["StoreUpdatedDate"].ToString();
                        }
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(InitializeUser._key_con))
            {
            }
        }
    }
}
