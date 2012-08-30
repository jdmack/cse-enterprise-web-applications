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
            game.player1 = new Player();
            game.player1.id = 1;
            game.player1_race = new Race();
            game.player1_race.id = 1;
            game.player2 = new Player();
            game.player2.id = 2;
            game.player2_race = new Race();
            game.player2_race.id = 2;
            game.winner = game.player1;
            game.map = new Map();
            game.map.id = 1;

            List<string> errors = new List<string>();
            BLGame.InsertGame(game, ref errors);

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
