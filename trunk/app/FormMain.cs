using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Commons;
namespace Nv.Parkir
{
    public partial class FormMain : Form
    {
        private string image_path = "Y:\\USER\\HES\\";
        private FormPrice price = null;
        private FormUser user = null;

        public FormMain()
        {
            InitializeComponent();
            timer.Start();
            AppConfig.Instance.LoadAppSetting(
                System.Configuration.ConfigurationManager.AppSettings["db"]);
        }
               

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            toolStripStatusLabel2.Text = now.ToString("T");
        }

        private void mnItemLogin_Click(object sender, EventArgs e)
        {
            if (mnItemLogin.Text == "&Login")
            {
                FormLogin login = new FormLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string username = login.Username;
                    string password = login.Password;
                    if (AppConfig.Instance.ValidateLogin(username, password))
                    {
                        mnItemReport.Visible = true;
                        mnItemManage.Visible = true;
                        mnItemGantiPassword.Visible = true;

                        if (AppConfig.Instance.IsCurrentUserAdmin())
                        {
                            mnItemPrice.Visible = true;
                            mnItemMember.Visible = true;
                            mnItemUser.Visible = true;
                            mnItemSetting.Visible = true;
                        }
                        else
                        {
                            mnItemPrice.Visible = false;
                            mnItemMember.Visible = false;
                            mnItemUser.Visible = false;
                            mnItemSetting.Visible = false;
                        }
                        

                        statusLabelUser.Text = "User :" + username;
                        DateTime now = DateTime.Now;
                        statusLabelStartLogin.Text = "Mulai Login :" + now.ToString("dd MMMM yyyy") + " " +
                            now.ToString("T");
                        mnItemLogin.Text = "&Logout";
                    }
                    else
                    {
                        MessageBox.Show("Login Failed ...");
                    }                   
                }
            }
            else
            {
                // TODO close all form
                mnItemManage.Visible = false;
                mnItemReport.Visible = false;
                mnItemLogin.Text = "&Login";

                statusLabelUser.Text = "User :";
                statusLabelStartLogin.Text = "Mulai Login :";

                //close allform
                if (null != price)
                {
                    price.Close();
                    price.Dispose();
                }

                if (null != user)
                {
                    user.Close();
                    user.Dispose();
                }
            }
        }

        private void mnItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void priceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == price || price.IsDisposed)
            {
                price = new FormPrice();
                price.MdiParent = this;
            }
            price.Select();
            price.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == user || user.IsDisposed)
            {
                user = new FormUser();
            }
            user.MdiParent = this;
            user.Select();
            user.Show();
        }

        private void mnItemMember_Click(object sender, EventArgs e)
        {
            FormMember member = new FormMember();
            member.MdiParent = this;
            member.Show();
        }

        private void mnItemAbout_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog(this);
        }

        private void mnItemGantiPassword_Click(object sender, EventArgs e)
        {
            FormChangePassword change = new FormChangePassword(
                AppConfig.Instance.UserID);
            change.ShowDialog(this);
        }

        private void mnItemSetting_Click(object sender, EventArgs e)
        {
            FormAppSetting setting = new FormAppSetting();
            setting.MdiParent = this;
            setting.Show() ;
        }

        private void mnItemLaporan_Click(object sender, EventArgs e)
        {

        }        
    }
}