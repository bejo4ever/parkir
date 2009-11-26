using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;

using gatein.Properties;
using System.Configuration;
using MySql.Data.MySqlClient;
using AForge.Video;
using Commons;
namespace gatein
{
    internal delegate Boolean WriteToComPortDelegate(string textToWrite);
    internal delegate void ProcessSerialDataMarshalDelegate(string inputToDisplay);
    internal delegate void ProcessSerialErrorMarshalDelegate(string message);

    public partial class FormMain : Form
    {
        private Image currentImage = null;
        private string imagePath;
        private bool takeImage = false;

        private bool useNetworkShare = false;

        private NetworkShare networkShare;
        private SerialPort inputSerial = null;
        private SerialPort gateSerial = null;
        private SerialUtilities serialUtilities = new SerialUtilities();
        private string rfid_start = "";
        private string currentRFIDProcessed = "";

        private SerialDataReceivedEventHandler inputDataReceivedEventHandler;
        private SerialErrorReceivedEventHandler inputErrorReceivedEventHandler;

        private SerialDataReceivedEventHandler gateDataReceivedEventHandler;
        private SerialErrorReceivedEventHandler gateErrorReceivedEventHandler;

        private WriteToComPortDelegate writeToInputDelegate;
        private WriteToComPortDelegate writeToGateDelegate;

        private string currentRFIDTicketNumber = "";


        string share_server;
        string share_folder;
        string share_user;
        string share_password;
        string share_path;

        private string RFID_START_DELIM = "";
        private string RFID_END_DELIM = "";

        public FormMain()
        {
            InitializeComponent();

            timer.Start();

            RFID_START_DELIM = Properties.Settings.Default.SerialStartChar;
            RFID_END_DELIM = Properties.Settings.Default.SerialEndChar;

            AppConfig.Instance.LoadAppSetting(
                ConfigurationManager.AppSettings["db"]);
            AppConfig.Instance.LoadGateSetting(
                int.Parse(ConfigurationManager.AppSettings["gateid"]));

            //check if using network share to store image
            string share =
                ConfigurationManager.AppSettings["use_network_share"];
            useNetworkShare = int.Parse(share) > 0 ? true : false;
            if (useNetworkShare)
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
                imagePath = System.IO.Path.Combine(Application.StartupPath, "images");
                if (!System.IO.Directory.Exists(imagePath))
                {
                    System.IO.Directory.CreateDirectory(imagePath);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            using (FormLogin login = new FormLogin())
            {
                login.StartPosition = FormStartPosition.CenterScreen;
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string username = login.Username;
                    string password = login.Password;
                    if (AppConfig.Instance.ValidateLogin(username, password))
                    {
                        FullScreen.SetWinFullScreen(this.Handle);

                        lblCompanyName.Text = AppConfig.Instance.CompanyName;
                        lblCompanyAddress.Text = AppConfig.Instance.CompanyAddress + " (" +
                            AppConfig.Instance.CompanyPhoneNumber + ")";
                        lblGateName.Text = AppConfig.Instance.GateName;

                        OpenVideoPlayer();
                        OpenSerialPort();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah", "Gagal Login",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }

        }

        private void InputSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Properties.Settings.Default.InputDataMode == DataMode.Text)
            {
                string data = inputSerial.ReadExisting();
                ProcessInputSerialDataMarshal(data);
            }
            else if (Properties.Settings.Default.InputDataMode == DataMode.Hex)
            {
                int length = inputSerial.BytesToRead;
                byte[] datas = new byte[length];
                inputSerial.Read(datas, 0, length);
                string input = serialUtilities.ByteArrayToHexString(datas);
                ProcessInputSerialDataMarshal(input);
            }
        }

        private void InputSerialErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string message = "";
            switch (e.EventType)
            {
                case SerialError.Frame:
                    message = "Framing error ";
                    break;
                case SerialError.Overrun:
                    message = "character-buffer overrun ";
                    break;
                case SerialError.RXOver:
                    message = "Input buffer overflow";
                    break;
                case SerialError.RXParity:
                    message = "parity error pada hardware";
                    break;
                case SerialError.TXFull:
                    message = "transmit data, namun output buffer sedang penuh";
                    break;
            }
            ProcessInputSerialErrorMarshal(message);
        }

