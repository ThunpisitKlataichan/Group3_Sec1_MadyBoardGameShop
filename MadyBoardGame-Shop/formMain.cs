using System;
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
            InitializeUser.Confic();
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
            switch (InitializeUser.UserState)
            {
                case "Member":
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = true;
                    this.Text = "MadyStore (Member)";
                    break;
                case "ผู้จัดการ":
                    this.Text = "MadyStore (Manager)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = true;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupShipping.Enabled = false;
                    groupMember.Enabled = false;//6
                    break;
                case "เจ้าหน้าที่จัดส่งสินค้า":
                    this.Text = "MadyStore (Shipping)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = true;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = false;//6
                    break;
                case "เจ้าหน้าที่บริการลูกค้า":
                    this.Text = "MadyStore (Cashier)";
                    groupBoxCashier.Enabled = true;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = false;//6
                    break;
                case "เจ้าหน้าที่คลังสินค้า":
                    this.Text = "MadyStore (Stock)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = true;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = false;//6
                    break;
                case "เจ้าหน้าที่บัญชี":
                    this.Text = "MadyStore (Accounting)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = false;//6
                    break;
                case "เจ้าหน้าที่ขนส่ง":
                    this.Text = "MadyStore (Shipping)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = true;//6
                    break;
                default:
                    this.Text = "MadyStore (Guest)";
                    groupBoxCashier.Enabled = false;
                    groupBoxmanager.Enabled = false;
                    groupboxStock.Enabled = false;
                    groupPacking.Enabled = false;
                    groupMember.Enabled = false;
                    groupShipping.Enabled = false;//6
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

        private void btnTotleorder_Click(object sender, EventArgs e)
        {
            formReportTotalOrders formReportTotalOrders = new formReportTotalOrders();
            formReportTotalOrders.ShowDialog();
        }

        private void btnReportFrontStore_Click(object sender, EventArgs e)
        {
            formReportFrontStore formReportFrontStore = new formReportFrontStore();
            formReportFrontStore.ShowDialog();
        }
    }
}
