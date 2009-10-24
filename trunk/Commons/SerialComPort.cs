using System;
using System.Collections.Generic;
using System.Text;

using System.IO.Ports;

namespace Commons
{
    public enum DataMode { Text, Hex }
    public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
    
    public delegate void IncomingDataEventHandler(string incomingData);
    public delegate void SendingDataEventHandler(string sendingData);
    public delegate void ErrorDataEventHandler(string errorMessage);
    internal delegate bool SendDataDelegate(string dataToSent);

    /// <summary>
    /// Client processing ...
    /// </summary>
    /// <param name="textToProcess"></param>
    public delegate void ProcessDataMarshalDelegate(string textToProcess);

    public class SerialComPort
    {
        private SerialPort m_selectedPort = null;

        public event IncomingDataEventHandler IncomingData;
        public event SendingDataEventHandler SendingData;
        public event ErrorDataEventHandler ErrorData;

        private SerialDataReceivedEventHandler dataReceivedHandler;
        private SerialErrorReceivedEventHandler errorReceivedHandler;

        private DataMode m_DataMode;
        private SerialUtilities m_SerialUtilities;
        private SendDataDelegate m_SendDataDelegate;

        public SerialComPort()
        {
            m_selectedPort = new SerialPort();
            m_SerialUtilities = new SerialUtilities();

            dataReceivedHandler = new SerialDataReceivedEventHandler(SerialDataReceived);
            m_selectedPort.DataReceived += dataReceivedHandler;

            errorReceivedHandler = new SerialErrorReceivedEventHandler(ErrorReceivedHandler);
            m_selectedPort.ErrorReceived += errorReceivedHandler;
        }

        public SerialPort SelectedPort
        {
            get { return m_selectedPort; }
            set {
                if (null == m_selectedPort)
                    throw new Exception("null port was assigned");

                m_selectedPort = value;                
                m_selectedPort.DataReceived += dataReceivedHandler;                
                m_selectedPort.ErrorReceived += errorReceivedHandler;
            }
        }

        public DataMode DataMode
        {
            get { return m_DataMode; }
            set { m_DataMode = value; }
        }

        public SerialUtilities SerialUtilities
        {
            get { return m_SerialUtilities; }
        }

        private void ErrorReceivedHandler(object sender, SerialErrorReceivedEventArgs e)
        {
            // TODO processing error message here
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
            if (null != ErrorData)
            {
                ErrorData(message);
            }
        }

        internal void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = string.Empty;
            if (DataMode == DataMode.Text)
            {
                receivedData = SelectedPort.ReadExisting();
            }
            else if(DataMode == DataMode.Hex)
            {
                int length = SelectedPort.BytesToRead;
                byte[] datas = new byte[length];
                SelectedPort.Write(datas, 0, length);
                receivedData = SerialUtilities.ByteArrayToHexString(datas);
            }
            // raise event to make the data available to other modules
            if (null != IncomingData)
            {
                IncomingData(receivedData);
            }
        }

        public void SendData(string textData)
        {
            m_SendDataDelegate = new SendDataDelegate(_SendData);
            m_SendDataDelegate.BeginInvoke(textData, new AsyncCallback(_SendDataCompleted), DateTime.Now.ToString());
        }

        private bool _SendData(string text)
        {
            bool result = false;
            if (SelectedPort.IsOpen)
            {
                if ((SelectedPort.WriteBufferSize - SelectedPort.BytesToWrite) > text.Length)
                {
                    SelectedPort.Write(text);
                    result = true;
                }
                else
                {
                    if (null != ErrorData)
                    {
                        ErrorData("Tidak cukup buffer untuk mengirim pesan :" +
                            text);
                    }
                }
            }
            else
            {
                if (null != ErrorData)
                {
                    ErrorData("Serial port closed");
                }
            }
            return result;
        }

        private void _SendDataCompleted(IAsyncResult iar)
        {
            string message = iar.AsyncState as string;
            bool result = m_SendDataDelegate.EndInvoke(iar);
            if (null != SendingData)
            {
                if (result)
                {
                    SendingData("Pengiriman Pesan [" + message + "] sukses ");
                }
                else
                {
                    SendingData("Pengiriman Pesan [" + message + "] gagal");
                }
            }
        }

        public void Open()
        {
            SelectedPort.Open();
        }

        public void Close()
        {
            if (SelectedPort.IsOpen)
            {
                while (SelectedPort.BytesToWrite > 0)
                { }
                SelectedPort.DataReceived -= dataReceivedHandler;
                SelectedPort.ErrorReceived -= errorReceivedHandler;
                SelectedPort.Close();
                SelectedPort.Dispose();
            }
        }
    }
}
