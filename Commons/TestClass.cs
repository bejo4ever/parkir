using System;
using System.Collections.Generic;
using System.Text;

namespace Commons
{
    public class TestClass
    {
        public TestClass()
        {
            SerialComPort port = new SerialComPort();
            port.IncomingData += new IncomingDataEventHandler(port_IncomingData);
            port.SendingData += new SendingDataEventHandler(port_SendingData);
            port.ErrorData += new ErrorDataEventHandler(port_ErrorData);
        }

        void port_ErrorData(string errorMessage)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void port_SendingData(string sendingData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void port_IncomingData(string incomingData)
        {
            object[] args = new object[] { incomingData };
            ProcessDataMarshalDelegate processData = new ProcessDataMarshalDelegate(ProcessData);
            ///this.Invoke(processData, args);
        }

        private void ProcessData(string data)
        {
            Console.WriteLine(data);
        }
    }
}
