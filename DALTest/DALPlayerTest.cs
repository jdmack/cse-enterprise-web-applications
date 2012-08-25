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
      Player player = new Player();
      player.name = "Niter";
      player.code = 777;
      player.race = 1;
      player.league = 1;

      List<string> errors = new List<string>();
      int playerID = DALPlayer.InsertPlayer(player, ref errors);
      player.id = playerID;

      Assert.AreEqual(0, errors.Count);

      Player verifyPlayer = DALPlayer.GetPlayerDetail(player.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(player.name, verifyPlayer.name);
      Assert.AreEqual(player.code, verifyPlayer.code);
      Assert.AreEqual(player.race, verifyPlayer.race);
      Assert.AreEqual(player.league, verifyPlayer.league);

      Player player2 = new Player();
      player2.name = "WolfBro";
      player2.code = 123;
      player2.race = 2;
      player2.league = 1;
      player2.id = player.id;

      DALPlayer.UpdatePlayer(player2, ref errors);

      verifyPlayer = DALPlayer.GetPlayerDetail(player2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(player2.name, verifyPlayer.name);
      Assert.AreEqual(player2.code, verifyPlayer.code);
      Assert.AreEqual(player2.race, verifyPlayer.race);
      Assert.AreEqual(player2.league, verifyPlayer.league);

      DALPlayer.DeletePlayer(player.id, ref errors);

      Player verifyEmptyPlayer = DALPlayer.GetPlayerDetail(player.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyPlayer);

    }
  }
}
