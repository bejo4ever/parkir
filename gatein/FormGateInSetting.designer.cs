namespace gatein
{
  partial class FormGateInSetting
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGateInSetting));
        this.rtfTerminal = new System.Windows.Forms.RichTextBox();
        this.txtSendData = new System.Windows.Forms.TextBox();
        this.lblSend = new System.Windows.Forms.Label();
        this.btnSend = new System.Windows.Forms.Button();
        this.cmbInputPortName = new System.Windows.Forms.ComboBox();
        this.cmbInputBaudRate = new System.Windows.Forms.ComboBox();
        this.rbHex = new System.Windows.Forms.RadioButton();
        this.rbText = new System.Windows.Forms.RadioButton();
        this.gbMode = new System.Windows.Forms.GroupBox();
        this.lblComPort = new System.Windows.Forms.Label();
        this.lblBaudRate = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.cmbInputParity = new System.Windows.Forms.ComboBox();
        this.lblDataBits = new System.Windows.Forms.Label();
        this.cmbInputDataBits = new System.Windows.Forms.ComboBox();
        this.lblStopBits = new System.Windows.Forms.Label();
        this.cmbInputStopBits = new System.Windows.Forms.ComboBox();
        this.btnOpenPort = new System.Windows.Forms.Button();
        this.gbPortSettings = new System.Windows.Forms.GroupBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.btnOpenCamera = new System.Windows.Forms.Button();
        this.txtCameraPassword = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.txtCameraUsername = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txtCameraUrl = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.videoSource = new AForge.Controls.VideoSourcePlayer();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.button1 = new System.Windows.Forms.Button();
        this.gbGateSetting = new System.Windows.Forms.GroupBox();
        this.label5 = new System.Windows.Forms.Label();
        this.cmbGatePortName = new System.Windows.Forms.ComboBox();
        this.label6 = new System.Windows.Forms.Label();
        this.cmbGateBaudRate = new System.Windows.Forms.ComboBox();
        this.cmbGateStopBits = new System.Windows.Forms.ComboBox();
        this.label7 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.cmbGateParity = new System.Windows.Forms.ComboBox();
        this.cmbGateDataBits = new System.Windows.Forms.ComboBox();
        this.label9 = new System.Windows.Forms.Label();
        this.gbGateDataMode = new System.Windows.Forms.GroupBox();
        this.rbGateText = new System.Windows.Forms.RadioButton();
        this.rbGateHex = new System.Windows.Forms.RadioButton();
        this.txtGateSendData = new System.Windows.Forms.TextBox();
        this.label10 = new System.Windows.Forms.Label();
        this.btnGateSend = new System.Windows.Forms.Button();
        this.groupBox4 = new System.Windows.Forms.GroupBox();
        this.btnApply = new System.Windows.Forms.Button();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.btnClose = new System.Windows.Forms.Button();
        this.gbMode.SuspendLayout();
        this.gbPortSettings.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        this.gbGateSetting.SuspendLayout();
        this.gbGateDataMode.SuspendLayout();
        this.groupBox4.SuspendLayout();
        this.SuspendLayout();
        // 
        // rtfTerminal
        // 
        this.rtfTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.rtfTerminal.Location = new System.Drawing.Point(401, 4);
        this.rtfTerminal.Name = "rtfTerminal";
        this.rtfTerminal.Size = new System.Drawing.Size(468, 179);
        this.rtfTerminal.TabIndex = 0;
        this.rtfTerminal.Text = "";
        // 
        // txtSendData
        // 
        this.txtSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtSendData.Location = new System.Drawing.Point(71, 12);
        this.txtSendData.Name = "txtSendData";
        this.txtSendData.Size = new System.Drawing.Size(307, 20);
        this.txtSendData.TabIndex = 2;
        this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendData_KeyDown);
        this.txtSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendData_KeyPress);
        // 
        // lblSend
        // 
        this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.lblSend.AutoSize = true;
        this.lblSend.Location = new System.Drawing.Point(4, 15);
        this.lblSend.Name = "lblSend";
        this.lblSend.Size = new System.Drawing.Size(61, 13);
        this.lblSend.TabIndex = 1;
        this.lblSend.Text = "Send &Data:";
        // 
        // btnSend
        // 
        this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSend.Location = new System.Drawing.Point(384, 10);
        this.btnSend.Name = "btnSend";
        this.btnSend.Size = new System.Drawing.Size(75, 23);
        this.btnSend.TabIndex = 3;
        this.btnSend.Text = "Send";
        this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
        // 
        // cmbInputPortName
        // 
        this.cmbInputPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbInputPortName.FormattingEnabled = true;
        this.cmbInputPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
        this.cmbInputPortName.Location = new System.Drawing.Point(13, 35);
        this.cmbInputPortName.Name = "cmbInputPortName";
        this.cmbInputPortName.Size = new System.Drawing.Size(67, 21);
        this.cmbInputPortName.TabIndex = 1;
        // 
        // cmbInputBaudRate
        // 
        this.cmbInputBaudRate.FormattingEnabled = true;
        this.cmbInputBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
        this.cmbInputBaudRate.Location = new System.Drawing.Point(86, 35);
        this.cmbInputBaudRate.Name = "cmbInputBaudRate";
        this.cmbInputBaudRate.Size = new System.Drawing.Size(69, 21);
        this.cmbInputBaudRate.TabIndex = 3;
        this.cmbInputBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBaudRate_Validating);
        // 
        // rbHex
        // 
        this.rbHex.AutoSize = true;
        this.rbHex.Location = new System.Drawing.Point(12, 39);
        this.rbHex.Name = "rbHex";
        this.rbHex.Size = new System.Drawing.Size(44, 17);
        this.rbHex.TabIndex = 1;
        this.rbHex.Text = "Hex";
        this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
        // 
        // rbText
        // 
        this.rbText.AutoSize = true;
        this.rbText.Location = new System.Drawing.Point(12, 19);
        this.rbText.Name = "rbText";
        this.rbText.Size = new System.Drawing.Size(46, 17);
        this.rbText.TabIndex = 0;
        this.rbText.Text = "Text";
        this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
        // 
        // gbMode
        // 
        this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbMode.Controls.Add(this.rbText);
        this.gbMode.Controls.Add(this.rbHex);
        this.gbMode.Location = new System.Drawing.Point(383, 38);
        this.gbMode.Name = "gbMode";
        this.gbMode.Size = new System.Drawing.Size(84, 64);
        this.gbMode.TabIndex = 5;
        this.gbMode.TabStop = false;
        this.gbMode.Text = "Data &Mode";
        // 
        // lblComPort
        // 
        this.lblComPort.AutoSize = true;
        this.lblComPort.Location = new System.Drawing.Point(12, 19);
        this.lblComPort.Name = "lblComPort";
        this.lblComPort.Size = new System.Drawing.Size(56, 13);
        this.lblComPort.TabIndex = 0;
        this.lblComPort.Text = "COM Port:";
        // 
        // lblBaudRate
        // 
        this.lblBaudRate.AutoSize = true;
        this.lblBaudRate.Location = new System.Drawing.Point(85, 19);
        this.lblBaudRate.Name = "lblBaudRate";
        this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
        this.lblBaudRate.TabIndex = 2;
        this.lblBaudRate.Text = "Baud Rate:";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(163, 19);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(36, 13);
        this.label1.TabIndex = 4;
        this.label1.Text = "Parity:";
        // 
        // cmbInputParity
        // 
        this.cmbInputParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbInputParity.FormattingEnabled = true;
        this.cmbInputParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
        this.cmbInputParity.Location = new System.Drawing.Point(161, 35);
        this.cmbInputParity.Name = "cmbInputParity";
        this.cmbInputParity.Size = new System.Drawing.Size(60, 21);
        this.cmbInputParity.TabIndex = 5;
        // 
        // lblDataBits
        // 
        this.lblDataBits.AutoSize = true;
        this.lblDataBits.Location = new System.Drawing.Point(229, 19);
        this.lblDataBits.Name = "lblDataBits";
        this.lblDataBits.Size = new System.Drawing.Size(53, 13);
        this.lblDataBits.TabIndex = 6;
        this.lblDataBits.Text = "Data Bits:";
        // 
        // cmbInputDataBits
        // 
        this.cmbInputDataBits.FormattingEnabled = true;
        this.cmbInputDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
        this.cmbInputDataBits.Location = new System.Drawing.Point(227, 35);
        this.cmbInputDataBits.Name = "cmbInputDataBits";
        this.cmbInputDataBits.Size = new System.Drawing.Size(60, 21);
        this.cmbInputDataBits.TabIndex = 7;
        this.cmbInputDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDataBits_Validating);
        // 
        // lblStopBits
        // 
        this.lblStopBits.AutoSize = true;
        this.lblStopBits.Location = new System.Drawing.Point(295, 19);
        this.lblStopBits.Name = "lblStopBits";
        this.lblStopBits.Size = new System.Drawing.Size(52, 13);
        this.lblStopBits.TabIndex = 8;
        this.lblStopBits.Text = "Stop Bits:";
        // 
        // cmbInputStopBits
        // 
        this.cmbInputStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbInputStopBits.FormattingEnabled = true;
        this.cmbInputStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
        this.cmbInputStopBits.Location = new System.Drawing.Point(293, 35);
        this.cmbInputStopBits.Name = "cmbInputStopBits";
        this.cmbInputStopBits.Size = new System.Drawing.Size(65, 21);
        this.cmbInputStopBits.TabIndex = 9;
        // 
        // btnOpenPort
        // 
        this.btnOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.btnOpenPort.Location = new System.Drawing.Point(389, 100);
        this.btnOpenPort.Name = "btnOpenPort";
        this.btnOpenPort.Size = new System.Drawing.Size(73, 21);
        this.btnOpenPort.TabIndex = 6;
        this.btnOpenPort.Text = "&Open Port";
        this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
        // 
        // gbPortSettings
        // 
        this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbPortSettings.Controls.Add(this.lblComPort);
        this.gbPortSettings.Controls.Add(this.cmbInputPortName);
        this.gbPortSettings.Controls.Add(this.lblStopBits);
        this.gbPortSettings.Controls.Add(this.cmbInputBaudRate);
        this.gbPortSettings.Controls.Add(this.cmbInputStopBits);
        this.gbPortSettings.Controls.Add(this.lblBaudRate);
        this.gbPortSettings.Controls.Add(this.lblDataBits);
        this.gbPortSettings.Controls.Add(this.cmbInputParity);
        this.gbPortSettings.Controls.Add(this.cmbInputDataBits);
        this.gbPortSettings.Controls.Add(this.label1);
        this.gbPortSettings.Location = new System.Drawing.Point(7, 38);
        this.gbPortSettings.Name = "gbPortSettings";
        this.gbPortSettings.Size = new System.Drawing.Size(370, 64);
        this.gbPortSettings.TabIndex = 4;
        this.gbPortSettings.TabStop = false;
        this.gbPortSettings.Text = "Serial Port &Settings";
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.btnOpenPort);
        this.groupBox1.Controls.Add(this.gbPortSettings);
        this.groupBox1.Controls.Add(this.gbMode);
        this.groupBox1.Controls.Add(this.txtSendData);
        this.groupBox1.Controls.Add(this.lblSend);
        this.groupBox1.Controls.Add(this.btnSend);
        this.groupBox1.Location = new System.Drawing.Point(401, 329);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(468, 127);
        this.groupBox1.TabIndex = 7;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "RFID/Input Setting";
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.groupBox4);
        this.groupBox2.Controls.Add(this.videoSource);
        this.groupBox2.Location = new System.Drawing.Point(12, 5);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(383, 454);
        this.groupBox2.TabIndex = 8;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "IP Camera Setting";
        // 
        // btnOpenCamera
        // 
        this.btnOpenCamera.Location = new System.Drawing.Point(282, 70);
        this.btnOpenCamera.Name = "btnOpenCamera";
        this.btnOpenCamera.Size = new System.Drawing.Size(75, 23);
        this.btnOpenCamera.TabIndex = 7;
        this.btnOpenCamera.Text = "O&pen";
        this.btnOpenCamera.UseVisualStyleBackColor = true;
        this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
        // 
        // txtCameraPassword
        // 
        this.txtCameraPassword.Location = new System.Drawing.Point(64, 73);
        this.txtCameraPassword.Name = "txtCameraPassword";
        this.txtCameraPassword.PasswordChar = '+';
        this.txtCameraPassword.Size = new System.Drawing.Size(128, 20);
        this.txtCameraPassword.TabIndex = 6;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(7, 76);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(53, 13);
        this.label4.TabIndex = 5;
        this.label4.Text = "Password";
        // 
        // txtCameraUsername
        // 
        this.txtCameraUsername.Location = new System.Drawing.Point(64, 47);
        this.txtCameraUsername.Name = "txtCameraUsername";
        this.txtCameraUsername.Size = new System.Drawing.Size(128, 20);
        this.txtCameraUsername.TabIndex = 4;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(6, 50);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(55, 13);
        this.label3.TabIndex = 3;
        this.label3.Text = "Username";
        // 
        // txtCameraUrl
        // 
        this.txtCameraUrl.Location = new System.Drawing.Point(64, 10);
        this.txtCameraUrl.Multiline = true;
        this.txtCameraUrl.Name = "txtCameraUrl";
        this.txtCameraUrl.Size = new System.Drawing.Size(293, 34);
        this.txtCameraUrl.TabIndex = 2;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(9, 13);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(35, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "URL :";
        // 
        // videoSource
        // 
        this.videoSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.videoSource.Location = new System.Drawing.Point(6, 19);
        this.videoSource.Name = "videoSource";
        this.videoSource.Size = new System.Drawing.Size(371, 328);
        this.videoSource.TabIndex = 0;
        this.videoSource.Text = "videoSourcePlayer1";
        this.videoSource.VideoSource = null;
        // 
        // groupBox3
        // 
        this.groupBox3.Controls.Add(this.button1);
        this.groupBox3.Controls.Add(this.gbGateSetting);
        this.groupBox3.Controls.Add(this.gbGateDataMode);
        this.groupBox3.Controls.Add(this.txtGateSendData);
        this.groupBox3.Controls.Add(this.label10);
        this.groupBox3.Controls.Add(this.btnGateSend);
        this.groupBox3.Location = new System.Drawing.Point(401, 189);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(468, 134);
        this.groupBox3.TabIndex = 9;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "Gate Setting";
        // 
        // button1
        // 
        this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.button1.Location = new System.Drawing.Point(388, 107);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(73, 21);
        this.button1.TabIndex = 6;
        this.button1.Text = "&Open Port";
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // gbGateSetting
        // 
        this.gbGateSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbGateSetting.Controls.Add(this.label5);
        this.gbGateSetting.Controls.Add(this.cmbGatePortName);
        this.gbGateSetting.Controls.Add(this.label6);
        this.gbGateSetting.Controls.Add(this.cmbGateBaudRate);
        this.gbGateSetting.Controls.Add(this.cmbGateStopBits);
        this.gbGateSetting.Controls.Add(this.label7);
        this.gbGateSetting.Controls.Add(this.label8);
        this.gbGateSetting.Controls.Add(this.cmbGateParity);
        this.gbGateSetting.Controls.Add(this.cmbGateDataBits);
        this.gbGateSetting.Controls.Add(this.label9);
        this.gbGateSetting.Location = new System.Drawing.Point(6, 45);
        this.gbGateSetting.Name = "gbGateSetting";
        this.gbGateSetting.Size = new System.Drawing.Size(370, 64);
        this.gbGateSetting.TabIndex = 4;
        this.gbGateSetting.TabStop = false;
        this.gbGateSetting.Text = "Serial Port &Settings";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 19);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(56, 13);
        this.label5.TabIndex = 0;
        this.label5.Text = "COM Port:";
        // 
        // cmbGatePortName
        // 
        this.cmbGatePortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbGatePortName.FormattingEnabled = true;
        this.cmbGatePortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
        this.cmbGatePortName.Location = new System.Drawing.Point(13, 35);
        this.cmbGatePortName.Name = "cmbGatePortName";
        this.cmbGatePortName.Size = new System.Drawing.Size(67, 21);
        this.cmbGatePortName.TabIndex = 1;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(295, 19);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(52, 13);
        this.label6.TabIndex = 8;
        this.label6.Text = "Stop Bits:";
        // 
        // cmbGateBaudRate
        // 
        this.cmbGateBaudRate.FormattingEnabled = true;
        this.cmbGateBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
        this.cmbGateBaudRate.Location = new System.Drawing.Point(86, 35);
        this.cmbGateBaudRate.Name = "cmbGateBaudRate";
        this.cmbGateBaudRate.Size = new System.Drawing.Size(69, 21);
        this.cmbGateBaudRate.TabIndex = 3;
        this.cmbGateBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGateBaudRate_Validating);
        // 
        // cmbGateStopBits
        // 
        this.cmbGateStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbGateStopBits.FormattingEnabled = true;
        this.cmbGateStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
        this.cmbGateStopBits.Location = new System.Drawing.Point(293, 35);
        this.cmbGateStopBits.Name = "cmbGateStopBits";
        this.cmbGateStopBits.Size = new System.Drawing.Size(65, 21);
        this.cmbGateStopBits.TabIndex = 9;
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(85, 19);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(61, 13);
        this.label7.TabIndex = 2;
        this.label7.Text = "Baud Rate:";
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(229, 19);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(53, 13);
        this.label8.TabIndex = 6;
        this.label8.Text = "Data Bits:";
        // 
        // cmbGateParity
        // 
        this.cmbGateParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbGateParity.FormattingEnabled = true;
        this.cmbGateParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
        this.cmbGateParity.Location = new System.Drawing.Point(161, 35);
        this.cmbGateParity.Name = "cmbGateParity";
        this.cmbGateParity.Size = new System.Drawing.Size(60, 21);
        this.cmbGateParity.TabIndex = 5;
        // 
        // cmbGateDataBits
        // 
        this.cmbGateDataBits.FormattingEnabled = true;
        this.cmbGateDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
        this.cmbGateDataBits.Location = new System.Drawing.Point(227, 35);
        this.cmbGateDataBits.Name = "cmbGateDataBits";
        this.cmbGateDataBits.Size = new System.Drawing.Size(60, 21);
        this.cmbGateDataBits.TabIndex = 7;
        this.cmbGateDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGateDataBits_Validating);
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(163, 19);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(36, 13);
        this.label9.TabIndex = 4;
        this.label9.Text = "Parity:";
        // 
        // gbGateDataMode
        // 
        this.gbGateDataMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbGateDataMode.Controls.Add(this.rbGateText);
        this.gbGateDataMode.Controls.Add(this.rbGateHex);
        this.gbGateDataMode.Location = new System.Drawing.Point(382, 45);
        this.gbGateDataMode.Name = "gbGateDataMode";
        this.gbGateDataMode.Size = new System.Drawing.Size(84, 64);
        this.gbGateDataMode.TabIndex = 5;
        this.gbGateDataMode.TabStop = false;
        this.gbGateDataMode.Text = "Data &Mode";
        // 
        // rbGateText
        // 
        this.rbGateText.AutoSize = true;
        this.rbGateText.Location = new System.Drawing.Point(12, 19);
        this.rbGateText.Name = "rbGateText";
        this.rbGateText.Size = new System.Drawing.Size(46, 17);
        this.rbGateText.TabIndex = 0;
        this.rbGateText.Text = "Text";
        this.rbGateText.CheckedChanged += new System.EventHandler(this.rbGateText_CheckedChanged);
        // 
        // rbGateHex
        // 
        this.rbGateHex.AutoSize = true;
        this.rbGateHex.Location = new System.Drawing.Point(12, 39);
        this.rbGateHex.Name = "rbGateHex";
        this.rbGateHex.Size = new System.Drawing.Size(44, 17);
        this.rbGateHex.TabIndex = 1;
        this.rbGateHex.Text = "Hex";
        this.rbGateHex.CheckedChanged += new System.EventHandler(this.rbGateHex_CheckedChanged);
        // 
        // txtGateSendData
        // 
        this.txtGateSendData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtGateSendData.Location = new System.Drawing.Point(70, 19);
        this.txtGateSendData.Name = "txtGateSendData";
        this.txtGateSendData.Size = new System.Drawing.Size(307, 20);
        this.txtGateSendData.TabIndex = 2;
        // 
        // label10
        // 
        this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(3, 22);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(61, 13);
        this.label10.TabIndex = 1;
        this.label10.Text = "Send &Data:";
        // 
        // btnGateSend
        // 
        this.btnGateSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnGateSend.Location = new System.Drawing.Point(383, 17);
        this.btnGateSend.Name = "btnGateSend";
        this.btnGateSend.Size = new System.Drawing.Size(75, 23);
        this.btnGateSend.TabIndex = 3;
        this.btnGateSend.Text = "Send";
        this.btnGateSend.Click += new System.EventHandler(this.btnGateSend_Click);
        // 
        // groupBox4
        // 
        this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.groupBox4.Controls.Add(this.txtCameraUrl);
        this.groupBox4.Controls.Add(this.btnOpenCamera);
        this.groupBox4.Controls.Add(this.label2);
        this.groupBox4.Controls.Add(this.txtCameraPassword);
        this.groupBox4.Controls.Add(this.label4);
        this.groupBox4.Controls.Add(this.txtCameraUsername);
        this.groupBox4.Controls.Add(this.label3);
        this.groupBox4.Location = new System.Drawing.Point(6, 348);
        this.groupBox4.Name = "groupBox4";
        this.groupBox4.Size = new System.Drawing.Size(369, 100);
        this.groupBox4.TabIndex = 8;
        this.groupBox4.TabStop = false;
        // 
        // btnApply
        // 
        this.btnApply.Location = new System.Drawing.Point(12, 465);
        this.btnApply.Name = "btnApply";
        this.btnApply.Size = new System.Drawing.Size(75, 23);
        this.btnApply.TabIndex = 10;
        this.btnApply.Text = "&Apply";
        this.btnApply.UseVisualStyleBackColor = true;
        this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
        // 
        // statusStrip1
        // 
        this.statusStrip1.Location = new System.Drawing.Point(0, 502);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(874, 22);
        this.statusStrip1.TabIndex = 11;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // btnClose
        // 
        this.btnClose.Location = new System.Drawing.Point(93, 465);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(75, 23);
        this.btnClose.TabIndex = 12;
        this.btnClose.Text = "&Tutup";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // FormGateInSetting
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(874, 524);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.btnApply);
        this.Controls.Add(this.rtfTerminal);
        this.Controls.Add(this.groupBox3);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.groupBox1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(559, 288);
        this.Name = "FormGateInSetting";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Gate In Setting";
        this.Shown += new System.EventHandler(this.frmTerminal_Shown);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminal_FormClosing);
        this.gbMode.ResumeLayout(false);
        this.gbMode.PerformLayout();
        this.gbPortSettings.ResumeLayout(false);
        this.gbPortSettings.PerformLayout();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox3.ResumeLayout(false);
        this.groupBox3.PerformLayout();
        this.gbGateSetting.ResumeLayout(false);
        this.gbGateSetting.PerformLayout();
        this.gbGateDataMode.ResumeLayout(false);
        this.gbGateDataMode.PerformLayout();
        this.groupBox4.ResumeLayout(false);
        this.groupBox4.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtfTerminal;
    private System.Windows.Forms.TextBox txtSendData;
    private System.Windows.Forms.Label lblSend;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.ComboBox cmbInputPortName;
    private System.Windows.Forms.ComboBox cmbInputBaudRate;
    private System.Windows.Forms.RadioButton rbHex;
    private System.Windows.Forms.RadioButton rbText;
    private System.Windows.Forms.GroupBox gbMode;
    private System.Windows.Forms.Label lblComPort;
    private System.Windows.Forms.Label lblBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbInputParity;
    private System.Windows.Forms.Label lblDataBits;
    private System.Windows.Forms.ComboBox cmbInputDataBits;
    private System.Windows.Forms.Label lblStopBits;
    private System.Windows.Forms.ComboBox cmbInputStopBits;
    private System.Windows.Forms.Button btnOpenPort;
      private System.Windows.Forms.GroupBox gbPortSettings;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private AForge.Controls.VideoSourcePlayer videoSource;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox txtCameraUrl;
      private System.Windows.Forms.TextBox txtCameraPassword;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtCameraUsername;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button btnOpenCamera;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.GroupBox gbGateSetting;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox cmbGatePortName;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox cmbGateBaudRate;
      private System.Windows.Forms.ComboBox cmbGateStopBits;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.ComboBox cmbGateParity;
      private System.Windows.Forms.ComboBox cmbGateDataBits;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.GroupBox gbGateDataMode;
      private System.Windows.Forms.RadioButton rbGateText;
      private System.Windows.Forms.RadioButton rbGateHex;
      private System.Windows.Forms.TextBox txtGateSendData;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Button btnGateSend;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Button btnApply;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.Button btnClose;
  }
}

