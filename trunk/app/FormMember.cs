using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nv.Parkir
{
    using MySql.Data.MySqlClient;
    using Commons;

    public partial class FormMember : Form
    {
        private DataOperationMode operationMode;
        private long selected_id = -1;
        private DataSet dataset;

        private int currentDeposit = 0;

        public FormMember()
        {
            InitializeComponent();
            dataset = new DataSet();
            GetGroupMembers();
            RefreshGrid();
        }

        private void GetGroupMembers()
        {
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(
                "select name from member_groups order by name asc",
                conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            cmbGroupMember.BeginUpdate();
            cmbGroupMember.Items.Clear();
            while (reader.Read())
            {
                cmbGroupMember.Items.Add(reader.GetString("name"));
            }
            reader.Close();
            cmbGroupMember.EndUpdate();
            conn.Close();
        }

        private long GetGroupsId(string groupName)
        {
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(
                "select id from member_groups where name = '" + groupName + "' limit 1",
                conn);
            conn.Open();
            long result = -1;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt64("id");
            }
            reader.Close();
            conn.Close();
            return result;
        }

        private void ClearDataDetail()
        {
            txtRFID.Clear();
            cmbGroupMember.SelectedItem = null;
            txtName.Clear();
            cmbIdentityType.SelectedItem = null;
            txtIdentityNumber.Clear();
            txtPhone.Clear();
            txtMobilePhone.Clear();
            txtAddress.Clear();
            txtDeposit.Clear();
            txtLastDeposit.Clear();
        }

        

        private void RefreshGrid()
        {
            dataset.Clear();
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "select m.id as id, m.rf_id as rfid, g.name as member_groups," +
                "m.name as name, m.identity_no as identity, m.identity_type as identity_type, " +
                "m.phone as phone, m.mobile_phone as mobile, m.address as address, " +
                "m.current_deposit as deposit,m.last_deposit_at as last_deposit from members as m," +
                " member_groups g where m.member_group_id = g.id", conn);
            conn.Open();
            adapter.Fill(dataset, "members");
            dataGrid.DataSource = dataset.Tables["members"].DefaultView;
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGrid.CurrentCell.Value.ToString().Length > 0)
                {
                    selected_id = long.Parse(dataGrid.CurrentCell.Value.ToString());
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnAddDeposit.Visible = true;
                }
                else
                {
                    selected_id = -1;
                    operationMode = DataOperationMode.none;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnAddDeposit.Visible = false;
                }
            }
            else
            {
                selected_id = -1;
                operationMode = DataOperationMode.none;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnAddDeposit.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            operationMode = DataOperationMode.add;
            groupManage.Enabled = true;
            groupManage.Text = "Manage Member [Add]";
            label10.Visible = false;
            txtLastDeposit.Visible = false;
            ClearDataDetail();
            txtRFID.Focus();
            
        }
        private void FillDataDetail(long selected_id)
        {
            string sql = "select m.id as id, m.rf_id as rfid, g.name as member_groups," +
                "m.name as name, m.identity_no as identity, m.identity_type as identity_type, " +
                "m.phone as phone, m.mobile_phone as mobile, m.address as address, " +
                "m.current_deposit as deposit,m.last_deposit_at as last_deposit from members as m," +
                " member_groups g where m.id = " + selected_id+ " and m.member_group_id = g.id limit 1";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtRFID.Text = reader.GetString("rfid");
                txtName.Text = reader.GetString("name");
                cmbGroupMember.SelectedItem = reader.GetString("member_groups");
                cmbIdentityType.SelectedItem = reader.GetString("identity_type");
                txtIdentityNumber.Text = reader.GetString("identity");
                txtPhone.Text = reader.GetString("phone");
                txtMobilePhone.Text = reader.GetString("mobile");
                txtAddress.Text = reader.GetString("address");
                txtDeposit.Text = reader.GetString("deposit");
                DateTime dt = reader.GetDateTime("last_deposit");
                txtLastDeposit.Text = dt.Year + "-" + dt.Month + "-" + dt.Day + " " +
                    dt.Hour + ":" + dt.Minute + ":" + dt.Second;
            }
            reader.Close();
            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            operationMode = DataOperationMode.edit;
            groupManage.Enabled = true;
            groupManage.Text = "Manage Member [Edit]";
            label10.Visible = true;
            txtLastDeposit.Visible = true;
            FillDataDetail(selected_id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupManage.Text = "Manage Member [Delete]";
            if (MessageBox.Show(this, "Yakin untuk menghapus data member ini ?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                operationMode = DataOperationMode.delete;
                MySqlConnection conn = new MySqlConnection(
                    AppConfig.Instance.ConnectionString);
                MySqlCommand cmd = new MySqlCommand(
                    "delete from members where id = " + selected_id, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                RefreshGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (operationMode)
            {
                case DataOperationMode.add:
                    DateTime nowDate = DateTime.Now;
                    string now = nowDate.Year + "-" + nowDate.Month + "-" + nowDate.Day + " " +
                        nowDate.Hour + ":" + nowDate.Minute + ":" + nowDate.Second;
                    string memberGroup = cmbGroupMember.SelectedItem.ToString();
                    long groupId = GetGroupsId(memberGroup);
                    string sql = "insert into members set rf_id = '" + txtRFID.Text + "', " +
                        " member_group_id = " + groupId.ToString() + ", " +
                        " name = '" + txtName.Text + "', " +
                        " identity_no = '" + txtIdentityNumber.Text + "', " +
                        " identity_type = '" + cmbIdentityType.SelectedItem.ToString() + "', " +
                        " phone = '" + txtPhone.Text + "', " +
                        " mobile_phone = '" + txtMobilePhone.Text + "', " +
                        " address = '" + txtAddress.Text + "', " +
                        " current_deposit = " + txtDeposit.Text + ", " +
                        " last_deposit_at = '" + now + "', " +
                        " created_at = '" + now + "'";
                    MySqlConnection conn = new MySqlConnection(
                        AppConfig.Instance.ConnectionString);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();                  
                    break;
                case DataOperationMode.edit:
                    nowDate = DateTime.Now;
                    now = nowDate.Year + "-" + nowDate.Month + "-" + nowDate.Day + " " +
                        nowDate.Hour + ":" + nowDate.Minute + ":" + nowDate.Second;
                    memberGroup = cmbGroupMember.SelectedItem.ToString();
                    groupId = GetGroupsId(memberGroup);
                    sql = "update members set rf_id = '" + txtRFID.Text + "', " +
                        " member_group_id = " + groupId.ToString() + ", " +
                        " name = '" + txtName.Text + "', " +
                        " identity_no = '" + txtIdentityNumber.Text + "', " +
                        " identity_type = '" + cmbIdentityType.SelectedItem.ToString() + "', " +
                        " phone = '" + txtPhone.Text + "', " +
                        " mobile_phone = '" + txtMobilePhone.Text + "', " +
                        " address = '" + txtAddress.Text + "', " +
                        " current_deposit = " + txtDeposit.Text + ", " +                        
                        " modified_at = '" + now + "' where id = " + selected_id;
                    conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
                    cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close(); 
                    break;
                default:
                    break;
            }
            groupManage.Enabled = false;
            groupManage.Text = "Manage Member";
            RefreshGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearDataDetail();
            groupManage.Enabled = false;
            groupManage.Text = "Manage Member";
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            if (selected_id != -1)
            {
                gbAddDeposit.Visible = true;
                string sql = "select current_deposit from members where id = " + selected_id;
                MySqlConnection conn = new MySqlConnection(
                    Commons.AppConfig.Instance.ConnectionString);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                string deposit = cmd.ExecuteScalar().ToString();
                conn.Close();

                currentDeposit = 0;
                int.TryParse(deposit, out currentDeposit);
                lblCurrentDeposit.Text = "Rp. " + currentDeposit.ToString();
                lblLastDeposit.Text = lblCurrentDeposit.Text;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int addedDeposit = 0;
            int.TryParse(textBox2.Text, out addedDeposit);

            int total = addedDeposit + currentDeposit;
            lblLastDeposit.Text = "Rp. " + total.ToString();
        }

        private void btnSaveAddDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                int adddeDeposit = 0;
                int.TryParse(textBox2.Text, out adddeDeposit);
                int total = adddeDeposit + currentDeposit;
                string sql = "update members set current_deposit = " + total + " where id = " + selected_id;
                MySqlConnection conn = new MySqlConnection(
                    Commons.AppConfig.Instance.ConnectionString);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("success update deposit ..", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbAddDeposit.Visible = false;
                RefreshGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed Update Deposit ", "Terjadi Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelAddDeposit_Click(object sender, EventArgs e)
        {
            gbAddDeposit.Visible = false;
            textBox2.Clear();

        }
    }
}