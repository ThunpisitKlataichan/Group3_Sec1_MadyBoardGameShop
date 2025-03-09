using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            formStock a = new formStock();
            a.ShowDialog();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_member_Click(object sender, EventArgs e)
        {
            formMember a = new formMember();
            a.ShowDialog();

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLogin a = new formLogin();
            a.ShowDialog();
            this.Dispose();
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            formOrder a = new formOrder();
            a.ShowDialog();
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {

        }
    }
}
