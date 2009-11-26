namespace Nv.Parkir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelStartLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemMember = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemGantiPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemLaporan = new System.Windows.Forms.ToolStripMenuItem();
            this.nmItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnItemGate = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelUser,
            this.statusLabelStartLogin,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(845, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelUser
            // 
            this.statusLabelUser.Name = "statusLabelUser";
            this.statusLabelUser.Size = new System.Drawing.Size(36, 17);
            this.statusLabelUser.Text = "User :";
            // 
            // statusLabelStartLogin
            // 
            this.statusLabelStartLogin.Name = "statusLabelStartLogin";
            this.statusLabelStartLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabel2.Text = "Jam:";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.mnItemManage,
            this.mnItemReport,
            this.nmItemWindow,
            this.mnItemHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.nmItemWindow;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(845, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemLogin,
            this.mnItemExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // mnItemLogin
            // 
            this.mnItemLogin.Name = "mnItemLogin";
            this.mnItemLogin.Size = new System.Drawing.Size(110, 22);
            this.mnItemLogin.Text = "&Login";
            this.mnItemLogin.Click += new System.EventHandler(this.mnItemLogin_Click);
            // 
            // mnItemExit
            // 
            this.mnItemExit.Name = "mnItemExit";
            this.mnItemExit.Size = new System.Drawing.Size(110, 22);
            this.mnItemExit.Text = "&Exit";
            this.mnItemExit.Click += new System.EventHandler(this.mnItemExit_Click);
            // 
            // mnItemManage
            // 
            this.mnItemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemPrice,
            this.mnItemUser,
            this.mnItemMember,
            this.mnItemGantiPassword,
            this.mnItemSetting,
            this.mnItemGate});
            this.mnItemManage.Name = "mnItemManage";
            this.mnItemManage.Size = new System.Drawing.Size(57, 20);
            this.mnItemManage.Text = "Manage";
            this.mnItemManage.Visible = false;
            // 
            // mnItemPrice
            // 
            this.mnItemPrice.Name = "mnItemPrice";
            this.mnItemPrice.Size = new System.Drawing.Size(159, 22);
            this.mnItemPrice.Text = "Price";
            this.mnItemPrice.Click += new System.EventHandler(this.priceToolStripMenuItem_Click);
            // 
            // mnItemUser
            // 
            this.mnItemUser.Name = "mnItemUser";
            this.mnItemUser.Size = new System.Drawing.Size(159, 22);
            this.mnItemUser.Text = "User";
            this.mnItemUser.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // mnItemMember
            // 
            this.mnItemMember.Name = "mnItemMember";
            this.mnItemMember.Size = new System.Drawing.Size(159, 22);
            this.mnItemMember.Text = "Member";
            this.mnItemMember.Click += new System.EventHandler(this.mnItemMember_Click);
            // 
            // mnItemGantiPassword
            // 
            this.mnItemGantiPassword.Name = "mnItemGantiPassword";
            this.mnItemGantiPassword.Size = new System.Drawing.Size(159, 22);
            this.mnItemGantiPassword.Text = "&Ganti Password";
            this.mnItemGantiPassword.Click += new System.EventHandler(this.mnItemGantiPassword_Click);
            // 
            // mnItemSetting
            // 
            this.mnItemSetting.Name = "mnItemSetting";
            this.mnItemSetting.Size = new System.Drawing.Size(159, 22);
            this.mnItemSetting.Text = "&Setting";
            this.mnItemSetting.Click += new System.EventHandler(this.mnItemSetting_Click);
            // 
            // mnItemReport
            // 
            this.mnItemReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemLaporan});
            this.mnItemReport.Name = "mnItemReport";
            this.mnItemReport.Size = new System.Drawing.Size(52, 20);
            this.mnItemReport.Text = "Report";
            this.mnItemReport.Visible = false;
            // 
            // mnItemLaporan
            // 
            this.mnItemLaporan.Name = "mnItemLaporan";
            this.mnItemLaporan.Size = new System.Drawing.Size(152, 22);
            this.mnItemLaporan.Text = "Laporan";
            this.mnItemLaporan.Click += new System.EventHandler(this.mnItemLaporan_Click);
            // 
            // nmItemWindow
            // 
            this.nmItemWindow.Name = "nmItemWindow";
            this.nmItemWindow.Size = new System.Drawing.Size(57, 20);
            this.nmItemWindow.Text = "Window";
            // 
            // mnItemHelp
            // 
            this.mnItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnItemAbout});
            this.mnItemHelp.Name = "mnItemHelp";
            this.mnItemHelp.Size = new System.Drawing.Size(40, 20);
            this.mnItemHelp.Text = "Help";
            // 
            // mnItemAbout
            // 
            this.mnItemAbout.Name = "mnItemAbout";
            this.mnItemAbout.Size = new System.Drawing.Size(114, 22);
            this.mnItemAbout.Text = "About";
            this.mnItemAbout.Click += new System.EventHandler(this.mnItemAbout_Click);
            // 
            // mnItemGate
            // 
            this.mnItemGate.Name = "mnItemGate";
            this.mnItemGate.Size = new System.Drawing.Size(159, 22);
            this.mnItemGate.Text = "Gate";
            this.mnItemGate.Click += new System.EventHandler(this.mnItemGate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 511);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FormMain";
            this.Text = "Form Main";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnItemLogin;
        private System.Windows.Forms.ToolStripMenuItem mnItemManage;
        private System.Windows.Forms.ToolStripMenuItem mnItemPrice;
        private System.Windows.Forms.ToolStripMenuItem mnItemUser;
        private System.Windows.Forms.ToolStripMenuItem mnItemReport;
        private System.Windows.Forms.ToolStripMenuItem mnItemLaporan;
        private System.Windows.Forms.ToolStripMenuItem mnItemHelp;
        private System.Windows.Forms.ToolStripMenuItem mnItemExit;
        private System.Windows.Forms.ToolStripMenuItem mnItemAbout;
        private System.Windows.Forms.ToolStripMenuItem mnItemMember;
        private System.Windows.Forms.ToolStripMenuItem nmItemWindow;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelStartLogin;
        private System.Windows.Forms.ToolStripMenuItem mnItemGantiPassword;
        private System.Windows.Forms.ToolStripMenuItem mnItemSetting;
        private System.Windows.Forms.ToolStripMenuItem mnItemGate;

    }
}

