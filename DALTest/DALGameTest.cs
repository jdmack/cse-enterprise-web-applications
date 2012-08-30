using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DomainModel;

namespace DALTest
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class DALGameTest
  {
    public DALGameTest()
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

    /// <summary>
    ///A test for InsertGame
    ///</summary>
    [TestMethod]
    public void InsertGameTest()
    {
        List<string> errors = new List<string>();

        Race race = new Race();
        race.name = "Protoss";
        race.code = 'P';
        int raceID = DALRace.InsertRace(race, ref errors);
        race.id = raceID;

        Race race2 = new Race();
        race.name = "Terran";
        race.code = 'T';
        raceID = DALRace.InsertRace(race2, ref errors);
        race.id = raceID;

        Race race3 = new Race();
        race.name = "Zerg";
        race.code = 'Z';
        raceID = DALRace.InsertRace(race3, ref errors);
        race.id = raceID;

        League league = new League();
        league.name = "Diamond";
        int leagueID = DALLeague.InsertLeague(league, ref errors);
        league.id = leagueID;

        League league2 = new League();
        league.name = "Platinum";
        leagueID = DALLeague.InsertLeague(league2, ref errors);
        league.id = leagueID;

        League league3 = new League();
        league.name = "Master";
        leagueID = DALLeague.InsertLeague(league3, ref errors);
        league.id = leagueID;

        Map map = new Map();
        map.name = "Shakuras Plateau";
        map.spawns = 4;
        map.size = "120x100";
        int mapID = DALMap.InsertMap(map, ref errors);
        map.id = mapID;

        Map map2 = new Map();
        map2.name = "Daybreak";
        map2.spawns = 2;
        map2.size = "100x100";
        mapID = DALMap.InsertMap(map, ref errors);
        map.id = mapID;

        Player player = new Player();
        player.name = "Niter";
        player.code = 777;
        player.race = race3;
        player.league = league2;
        int playerID = DALPlayer.InsertPlayer(player, ref errors);
        player.id = playerID;

        Player player2 = new Player();
        player2.name = "WolfBro";
        player2.code = 123;
        player2.race = race;
        player2.league = league;
        playerID = DALPlayer.InsertPlayer(player2, ref errors);
        player.id = playerID;

        Player player3 = new Player();
        player3.name = "Corone";
        player3.code = 123;
        player3.race = race2;
        player3.league = league3;
        playerID = DALPlayer.InsertPlayer(player3, ref errors);
        player.id = playerID;
        
      Game game = new Game();
      game.matchup = "ZVT";
      game.length = "0:23:00";
      game.player1 = player;
      game.player1_race = player.race;
      game.player2 = player2;
      game.player2_race = player2.race;
      game.winner = game.player1;
      game.map = new Map();
      game.map.id = 1;

      int gameID = DALGame.InsertGame(game, ref errors);
      game.id = gameID;

      Assert.AreEqual(0, errors.Count);

      Game verifyGame = DALGame.GetGameDetail(game.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(game.matchup, verifyGame.matchup);
      Assert.AreEqual(game.length, verifyGame.length);
      Assert.AreEqual(game.player1.id, verifyGame.player1.id);
      Assert.AreEqual(game.player1_race.id, verifyGame.player1_race.id);
      Assert.AreEqual(game.player2.id, verifyGame.player2.id);
      Assert.AreEqual(game.player2_race.id, verifyGame.player2_race.id);

      Game game2 = new Game();
      game2.matchup = "TVP";
      game2.length = "0:44:44";
      game2.player1 = player2;
      game2.player1_race = player2.race;
      game2.player2 = player3;
      game2.player2_race = player3.race;
      game2.winner = game.player2;
      game2.map = new Map();
      game2.map.id = 2;
      game2.id = game.id;

      DALGame.UpdateGame(game2, ref errors);

      verifyGame = DALGame.GetGameDetail(game2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(game2.matchup, verifyGame.matchup);
      Assert.AreEqual(game2.length, verifyGame.length);
      Assert.AreEqual(game2.player1.id, verifyGame.player1.id);
      Assert.AreEqual(game2.player1_race.id, verifyGame.player1_race.id);
      Assert.AreEqual(game2.player2.id, verifyGame.player2.id);
      Assert.AreEqual(game2.player2_race.id, verifyGame.player2_race.id);

      DALGame.DeleteGame(game.id, ref errors);
      DALPlayer.DeletePlayer(player.id, ref errors);
      DALPlayer.DeletePlayer(player2.id, ref errors);
      DALPlayer.DeletePlayer(player3.id, ref errors);
      DALRace.DeleteRace(race.id, ref errors);
      DALRace.DeleteRace(race2.id, ref errors);
      DALRace.DeleteRace(race3.id, ref errors);
      DALLeague.DeleteLeague(league.id, ref errors);
      DALLeague.DeleteLeague(league2.id, ref errors);
      DALLeague.DeleteLeague(league3.id, ref errors);
      DALMap.DeleteMap(map.id, ref errors);
      DALMap.DeleteMap(map2.id, ref errors);

      Game verifyEmptyGame = DALGame.GetGameDetail(game.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyGame);

    }
  }
}
