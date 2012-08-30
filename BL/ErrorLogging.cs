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
            StreamWriter writer = new StreamWriter("c:\\errorlog.txt");
            foreach (string error in errorList)
            {
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
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["dsn"]);
            try
            {
                string strSQL = "spInsertLog";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@matchup", SqlDbType.Char, 3));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@length", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player1", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player1_race", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player2", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player2_race", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@winner", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@map", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@matchup"].Value = game.matchup;
                mySA.SelectCommand.Parameters["@time"].Value = game.time;
                mySA.SelectCommand.Parameters["@length"].Value = game.length;

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
