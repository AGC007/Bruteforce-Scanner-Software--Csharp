using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RelyUI.Controls;

namespace Bruteforce_Scanner_v1
{
    public partial class About : RelyForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void GitHub_BTN_Click(object sender, EventArgs e)// GitHub
        {
            Process.Start("https://GitHub.Com/AGC007");
        }

        private void Donate_IRR_BTN_Click(object sender, EventArgs e)// Donate_IRR
        {
            Process.Start("https://t.me/AGC007");
        }

        private void Donate_BTC_BTN_Click(object sender, EventArgs e)// Donate_BTC
        {
            Process.Start("https://t.me/AGC007");
        }

        private void API_BTN_Click(object sender, EventArgs e)// API
        {
            Process.Start("https://agc007.online/AGC007/API/Bruteforce_Scanner.php?LoginPage=");
        }

        private void Exit_BTN_Click(object sender, EventArgs e)// Exit
        {
            this.Close();
        }
    }
}
