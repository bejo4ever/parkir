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
        private static string OpenButtonText = "Buka Koneksi Serial";
        private static string CloseButtonText = "Putus Koneksi Serial";

        private Image currentImage = null;
        private string imagePath;

        private bool useNetworkShare = false;

        private NetworkShare networkShare;
        private SerialPort inputSerial = null;
        private SerialPort gateSerial = null;
        private SerialUtilities serialUtilities = new SerialUtilities();
        private string rfid_start = "";
        private string currentRFIDProcessed = "";

        private SerialDataReceivedEventHandler inputSerialDataReceivedEventHandler;
        private SerialErrorReceivedEventHandler inputSerialErrorReceivedEventHandler;

        private SerialDataReceivedEventHandler gateSerialDataReceivedEventHandler;
        private WriteToComPortDelegate writeToInputSerialDelegate;
        

        private string currentTicketNumber = "";


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

            RFID_START_DELIM = ConfigurationManager.AppSettings["rfid_start_char"];
            RFID_END_DELIM = ConfigurationManager.AppSettings["rfid_end_char"];

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
            FullScreen.SetWinFullScreen(this.Handle);
            
            lblCompanyName.Text = AppConfig.Instance.CompanyName;
            lblCompanyAddress.Text = AppConfig.Instance.CompanyAddress + " (" +
                AppConfig.Instance.CompanyPhoneNumber + ")";
            lblGateName.Text = AppConfig.Instance.GateName;
            
            OpenVideoPlayer();
            OpenSerialPort();

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

        private void ProcessInputSerialErrorMarshal(string message)
        {
            if (InvokeRequired)
            {
                object[] args = new object[] { message };
                ProcessSerialErrorMarshalDelegate del = new ProcessSerialErrorMarshalDelegate(ProcessSerialError);
                this.Invoke(del, args);
            }
            else
            {
                ProcessSerialError(message);
            }
        }

        private void ProcessSerialError(string message)
        {
            statusTransfer.Text = message;
        }

        internal void ProcessInputSerialDataMarshal(string textToDisplay)
        {
            if (InvokeRequired)
            {
                object[] args = new object[] { textToDisplay };
                ProcessSerialDataMarshalDelegate del = new ProcessSerialDataMarshalDelegate(ProcessInputSerialData);
                this.Invoke(del, args);
            }
            else
            {
                ProcessInputSerialData(textToDisplay);
            }
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
                    GenerateTicket(toDisplay);
                }
                else
                {
                    rfid += " not processed";

                }
                rtbCurrentStatus.AppendText(rfid);
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
                    GenerateTicket(rfid);
                }
                else
                {
                    rfid += " not processed";
                }
                rfid_start = "";
                rtbCurrentStatus.AppendText(rfid);
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

                inputSerial.Open();
                statusKoneksi.Text = "Input connected to Port : " + inputSerial.PortName;
                inputSerialDataReceivedEventHandler = new SerialDataReceivedEventHandler(InputSerialDataReceived);
                inputSerial.DataReceived += inputSerialDataReceivedEventHandler;
                
                inputSerialErrorReceivedEventHandler = new SerialErrorReceivedEventHandler(InputSerialErrorReceived);
                inputSerial.ErrorReceived += inputSerialErrorReceivedEventHandler;

                gateSerial = new SerialPort();
                gateSerial.BaudRate = Properties.Settings.Default.GateBaudRate;
                gateSerial.DataBits = Properties.Settings.Default.GateDataBits;
                gateSerial.StopBits = Properties.Settings.Default.GateStopBits;
                gateSerial.Parity = Properties.Settings.Default.GateParity;
                gateSerial.PortName = Properties.Settings.Default.GatePortName;

                gateSerial.Open();
                statusKoneksi.Text +=
                    ", Gate connected to Port :" + gateSerial.PortName;
                gateSerialDataReceivedEventHandler = new SerialDataReceivedEventHandler(GateSerialDataReceived);
                gateSerial.DataReceived += gateSerialDataReceivedEventHandler;

                btnSerialConnection.Text = FormMain.CloseButtonText;
                btnSerialConnection.Tag = true;
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
            writeToInputSerialDelegate = new WriteToComPortDelegate(_WriteToInputSerial);
            IAsyncResult iar = writeToInputSerialDelegate.BeginInvoke(textToWrite, new AsyncCallback(_WriteToInputSerialCompleted), DateTime.Now.ToString());
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
            success = writeToInputSerialDelegate.EndInvoke(iar);
            statusTransfer.Text = "Pengiriman pesan [ " + message + " ] sukses.";
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
            if (!(null == inputSerial))
            {
                if (inputSerial.IsOpen)
                {
                    while (inputSerial.BytesToWrite > 0)
                    { }
                    inputSerial.DataReceived -= inputSerialDataReceivedEventHandler;
                    inputSerial.Dispose();
                }
            }

            if (!(null == gateSerial))
            {
                if (gateSerial.IsOpen)
                {
                    while (gateSerial.BytesToWrite > 0)
                    {
                    }
                    gateSerial.Dispose();
                }
            }
            btnSerialConnection.Text = FormMain.OpenButtonText;
            btnSerialConnection.Tag = false;
            statusKoneksi.Text = "Tidak Terhubung ke Input dan Palang Pintu";
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

        private void openSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string username = login.Username;
                    string password = login.Password;
                    if (AppConfig.Instance.ValidateLogin(username, password))
                    {
                        StopIO();
                        FormGateInSetting setting = new FormGateInSetting();
                        setting.ShowDialog(this);
                        StartIO();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah", "Gagal Login",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string username = login.Username;
                    string password = login.Password;
                    if (AppConfig.Instance.ValidateLogin(username, password))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah", "Gagal Login",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(image);
            SolidBrush sb = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, sb, new PointF(5, 20));
            sb.Dispose();
            g.Dispose();
            currentImage = image;
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
            GenerateTicket(signal);
        }



        private void GenerateTicket(string rfid)
        {
            currentRFIDProcessed = rfid;
            currentTicketNumber =
                Commons.AppConfig.Instance.GenerateTicketID();
            //take picture
            Image img = (Image)currentImage.Clone();
            string path = System.IO.Path.Combine(imagePath, currentTicketNumber + ".jpg");
            img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
            //save new ticket
            DateTime now = DateTime.Now;
            string date_in = now.Year + "-" + now.Month + "-" + now.Day + " " + now.Hour + ":" +
                now.Minute + ":" + now.Second;
            // TODO check signal to determine members or not
            string sql = "insert into tickets set gate_in_id =" + Commons.AppConfig.Instance.GateId +
                ", ticket_number = '" + currentTicketNumber + "', " +
                " date_in = '" + date_in + "', " +
                " image_path = '" + currentTicketNumber + ".jpg', " +
                " initial_price = " + Commons.AppConfig.Instance.TarifInitial;
            MySqlConnection conn = new MySqlConnection(
                Commons.AppConfig.Instance.ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //printing ticket
            //PrintTicket();
            statusTiket.Text = "generate tiket selesai ..";
        }

        private void PrintTicket()
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
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
            e.Graphics.DrawString(currentTicketNumber, this.Font, Brushes.Black, leftMargin, yPos);

        }

        private void btnSerialConnection_Click(object sender, EventArgs e)
        {
            bool connected = (bool)btnSerialConnection.Tag;
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

    }
}