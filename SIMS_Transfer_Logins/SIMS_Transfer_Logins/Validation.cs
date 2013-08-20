using System;

namespace SIMS_Transfer_Logins
{
    class Validation
    {
        private string serverName = null;
        private string databaseName = null;
        private string userName = null;
        private string passWord = null;

        public void Entry(string sr, string db, string ur, string ps)
        {
            serverName = sr;
            databaseName = db;
            userName = ur;
            passWord = ps;
        }

        public bool Run()
        {
            bool value = true;
            if (!servername())
            {
                Console.WriteLine("No server name supplied");
                value = false;
            }
            if (!databasename())
            {
                Console.WriteLine("No database name supplied");
                value = false;
            }
            return value;
        }

        public void Close()
        {
            serverName = null;
            databaseName = null;
            userName = null;
            passWord = null;
        }

        private bool servername()
        {
            return (serverName != null);
        }

        private bool databasename()
        {
            return (databaseName != null);
        }
    }
}