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
  public static class DALPlayer
  {
		static string connection_string = ConfigurationManager.AppSettings["dsn"];

    public static int InsertPlayer(Player player, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spInsertPlayerInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_code", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_race", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_league", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@player_name"].Value = player.name;
        mySA.SelectCommand.Parameters["@player_code"].Value = player.code;
        mySA.SelectCommand.Parameters["@player_race"].Value = player.race.id;
        mySA.SelectCommand.Parameters["@player_league"].Value = player.league.id;

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

    public static void UpdatePlayer(Player player, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      try
      {
        string strSQL = "spUpdatePlayerInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_id", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_name", SqlDbType.VarChar, 50));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_code", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_race", SqlDbType.Int));
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_league", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@player_id"].Value = player.id;
        mySA.SelectCommand.Parameters["@player_name"].Value = player.name;
        mySA.SelectCommand.Parameters["@player_code"].Value = player.code;
        mySA.SelectCommand.Parameters["@player_race"].Value = player.race.id;
        mySA.SelectCommand.Parameters["@player_league"].Value = player.league.id;

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

    public static void DeletePlayer(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);

      try
      {
        string strSQL = "spDeletePlayerInfo";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@player_id"].Value = id;

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

    public static Player GetPlayerDetail(int id, ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Player player = null;

      try
      {
        string strSQL = "spGetPlayerDetail";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
        mySA.SelectCommand.Parameters.Add(new SqlParameter("@player_id", SqlDbType.Int));

        mySA.SelectCommand.Parameters["@player_id"].Value = id;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        player = new Player();
        player.id = id;
        player.name = myDS.Tables[0].Rows[0]["name"].ToString();
        player.code = Convert.ToInt32(myDS.Tables[0].Rows[0]["code"].ToString());
        player.race = DALRace.GetRaceDetail(Convert.ToInt32(myDS.Tables[0].Rows[0]["race"].ToString()), ref errors);
        player.league = DALLeague.GetLeagueDetail(Convert.ToInt32(myDS.Tables[0].Rows[0]["league"].ToString()), ref errors);

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

      return player;
    }

    public static List<Player> GetPlayerList(ref List<string> errors)
    {
      SqlConnection conn = new SqlConnection(connection_string);
      Player player = null;
      List<Player> playerList = new List<Player>();

      try
      {
        string strSQL = "spGetPlayerList";

        SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
        mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet myDS = new DataSet();
        mySA.Fill(myDS);

        if (myDS.Tables[0].Rows.Count == 0)
          return null;

        for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
        {
          player = new Player();
          player.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["player_id"].ToString());
          player.name = myDS.Tables[0].Rows[0]["player_name"].ToString();
          player.code = Convert.ToInt32(myDS.Tables[0].Rows[0]["player_code"].ToString());
          player.race = DALRace.GetRaceDetail(Convert.ToInt32(myDS.Tables[0].Rows[0]["race"].ToString()), ref errors);
          player.league = DALLeague.GetLeagueDetail(Convert.ToInt32(myDS.Tables[0].Rows[0]["league"].ToString()), ref errors);
          playerList.Add(player);
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

      return playerList;
    }

  }
}
