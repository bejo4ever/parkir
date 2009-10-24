using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Commons;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace gateout
{
    public partial class FormMain : Form
    {
        private bool KeyHandled = false;

        private bool useNetworkStorage = false;
        private NetworkShare networkShare;
        private string imagePath;
        string share_server;
        string share_folder;
        string share_user;
        string share_password;
        string share_path;

        private long userID;

        private long currentTiketID;
        private long currentMemberID;
        private long currentInitialTarif;
        private TimeSpan currentDuration;

        public FormMain()
        {
            InitializeComponent();
            AppConfig.Instance.LoadAppSetting(
                System.Configuration.ConfigurationManager.AppSettings["db"]);
            AppConfig.Instance.LoadGateSetting(
                int.Parse(System.Configuration.ConfigurationManager.AppSettings["gateid"]));
            useNetworkStorage = int.Parse(ConfigurationManager.AppSettings["use_remote_file"]) > 0 ?  true : false;
            if (useNetworkStorage)
            {
                //open network share
                share_server = ConfigurationManager.AppSettings["remote_server"];
                share_folder = ConfigurationManager.AppSettings["remote_share"];
                share_user = ConfigurationManager.AppSettings["remote_user"];
                share_password = ConfigurationManager.AppSettings["remote_password"];
                share_path = ConfigurationManager.AppSettings["remote_folder"];

                networkShare = new NetworkShare();
                networkShare.LoginToShare(share_server, share_folder, share_user, share_password);
                if (share_path.Length > 0)
                    imagePath = string.Format(@"\\{0}\{1}\{2}\", share_server, share_folder, share_path);
                else
                    imagePath = string.Format(@"\\{0}\{1}\", share_server, share_folder);
            }
            else
            {
                imagePath = ConfigurationManager.AppSettings["local_image_dir"];
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblDate.Text = dt.ToString("dd MMMM yyyy");
            lblTime.Text = dt.ToString("T");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer.Start();
            lblCompanyName.Text =
                AppConfig.Instance.CompanyName;
            lblCompanyAddress.Text =
                AppConfig.Instance.CompanyAddress +
                " Phone (" +
                AppConfig.Instance.CompanyPhoneNumber +
                ")";
            lblGateName.Text =
                AppConfig.Instance.GateName;

            FormLogin login = new FormLogin();
            if (login.ShowDialog(this) == DialogResult.OK)
            {
                string username = login.Username;
                string password = login.Password;

                if (!AppConfig.Instance.ValidateLogin(username, password))
                {
                    MessageBox.Show(this, "Gagal melakukan login ke server",
                        "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
                else
                {
                    statusLabelUser.Text = "User :" + username;
                    DateTime dt = DateTime.Now;
                    string dateStr = 
                        dt.Year + "-" + dt.Month + "-" + dt.Day +
                        " " + dt.Hour + ":" + dt.Minute + ":" + dt.Second;
                    statusLabelStartLogin.Text = "Mulai Login:" +
                        dateStr;
                    ClearForm();
                }
            }
            else
            {
                Application.Exit();
            }

            Commons.FullScreen.SetWinFullScreen(this.Handle);
        }

             

        private void mnItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearchTicket_KeyPress(object sender, KeyPressEventArgs e)
        {            
            e.Handled = KeyHandled;
        }

        private void txtSearchTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHandled = e.KeyCode == Keys.Enter) 
            { 
                e.Handled = true;
                SearchTicket(txtSearchTicket.Text);
            }
            else if (KeyHandled = e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                ClearForm();
            }
        }

        private void UpdateTicket()
        {
            using (MySqlConnection conn = new MySqlConnection(
                AppConfig.Instance.ConnectionString))
            {
                DateTime now = DateTime.Now;
                string nowString = now.Year+"-"+now.Month +"-" +now.Day+
                    " " + now.Hour+":"+now.Minute+":"+now.Second;
                
                long extendedTarifInt = 0;
                if (txtExtendedTarif.Text.Trim().Length > 0)
                {                    
                    try
                    {
                        long.TryParse(txtExtendedTarif.Text.Trim(),out extendedTarifInt);
                    }
                    catch (Exception)
                    {
                        extendedTarifInt = 0;
                    }
                }
                long totalTarif = currentInitialTarif + extendedTarifInt;
                string sql = "update tickets set date_out = '" + nowString + "', " +
                    " extended_price = " + extendedTarifInt.ToString() + ", gate_out_id = " + AppConfig.Instance.GateId +
                    ", gate_out_operator_id = " + AppConfig.Instance.UserID +
                    ", total_price = " + totalTarif.ToString() + " where id=" + currentTiketID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Data sudah di update", "Informasi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void SearchTicket(string p)
        {           
            using (MySqlConnection conn = new MySqlConnection(
                Commons.AppConfig.Instance.ConnectionString))
            {
                //check if this ticket is already out from 
                string sql = "select gate_out_id, gate_out_operator_id from tickets " +
                    "  where ticket_number= '" + p + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                bool ticketInvalid = false;
                while (reader.Read())
                {
                    long gateId = reader.GetInt64("gate_out_id");
                    long operatorId = reader.GetInt64("gate_out_operator_id");
                    if (gateId != AppConfig.NOT_DEFINED_ID)
                    {
                        ticketInvalid = true;
                    }
                }
                reader.Close();
                if (ticketInvalid)
                {
                    conn.Close();
                    MessageBox.Show(this, "Ticket Tidak Valid, sudah pernah digunakan", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    return;
                }


                reader.Close();
                sql = "select id, date_in, initial_price, image_path, member_id from tickets " +
                        " where ticket_number = '" + p + "'";
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                reader = cmd.ExecuteReader();
                bool found = false;
                while (reader.Read())
                {
                    found = true;
                    DateTime dateIn = reader.GetDateTime("date_in");
                    lblJamMasuk.Text = dateIn.Hour + ":" + dateIn.Minute + ":" + dateIn.Second;
                    DateTime now = DateTime.Now;
                    lblJamKeluar.Text = now.Hour + ":" + now.Minute + ":" + now.Second;
                    
                    currentDuration = now.Subtract(dateIn);
                    string message = "Hari :" + currentDuration.Days + " Jam :" + currentDuration.Hours + " Menit :" + currentDuration.Minutes;
                    lblDuration.Text = message;
                    

                    
                    currentTiketID = reader.GetInt64("id");
                    currentMemberID = reader.GetInt64("member_id");
                    if (currentMemberID == AppConfig.NOT_DEFINED_ID)
                    {
                        btnAddDeposit.Enabled = false;
                        gbMember.Visible = false;
                    }
                    else
                    {
                        gbMember.Visible = true;
                        btnAddDeposit.Enabled = true;
                    }
                    // calculate tarif
                    currentInitialTarif = reader.GetInt64("initial_price");
                    long extendedTarifInt = AppConfig.Instance.CalculateExtendedTarif(currentDuration);                    
                    long totalTarif = currentInitialTarif + extendedTarifInt;

                    txtExtendedTarif.Text = extendedTarifInt.ToString();
                    lblInitialTarif.Text = "Rp. " + currentInitialTarif.ToString();
                    lblTotalTarif.Text = "Rp. " + totalTarif.ToString();

                    string image_file = reader.GetString("image_path");
                    try
                    {
                        Image img = Image.FromFile(System.IO.Path.Combine(imagePath, image_file));
                        pictureBox1.Image = img;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Gambar Kendaraan tidak ditemukan, chek kembali konfigurasi applikasi", "Gambar Tidak Ditemukan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    btnNext.Enabled = true;
                    txtExtendedTarif.Focus();
                }
                reader.Close();
                conn.Close();

                if (!found)
                {
                    ClearForm();
                    MessageBox.Show(this, "Data Tidak Ditemukan, check kembali nomor tiket", "Data Tidak Ditemukan",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            // TODO Process ...
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            FormAddDeposit addDeposit = new FormAddDeposit();
            if (addDeposit.ShowDialog(this) == DialogResult.OK)
            {
                int addedDeposit = addDeposit.Deposit;               
                using (MySqlConnection cnn = new MySqlConnection(AppConfig.Instance.ConnectionString))
                {
                    try
                    {

                        string sql = "select current_deposit from members where id = " +
                            currentMemberID;
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cnn.Open();
                        long currentDeposit = (long)cmd.ExecuteScalar();
                        currentDeposit += addedDeposit;
                        DateTime now = DateTime.Now;
                        string nowStr =
                            now.Year + "-" + now.Month + "-" + now.Day + " " +
                            now.Hour + ":" + now.Minute + ":" + now.Second;

                        sql = "update members set current_deposit = " + currentDeposit +
                            ", last_deposit_at = '" + nowStr + "' " +
                            " where id = " + currentMemberID;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(this, "Sukses melakukan update deposit", "Transaksi Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Gagal melakukan update deposit", "Gagal Transaksi",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                
            }
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (useNetworkStorage)
            {
                networkShare.LogoutFromShare(share_server, share_folder);
            }
            AppConfig.Instance.EndUserGateOperation();
        }

        private void mnItemGantiPassword_Click(object sender, EventArgs e)
        {
            FormChangePassword change = new FormChangePassword(
                AppConfig.Instance.UserID);
            change.ShowDialog(this);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UpdateTicket();
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {            
            currentInitialTarif = 0;
            currentTiketID = AppConfig.NOT_DEFINED_ID;
            currentMemberID = AppConfig.NOT_DEFINED_ID;
            pictureBox1.Image = null;
            gbMember.Visible = false;

            lblJamKeluar.Text = "";
            lblJamMasuk.Text = "";
            lblDuration.Text = "";
            lblInitialTarif.Text = "";
            txtExtendedTarif.Clear();
            txtPay.Clear();
            lblTotalTarif.Text = "Rp. -";
            lblReturnMoney.Text = "Rp. -";

            btnNext.Enabled = false;
            txtSearchTicket.Clear();
            txtSearchTicket.Focus();
            txtSearchTicket.SelectAll();
        }

        private void txtExtendedTarif_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long extendedTarif = 0;
                long.TryParse(txtExtendedTarif.Text, out extendedTarif);
                long total = currentInitialTarif + extendedTarif;
                lblTotalTarif.Text = "Rp. " + total.ToString();
                statusLabelError.Text = "";
                if (txtPay.Text.Trim().Length > 0)
                {
                    txtPay_TextChanged(sender, e);
                }
            }
            catch (Exception)
            {
                statusLabelError.Text = "Data Yang dimasukan bukan angka"; 
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long extendedTarif = 0;
                long bayar = 0;
                long.TryParse(txtExtendedTarif.Text, out extendedTarif);
                long.TryParse(txtPay.Text.Trim(), out bayar);
                long total = currentInitialTarif + extendedTarif;
                statusLabelError.Text = "";
                long returnMoney = bayar - total;
                lblReturnMoney.Text = "Rp. " + returnMoney.ToString();
            }
            catch (Exception)
            {
                statusLabelError.Text = "Data Yang dimasukan bukan angka";
                lblReturnMoney.Text = "Rp. -";
            }
        }

        private void txtExtendedTarif_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHandled = e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtPay.Focus();
                txtPay.SelectAll();
            }
            else if (KeyHandled = e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtExtendedTarif.Clear();
            }
        }

        private void txtExtendedTarif_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = KeyHandled;
        }

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = KeyHandled;
        }

        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyHandled = e.KeyCode == Keys.Enter)
            {
                btnNext.Focus();
            }
            else if (KeyHandled = e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                txtPay.Clear();
            }
        }

        

        
    }
}