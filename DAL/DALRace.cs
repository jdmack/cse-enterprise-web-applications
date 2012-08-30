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
  public static class DALRace
  {
		static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static int InsertRace(Race race, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertRaceInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.Char, 1));

        mySA.SelectCommand.Parameters["@name"].Value = race.name;
        mySA.SelectCommand.Parameters["@code"].Value = race.code;

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

    public static void UpdateRace(Race race, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdateRaceInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@race_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.Char, 1));

        mySA.SelectCommand.Parameters["@race_id"].Value = race.id;
        mySA.SelectCommand.Parameters["@name"].Value = race.name;
        mySA.SelectCommand.Parameters["@code"].Value = race.code;

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

    public static void DeleteRace(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeleteRaceInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@race_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@race_id"].Value = id;

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

    public static Race GetRaceDetail(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Race race = null;

      try
      {
        string strSQL = "spGetRaceDetail";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@race_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@race_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        race = new Race();
        race.id = id;
        race.name = myDS.Tables[0].Rows[0]["name"].ToString();
        race.code = Convert.ToChar(myDS.Tables[0].Rows[0]["code"].ToString());

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

      return race;
    }

    public static List<Race> GetRaceList(ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Race race = null;
      List<Race> raceList = new List<Race>();

      try
      {
        string strSQL = "spGetRaceList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
            race = new Race();
            race.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["id"].ToString());
            race.name = myDS.Tables[0].Rows[0]["name"].ToString();
            race.code = Convert.ToChar(myDS.Tables[0].Rows[0]["code"].ToString());
            raceList.Add(race);
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

      return raceList;
    }
  }
}
