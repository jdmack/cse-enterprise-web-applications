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
  public class DALPlayerTest
  {
    public DALPlayerTest()
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
    ///A test for InsertPlayer
    ///</summary>
    [TestMethod]
    public void InsertPlayerTest()
    {
        List<string> errors = new List<string>();

        Race race = new Race();
        race.name = "Protoss";
        race.code = 'P';
        int raceID = DALRace.InsertRace(race, ref errors);
        race.id = raceID;

        Race race3 = new Race();
        race3.name = "Zerg";
        race3.code = 'Z';
        raceID = DALRace.InsertRace(race3, ref errors);
        race3.id = raceID;

        League league = new League();
        league.name = "Diamond";
        int leagueID = DALLeague.InsertLeague(league, ref errors);
        league.id = leagueID;

        League league2 = new League();
        league2.name = "Platinum";
        leagueID = DALLeague.InsertLeague(league2, ref errors);
        league2.id = leagueID;

        Player player = new Player();
        player.name = "Niter";
        player.code = 777;
        player.race = race3;
        player.league = league2;

        Player player2 = new Player();
        player2.name = "WolfBro";
        player2.code = 123;
        player2.race = race;
        player2.league = league;

      int playerID = DALPlayer.InsertPlayer(player, ref errors);
      player.id = playerID;

      Assert.AreEqual(0, errors.Count);

      Player verifyPlayer = DALPlayer.GetPlayerDetail(player.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(player.name, verifyPlayer.name);
      Assert.AreEqual(player.code, verifyPlayer.code);
      Assert.AreEqual(player.race.id, verifyPlayer.race.id);
      Assert.AreEqual(player.league.id, verifyPlayer.league.id);

      player2.id = player.id;

      DALPlayer.UpdatePlayer(player2, ref errors);

      verifyPlayer = DALPlayer.GetPlayerDetail(player2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(player2.name, verifyPlayer.name);
      Assert.AreEqual(player2.code, verifyPlayer.code);
      Assert.AreEqual(player2.race.id, verifyPlayer.race.id);
      Assert.AreEqual(player2.league.id, verifyPlayer.league.id);

      DALPlayer.DeletePlayer(player.id, ref errors);

      Player verifyEmptyPlayer = DALPlayer.GetPlayerDetail(player.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyPlayer);

    }
  }
}
