using System;

namespace SIMS_Transfer_Logins
{
    class Entry
    {
        static void Main(string[] args)
        {
            string ur = null;
            string ps = null;
            string sr = null;
            string db = null;

            for (int i = 0; i < args.Length; i++)
            {
                string str = args[i].ToUpper();
                if (str.StartsWith("/USER"))
                {
                    ur = GetParameterValue(args, "/USER");
                }
                if (str.StartsWith("/PASS"))
                {
                    ps = GetParameterValue(args, "/PASS");
                }
                if (str.StartsWith("/SERVER"))
                {
                    sr = GetParameterValue(args, "/SERVER");
                }
                if (str.StartsWith("/DATABASE"))
                {
                    db = GetParameterValue(args, "/DATABASE");
                }
            }

            // Read sims.ini and connect.ini to get servername and databasename - JIC
            GetServerSettings serverSettings = new GetServerSettings();
            serverSettings.Entry();
            if (sr == null) { sr = serverSettings.getServer; }
            if (db == null) { db = serverSettings.getDB; }
            serverSettings.Close();

#if DEBUG
            Console.WriteLine(sr);
            Console.WriteLine(db);
            Console.WriteLine(ur);
            Console.WriteLine(ps);
#endif

            // Check user input
            Validation valid = new Validation();
            valid.Entry(sr, db, ur, ps);
            bool validationResults = valid.Run();
            valid.Close();

            if (validationResults)
            {
                // Begin work
                Work work = new Work();
                work.Entry(sr, db, ur, ps);
                bool result = work.Run();
                work.Close();
                if (result) { Console.WriteLine("Complete"); }
            }
        }

        private static string GetParameterValue(string[] commandParameters, string parameterName)
        {
            try
            {
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    string str = commandParameters[i];
                    if (str.ToUpper().StartsWith(parameterName.ToUpper()))
                    {
                        if (parameterName == str)
                        {
                            return "";
                        }
                        return str.Substring(parameterName.Length + 1);
                    }
                }
            }

            catch (Exception)
            {
            }
            return "";
        }
    }
}
