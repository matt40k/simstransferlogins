using System.Data.SqlClient;

namespace SIMS_Transfer_Logins
{
    internal class SqlConn
    {
        public SqlConnection connect(string sr, string db, string ur, string ps)
        {
            var sqlConn = new SqlConnection("user id=" + ur + ";" +
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
            var sqlConn = new SqlConnection("Trusted_Connection=yes; " +
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