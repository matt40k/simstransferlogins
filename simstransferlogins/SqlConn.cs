using System;
using System.Data;
using System.Data.SqlClient;

namespace SIMS_Transfer_Logins
{
    class SqlConn
    {
        public SqlConnection connect(string sr, string db, string ur, string ps)
        {
            SqlConnection sqlConn = new SqlConnection("user id=" + ur + ";" +
                                            "password=" + ps + "; " +
                                            "Trusted_Connection=no; " +
                                            "server=" + sr + "; " +
                                            "database=" + db + "; " +
                                            "connection timeout=30");
            sqlConn.Open();
            return sqlConn;
        }

        public SqlConnection connect(string sr, string db)
        {
            SqlConnection sqlConn = new SqlConnection("Trusted_Connection=yes; " +
                                            "server=" + sr + "; " +
                                            "database=" + db + "; " +
                                            "connection timeout=30");
            sqlConn.Open();
            return sqlConn;
        }

        public void closeConn(SqlConnection sqlConn)
        {
            sqlConn.Close();
        }
    }
}
