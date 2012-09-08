using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models
{
    public class PLGame
    {
        [DisplayName("Game ID")]
        public int id { get; set; }
        /*
        [Required]
        [DisplayName("Game Name")]
        public string gameName { get; set; }
        */
        [Required]
        [DisplayName("Player 1 Name")]
        public string player1Name { get; set; }

        [Required]
        [DisplayName("Player 1 Race")]
        public string player1Race { get; set; }

        [Required]
        [DisplayName("Player 1 Race Code")]
        public string player1RaceCode { get; set; }

        [Required]
        [DisplayName("Player 1 Code")]
        public string player1Code { get; set; }

        [Required]
        [DisplayName("Player 1 League")]
        public string player1League { get; set; }

        [Required]
        [DisplayName("Player 2 Name")]
        public string player2Name { get; set; }

        [Required]
        [DisplayName("Player 2 Code")]
        public string player2Code { get; set; }

        [Required]
        [DisplayName("Player 2 Race")]
        public string player2Race { get; set; }

        [Required]
        [DisplayName("Player 2 Race Code")]
        public string player2RaceCode { get; set; }

        [Required]
        [DisplayName("Player 2 League")]
        public string player2League { get; set; }

        [Required]
        [DisplayName("Match Up")]
        public string matchup { get; set; }

        [Required]
        [DisplayName("Game length")]
        public string length { get; set; }

        [Required]
        [DisplayName("Date of game")]
        public String time { get; set; }

        [Required]
        [DisplayName("Winner")]
        public string winnerName { get; set; }

        [Required]
        [DisplayName("Map")]
        public string map { get; set; }

        [Required]
        [DisplayName("Map Spawns")]
        public string spawns { get; set; }

        [Required]
        [DisplayName("Map Size")]
        public string size { get; set; }

        [DisplayName("Download Count")]
        public int downloadCount { get; set; }
    }
    public static class GameClientService
    {
        public static List<PLGame> GetGameList()
        {
            List<PLGame> gameList = new List<PLGame>();
            SLGame.ISLGame SLGame = new SLGame.SLGameClient();
            string[] errors = new string[0];
            SLGame.Game[] gamesLoaded = SLGame.GetGameList(ref errors);
            foreach (SLGame.Game g in gamesLoaded)
            {
                PLGame game = DTO_to_PL(g);
                gameList.Add(game);
            }

            return gameList;
        }

        public static void CreateGame(PLGame g)
        {
            SLGame.Game newGame = DTO_to_SL(g);

            SLGame.ISLGame SLGame = new SLGame.SLGameClient();
            string[] errors = new string[0];
            SLGame.InsertGame(newGame, ref errors);
        }

        public static void UpdateGame(PLGame g)
        {
            SLGame.Game newGame = DTO_to_SL(g);

            SLGame.ISLGame SLGame = new SLGame.SLGameClient();
            string[] errors = new string[0];
            SLGame.UpdateGame(newGame, ref errors);
        }

        public static PLGame GetGameDetail(int id)
        {
            SLGame.ISLGame SLGame = new SLGame.SLGameClient();

            string[] errors = new string[0];
            SLGame.Game newGame = SLGame.GetGame(id, ref errors);

            return DTO_to_PL(newGame);
        }

        private static PLGame DTO_to_PL(SLGame.Game game)
        {
            PLGame PLGame = new Models.PLGame();
            PLGame.id = game.id;
            //PLGame.gameName = game.game_name;
            PLGame.player1Name = game.player1.name;
            PLGame.player1Race = game.player1_race.name;
            PLGame.player1Code = game.player1.code.ToString();
            PLGame.player1League = game.player1.league.name;
            PLGame.player2Name = game.player2.name;
            PLGame.player2Race = game.player2_race.name;
            PLGame.player2Code = game.player2.code.ToString();
            PLGame.matchup = game.matchup;
            PLGame.length = game.length;
            PLGame.time = game.time.ToString();
            PLGame.winnerName = game.winner.name;
            //PLGame.downloadCount = game.downloadCount.ToString();
            PLGame.map = game.map.name;
            PLGame.spawns = game.map.spawns.ToString();
            PLGame.size = game.map.size;

            return PLGame;
        }

        private static SLGame.Game DTO_to_SL(PLGame game)
        {
            SLGame.Game SLGame = new SLGame.Game();
            SLGame.matchup = game.matchup;
            SLGame.time = Convert.ToDateTime(game.time);
            SLGame.length = game.length;

            SLGame.player1 = new SLGame.Player();
            SLGame.player1.name = game.player1Name;
            SLGame.player1.code = Convert.ToInt32(game.player1Code);
            SLGame.player1.league = new SLGame.League();
            SLGame.player1.league.name = game.player1League;
            SLGame.player1.race = new SLGame.Race();
            SLGame.player1.race.name = game.player1Race;
            SLGame.player1.race.code = Convert.ToChar(game.player1RaceCode);
            SLGame.player1_race = SLGame.player1.race;

            SLGame.player2 = new SLGame.Player();
            SLGame.player2.name = game.player2Name;
            SLGame.player2.code = Convert.ToInt32(game.player2Code);
            SLGame.player2.league = new SLGame.League();
            SLGame.player2.league.name = game.player2League;
            SLGame.player2.race = new SLGame.Race();
            SLGame.player2.race.name = game.player2Race;
            SLGame.player2.race.code = Convert.ToChar(game.player2RaceCode);
            SLGame.player2_race = SLGame.player2.race;

            if (game.winnerName == game.player1Name)
            {
                SLGame.winner = SLGame.player1;
            }
            else
            {
                SLGame.winner = SLGame.player2;
            }

            SLGame.map = new SLGame.Map();
            SLGame.map.name = game.map;
            SLGame.map.spawns = Convert.ToInt32(game.spawns);
            SLGame.map.size = game.size;

            return SLGame;
        }
    }
}