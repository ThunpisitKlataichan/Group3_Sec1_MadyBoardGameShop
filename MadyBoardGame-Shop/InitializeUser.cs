using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadyBoardGame_Shop
{
    public static class InitializeUser
    {
        public static string _key_con;
        public static string UserState;
        public static string UserID;
        public static string Userusername;
        public static string UserNameLogin;
        public static string UserLastNameLogin;
        public static string ManagerID;
        public static void Confic()
        {
            string stringcon = Path.Combine(Application.StartupPath, "ConnectionString.ini");

            if (File.Exists(stringcon))
            {
                InitializeUser._key_con = File.ReadAllText(stringcon).Trim();
                if (string.IsNullOrWhiteSpace(InitializeUser._key_con))
                {
                    MessageBox.Show("ไฟล์ ConnectionString.ini ว่างเปล่า หรือไม่ได้ตั้งค่า");
                }
            }
            string manageridcon = Path.Combine(Application.StartupPath, "ManagerIDString.ini");
            if (File.Exists(manageridcon))
            {
                InitializeUser.ManagerID = File.ReadAllText(manageridcon).Trim();
                if (string.IsNullOrWhiteSpace(InitializeUser._key_con))
                {
                    MessageBox.Show("ไฟล์ ConnectionString.ini ว่างเปล่า หรือไม่ได้ตั้งค่า");
                }
            }
            else
            {
                MessageBox.Show("ไม่เจอไฟล์ ConnectionString.ini");
            }
        }
    }
}
