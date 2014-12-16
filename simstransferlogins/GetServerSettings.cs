using System;
using System.IO;

namespace SIMS_Transfer_Logins
{
    internal class GetServerSettings
    {
        private string simsDir;

        public GetServerSettings()
        {
            getDB = null;
            getServer = null;
        }

        public string getServer { get; private set; }
        public string getDB { get; private set; }

        public void Entry()
        {
            simsDir = gatherSIMS();
            getServer = gatherServer(simsDir);
            getDB = gatherDatabase(simsDir);
        }

        private string gatherSIMS()
        {
            var simsINI = Path.Combine(Environment.GetEnvironmentVariable("windir"), "sims.ini");
            if (File.Exists(simsINI))
            {
                var simsIni = new IniFile(simsINI);
                return simsIni.IniReadValue("Setup", "SIMSDotNetDirectory");
            }
            return null;
        }

        private string gatherServer(string simsDir)
        {
            var connectIni = Path.Combine(simsDir, "connect.ini");
            if (File.Exists(connectIni))
            {
                var simsIni = new IniFile(connectIni);
                return simsIni.IniReadValue("SIMSConnection", "ServerName");
            }
            return null;
        }

        private string gatherDatabase(string simsDir)
        {
            var connectIni = Path.Combine(simsDir, "connect.ini");
            if (File.Exists(connectIni))
            {
                var simsIni = new IniFile(connectIni);
                return simsIni.IniReadValue("SIMSConnection", "DatabaseName");
            }
            return null;
        }

        public void Close()
        {
            getServer = null;
            getDB = null;
            simsDir = null;
        }
    }
}