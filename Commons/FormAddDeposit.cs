using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commons
{
    public partial class FormAddDeposit : Commons.FormBase
    {
        public FormAddDeposit()
        {
            InitializeComponent();
        }

        public int Deposit
        {
            get { return int.Parse(textBox1.Text); }
        }
    }
}

