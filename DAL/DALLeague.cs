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
  public static class DALLeague
  {
		static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static int InsertLeague(League league, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertLeagueInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@league_name", SqlDbType.VarChar, 50));

        mySA.SelectCommand.Parameters["@league_name"].Value = league.name;

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

    public static void UpdateLeague(League league, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdateLeagueInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@league_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@league_name", SqlDbType.VarChar, 50));

        mySA.SelectCommand.Parameters["@league_id"].Value = league.id;
        mySA.SelectCommand.Parameters["@league_name"].Value = league.name;

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

    public static void DeleteLeague(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeleteLeagueInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@league_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@league_id"].Value = id;

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

    public static League GetLeagueDetail(int id, ref List<string> errors)
        {
      SqlConnection conn = new SqlConnection(connection_string);
      League league = null;

      try
      {
        string strSQL = "spGetLeagueDetail";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@league_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@league_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        league = new League();
        league.id = id;
        league.name = myDS.Tables[0].Rows[0]["name"].ToString();

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

      return league;
    }

    public static List<League> GetLeagueList(ref List<string> errors)
    {
        SqlConnection conn = new SqlConnection(connection_string);
        League league = null;
        List<League> leagueList = new List<League>();

        try
        {
            string strSQL = "spGetLeagueList";

            SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
            mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet myDS = new DataSet();
            mySA.Fill(myDS);

            if (myDS.Tables[0].Rows.Count == 0)
                return null;

            for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
            {
                league = new League();
                league.id = Convert.ToInt32(myDS.Tables[0].Rows[i]["league_id"].ToString());
                league.name = myDS.Tables[0].Rows[i]["name"].ToString();
                leagueList.Add(league);
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

        return leagueList;
    }

  }
}
