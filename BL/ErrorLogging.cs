using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration; // must add this... make sure to add "System.Configuration" first

///
/// Note, in real world practice, each class definition should be in its own
/// file because the logic is much more complicated.  For 136, it's all in one
/// file for simplicity.
///
namespace BL
{
    // this is the interface definition
    public interface IErrorLogging
    {
        void LogError(List<string> errorList);
    }

    public class LogToFile : IErrorLogging
    {
        public void LogError(List<string> errorList)
        {
            // 136 Students TODO: Write to local file system somewhere
            StreamWriter writer = new StreamWriter("c:\\errorlog.txt",true);
            foreach (string error in errorList)
            {
                Console.WriteLine(error);
                writer.WriteLine(error);
            }
            writer.Close();
        }
    }

    public class LogToDB : IErrorLogging
    {
        public void LogError(List<string> errorList)
        {
            // 136 Students TODO: write to database table.
            

            foreach (string error in errorList)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["dsn"]);
                string strSQL = "spInsertLog";
                
                try
                {
                    SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                    mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                    mySA.SelectCommand.Parameters.Add(new SqlParameter("@log", SqlDbType.VarChar, 100));
                    mySA.SelectCommand.Parameters["@log"].Value = error;

                    DataSet myDS = new DataSet();
                    mySA.Fill(myDS);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                finally
                {
                    conn.Dispose();
                    conn = null;
                }
            }


        }
    }

    public class ErrorLogFactory
    {

        static string logDestination = ConfigurationManager.AppSettings["logDestination"];
        public IErrorLogging logInstance = null;

        public IErrorLogging GetErrorLogInstance()
        {
            switch (logDestination)
            {
                case "file":
                    logInstance = new LogToFile();
                    break;
                case "db":
                    logInstance = new LogToDB();
                    break;
                default:
                    break;
            }
            return logInstance;
        }
    }

    public class AsynchLog
    {
        delegate void MethodDelegate(List<string> strError);

        public static void LogNow(List<string> strError)
        {
            IErrorLogging log = new ErrorLogFactory().GetErrorLogInstance();

            MethodDelegate callGenerateFileAsync = new MethodDelegate(log.LogError);
            IAsyncResult ar = callGenerateFileAsync.BeginInvoke(strError, null, null);
        }
    }

}
