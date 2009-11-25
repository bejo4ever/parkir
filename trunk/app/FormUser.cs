using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Commons;
namespace Nv.Parkir
{
    public partial class FormUser : Form
    {
        private DataSet dataset;
        private long selected_id;
        private DataOperationMode operationMode = DataOperationMode.none;
        public FormUser()
        {
            InitializeComponent();
            dataset = new DataSet();
            RefreshGridData();
            GetRoleNames();
        }

        private void RefreshGridData()
        {
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter(
                "select users.id, users.username, users.password, roles.role_name from users, roles where users.role_id = roles.id", conn);
            conn.Open();
            dataset.Clear();
            adapter.Fill(dataset, "users");
            dataGrid.DataSource = dataset.Tables["users"].DefaultView;
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
                }
                else
                {
                    selected_id = -1;
                    operationMode = DataOperationMode.none;

                    btnDelete.Visible = false;
                    btnEdit.Visible = false;
                }
            }
            else
            {
                selected_id = -1;
                operationMode = DataOperationMode.none;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
            }
        }

        private void clear_field_data()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedItem = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear_field_data();
            selected_id = -1;
            groupBox1.Enabled = true;
            groupBox1.Text = "Manage User [Add]";
            operationMode = DataOperationMode.add;
            txtUsername.Enabled = true;
        }

        private void GetRoleNames()
        {
            string sql = "select role_name from roles";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            cmbRole.BeginUpdate();
            cmbRole.Items.Clear();
            while (reader.Read())
            {
                cmbRole.Items.Add(reader.GetString("role_name"));
            }
            cmbRole.EndUpdate();
            reader.Close();
            conn.Close();
        }

        private long GetRoleId(string name)
        {
            string sql = "select id from roles where role_name ='" + name + "' limit 1";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Text = "Manage User [Edit]";
            string sql = "select u.id as id, u.username as name, u.password as password " +
                ", r.role_name as role_name from users u, roles r where u.id = " + selected_id +
                " and u.role_id = r.id";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtUsername.Text = reader.GetString("name");
                txtPassword.Text = reader.GetString("password");
                cmbRole.SelectedItem = reader.GetString("role_name");
            }
            reader.Close();
            conn.Close();
            operationMode = DataOperationMode.edit;
            txtUsername.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                long role_id = GetRoleId(cmbRole.SelectedItem.ToString());
                string sql = "";
                switch (operationMode)
                {
                    case DataOperationMode.add:
                        if (!IsUserAlreadyExist(txtUsername.Text))
                        {
                            sql = "insert into users set username = '" + txtUsername.Text + "', " +
                                "  password = password('" + txtPassword.Text + "'),  role_id = " + role_id;
                            conn.Open();
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show(this, "User dengan nama yang sama sudah ada dalam database",
                                "Konfirmasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    case DataOperationMode.edit:
                        sql = "update users set username = '" + txtUsername.Text + "', " +
                            "password = password('" + txtPassword.Text + "'), " +
                            "role_id = " + role_id + " where id = " + selected_id;
                        conn.Open();
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }
                conn.Close();
                RefreshGridData();
            }
            groupBox1.Enabled = false;
            groupBox1.Text = "Manage User";
        }

        private bool CheckField()
        {
            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show(this, "Field Username tidak boleh kosong", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show(this, "Field Password tidak boleh kosong", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show(this, "Field Role tidak boleh kosong", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;

        }

        private bool IsUserAlreadyExist(string username)
        {
            string sql = "select count(*) as count from users where username = '" + username + "'";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32("count");
            }
            reader.Close();
            conn.Close();
            return count > 0 ? true : false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Text = "Manage User [Hapus]";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            if (MessageBox.Show(this, "Yakin untuk menghapus data ini ?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "delete from users where id = " + selected_id;
                conn.Open();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            RefreshGridData();
            clear_field_data();
            groupBox1.Enabled = false;
            groupBox1.Text = "Manage User";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear_field_data();
            groupBox1.Enabled = false;
            groupBox1.Text = "Manage User";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (null != cmbReportType.SelectedItem)
            {
                GenerateReport(cmbReportType.SelectedItem.ToString());
            }
        }
        
        /// <summary>
        /// Semua
        /// Role = Admin
        /// Role = Operator
        /// </summary>
        /// <param name="p"></param>
        private void GenerateReport(string p)
        {
            switch (p)
            {
                case "Semua":
                    string sql="select users.id, users.username, roles.role_name from users, roles " +
                        " order by roles.role_name asc";

                    break;
                case "Role = Admin":

                    break;
                case "Role = Operator":

                    break;
                default:
                    break;
            }
        }
    }
}