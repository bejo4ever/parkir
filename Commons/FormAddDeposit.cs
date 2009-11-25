using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Commons
{
    public partial class FormAddDeposit : Commons.FormBase
    {
        private long m_MemberID;
        

        public FormAddDeposit(long memberId)
        {
            InitializeComponent();
            if (memberId < 0)
            {
                throw new Exception("no member id is less than 0");
            }
            m_MemberID = memberId;
        }

        public long Deposit
        {
            get { return long.Parse(textBox1.Text); }
        }

        private void FormAddDeposit_Load(object sender, EventArgs e)
        {
            using (MySqlConnection cnn = new MySqlConnection(AppConfig.Instance.ConnectionString))
            {
                string sql = "SELECT  name, current_deposit, address " +
                    " FROM  members " +
                    " WHERE id = " + m_MemberID;

                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cnn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lblName.Text = reader.GetString("name");
                    lblCurrentDeposit.Text = reader.GetString("current_deposit");
                    lblAlamat.Text = reader.GetString("address");
                }
                reader.Close();
            }
        }
    }
}

