using System;
using System.IO;

namespace SIMS_Transfer_Logins
{
    class GetServerSettings
    {
        private string serverName = null;
        private string databaseName = null;
        private string simsDir = null;

        public string getServer
        {
            get { return serverName; }
        }

        public string getDB
        {
            get { return databaseName; }
        }

        public void Entry()
        {
            simsDir = gatherSIMS();
            serverName = gatherServer(simsDir);
            databaseName = gatherDatabase(simsDir);
        }

        private string gatherSIMS()
        {
            string simsINI = Path.Combine(Environment.GetEnvironmentVariable("windir"), "sims.ini");
            if (File.Exists(simsINI))
            {
                IniFile simsIni = new IniFile(simsINI);
                return simsIni.IniReadValue("Setup", "SIMSDotNetDirectory");
            }
            return null;
        }

        private string gatherServer(string simsDir)
        {
            string connectIni = Path.Combine(simsDir, "connect.ini");
            if (File.Exists(connectIni))
            {
                IniFile simsIni = new IniFile(connectIni);
                return simsIni.IniReadValue("SIMSConnection", "ServerName");
            }
            return null;
        }

        private string gatherDatabase(string simsDir)
        {
            string connectIni = Path.Combine(simsDir, "connect.ini");
            if (File.Exists(connectIni))
            {
                IniFile simsIni = new IniFile(connectIni);
                return simsIni.IniReadValue("SIMSConnection", "DatabaseName");
            }
            return null;
        }

        public void Close()
        {
            serverName = null;
            databaseName = null;
            simsDir = null;
        }
    }
}