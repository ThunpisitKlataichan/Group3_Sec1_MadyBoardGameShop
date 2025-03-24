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
    public partial class formAddSuppiler : Form
    {
        public formAddSuppiler()
        {
            InitializeComponent();
        }
        SqlConnection suppilerConnection;
        SqlCommand suppilerCommand;
        SqlDataAdapter suppilerdataAdapter;
        DataTable suppilerDataTable;
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "INSERT INTO Suppilers(SuppilerName , SuppilerCoutry) VALUES(@suppilerName , @suppilerCoutry)";
                suppilerCommand = new SqlCommand(qry, suppilerConnection);
                suppilerCommand.Parameters.AddWithValue("@suppilerName", textBoxSupName.Text);
                suppilerCommand.Parameters.AddWithValue("@suppilerCoutry", textBoxSupContry.Text);
                suppilerCommand.ExecuteNonQuery();
                MessageBox.Show("บันทึกสำเร็จ" , "สำเร็จ" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formAddSuppiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            suppilerConnection.Close();
            suppilerConnection.Dispose();
        }

        private void formAddSuppiler_Load(object sender, EventArgs e)
        {
            InitializeUser.Confic();
            suppilerConnection = new SqlConnection(InitializeUser._key_con);
            suppilerCommand = new SqlCommand();
            suppilerConnection.Open();
        }
    }
}