        private void GateErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            string message = "";
            switch (e.EventType)
            {
                case SerialError.Frame:
                    message = "Framing error ";
                    break;
                case SerialError.Overrun:
                    message = "character-buffer overrun ";
                    break;
                case SerialError.RXOver:
                    message = "Input buffer overflow";
                    break;
                case SerialError.RXParity:
                    message = "parity error pada hardware";
                    break;
                case SerialError.TXFull:
                    message = "transmit data, namun output buffer sedang penuh";
                    break;
            }
            ProcessGateSerialErrorMarshal(message);
        }
        private void ProcessInputSerialErrorMarshal(string message)
        {           
            object[] args = new object[] { message };
            ProcessSerialErrorMarshalDelegate del = new ProcessSerialErrorMarshalDelegate(ProcessSerialError);
            base.Invoke(del, args);
         }

        private void ProcessSerialError(string message)
        {
            statusTransfer.Text = message;
        }

        private void ProcessGateSerialErrorMarshal(string message)
        {
            object[] args = { message };
            ProcessSerialDataMarshalDelegate del = new ProcessSerialDataMarshalDelegate(ProcessGateError);
            base.Invoke(del, args);
        }

        private void ProcessGateError(string errorMessage)
        {
            statusKoneksiPortal.Text = errorMessage;
        }

        internal void ProcessInputSerialDataMarshal(string textToDisplay)
        {
            //if (InvokeRequired)
            //{
            object[] args = new object[1] { textToDisplay };
            ProcessSerialDataMarshalDelegate del = new ProcessSerialDataMarshalDelegate(ProcessInputSerialData);
            this.Invoke(del, args);
            //}
            //else
            //{
            //    ProcessInputSerialData(textToDisplay);
            //}
        }

        internal void ProcessInputSerialData(string toDisplay)
        {
            string rfid = "";
            if (toDisplay.StartsWith(RFID_START_DELIM) && toDisplay.EndsWith(RFID_END_DELIM))
            {
                rfid = toDisplay;
                if (toDisplay != currentRFIDProcessed)
                {
                    statusTiket.Text = "Generating ticket for .." + toDisplay;
                    GenerateMemberTicket(toDisplay);
                }
                else
                {
                    rfid += " not processed";

                }

            }
            else if (toDisplay.StartsWith(RFID_START_DELIM) && !toDisplay.EndsWith(RFID_END_DELIM))
            {
                rfid_start = toDisplay;
                statusTiket.Text = "";
            }
            else if (!toDisplay.StartsWith(RFID_START_DELIM) && toDisplay.EndsWith(RFID_END_DELIM) && rfid_start.Length > 0)
            {
                rfid = rfid_start + toDisplay;
                if (rfid != currentRFIDProcessed)
                {
                    statusTiket.Text = "Generating ticket for .." + toDisplay;
                    GenerateMemberTicket(rfid);
                }
                else
                {
                    rfid += " not processed";
                }
                rfid_start = "";

            }

        }

