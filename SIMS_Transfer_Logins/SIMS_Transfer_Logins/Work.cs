using System;
using System.Data;
using System.Data.SqlClient;

namespace SIMS_Transfer_Logins
{
    class Work
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

        public void Close()
        {
            serverName = null;
            databaseName = null;
            userName = null;
            passWord = null;
        }

        public bool Run()
        {
            bool value = true;
            string query = "sims.db_p_transfer_login";

            try
            {
                SqlConn Conn = new SqlConn();
                SqlConnection sqlConn;

                if (passWord == null)
                {
                    sqlConn = Conn.connect(serverName, databaseName);
                }
                else
                {
                    if (userName == null) { userName = "sa"; }
                    sqlConn = Conn.connect(serverName, databaseName, userName, passWord);
                }

                SqlCommand command = new SqlCommand(query, sqlConn);
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