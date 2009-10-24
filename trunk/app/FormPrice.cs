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
    public partial class FormPrice : Form
    {
        private DataSet dataset;
        private long selected_id = -1;
        private long selected_group_id = -1;
        private string selected_group_name = "";
        private DataOperationMode dataOperationMode = DataOperationMode.none;

        public FormPrice()
        {
            InitializeComponent();

            dataset = new DataSet();
            
            RefreshGridData();
            GetPriceGroups();
        }

        private void GetPriceGroups()
        {
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand("select group_name from price_groups", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            cbPriceGroups.BeginUpdate();
            cbPriceGroups.Items.Clear();
            while (reader.Read())
            {
                cbPriceGroups.Items.Add(reader.GetString("group_name"));
            }
            cbPriceGroups.EndUpdate();
            reader.Close();
            conn.Close();
        }

        private long PriceGroupId(string name)
        {
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand("select id from price_groups where group_name ='"
                + name + "' limit 1", conn);
            conn.Open();
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return long.Parse(obj.ToString());
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
                    groupBoxEdit.Visible = true;
                }
                else
                {
                    clear_data_detail();
                    groupBoxEdit.Visible = false;
                }
            }
            else
            {
                clear_data_detail();
                groupBoxEdit.Visible = false;
            }
        }

        private void RefreshGridData()
        {
            dataset.Clear();
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(
               AppConfig.Instance.ConnectionString);
            MySql.Data.MySqlClient.MySqlDataAdapter adp = new MySql.Data.MySqlClient.MySqlDataAdapter(
                "select p.id as id, p.name as name, p.initial_price as initial_tarif, p.extended_price as " +
                " extended_tarif, g.group_name from price p, price_groups g where " + 
                " p.group_id = g.id", conn);
            conn.Open();
            adp.Fill(dataset, "price");
            dataGrid.DataSource = dataset.Tables["price"].DefaultView;
        }

        private void clear_data_detail()
        {
            txtName.Clear();
            txtInitialPrice.Clear();
            txtExtendedPrice.Clear();
            cbPriceGroups.SelectedItem = null;
            selected_id = -1;
            selected_group_id = -1;
            selected_group_name = "";
            dataOperationMode = DataOperationMode.none;
        }

        private void show_data_detail()
        {
            string sql = "select p.name as name, pg.id as group_id , pg.group_name as group_name, " +
                " p.initial_price as initial_price , p.extended_price as extended_price from price p, price_groups pg where p.id = "
                + selected_id.ToString() + " and p.group_id = pg.id";
            MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtName.Text = reader.GetString("name");
                selected_group_id = reader.GetInt64("group_id");
                selected_group_name = reader.GetString("group_name");

                cbPriceGroups.SelectedItem = selected_group_name;
                txtInitialPrice.Text = reader.GetString("initial_price");
                txtExtendedPrice.Text = reader.GetString("extended_price");
            }

            reader.Close();
            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dataOperationMode = DataOperationMode.edit;
            btnSave.Enabled = true;
            groupBoxEdit.Enabled = true;
            groupBoxEdit.Text = "Manage Tarif [Edit]";
            show_data_detail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "";
            MySqlConnection conn;
            MySqlCommand cmn;
            show_data_detail();
            groupBoxEdit.Enabled = true;
            groupBoxEdit.Text = "Manage Tarif [Hapus]";
            dataOperationMode = DataOperationMode.delete;
            //TODO add confirm dialog
            if (MessageBox.Show(this, "Yakin untuk menghapus data ini ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                sql = "delete from price where id = " + selected_id;
                conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
                cmn = new MySqlCommand(sql, conn);
                conn.Open();
                cmn.ExecuteNonQuery();
                conn.Close();
                RefreshGridData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear_data_detail();
            dataOperationMode = DataOperationMode.add;
            groupBoxEdit.Enabled = true;
            groupBoxEdit.Text = "Manage Tarif [Add]";
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (dataOperationMode)
            {
                case DataOperationMode.add:
                    DateTime now = DateTime.Now;
                    string strNow = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Hour;
                    long price_groups_id = PriceGroupId(cbPriceGroups.SelectedItem.ToString());
                    string sql = "insert into price set name = '" + txtName.Text + "', group_id = " + price_groups_id +
                        ", initial_price = " + txtInitialPrice.Text + ", extended_price = " + txtExtendedPrice.Text +
                        ", created_at = '" + strNow + "'";
                    MySqlConnection conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
                    MySqlCommand cmn = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmn.ExecuteNonQuery();
                    conn.Close();
                    break;
                case DataOperationMode.edit:
                    now = DateTime.Now;
                    strNow = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" + now.Minute + ":" + now.Hour;
                    price_groups_id = PriceGroupId(cbPriceGroups.SelectedItem.ToString());
                    sql = "update price set name = '" + txtName.Text + "', group_id = " + price_groups_id +
                        ", initial_price = " + txtInitialPrice.Text + ", extended_price = " + txtExtendedPrice.Text +
                        ", modified_at = '" + strNow + "' where id = " + selected_id;

                    conn = new MySqlConnection(AppConfig.Instance.ConnectionString);
                    cmn = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmn.ExecuteNonQuery();
                    conn.Close();
                    break;                
                default:

                    break;
            }
            RefreshGridData();
            btnSave.Enabled = false;
            groupBoxEdit.Text = "Manage Tarif";
            groupBoxEdit.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear_data_detail();
            groupBoxEdit.Enabled = false;
            groupBoxEdit.Text = "Manage Tarif";
        }
    }
}