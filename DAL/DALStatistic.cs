using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;  // must add this...
using System.Configuration; // must add this... make sure to add "System.Configuration" first
using System.Data.SqlClient; // must add this...
using System.Data; // must add this...

namespace DAL
{
  public static class DALStatistic
  {
		static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static int InsertStatistic(Statistic statistic, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertStatisticInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@game_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@apm", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@resources", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@structures", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@player_id"].Value = statistic.getPlayer();
        mySA.SelectCommand.Parameters["@game_id"].Value = statistic.getGame();
        mySA.SelectCommand.Parameters["@apm"].Value = statistic.getAPM();
        mySA.SelectCommand.Parameters["@resources"].Value = statistic.getResources();
        mySA.SelectCommand.Parameters["@units"].Value = statistic.getUnits();
        mySA.SelectCommand.Parameters["@structures"].Value = statistic.getStructures();

        DataSet myDS = new DataSet();
        mySA.Fill(myDS); 
        return Convert.ToInt32(myDS.Tables[0].Rows[0][0].ToString());

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
        return -1;
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static void UpdateStatistic(Statistic statistic, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdateStatisticInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        mySA.SelectCommand.Parameters.Add(new SqlParameter("@stat_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@game_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@apm", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@resources", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@structures", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@stat_id"].Value = statistic.getId();
        mySA.SelectCommand.Parameters["@player_id"].Value = statistic.getPlayer();
        mySA.SelectCommand.Parameters["@game_id"].Value = statistic.getGame();
        mySA.SelectCommand.Parameters["@apm"].Value = statistic.getAPM();
        mySA.SelectCommand.Parameters["@resources"].Value = statistic.getResources();
        mySA.SelectCommand.Parameters["@units"].Value = statistic.getUnits();
        mySA.SelectCommand.Parameters["@structures"].Value = statistic.getStructures();

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static void DeleteStatistic(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeleteStatisticInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@stat_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@stat_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }
    }

    public static Statistic GetStatisticDetail(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Statistic statistic = null;

      try
      {
        string strSQL = "spGetStatisticDetail";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@stat_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@stat_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        statistic = new Statistic();
        statistic.setId(id);
        statistic.setPlayer(Convert.ToInt32(myDS.Tables[0].Rows[0]["player"].ToString()));
        statistic.setGame(Convert.ToInt32(myDS.Tables[0].Rows[0]["game"].ToString()));
        statistic.setAPM(Convert.ToInt32(myDS.Tables[0].Rows[0]["apm"].ToString()));
        statistic.setResources(Convert.ToInt32(myDS.Tables[0].Rows[0]["resources"].ToString()));
        statistic.setUnits(Convert.ToInt32(myDS.Tables[0].Rows[0]["units"].ToString()));
        statistic.setStructures(Convert.ToInt32(myDS.Tables[0].Rows[0]["structures"].ToString()));

      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }

      return statistic;
    }

    public static List<Statistic> GetStatisticList(ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Statistic statistic = null;
      List<Statistic> statisticList = new List<Statistic>();

      try
      {
        string strSQL = "spGetStatisticList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
            statistic = new Statistic();
            statistic.setId(Convert.ToInt32(myDS.Tables[0].Rows[0]["id"].ToString()));
            statistic.setPlayer(Convert.ToInt32(myDS.Tables[0].Rows[0]["player"].ToString()));
            statistic.setGame(Convert.ToInt32(myDS.Tables[0].Rows[0]["game"].ToString()));
            statistic.setAPM(Convert.ToInt32(myDS.Tables[0].Rows[0]["apm"].ToString()));
            statistic.setResources(Convert.ToInt32(myDS.Tables[0].Rows[0]["resources"].ToString()));
            statistic.setUnits(Convert.ToInt32(myDS.Tables[0].Rows[0]["units"].ToString()));
            statistic.setStructures(Convert.ToInt32(myDS.Tables[0].Rows[0]["structures"].ToString()));
            statisticList.Add(statistic);
        }
      }
      catch (Exception e)
      {
        errors.Add("Error: " + e.ToString());
      }
      finally
      {
        conn.Dispose();
        conn = null;
      }

      return statisticList;
    }
  }
}
