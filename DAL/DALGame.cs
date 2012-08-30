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
    public static class DALGame
    {
        static string connection_string = ConfigurationManager.AppSettings["dsn"];

        public static int InsertGame(Game game, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spInsertGameInfo";

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
                mySA.SelectCommand.Parameters["@player1"].Value = game.player1;
                mySA.SelectCommand.Parameters["@player1_race"].Value = game.player1_race;
                mySA.SelectCommand.Parameters["@player2"].Value = game.player2;
                mySA.SelectCommand.Parameters["@player2_race"].Value = game.player2_race;
                mySA.SelectCommand.Parameters["@winner"].Value = game.winner;
                mySA.SelectCommand.Parameters["@map"].Value = game.map;

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

        public static void UpdateGame(Game game, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            try
            {
                string strSQL = "spUpdateGameInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@game_id", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@matchup", SqlDbType.Char, 3));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@length", SqlDbType.VarChar, 50));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player1", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player1_race", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player2", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@player2_race", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@winner", SqlDbType.Int));
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@map", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@game_id"].Value = game.id;
                mySA.SelectCommand.Parameters["@matchup"].Value = game.matchup;
                mySA.SelectCommand.Parameters["@time"].Value = game.time;
                mySA.SelectCommand.Parameters["@length"].Value = game.length;
                mySA.SelectCommand.Parameters["@player1"].Value = game.player1;
                mySA.SelectCommand.Parameters["@player1_race"].Value = game.player1_race;
                mySA.SelectCommand.Parameters["@player2"].Value = game.player2;
                mySA.SelectCommand.Parameters["@player2_race"].Value = game.player2_race;
                mySA.SelectCommand.Parameters["@winner"].Value = game.winner;
                mySA.SelectCommand.Parameters["@map"].Value = game.map;

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

        public static void DeleteGame(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);

            try
            {
                string strSQL = "spDeleteGameInfo";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@game_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@game_id"].Value = id;

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

        public static Game GetGameDetail(int id, ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Game game = null;

            try
            {
                string strSQL = "spGetGameDetail";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;
                mySA.SelectCommand.Parameters.Add(new SqlParameter("@game_id", SqlDbType.Int));

                mySA.SelectCommand.Parameters["@game_id"].Value = id;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                game = new Game();    
                game.id = id;
                game.matchup = myDS.Tables[0].Rows[0]["matchup"].ToString();
                game.time = Convert.ToDateTime(myDS.Tables[0].Rows[0]["time"].ToString());
                game.length = myDS.Tables[0].Rows[0]["length"].ToString();
                game.player1 = Convert.ToInt32(myDS.Tables[0].Rows[0]["player1"].ToString());
                game.player1_race = Convert.ToInt32(myDS.Tables[0].Rows[0]["player1_race"].ToString());
                game.player2 = Convert.ToInt32(myDS.Tables[0].Rows[0]["player2"].ToString());
                game.player2_race = Convert.ToInt32(myDS.Tables[0].Rows[0]["player2_race"].ToString());
                game.winner = Convert.ToInt32(myDS.Tables[0].Rows[0]["winner"].ToString());
                game.map = Convert.ToInt32(myDS.Tables[0].Rows[0]["map"].ToString());
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

            return game;
        }

        public static List<Game> GetGameList(ref List<string> errors)
        {
            SqlConnection conn = new SqlConnection(connection_string);
            Game game = null;
            List<Game> gameList = new List<Game>();

            try
            {
                string strSQL = "spGetGameList";

                SqlDataAdapter mySA = new SqlDataAdapter(strSQL, conn);
                mySA.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet myDS = new DataSet();
                mySA.Fill(myDS);

                if (myDS.Tables[0].Rows.Count == 0)
                    return null;

                for (int i = 0; i < myDS.Tables[0].Rows.Count; i++)
                {
                    game = new Game();

                    game.id = Convert.ToInt32(myDS.Tables[0].Rows[0]["game_id"].ToString());
                    game.matchup = myDS.Tables[0].Rows[0]["matchup"].ToString();
                    game.time = Convert.ToDateTime(myDS.Tables[0].Rows[0]["time"].ToString());
                    game.length = myDS.Tables[0].Rows[0]["length"].ToString();
                    game.player1 = Convert.ToInt32(myDS.Tables[0].Rows[0]["player1"].ToString());
                    game.player1_race = Convert.ToInt32(myDS.Tables[0].Rows[0]["player1_race"].ToString());
                    game.player2 = Convert.ToInt32(myDS.Tables[0].Rows[0]["player2"].ToString());
                    game.player2_race = Convert.ToInt32(myDS.Tables[0].Rows[0]["player2_race"].ToString());
                    game.player2 = Convert.ToInt32(myDS.Tables[0].Rows[0]["winner"].ToString());
                    game.player2_race = Convert.ToInt32(myDS.Tables[0].Rows[0]["map"].ToString());

                    gameList.Add(game);
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

            return gameList;
        }
    }
}