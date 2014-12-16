using System;

namespace SIMS_Transfer_Logins
{
    internal class Validation
    {
        private string databaseName;
        private string passWord;
        private string serverName;
        private string userName;

        public void Entry(string sr, string db, string ur, string ps)
        {
            serverName = sr;
            databaseName = db;
            userName = ur;
            passWord = ps;
        }

        public bool Run()
        {
            var value = true;
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