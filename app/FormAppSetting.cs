using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Commons;
namespace Nv.Parkir
{
    public partial class FormAppSetting : Form
    {
        public FormAppSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.CompanyAddress = txtCompanyAddress.Text;
            AppConfig.Instance.CompanyName = txtCompanyName.Text;
            AppConfig.Instance.CompanyPhoneNumber = txtCompanyPhone.Text;
            AppConfig.Instance.SaveCompanySettting();

            AutoStart auto = new AutoStart();
            auto.EnabledThroughStartupMenu = true;
            Close();
        }

        private void FormAppSetting_Load(object sender, EventArgs e)
        {
            txtCompanyAddress.Text = AppConfig.Instance.CompanyAddress;
            txtCompanyName.Text = AppConfig.Instance.CompanyName;
            txtCompanyPhone.Text = AppConfig.Instance.CompanyPhoneNumber;
        }
    }
}