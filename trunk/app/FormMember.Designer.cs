namespace Nv.Parkir
{
    partial class FormMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.groupManage = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLastDeposit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.cmbIdentityType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbGroupMember = new System.Windows.Forms.ComboBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.gbAddDeposit = new System.Windows.Forms.GroupBox();
            this.lblLastDeposit = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancelAddDeposit = new System.Windows.Forms.Button();
            this.btnSaveAddDeposit = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCurrentDeposit = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.groupManage.SuspendLayout();
            this.gbAddDeposit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(3, 220);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(757, 225);
            this.dataGrid.TabIndex = 3;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // groupManage
            // 
            this.groupManage.Controls.Add(this.btnCancel);
            this.groupManage.Controls.Add(this.btnSave);
            this.groupManage.Controls.Add(this.txtLastDeposit);
            this.groupManage.Controls.Add(this.label10);
            this.groupManage.Controls.Add(this.txtDeposit);
            this.groupManage.Controls.Add(this.label9);
            this.groupManage.Controls.Add(this.txtAddress);
            this.groupManage.Controls.Add(this.label8);
            this.groupManage.Controls.Add(this.txtMobilePhone);
            this.groupManage.Controls.Add(this.label7);
            this.groupManage.Controls.Add(this.txtPhone);
            this.groupManage.Controls.Add(this.label6);
            this.groupManage.Controls.Add(this.txtIdentityNumber);
            this.groupManage.Controls.Add(this.cmbIdentityType);
            this.groupManage.Controls.Add(this.txtName);
            this.groupManage.Controls.Add(this.cmbGroupMember);
            this.groupManage.Controls.Add(this.txtRFID);
            this.groupManage.Controls.Add(this.label5);
            this.groupManage.Controls.Add(this.label4);
            this.groupManage.Controls.Add(this.label3);
            this.groupManage.Controls.Add(this.label2);
            this.groupManage.Controls.Add(this.label1);
            this.groupManage.Enabled = false;
            this.groupManage.Location = new System.Drawing.Point(3, 10);
            this.groupManage.Name = "groupManage";
            this.groupManage.Size = new System.Drawing.Size(468, 165);
            this.groupManage.TabIndex = 1;
            this.groupManage.TabStop = false;
            this.groupManage.Text = "Manage Member";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(92, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Simpan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLastDeposit
            // 
            this.txtLastDeposit.Enabled = false;
            this.txtLastDeposit.Location = new System.Drawing.Point(340, 136);
            this.txtLastDeposit.Name = "txtLastDeposit";
            this.txtLastDeposit.Size = new System.Drawing.Size(122, 20);
            this.txtLastDeposit.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Terakhir Deposit";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(322, 112);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(140, 20);
            this.txtDeposit.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Deposit";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(322, 58);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(140, 48);
            this.txtAddress.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Alamat";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(322, 36);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(140, 20);
            this.txtMobilePhone.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "HP";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(322, 13);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(140, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telp.";
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Location = new System.Drawing.Point(84, 107);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(161, 20);
            this.txtIdentityNumber.TabIndex = 4;
            // 
            // cmbIdentityType
            // 
            this.cmbIdentityType.FormattingEnabled = true;
            this.cmbIdentityType.Items.AddRange(new object[] {
            "KTP",
            "SIM",
            "Kartu Pelajar",
            "Lain nya"});
            this.cmbIdentityType.Location = new System.Drawing.Point(84, 83);
            this.cmbIdentityType.Name = "cmbIdentityType";
            this.cmbIdentityType.Size = new System.Drawing.Size(161, 21);
            this.cmbIdentityType.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(161, 20);
            this.txtName.TabIndex = 2;
            // 
            // cmbGroupMember
            // 
            this.cmbGroupMember.FormattingEnabled = true;
            this.cmbGroupMember.Location = new System.Drawing.Point(84, 36);
            this.cmbGroupMember.Name = "cmbGroupMember";
            this.cmbGroupMember.Size = new System.Drawing.Size(161, 21);
            this.cmbGroupMember.TabIndex = 1;
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(84, 13);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(161, 20);
            this.txtRFID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "No. Identitas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipe Identitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group Member";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFID";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 194);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(87, 194);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 194);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.Location = new System.Drawing.Point(249, 194);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(98, 23);
            this.btnAddDeposit.TabIndex = 4;
            this.btnAddDeposit.Text = "&Tambah Deposit";
            this.btnAddDeposit.UseVisualStyleBackColor = true;
            this.btnAddDeposit.Visible = false;
            this.btnAddDeposit.Click += new System.EventHandler(this.btnAddDeposit_Click);
            // 
            // gbAddDeposit
            // 
            this.gbAddDeposit.Controls.Add(this.lblLastDeposit);
            this.gbAddDeposit.Controls.Add(this.label12);
            this.gbAddDeposit.Controls.Add(this.btnCancelAddDeposit);
            this.gbAddDeposit.Controls.Add(this.btnSaveAddDeposit);
            this.gbAddDeposit.Controls.Add(this.label13);
            this.gbAddDeposit.Controls.Add(this.lblCurrentDeposit);
            this.gbAddDeposit.Controls.Add(this.textBox2);
            this.gbAddDeposit.Controls.Add(this.label11);
            this.gbAddDeposit.Location = new System.Drawing.Point(477, 16);
            this.gbAddDeposit.Name = "gbAddDeposit";
            this.gbAddDeposit.Size = new System.Drawing.Size(237, 159);
            this.gbAddDeposit.TabIndex = 5;
            this.gbAddDeposit.TabStop = false;
            this.gbAddDeposit.Text = "Tambah Deposit";
            this.gbAddDeposit.Visible = false;
            // 
            // lblLastDeposit
            // 
            this.lblLastDeposit.Location = new System.Drawing.Point(80, 85);
            this.lblLastDeposit.Name = "lblLastDeposit";
            this.lblLastDeposit.Size = new System.Drawing.Size(100, 15);
            this.lblLastDeposit.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Saldo Akhir :";
            // 
            // btnCancelAddDeposit
            // 
            this.btnCancelAddDeposit.Location = new System.Drawing.Point(154, 130);
            this.btnCancelAddDeposit.Name = "btnCancelAddDeposit";
            this.btnCancelAddDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAddDeposit.TabIndex = 6;
            this.btnCancelAddDeposit.Text = "B&atal";
            this.btnCancelAddDeposit.UseVisualStyleBackColor = true;
            this.btnCancelAddDeposit.Click += new System.EventHandler(this.btnCancelAddDeposit_Click);
            // 
            // btnSaveAddDeposit
            // 
            this.btnSaveAddDeposit.Location = new System.Drawing.Point(73, 130);
            this.btnSaveAddDeposit.Name = "btnSaveAddDeposit";
            this.btnSaveAddDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAddDeposit.TabIndex = 5;
            this.btnSaveAddDeposit.Text = "S&impan";
            this.btnSaveAddDeposit.UseVisualStyleBackColor = true;
            this.btnSaveAddDeposit.Click += new System.EventHandler(this.btnSaveAddDeposit_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Tambah :";
            // 
            // lblCurrentDeposit
            // 
            this.lblCurrentDeposit.Location = new System.Drawing.Point(80, 26);
            this.lblCurrentDeposit.Name = "lblCurrentDeposit";
            this.lblCurrentDeposit.Size = new System.Drawing.Size(151, 17);
            this.lblCurrentDeposit.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(83, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Saldo Awal:";
            // 
            // FormMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 444);
            this.Controls.Add(this.gbAddDeposit);
            this.Controls.Add(this.btnAddDeposit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupManage);
            this.Controls.Add(this.dataGrid);
            this.Name = "FormMember";
            this.ShowIcon = false;
            this.Text = "Form Keanggotaan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.groupManage.ResumeLayout(false);
            this.groupManage.PerformLayout();
            this.gbAddDeposit.ResumeLayout(false);
            this.gbAddDeposit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.GroupBox groupManage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMobilePhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.ComboBox cmbIdentityType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbGroupMember;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLastDeposit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddDeposit;
        private System.Windows.Forms.GroupBox gbAddDeposit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCurrentDeposit;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancelAddDeposit;
        private System.Windows.Forms.Button btnSaveAddDeposit;
        private System.Windows.Forms.Label lblLastDeposit;
        private System.Windows.Forms.Label label12;

    }
}