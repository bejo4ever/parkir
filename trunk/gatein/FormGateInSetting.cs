/* 
 * Project:    SerialPort Terminal
 * Company:    Coad .NET, http://coad.net
 * Author:     Noah Coad, http://coad.net/noah
 * Created:    March 2005
 * 
 * Notes:      This was created to demonstrate how to use the SerialPort control for
 *             communicating with your PC's Serial RS-232 COM Port
 * 
 *             It is for educational purposes only and not sanctified for industrial use. :)
 * 
 *             Search for "inputPort" to see how I'm using the SerialPort control.
 */

#region Namespace Inclusions
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using gatein.Properties;
using Commons;
#endregion

namespace gatein
{
    
    public partial class FormGateInSetting : Form
    {
        #region Local Variables

        // The main control for communicating through the RS-232 port
        private SerialPort inputPort = new SerialPort();
        private SerialPort gatePort = new SerialPort();

        // Various colors for logging info
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        // Temp holder for whether a key was pressed
        private bool KeyHandled = false;

        #endregion

        #region Constructor
        public FormGateInSetting()
        {
            // Build the form
            InitializeComponent();
            
            // Restore the users settings
            InitializeControlValues();
            InitializeCamera();

            // Enable/disable controls based on the current state
            EnableControls();

            // When data is recieved through the port, call this method
            inputPort.DataReceived += new SerialDataReceivedEventHandler(inputPort_DataReceived);
            gatePort.DataReceived += new SerialDataReceivedEventHandler(gatePort_DataReceived);
        }

        void gatePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = gatePort.ReadExisting();
            Log(LogMsgType.Normal, message);
        }

        private void InitializeCamera()
        {
            txtCameraUrl.Text = Settings.Default.CameraURL;
            txtCameraUsername.Text = Settings.Default.CameraUser;
            txtCameraPassword.Text = Settings.Default.CameraPassword;           
        }
        #endregion
        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            videoSource.SignalToStop();
            videoSource.WaitForStop();