        private void GateSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }


        private void OpenSerialPort()
        {
            try
            {
                StopSerialPorts();
                inputSerial = new SerialPort();
                inputSerial.BaudRate = Properties.Settings.Default.InputBaudRate;
                inputSerial.DataBits = Properties.Settings.Default.InputDataBits;
                inputSerial.StopBits = Properties.Settings.Default.InputStopBits;
                inputSerial.Parity = Properties.Settings.Default.InputParity;
                inputSerial.PortName = Properties.Settings.Default.InputPortName;
                try
                {
                    inputSerial.Open();
                    statusKoneksiInput.Text = "Input connected to Port : " + inputSerial.PortName;
                    inputDataReceivedEventHandler = new SerialDataReceivedEventHandler(InputSerialDataReceived);
                    inputSerial.DataReceived += inputDataReceivedEventHandler;

                    inputErrorReceivedEventHandler = new SerialErrorReceivedEventHandler(InputSerialErrorReceived);
                    inputSerial.ErrorReceived += inputErrorReceivedEventHandler;
                }
                catch (Exception ex)
                {
                    statusKoneksiInput.ForeColor = Color.Red;
                    statusKoneksiInput.Text = "Gagal Koneksi Ke Input";
                }

                gateSerial = new SerialPort();
                gateSerial.BaudRate = Properties.Settings.Default.GateBaudRate;
                gateSerial.DataBits = Properties.Settings.Default.GateDataBits;
                gateSerial.StopBits = Properties.Settings.Default.GateStopBits;
                gateSerial.Parity = Properties.Settings.Default.GateParity;
                gateSerial.PortName = Properties.Settings.Default.GatePortName;
                try
                {
                    gateSerial.Open();
                    statusKoneksiPortal.Text =
                        "Gate connected to Port :" + gateSerial.PortName;
                    gateDataReceivedEventHandler = new SerialDataReceivedEventHandler(GateSerialDataReceived);
                    gateSerial.DataReceived += gateDataReceivedEventHandler;
                    gateErrorReceivedEventHandler = new SerialErrorReceivedEventHandler(GateErrorReceived);
                    gateSerial.ErrorReceived += gateErrorReceivedEventHandler;
                }
                catch (Exception ex)
                {
                    statusKoneksiPortal.ForeColor = Color.Red;
                    statusKoneksiPortal.Text = "Gagal Koneksi ke Portal";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Sending data to input serial
        /// </summary>
        /// <param name="textToWrite"></param>
        public void WriteDataToInputSerial(string textToWrite)
        {
            writeToInputDelegate = new WriteToComPortDelegate(_WriteToInputSerial);
            IAsyncResult iar = writeToInputDelegate.BeginInvoke(textToWrite, new AsyncCallback(_WriteToInputSerialCompleted), DateTime.Now.ToString());
        }

        private Boolean _WriteToInputSerial(string textToWrite)
        {
            Boolean result = false;
            if (inputSerial.IsOpen)
            {
                if ((inputSerial.WriteBufferSize - inputSerial.BytesToWrite) > textToWrite.Length)
                {
                    inputSerial.Write(textToWrite);
                    result = true;
                }
                else
                {
                    statusTransfer.Text = "Tidak cukup buffer untuk mengirim pesan :" +
                        textToWrite;
                    result = false;
                }
            }
            return result;
        }

        private void _WriteToInputSerialCompleted(IAsyncResult iar)
        {
            string message;

            Boolean success;
            message = iar.AsyncState as string;
            success = writeToInputDelegate.EndInvoke(iar);
            statusTransfer.Text = "Pengiriman pesan [ " + message + " ] sukses.";
        }

        public void WriteDataToGate(string textToWrite)
        {
            writeToGateDelegate = new WriteToComPortDelegate(_WriteToGate);
            IAsyncResult iar = writeToGateDelegate.BeginInvoke(textToWrite, new AsyncCallback(_WriteToGateCompleted), DateTime.Now.ToString());
        }

        private Boolean _WriteToGate(string textToWrite)
        {
            bool result = false;
            if (gateSerial.IsOpen)
            {
                if((gateSerial.WriteBufferSize - gateSerial.BytesToWrite) > textToWrite.Length)
                {
                    gateSerial.Write(textToWrite);
                    result = true;
                } 
                else 
                {
                    statusTransfer.Text = "Tidak cukup buffer untuk mengirim pesan :" +
                        textToWrite + " Ke Portal";
                    result = false;
                }
            }
            return result;
        }

        private void _WriteToGateCompleted(IAsyncResult iar)
        {
            string message;
            bool success;
            message = iar.AsyncState as string;
            success = writeToGateDelegate.EndInvoke(iar);
            statusTransfer.Text = "Pengiriman Pesan [" + message + "] sukses.";
        }
        private void OpenVideoPlayer()
        {
            StopVideoPlayer();

            JPEGStream cameraStream = new JPEGStream(
                Properties.Settings.Default.CameraURL);
            cameraStream.Login = Properties.Settings.Default.CameraUser;
            cameraStream.Password = Properties.Settings.Default.CameraPassword;
            this.Cursor = Cursors.WaitCursor;

            videoPlayer.VideoSource = cameraStream;
            videoPlayer.Start(); ;
            this.Cursor = Cursors.Default;
        }

        public void StopIO()
        {
            StopVideoPlayer();

            StopSerialPorts();
        }

        private void StopVideoPlayer()
        {
            // stopping video came
            videoPlayer.SignalToStop();
            videoPlayer.WaitForStop();
        }

        private void StopSerialPorts()
        {
            CloseInput();
            CloseGate();
        }

        private void CloseInput()
        {
            if (!(null == inputSerial))
            {
                if (inputSerial.IsOpen)
                {
                    while (inputSerial.BytesToWrite > 0)
                    { }
                    inputSerial.DataReceived -= inputDataReceivedEventHandler;
                    inputSerial.Dispose();
                    statusKoneksiInput.Text = "Tidak Terhubung Ke Input";
                }
            }
        }

        private void CloseGate()
        {
            if (!(null == gateSerial))
            {
                if (gateSerial.IsOpen)
                {
                    while (gateSerial.BytesToWrite > 0)
                    {
                    }
                    gateSerial.DataReceived -= gateDataReceivedEventHandler;
                    gateSerial.ErrorReceived -= gateErrorReceivedEventHandler;
                    gateSerial.Dispose();
                    statusKoneksiPortal.Text = "Tidak Terhubung Ke Portal";
                }
            }
        }

        public void StartIO()
        {
            StartVideoPlayer();

            OpenSerialPort();
        }

        private void StartVideoPlayer()
        {
            StopVideoPlayer();
            JPEGStream videoStream = videoPlayer.VideoSource as JPEGStream;
            videoStream.Source = Properties.Settings.Default.CameraURL;
            videoStream.Login = Properties.Settings.Default.CameraUser;
            videoStream.Password = Properties.Settings.Default.CameraPassword;
            videoPlayer.Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            StopIO();
            if (useNetworkShare)
            {
                networkShare.LogoutFromShare(share_server, share_folder);
            }
            timer.Stop();
            Cursor = Cursors.Default;
        }

        private void mnItemOpenSetting_Click(object sender, EventArgs e)
        {

            StopIO();
            FormGateInSetting setting = new FormGateInSetting();
            setting.ShowDialog(this);
            StartIO();


        }

        private void mnItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(image);
            SolidBrush sb = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, sb, new PointF(5, 20));
            sb.Dispose();
            g.Dispose();
            if (this.takeImage)
            {
                currentImage = image;
                this.takeImage = false;
                statusAmbilGambar.Text = "Ambil Gambar Selesai";
            }
            else
            {
                currentImage = null;
                this.takeImage = false;
                statusAmbilGambar.Text = "Ambil Gambar";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("dd MMMM yyyy");
            lblTime.Text = now.ToString("T");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //process start from incoming signal from inputSerial
            //the generate ticket.
            string signal = "";
            //GenerateTicket(signal);

        }

        private void GenerateNopolTicket(string nopol, string tarif)
        {
            string ticketNumber = Commons.AppConfig.Instance.GenerateTicketID();
            
            DateTime now = DateTime.Now;
            string date_in = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" +
                now.Minute + ":" + now.Second;
            string sql = "";
            if (null != currentImage)
            {
                string path = System.IO.Path.Combine(imagePath, ticketNumber + ".jpg");
                currentImage.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                
                sql = "insert into tickets set gate_in_id =" + Commons.AppConfig.Instance.GateId +
                    ", ticket_number = '" + ticketNumber + "', " +
                    " date_in = '" + date_in + "', " +
                    " image_path = '" + ticketNumber + ".jpg', " +
                    " initial_price = " + tarif;
            }
            else
            {
                sql = "insert into tickets set gate_in_id = " + Commons.AppConfig.Instance.GateId +
                    ", ticket_number = '" + ticketNumber + "', " +
                    " date_in = '" + date_in + "', " +
                    " initial_price = " + tarif;
            }

            MySqlConnection conn = new MySqlConnection(
                    Commons.AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            statusTiket.Text = "Data Berhasil Disimpan";
            if (MessageBox.Show("Cetak Tiket ?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrintTicket();
                statusTiket.Text = "generate tiket selesai ..";
            }
            else
            {
                statusTiket.Text = "Tiket tidak dicetak";
            }
        }

        private void GenerateMemberTicket(string rfid)
        {
            currentRFIDProcessed = rfid;
            currentRFIDTicketNumber =
                Commons.AppConfig.Instance.GenerateTicketID();
            //take picture
            Image img = (Image)currentImage.Clone();
            string path = System.IO.Path.Combine(imagePath, currentRFIDTicketNumber + ".jpg");
            img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //save new ticket
            DateTime now = DateTime.Now;
            string date_in = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" +
                now.Minute + ":" + now.Second;
            // TODO check signal to determine members or not
            string sql = "insert into tickets set gate_in_id =" + Commons.AppConfig.Instance.GateId +
                ", ticket_number = '" + currentRFIDTicketNumber + "', " +
                " date_in = '" + date_in + "', " +
                " image_path = '" + currentRFIDTicketNumber + ".jpg', " +
                " initial_price = 0";
            MySqlConnection conn = new MySqlConnection(
                Commons.AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            statusTiket.Text = "Data Berhasil Disimpan";
            //printing ticket
            if (MessageBox.Show("Cetak Tiket ?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrintTicket();
                statusTiket.Text = "generate tiket selesai ..";
            }
            else
            {
                statusTiket.Text = "Tiket tidak dicetak";
            }
        }

        private void PrintTicket()
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();

            doc.DocumentName = "tiket.pdf";

            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }

        void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float topMargin = e.MarginBounds.Top;
            yPos = topMargin + this.Font.GetHeight(e.Graphics);

            e.Graphics.DrawString(Commons.AppConfig.Instance.CompanyName, this.Font, Brushes.Black, leftMargin, yPos);
            yPos += this.Font.GetHeight(e.Graphics);
            e.Graphics.DrawString(Commons.AppConfig.Instance.CompanyAddress + " (" +
                Commons.AppConfig.Instance.CompanyPhoneNumber + ")", this.Font, Brushes.Black, leftMargin, yPos);
            yPos += this.Font.GetHeight(e.Graphics);
            e.Graphics.DrawString("Ticket Number ", this.Font, Brushes.Black, leftMargin, yPos);
            yPos += this.Font.GetHeight(e.Graphics);
            e.Graphics.DrawString(currentRFIDTicketNumber, this.Font, Brushes.Black, leftMargin, yPos);

        }

        private void btnSerialConnection_Click(object sender, EventArgs e)
        {
            bool connected = (bool)btnOpenPortal.Tag;
            if (connected == true)
            {
                StopSerialPorts();
            }
            else
            {
                OpenSerialPort();
            }
        }

        private void mnItemGantiPassword_Click(object sender, EventArgs e)
        {
            Commons.FormChangePassword changePassword = new FormChangePassword(
                AppConfig.Instance.UserID);
            changePassword.ShowDialog(this);
        }

        private void btnTakeImage_Click(object sender, EventArgs e)
        {
            this.takeImage = true;
            statusAmbilGambar.Text = "Ambil Gambar Selesai";
        }

        private void btnOpenPortal_Click(object sender, EventArgs e)
        {
            string command = Properties.Settings.Default.OpenPortalCommand;
            WriteDataToGate(command);
        }

        private void btnCloseGate_Click(object sender, EventArgs e)
        {
            string command = Properties.Settings.Default.ClosePortalCommand;
            WriteDataToGate(command);
        }

        private void txtCashPay_TextChanged(object sender, EventArgs e)
        {
            long tarif;
            long cashPay;
            long.TryParse(txtTarif.Text, out tarif);
            long.TryParse(txtCashPay.Text, out cashPay);
            long cashBack = cashPay - tarif;
            txtCashBack.Text = "Rp. " + cashBack.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GenerateNopolTicket(txtNopol.Text, txtTarif.Text);
        }

    }
}