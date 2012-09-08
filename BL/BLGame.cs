using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DAL;
using DomainModel;

namespace BL
{
    public static class BLGame
    {
        public static int InsertGame(Game game, ref List<string> errors)
        {
            if (game == null)
            {
                errors.Add("Game cannot be null");
            }
            else
            {
                if (game.matchup.Length != 3)
                {
                    errors.Add("Game matchup has to be 3 characters");
                }

                // regex
                Match match = Regex.Match(game.length, @"[0-9]*:[0-9][0-9]:[0-9][0-9]");

                if (!match.Success)
                {
                    errors.Add("Game length must be 00:00");
                }

                if (game.player1 == null)
                {
                    errors.Add("player1 cannot be null");
                }

                if (game.player1_race == null)
                {
                    errors.Add("player1_race cannot be null");
                }

                if (game.player2 == null)
                {
                    errors.Add("player2 cannot be null");
                }

                if (game.player2_race == null)
                {
                    errors.Add("player2_race cannot be null");
                }

                if (game.winner == null)
                {
                    errors.Add("winner cannot be null");
                }

                if (game.map == null)
                {
                    errors.Add("map cannot be null");
                }
            }

            if (errors.Count > 0)
            {
                //AsynchLog.LogNow(errors);
                return 0;
            }
            
            int player1_race = DALRace.InsertRace(game.player1_race, ref errors);
            game.player1.race.id = player1_race;
            game.player1_race.id = player1_race;
            int player1_league = DALLeague.InsertLeague(game.player1.league, ref errors);
            game.player1.league.id = player1_league;
            int player1 = DALPlayer.InsertPlayer(game.player1, ref errors);
            
            int player2_race = DALRace.InsertRace(game.player2_race, ref errors);
            game.player2.race.id = player2_race;
            game.player2_race.id = player2_race;
            int player2_league = DALLeague.InsertLeague(game.player2.league, ref errors);
            game.player2.league.id = player2_league;
            int player2 = DALPlayer.InsertPlayer(game.player2, ref errors);

            if (game.winner.name == game.player1.name && game.winner.code == game.player1.code)
            {
                game.winner.id = player1;
            }
            else
            {
                game.winner.id = player2;
            }

            int map = DALMap.InsertMap(game.map, ref errors);        

            return DALGame.InsertGame(game, ref errors);
        }

        public static void UpdateGame(Game game, ref List<string> errors)
        {
            if (game == null)
            {
                errors.Add("Game cannot be null");
            }

            if (game.matchup.Length != 3)
            {
                errors.Add("Game matchup has to be 3 characters");
            }

            // regex
            Match match = Regex.Match(game.length, @"[0-9]*:[0-9][0-9]:[0-9][0-9]");

            if (!match.Success)
            {
                errors.Add("Game length must be 00:00");
            }

            if (game.player1 == null)
            {
                errors.Add("player1 cannot be null");
            }

            if (game.player1_race == null)
            {
                errors.Add("player1_race cannot be null");
            }

            if (game.player2 == null)
            {
                errors.Add("player2 cannot be null");
            }

            if (game.player2_race == null)
            {
                errors.Add("player2_race cannot be null");
            }

            if (game.winner == null)
            {
                errors.Add("winner cannot be null");
            }

            if (game.map == null)
            {
                errors.Add("map cannot be null");
            }

            if (errors.Count > 0)
            {
                //AsynchLog.LogNow(errors);
                return;
            }

            DALRace.UpdateRace(game.player1_race, ref errors);            
            DALLeague.UpdateLeague(game.player1.league, ref errors);            
            DALPlayer.UpdatePlayer(game.player1, ref errors);
            DALRace.UpdateRace(game.player2_race, ref errors);
            DALLeague.UpdateLeague(game.player2.league, ref errors);
            DALPlayer.UpdatePlayer(game.player2, ref errors);
            DALMap.UpdateMap(game.map, ref errors);

            DALGame.UpdateGame(game, ref errors);
        }

        public static Game GetGame(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid game ID");
            }
            
            if (id < 0)
            {
                errors.Add("The game ID cannot be negative");
            }

            if (errors.Count > 0)
            {
                //AsynchLog.LogNow(errors);
                return null;
            }

            Game game =  DALGame.GetGameDetail(id, ref errors);
            game.downloadCount = DALGame.GetDownloadCount(game.id, ref errors);
            return game;
        }

        public static void DeleteGame(int id, ref List<string> errors)
        {
            if (id < 0)
            {
                errors.Add("The game ID cannot be negative");
            }

            if (errors.Count > 0)
            {
                //AsynchLog.LogNow(errors);
                return;
            }

            Game game = DALGame.GetGameDetail(id, ref errors);

            DALRace.DeleteRace(game.player1_race.id, ref errors);
            DALLeague.DeleteLeague(game.player1.league.id, ref errors);
            DALPlayer.DeletePlayer(game.player1.id, ref errors);
            DALRace.DeleteRace(game.player2_race.id, ref errors);
            DALLeague.DeleteLeague(game.player2.league.id, ref errors);
            DALPlayer.DeletePlayer(game.player2.id, ref errors);
            DALMap.DeleteMap(game.map.id, ref errors);
            DALGame.DeleteGame(game.id, ref errors);
        }

        public static List<Game> GetGameList(ref List<string> errors)
        {
            return DALGame.GetGameList(ref errors);
        }
    }
}