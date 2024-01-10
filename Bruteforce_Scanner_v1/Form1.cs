using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System;
using RelyUI.Controls;
using Leaf.xNet;
using RelyUI;
using System.Net;
using System.Text.RegularExpressions;
using Json;

namespace Bruteforce_Scanner_v1
{
    public partial class Form1 : RelyForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void API_Connection(string LoginPage)// API Connection
        {
            try
            {
                HttpRequest API_REQ = new HttpRequest();
                API_REQ.UserAgentRandomize();

                string API_Respone = API_REQ.Get("https://agc007.online/AGC007/API/Bruteforce_Scanner.php?LoginPage=" + LoginPage).ToString();
                dynamic Json_API = JsonParser.FromJson(API_Respone);

                string Security = Json_API["Security"];
                string Challenge = Json_API["Challenge"];
                string reCaptcha = Json_API["reCaptcha"];
                string Captcha = Json_API["Captcha"];
                string Respone = Json_API["Respone"];


                Security_LBL.Text = Security;
                Challenge_LBL.Text = Challenge;
                reCAPTCHA_LBL.Text = reCaptcha;
                CAPTCHA_LBL.Text = Captcha;

                LOG_TXT.Text = Respone;
            }
            catch
            {
                MessageBox.Show("Api Error");
            }

        }

        private void Check_Connection()// Check Connection
        {
            string IP_REG = "null";
            HttpRequest CheckRequest = new HttpRequest();
            CheckRequest.UserAgentRandomize();

            try
            {
                string IC_Respone = CheckRequest.Get("https://www.speedtest.net/").ToString().ToLower();
                string IP_Respone = CheckRequest.Get("http://ipwhois.app/json/?lang=en").ToString();

                if (IC_Respone.Contains("html"))
                {
                    Refresh_BTN.Visible = false;
                    Match Get_IP_Reg = Regex.Match(IP_Respone, "currency_code\":\"(.*?)\"");
                    IP_REG = Get_IP_Reg.Groups[1].Value.ToString();

                    IC_LBL.ForeColor = Color.Green;
                    IC_LBL.Text = "Connected" + "(" + IP_REG + ")";

                    try
                    {
                        string AC_Respone = CheckRequest.Get("https://agc007.online/").ToString().ToLower();

                        if (AC_Respone.Contains("agc007"))
                        {
                            Refresh_BTN.Visible = false;
                            AC_LBL.ForeColor = Color.Green;
                            AC_LBL.Text = "Connected" + "(" + IP_REG + ")";
                        }

                    }
                    catch (Exception)
                    {
                        Refresh_BTN.Visible = true;
                        AC_LBL.ForeColor = Color.Red;
                        AC_LBL.Text = "Not Connected !";
                    }

                }
            }
            catch
            {
                Refresh_BTN.Visible = true;
                IC_LBL.ForeColor = Color.Red;
                IC_LBL.Text = "Not Connected !";

                AC_LBL.ForeColor = Color.Red;
                AC_LBL.Text = "Not Connected !";
            }
        }

        private void Exit_BTN_Click(object sender, EventArgs e)// Exit
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)// Load
        {
            Check_Connection();
        }

        private void Refresh_BTN_Click(object sender, EventArgs e)// Refresh BTN
        {
            Check_Connection();
        }

        private void Start_BTN_Click(object sender, EventArgs e)// Start
        {
            string LoginPage = URL_TXT.Text;

            if (LoginPage.ToLower().Contains("http"))
            {
                API_Connection(LoginPage);
            }
            else
            {
                MessageBox.Show("Please Enter The URL of The Login Page (https://dash.cloudflare.com/login)", "Error");
            }

        }

        private void Color_Contrl_TextChanged(object sender, EventArgs e)// Color Contrl
        {
            if (Security_LBL.Text != "" || Challenge_LBL.Text != "" || reCAPTCHA_LBL.Text != "" || CAPTCHA_LBL.Text != "")
            {
               var Get_LBL = ((Label)sender);

                if(Get_LBL.Text.Contains("No"))
                {
                    Get_LBL.ForeColor = Color.Red;
                }

                if (Get_LBL.Text.Contains("Yes"))
                {
                    Get_LBL.ForeColor = Color.Green;
                }

                if (Get_LBL.Text.Contains("Unknow"))
                {
                    Get_LBL.ForeColor = Color.Orange;
                }


                if (Security_LBL.Text.Contains("Low"))
                {
                    Security_LBL.ForeColor = Color.Red;
                    LOG_TXT.TextColor = Color.Red;
                }

                if (Security_LBL.Text.Contains("Medium"))
                {
                    Security_LBL.ForeColor = Color.Orange;
                    LOG_TXT.TextColor = Color.Orange;
                }

                if (Security_LBL.Text.Contains("Hard"))
                {
                    Security_LBL.ForeColor = Color.Green;
                    LOG_TXT.TextColor = Color.Green;
                }
            }
        }

        private void About_BTN_Click(object sender, EventArgs e)// About
        {
            About AboutForm = new About();
            AboutForm.ShowDialog();
        }
    }
}