            AForge.Video.JPEGStream sourceStream = new AForge.Video.JPEGStream(txtCameraUrl.Text);
            sourceStream.Login = txtCameraUsername.Text;
            sourceStream.Password = txtCameraPassword.Text;
            videoSource.VideoSource = sourceStream;
            videoSource.Start();
        }

        #region Local Methods

        /// <summary> Save the user's settings. </summary>
        private void SaveSettings()
        {

            Settings.Default.InputBaudRate = int.Parse(cmbInputBaudRate.Text);
            Settings.Default.InputDataBits = int.Parse(cmbInputDataBits.Text);
            Settings.Default.InputDataMode = CurrentInputDataMode;
            Settings.Default.InputParity = (Parity)Enum.Parse(typeof(Parity), cmbInputParity.Text);
            Settings.Default.InputStopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbInputStopBits.Text);
            Settings.Default.InputPortName = cmbInputPortName.Text;
            
            Settings.Default.CameraPassword = txtCameraPassword.Text;
            Settings.Default.CameraURL = txtCameraUrl.Text;
            Settings.Default.CameraUser = txtCameraUsername.Text;

            Settings.Default.GateBaudRate = int.Parse(cmbGateBaudRate.Text);
            Settings.Default.GateDataBits = int.Parse(cmbGateDataBits.Text);
            Settings.Default.GateDataMode = CurrentGateDataMode;
            Settings.Default.GateParity = (Parity)Enum.Parse(typeof(Parity), cmbGateParity.Text);
            Settings.Default.GateStopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbGateStopBits.Text);
            Settings.Default.GatePortName = cmbGatePortName.Text;

            Settings.Default.Save();

            if (inputPort.IsOpen)
                inputPort.Close();

            if (gatePort.IsOpen)
                gatePort.Close();
        }

        /// <summary> Populate the form's controls with default settings. </summary>
        private void InitializeControlValues()
        {
            cmbInputParity.Items.Clear();
            cmbInputParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            
            cmbInputStopBits.Items.Clear(); 
            cmbInputStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbInputParity.SelectedItem = Settings.Default.InputParity.ToString();
            cmbInputStopBits.SelectedItem = Settings.Default.InputStopBits.ToString();
            cmbInputDataBits.SelectedItem = Settings.Default.InputDataBits.ToString();
            cmbInputParity.SelectedItem = Settings.Default.InputParity.ToString();
            cmbInputBaudRate.SelectedItem = Settings.Default.InputBaudRate.ToString();
            CurrentInputDataMode = Settings.Default.InputDataMode;

            cmbInputPortName.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                cmbInputPortName.Items.Add(s);

            if (cmbInputPortName.Items.Contains(Settings.Default.InputPortName))
            {
                cmbInputPortName.SelectedItem = Settings.Default.InputPortName;
                statusKoneksiInput.Text = "RFID Reader belum terkoneksi";
            }
            else if (cmbInputPortName.Items.Count > 0)
            {
                cmbInputPortName.SelectedIndex = 0;
                statusKoneksiInput.Text = "RFID Reader belum terkoneksi";
            }
            else
            {
                statusKoneksiInput.Text =
                    "Tidak ada COM Ports terdeteksi di komputer ini";
            }

            /// -- gate
            cmbGateParity.Items.Clear();
            cmbGateParity.Items.AddRange(Enum.GetNames(typeof(Parity)));

            cmbGateStopBits.Items.Clear();
            cmbGateStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            cmbGateParity.SelectedItem = Settings.Default.GateParity.ToString();
            cmbGateStopBits.SelectedItem = Settings.Default.GateStopBits.ToString();
            cmbGateDataBits.SelectedItem = Settings.Default.GateDataBits.ToString();
            cmbGateParity.SelectedItem = Settings.Default.GateParity.ToString();
            cmbGateBaudRate.SelectedItem = Settings.Default.GateBaudRate.ToString();
            CurrentGateDataMode = Settings.Default.GateDataMode;

            cmbGatePortName.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                cmbGatePortName.Items.Add(s);

            if (cmbGatePortName.Items.Contains(Settings.Default.GatePortName))
            {
                cmbGatePortName.SelectedItem = Settings.Default.GatePortName;
                statusKoneksiPortal.Text = "Portal belum terkoneksi";
            }
            else if (cmbGatePortName.Items.Count > 0)
            {
                cmbGatePortName.SelectedIndex = 0;
                statusKoneksiPortal.Text = "Portal belum terkoneksi";
            }
            else
            {
                statusKoneksiPortal.Text = "Tidak ada COM Ports terdeteksi di komputer ini";
            }
        }

        /// <summary> Enable/disable controls based on the app's current state. </summary>
        private void EnableControls()
        {
            // Enable/disable controls based on whether the port is open or not
            gbPortSettings.Enabled = !inputPort.IsOpen;
            txtSendData.Enabled = btnSend.Enabled = inputPort.IsOpen;

            if (inputPort.IsOpen) btnOpenPort.Text = "&Close Port";
            else btnOpenPort.Text = "&Open Port";

            
        }

        private void EnableGateControls()
        {
            gbGateSetting.Enabled = !gatePort.IsOpen;
            txtGateSendData.Enabled = btnGateSend.Enabled = gatePort.IsOpen;

            if (gatePort.IsOpen) btnGateSend.Text = "&Close Port";
            else btnGateSend.Text = "&Open Port";
        }

        private void SendGateData()
        {
            if (CurrentGateDataMode == DataMode.Text)
            {
                gatePort.Write(txtGateSendData.Text);
                Log(LogMsgType.Outgoing, "Gate :" + txtSendData.Text + "\n");
            }
            else
            {
                try
                {
                    byte[] datas = HexStringToByteArray(txtGateSendData.Text);
                    gatePort.Write(datas, 0, datas.Length);
                    Log(LogMsgType.Outgoing, "Gate : " + ByteArrayToHexString(datas) + "\n");
                }
                catch (FormatException)
                {
                    Log(LogMsgType.Error, "GatePort Not properly formatted hex string: " + txtSendData.Text + "\n");
                }
            }
        }

        /// <summary> Send the user's data currently entered in the 'send' box.</summary>
        private void SendData()
        {
            if (CurrentInputDataMode == DataMode.Text)
            {
                // Send the user's text straight out the port
                inputPort.Write(txtSendData.Text);

                // Show in the terminal window the user's text
                Log(LogMsgType.Outgoing, txtSendData.Text + "\n");
            }
            else
            {
                try
                {
                    // Convert the user's string of hex digits (ex: B4 CA E2) to a byte array
                    byte[] data = HexStringToByteArray(txtSendData.Text);

                    // Send the binary data out the port
                    inputPort.Write(data, 0, data.Length);

                    // Show the hex digits on in the terminal window
                    Log(LogMsgType.Outgoing, ByteArrayToHexString(data) + "\n");
                }
                catch (FormatException)
                {
                    // Inform the user if the hex string was not properly formatted
                    Log(LogMsgType.Error, "Not properly formatted hex string: " + txtSendData.Text + "\n");
                }
            }
            txtSendData.SelectAll();
        }

        /// <summary> Log data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        private void Log(LogMsgType msgtype, string msg)
        {
            rtfTerminal.Invoke(new EventHandler(delegate
            {
                rtfTerminal.SelectedText = string.Empty;
                rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
                rtfTerminal.SelectionColor = LogMsgTypeColor[(int)msgtype];
                rtfTerminal.AppendText(msg);
                rtfTerminal.ScrollToCaret();
            }));
        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        #endregion

        #region Local Properties
        private DataMode CurrentInputDataMode
        {
            get
            {
                if (rbHex.Checked) return DataMode.Hex;
                else return DataMode.Text;
            }
            set
            {
                if (value == DataMode.Text) rbText.Checked = true;
                else rbHex.Checked = true;
            }
        }

        private DataMode CurrentGateDataMode
        {
            get
            {
                if (rbGateHex.Checked)
                    return DataMode.Hex;
                else
                    return DataMode.Text;
            }

            set
            {
                if (value == DataMode.Text)
                    rbGateText.Checked = true;
                else
                    rbGateHex.Checked = true;
            }
        }
        #endregion

        #region Event Handlers

        private void frmTerminal_Shown(object sender, EventArgs e)
        {
            Log(LogMsgType.Normal, String.Format("Application Started at {0}\n", DateTime.Now));
        }
        private void frmTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The form is closing, save the user's preferences
            SaveSettings();
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        { if (rbText.Checked) CurrentInputDataMode = DataMode.Text; }
        private void rbHex_CheckedChanged(object sender, EventArgs e)
        { if (rbHex.Checked) CurrentInputDataMode = DataMode.Hex; }

        private void rbGateText_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGateText.Checked)
                CurrentGateDataMode = DataMode.Text;
        }

        private void rbGateHex_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGateHex.Checked)
                CurrentGateDataMode = DataMode.Hex;
        }

        private void cmbBaudRate_Validating(object sender, CancelEventArgs e)
        { int x; e.Cancel = !int.TryParse(cmbInputBaudRate.Text, out x); }
        private void cmbDataBits_Validating(object sender, CancelEventArgs e)
        { int x; e.Cancel = !int.TryParse(cmbInputDataBits.Text, out x); }

        private void cmbGateBaudRate_Validating(object sender, CancelEventArgs e)
        {
            int x; 
            e.Cancel = !int.TryParse(cmbGateBaudRate.Text, out x); 
        }

        private void cmbGateDataBits_Validating(object sender, CancelEventArgs e)
        {
            int x;
            e.Cancel = !int.TryParse(cmbGateDataBits.Text, out x);
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            // If the port is open, close it.
            if (inputPort.IsOpen) inputPort.Close();
            else
            {
                // Set the port's settings
                inputPort.BaudRate = int.Parse(cmbInputBaudRate.Text);
                inputPort.DataBits = int.Parse(cmbInputDataBits.Text);
                inputPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbInputStopBits.Text,true);
                inputPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbInputParity.Text);
                inputPort.PortName = cmbInputPortName.Text;

                // Open the port
                inputPort.Open();
            }

            // Change the state of the form's controls
            EnableControls();

            // If the port is open, send focus to the send data box
            if (inputPort.IsOpen) txtSendData.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gatePort.IsOpen)
                gatePort.Close();
            else
            {
                gatePort.BaudRate = int.Parse(cmbGateBaudRate.Text);
                gatePort.DataBits = int.Parse(cmbGateDataBits.Text);
                gatePort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbGateStopBits.Text);
                gatePort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbGateParity.Text);
                gatePort.PortName = cmbGatePortName.Text;
                gatePort.Open();
            }
            EnableGateControls();
            if (gatePort.IsOpen)
                txtGateSendData.Focus();
        }

        private void btnSend_Click(object sender, EventArgs e)
        { 
            SendData(); 
        }

        private void inputPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            if (CurrentInputDataMode == DataMode.Text)
            {
                // Read all the data waiting in the buffer
                string data = inputPort.ReadExisting();

                // Display the text to the user in the terminal
                Log(LogMsgType.Incoming, data);
            }
            else
            {
                // Obtain the number of bytes waiting in the port's buffer
                int bytes = inputPort.BytesToRead;

                // Create a byte array buffer to hold the incoming data
                byte[] buffer = new byte[bytes];

                // Read the data from the port and store it in our buffer
                inputPort.Read(buffer, 0, bytes);

                // Show the user the incoming data in hex format
                Log(LogMsgType.Incoming, ByteArrayToHexString(buffer));
            }
        }

        private void txtSendData_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user presses [ENTER], send the data now
            if (KeyHandled = e.KeyCode == Keys.Enter) { e.Handled = true; SendData(); }
        }
        private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
        { e.Handled = KeyHandled; }
        #endregion

        
        private void btnClosePort_Click(object sender, EventArgs e)
        {
            if (inputPort.IsOpen)
                inputPort.Close();
        }

        private void btnGateSend_Click(object sender, EventArgs e)
        {
            SendGateData();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
    }
}