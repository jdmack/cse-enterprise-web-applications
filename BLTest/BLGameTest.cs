using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using DomainModel;

namespace BLTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BLGameTest
    {
        public BLGameTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InsertGameErrorTest()
        {
            List<string> errors = new List<string>();

            BLGame.InsertGame(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Game game = new Game();
            game.id = -1;
            BLGame.InsertGame(game, ref errors);
            Assert.AreNotEqual(0, errors.Count);
           
        }

        [TestMethod]
        public void GameErrorTest()
        {
            List<string> errors = new List<string>();

            BLGame.GetGame(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteGameErrorTest()
        {
            List<string> errors = new List<string>();

            BLGame.DeleteGame(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void GameInsertAndSelectTest()
        {
            List<string> errors = new List<string>();

            Race race = new Race();
            race.name = "Protoss";
            race.code = 'P';
            int raceID = BLRace.InsertRace(race, ref errors);
            race.id = raceID;

            Race race2 = new Race();
            race2.name = "Terran";
            race2.code = 'T';
            raceID = BLRace.InsertRace(race2, ref errors);
            race2.id = raceID;

            Race race3 = new Race();
            race3.name = "Zerg";
            race3.code = 'Z';
            raceID = BLRace.InsertRace(race3, ref errors);
            race3.id = raceID;

            League league = new League();
            league.name = "Diamond";
            int leagueID = BLLeague.InsertLeague(league, ref errors);
            league.id = leagueID;

            League league2 = new League();
            league2.name = "Platinum";
            leagueID = BLLeague.InsertLeague(league2, ref errors);
            league2.id = leagueID;

            League league3 = new League();
            league3.name = "Master";
            leagueID = BLLeague.InsertLeague(league3, ref errors);
            league3.id = leagueID;

            Map map = new Map();
            map.name = "Shakuras Plateau";
            map.spawns = 4;
            map.size = "120x100";
            int mapID = BLMap.InsertMap(map, ref errors);
            map.id = mapID;

            Map map2 = new Map();
            map2.name = "Daybreak";
            map2.spawns = 2;
            map2.size = "100x100";
            mapID = BLMap.InsertMap(map, ref errors);
            map2.id = mapID;

            Player player = new Player();
            player.name = "Niter";
            player.code = 777;
            player.race = race3;
            player.league = league2;
            int playerID = BLPlayer.InsertPlayer(player, ref errors);
            player.id = playerID;

            Player player2 = new Player();
            player2.name = "WolfBro";
            player2.code = 123;
            player2.race = race;
            player2.league = league;
            playerID = BLPlayer.InsertPlayer(player2, ref errors);
            player2.id = playerID;

            Player player3 = new Player();
            player3.name = "Corone";
            player3.code = 123;
            player3.race = race2;
            player3.league = league3;
            playerID = BLPlayer.InsertPlayer(player3, ref errors);
            player3.id = playerID;

            Game game = new Game();
            game.matchup = "ZVT";
            game.length = "0:23:00";
            game.player1 = player;
            game.player1_race = player.race;
            game.player2 = player2;
            game.player2_race = player2.race;
            game.winner = game.player1;
            game.map = map;

            game.id = BLGame.InsertGame(game, ref errors);

            Assert.AreEqual(0, errors.Count);

            Game verifyGame = BLGame.GetGame(game.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(game.matchup, verifyGame.matchup);
            Assert.AreEqual(game.time, verifyGame.time);
            Assert.AreEqual(game.length, verifyGame.length);
            Assert.AreEqual(game.player1.id, verifyGame.player1.id);
            Assert.AreEqual(game.player1_race.id, verifyGame.player1_race.id);
            Assert.AreEqual(game.player2.id, verifyGame.player2.id);
            Assert.AreEqual(game.player2_race.id, verifyGame.player2_race.id);
            Assert.AreEqual(game.winner.id, verifyGame.winner.id);
            Assert.AreEqual(game.map.id, verifyGame.map.id);

            BLGame.DeleteGame(game.id, ref errors);

            Game verifyEmptyGame = BLGame.GetGame(game.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyGame);

        }

    }
}
