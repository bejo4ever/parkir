using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System;
using System.Text;

namespace Commons
{
    
    public class NetworkShare
    {
        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2A(ref NetResource pstNetRes, string psPassword, string psUsername, int piFlags);
        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
        [StructLayout(LayoutKind.Sequential)]
        private struct NetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        private const int RESOURCETYPE_DISK = 0x1;

        public void LoginToShare(string serverName, string shareName, string user, string password)
        {
            string destinationDirectory = string.Format(@"\\{0}\{1}", serverName, shareName);

            NetResource nr = new NetResource();
            nr.iScope = 2;
            nr.iType = RESOURCETYPE_DISK;
            nr.iDisplayType = 3;
            nr.iUsage = 1;
            nr.sRemoteName = destinationDirectory;
            nr.sLocalName = null;

            int flags = 0;
            int rc = WNetAddConnection2A(ref nr, password, user, flags);

            if (rc != 0) 
                throw new Win32Exception(rc);          
        }

        public void LogoutFromShare(string serverName, string shareName)
        {
            string destinationDirectory = string.Format(@"\\{0}\{1}", serverName, shareName);
            int flags = 0;
            int rc = WNetCancelConnection2A(destinationDirectory, flags, Convert.ToInt32(false));
        }
    }
}
