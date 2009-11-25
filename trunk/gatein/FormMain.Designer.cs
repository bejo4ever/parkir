namespace gatein
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnItemOpenPortal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemOpenInput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCompanyAddress = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblGateName = new System.Windows.Forms.Label();
            this.videoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusKoneksiPortal = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusKoneksiInput = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTiket = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTransfer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusAmbilGambar = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnOpenPortal = new System.Windows.Forms.Button();
            this.btnTakeImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNopol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarif = new System.Windows.Forms.TextBox();
            this.txtCashPay = new System.Windows.Forms.TextBox();
            this.txtCashBack = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCloseGate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemSetting,
            this.toolStripSeparator1,
            this.mnItemOpenPortal,
            this.mnItemOpenInput,
            this.toolStripSeparator2,
            this.mnItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 104);
            // 
            // mnItemSetting
            // 
            this.mnItemSetting.Name = "mnItemSetting";
            this.mnItemSetting.Size = new System.Drawing.Size(148, 22);
            this.mnItemSetting.Text = "Open Setting";
            this.mnItemSetting.Click += new System.EventHandler(this.openSettingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnItemOpenPortal
            // 
            this.mnItemOpenPortal.Name = "mnItemOpenPortal";
            this.mnItemOpenPortal.Size = new System.Drawing.Size(148, 22);
            this.mnItemOpenPortal.Text = "Open Portal";
            // 
            // mnItemOpenInput
            // 
            this.mnItemOpenInput.Name = "mnItemOpenInput";
            this.mnItemOpenInput.Size = new System.Drawing.Size(148, 22);
            this.mnItemOpenInput.Text = "Open Input";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // mnItemExit
            // 
            this.mnItemExit.Name = "mnItemExit";
            this.mnItemExit.Size = new System.Drawing.Size(148, 22);
            this.mnItemExit.Text = "E&xit";
            this.mnItemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblCompanyAddress);
            this.panel1.Controls.Add(this.lblCompanyName);
            this.panel1.Controls.Add(this.lblGateName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 63);
            this.panel1.TabIndex = 1;
            // 
            // lblCompanyAddress
            // 
            this.lblCompanyAddress.AutoSize = true;
            this.lblCompanyAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyAddress.ForeColor = System.Drawing.Color.White;
            this.lblCompanyAddress.Location = new System.Drawing.Point(8, 39);
            this.lblCompanyAddress.Name = "lblCompanyAddress";
            this.lblCompanyAddress.Size = new System.Drawing.Size(0, 17);
            this.lblCompanyAddress.TabIndex = 2;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(3, 4);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(0, 24);
            this.lblCompanyName.TabIndex = 1;
            // 
            // lblGateName
            // 
            this.lblGateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGateName.AutoSize = true;
            this.lblGateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGateName.ForeColor = System.Drawing.Color.White;
            this.lblGateName.Location = new System.Drawing.Point(575, 9);
            this.lblGateName.Name = "lblGateName";
            this.lblGateName.Size = new System.Drawing.Size(0, 31);
            this.lblGateName.TabIndex = 0;
            this.lblGateName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // videoPlayer
            // 
            this.videoPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPlayer.Location = new System.Drawing.Point(318, 69);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(519, 414);
            this.videoPlayer.TabIndex = 2;
            this.videoPlayer.VideoSource = null;
            this.videoPlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusKoneksiPortal,
            this.statusKoneksiInput,
            this.statusTiket,
            this.statusTransfer,
            this.statusAmbilGambar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusKoneksiPortal
            // 
            this.statusKoneksiPortal.Name = "statusKoneksiPortal";
            this.statusKoneksiPortal.Size = new System.Drawing.Size(74, 17);
            this.statusKoneksiPortal.Text = "Koneksi Portal";
            // 
            // statusKoneksiInput
            // 
            this.statusKoneksiInput.Name = "statusKoneksiInput";
            this.statusKoneksiInput.Size = new System.Drawing.Size(72, 17);
            this.statusKoneksiInput.Text = "Koneksi Input";
            // 
            // statusTiket
            // 
            this.statusTiket.Name = "statusTiket";
            this.statusTiket.Size = new System.Drawing.Size(64, 17);
            this.statusTiket.Text = "Status Tiket";
            // 
            // statusTransfer
            // 
            this.statusTransfer.Name = "statusTransfer";
            this.statusTransfer.Size = new System.Drawing.Size(82, 17);
            this.statusTransfer.Text = "Status Transfer";
            // 
            // statusAmbilGambar
            // 
            this.statusAmbilGambar.Name = "statusAmbilGambar";
            this.statusAmbilGambar.Size = new System.Drawing.Size(72, 17);
            this.statusAmbilGambar.Text = "Ambil Gambar";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(74, 84);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(35, 29);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "xx";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(108, 120);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 29);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "yy";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnOpenPortal
            // 
            this.btnOpenPortal.Location = new System.Drawing.Point(79, 454);
            this.btnOpenPortal.Name = "btnOpenPortal";
            this.btnOpenPortal.Size = new System.Drawing.Size(71, 35);
            this.btnOpenPortal.TabIndex = 4;
            this.btnOpenPortal.Text = "&Buka";
            this.btnOpenPortal.UseVisualStyleBackColor = true;
            this.btnOpenPortal.Click += new System.EventHandler(this.btnOpenPortal_Click);
            // 
            // btnTakeImage
            // 
            this.btnTakeImage.Location = new System.Drawing.Point(216, 197);
            this.btnTakeImage.Name = "btnTakeImage";
            this.btnTakeImage.Size = new System.Drawing.Size(75, 39);
            this.btnTakeImage.TabIndex = 1;
            this.btnTakeImage.Text = "Ambil Gambar";
            this.btnTakeImage.UseVisualStyleBackColor = true;
            this.btnTakeImage.Click += new System.EventHandler(this.btnTakeImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(2, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Cetak";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNopol
            // 
            this.txtNopol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNopol.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNopol.Location = new System.Drawing.Point(11, 192);
            this.txtNopol.Name = "txtNopol";
            this.txtNopol.Size = new System.Drawing.Size(199, 44);
            this.txtNopol.TabIndex = 0;
            this.txtNopol.Text = "L4435CE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nomor Polisi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tarif Masuk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Bayar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Kembali";
            // 
            // txtTarif
            // 
            this.txtTarif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarif.Location = new System.Drawing.Point(90, 239);
            this.txtTarif.Name = "txtTarif";
            this.txtTarif.ReadOnly = true;
            this.txtTarif.Size = new System.Drawing.Size(152, 26);
            this.txtTarif.TabIndex = 21;
            // 
            // txtCashPay
            // 
            this.txtCashPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashPay.Location = new System.Drawing.Point(90, 270);
            this.txtCashPay.Name = "txtCashPay";
            this.txtCashPay.Size = new System.Drawing.Size(152, 26);
            this.txtCashPay.TabIndex = 2;
            this.txtCashPay.TextChanged += new System.EventHandler(this.txtCashPay_TextChanged);
            // 
            // txtCashBack
            // 
            this.txtCashBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashBack.Location = new System.Drawing.Point(90, 300);
            this.txtCashBack.Name = "txtCashBack";
            this.txtCashBack.ReadOnly = true;
            this.txtCashBack.Size = new System.Drawing.Size(152, 26);
            this.txtCashBack.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 116);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Daftar Tarif";
            // 
            // btnCloseGate
            // 
            this.btnCloseGate.Location = new System.Drawing.Point(156, 454);
            this.btnCloseGate.Name = "btnCloseGate";
            this.btnCloseGate.Size = new System.Drawing.Size(75, 35);
            this.btnCloseGate.TabIndex = 5;
            this.btnCloseGate.Text = "&Tutup";
            this.btnCloseGate.UseVisualStyleBackColor = true;
            this.btnCloseGate.Click += new System.EventHandler(this.btnCloseGate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "B&atal";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 511);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCloseGate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCashBack);
            this.Controls.Add(this.txtCashPay);
            this.Controls.Add(this.txtTarif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNopol);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOpenPortal);
            this.Controls.Add(this.btnTakeImage);
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnItemSetting;
        private System.Windows.Forms.ToolStripMenuItem mnItemExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGateName;
        private System.Windows.Forms.Label lblCompanyAddress;
        private System.Windows.Forms.Label lblCompanyName;
        private AForge.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusKoneksiInput;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel statusTiket;
        private System.Windows.Forms.Button btnOpenPortal;
        private System.Windows.Forms.ToolStripStatusLabel statusTransfer;
        private System.Windows.Forms.Button btnTakeImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNopol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarif;
        private System.Windows.Forms.TextBox txtCashPay;
        private System.Windows.Forms.TextBox txtCashBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCloseGate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripStatusLabel statusAmbilGambar;
        private System.Windows.Forms.ToolStripStatusLabel statusKoneksiPortal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnItemOpenPortal;
        private System.Windows.Forms.ToolStripMenuItem mnItemOpenInput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

