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
            Assert.AreEqual(1, errors.Count);
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
            Game game = new Game();
            game.matchup = "PvZ";
            game.time = new DateTime(2012, 8, 28, 11, 59, 59);
            game.length = "12:12";
            game.player1 = 1;
            game.player1_race = 1;
            game.player2 = 2;
            game.player2_race = 2;
            game.winner = 1;
            game.map = 1;

            List<string> errors = new List<string>();
            BLGame.InsertGame(game, ref errors);

            Assert.AreEqual(0, errors.Count);

            Game verifyGame = BLGame.GetGame(game.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(game.matchup, verifyGame.matchup);
            Assert.AreEqual(game.time, verifyGame.time);
            Assert.AreEqual(game.length, verifyGame.length);
            Assert.AreEqual(game.player1, verifyGame.player1);
            Assert.AreEqual(game.player1_race, verifyGame.player1_race);
            Assert.AreEqual(game.player2, verifyGame.player2);
            Assert.AreEqual(game.player2_race, verifyGame.player2_race);
            Assert.AreEqual(game.winner, verifyGame.winner);
            Assert.AreEqual(game.map, verifyGame.map);

            BLGame.DeleteGame(game.id, ref errors);

            Game verifyEmptyGame = BLGame.GetGame(game.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyGame);

        }

    }
}
