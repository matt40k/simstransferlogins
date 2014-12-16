using System;
using System.Data.SqlClient;

namespace SIMS_Transfer_Logins
{
    internal class Work
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

        public void Close()
        {
            serverName = null;
            databaseName = null;
            userName = null;
            passWord = null;
        }

        public bool Run()
        {
            var value = true;
            var query = "sims.db_p_transfer_login";

            try
            {
                var Conn = new SqlConn();
                SqlConnection sqlConn;

                if (passWord == null)
                {
                    sqlConn = Conn.connect(serverName, databaseName);
                }
                else
                {
                    if (userName == null)
                    {
                        userName = "sa";
                    }
                    sqlConn = Conn.connect(serverName, databaseName, userName, passWord);
                }

                var command = new SqlCommand(query, sqlConn);
                command.ExecuteNonQuery();
                Conn.closeConn(sqlConn);
            }
            catch (SqlException e)
            {
                value = false;
                Console.WriteLine(e.Message);
            }

            return value;
        }
    }
}