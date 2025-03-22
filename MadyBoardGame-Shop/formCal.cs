using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public partial class formCal : Form
    {
        public formCal()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textQRcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textQRcode.Text))
            {
                label4.Text = textQRcode.Text;
                textQRcode.Text = ""; // ล้างข้อความหลังจากคัดลอก
            }
        }
    }
}
