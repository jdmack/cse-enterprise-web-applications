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
        public static void InsertGame(Game game, ref List<string> errors)
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
            Match match = Regex.Match(game.length, @"[0-9]*:[0-9]2");

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
                return;

            DALGame.InsertGame(game, ref errors);
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
            Match match = Regex.Match(game.length, @"[0-9]*:[0-9]2");

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
                return;

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
                return null;

            return (DALGame.GetGameDetail(id, ref errors));
        }

        public static void DeleteGame(int id, ref List<string> errors)
        {
            if (id == null)
            {
                errors.Add("Invalid game ID");
            }

            if (Convert.ToInt32(id) < 0)
            {
                errors.Add("The game ID cannot be negative");
            }

            if (errors.Count > 0)
                return;

            DALGame.DeleteGame(id, ref errors);
        }

        public static List<Game> GetGameList(ref List<string> errors)
        {
            return DALGame.GetGameList(ref errors);
        }
    }
}