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
            formProduct a = new formProduct();
            a.ShowDialog();
        }
        private void formMain_Load(object sender, EventArgs e)
        {
            SetStage();
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
        private void SetStage()
        {
            switch(InitializeUser.UserState)
            {
                case "Employee":
                    groupBoxCashier.Enabled = true;
                    groupBoxmanager.Enabled = false;
                    this.Text = "MadyStore (Employee)";
                    break;
                case "Member":
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    this.Text = "MadyStore (Member)";
                    break;
                case "Manager":
                    groupBoxCashier.Enabled = true;
                    groupBoxmanager.Enabled = true;
                    this.Text = "MadyStore (Manager)";
                    break;
            }
            labelUsername.Text = $"Username : {InitializeUser.Userusername}\n" + InitializeUser.UserNameLogin + "  " + InitializeUser.UserLastNameLogin;
        }
        private void buttonformEmpmange_Click(object sender, EventArgs e)
        {
            formEmployeeManage a = new formEmployeeManage();
            a.ShowDialog();
        }
        private void buttonCashierCal_Click(object sender, EventArgs e)
        {
            formCal a = new formCal();
            a.ShowDialog();
        }
        private void buttonPacking_Click(object sender, EventArgs e)
        {
            formPacking a = new formPacking();
            a.ShowDialog();
        }

        private void buttonShippingOrder_Click(object sender, EventArgs e)
        {
            formShippingOrder formShippingOrder = new formShippingOrder();
            formShippingOrder.ShowDialog();
        }

        private void buttonShippingPur_Click(object sender, EventArgs e)
        {
            formShippingPur formShippingPur = new formShippingPur();
            formShippingPur.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            formAddProductQuality formAddProductQuality = new formAddProductQuality();
            formAddProductQuality.ShowDialog();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            formAddSuppiler formAddSuppiler = new formAddSuppiler();
            formAddSuppiler.ShowDialog();
        }
    }
}
