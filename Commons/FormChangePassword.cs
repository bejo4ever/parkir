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
    public partial class FormChangePassword : Commons.FormBase
    {
        private long userId;
        public FormChangePassword(long userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        public bool CheckNewPasswod()
        {
            return txtNewPassword.Text.Equals(txtNewPassword1.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (CheckNewPasswod())
            {
                using (MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString))
                {
                    Cursor = Cursors.WaitCursor;
                    string sql = "select count(*) as count from users where id = " + userId +
                        " and password = password('" + txtOldPassword.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();

                    int exist = int.Parse(cmd.ExecuteScalar().ToString());
                    if (exist < 1)
                    {
                        MessageBox.Show(this, "Password Lama yang dimasukan salah",
                            "Error Verifikasi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        conn.Close();
                        txtOldPassword.SelectAll();
                        txtOldPassword.Focus();
                        Cursor = Cursors.Default;
                        return;
                    }
                    sql = "update users set password = password('" + txtNewPassword1.Text + "') " +
                        " where id = " + userId;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Password berhasil di ganti", "Konfirmasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                }
                Close();
            }
            else
            {
                MessageBox.Show(this, "Password baru tidak sama", "Konfirmasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPassword.Focus();
            }
        }
    }
}

