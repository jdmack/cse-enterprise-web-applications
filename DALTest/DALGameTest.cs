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
      Game game = new Game();
      game.matchup = "ZVT";
      game.length = "0:23:00";
      game.player1 = 1;
      game.player1_race = 1;
      game.player2 = 2;
      game.player2_race = 2;
      game.winner = 1;
      game.map = 1;

      List<string> errors = new List<string>();
      int gameID = DALGame.InsertGame(game, ref errors);
      game.id = gameID;

      Assert.AreEqual(0, errors.Count);

      Game verifyGame = DALGame.GetGameDetail(game.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(game.matchup, verifyGame.matchup);
      Assert.AreEqual(game.length, verifyGame.length);
      Assert.AreEqual(game.player1, verifyGame.player1);
      Assert.AreEqual(game.player1_race, verifyGame.player1_race);
      Assert.AreEqual(game.player2, verifyGame.player2);
      Assert.AreEqual(game.player2_race, verifyGame.player2_race);

      Game game2 = new Game();
      game2.matchup = "TVP";
      game2.length = "0:44:44";
      game2.player1 = 2;
      game2.player1_race = 2;
      game2.player2 = 3;
      game2.player2_race = 3;
      game2.winner = 2;
      game2.map = 2;
      game2.id = game.id;

      DALGame.UpdateGame(game2, ref errors);

      verifyGame = DALGame.GetGameDetail(game2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(game2.matchup, verifyGame.matchup);
      Assert.AreEqual(game2.length, verifyGame.length);
      Assert.AreEqual(game2.player1, verifyGame.player1);
      Assert.AreEqual(game2.player1_race, verifyGame.player1_race);
      Assert.AreEqual(game2.player2, verifyGame.player2);
      Assert.AreEqual(game2.player2_race, verifyGame.player2_race);

      DALGame.DeleteGame(game.id, ref errors);

      Game verifyEmptyGame = DALGame.GetGameDetail(game.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyGame);

    }
  }
}
