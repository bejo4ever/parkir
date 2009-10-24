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
            AutoStart auto = new AutoStart();
            auto.EnabledThroughStartupMenu = true;
            Close();
        }
    }
}