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
  public class DALLeagueTest
  {
    public DALLeagueTest()
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
    ///A test for InsertLeague
    ///</summary>
    [TestMethod]
    public void InsertLeagueTest()
    {
      League league = new League();
      league.name = "Ownage";

      List<string> errors = new List<string>();
      int leagueID = DALLeague.InsertLeague(league, ref errors);
      league.id = leagueID;

      Assert.AreEqual(0, errors.Count);

      League verifyLeague = DALLeague.GetLeagueDetail(league.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(league.name, verifyLeague.name);

      League league2 = new League();
      league2.name = "Wolfs";
      league2.id = league.id;

      DALLeague.UpdateLeague(league2, ref errors);

      verifyLeague = DALLeague.GetLeagueDetail(league2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(league2.name, verifyLeague.name);

      DALLeague.DeleteLeague(league.id, ref errors);

      League verifyEmptyLeague = DALLeague.GetLeagueDetail(league.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyLeague);

    }
  }
}
