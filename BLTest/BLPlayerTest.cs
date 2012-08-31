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
    public class BLPlayerTest
    {
        public BLPlayerTest()
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
        public void InsertPlayerErrorTest()
        {
            List<string> errors = new List<string>();

            BLPlayer.InsertPlayer(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Player player = new Player();
            player.id = -1;
            BLPlayer.InsertPlayer(player, ref errors);
            Assert.AreNotEqual(0, errors.Count);
        }

        [TestMethod]
        public void PlayerErrorTest()
        {
            List<string> errors = new List<string>();

            BLPlayer.GetPlayer(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeletePlayerErrorTest()
        {
            List<string> errors = new List<string>();

            BLPlayer.DeletePlayer(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void PlayerInsertAndSelectTest()
        {
            Player player = new Player();
            player.name = "Niter";
            player.code = 777;
            player.race = new Race();
                player.race.id = 3;
                player.race.name = "Zerg";
                player.race.code = 'Z';
            player.league = new League();
                player.league.id = 3;
                player.league.name = "Platinum";

            List<string> errors = new List<string>();
            player.id = BLPlayer.InsertPlayer(player, ref errors);

            Assert.AreEqual(0, errors.Count);

            Player verifyPlayer = BLPlayer.GetPlayer(player.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(player.name, verifyPlayer.name);
            Assert.AreEqual(player.code, verifyPlayer.code);
            Assert.AreEqual(player.race.id, verifyPlayer.race.id);
            Assert.AreEqual(player.league.id, verifyPlayer.league.id);

            BLPlayer.DeletePlayer(player.id, ref errors);

            Player verifyEmptyPlayer = BLPlayer.GetPlayer(player.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyPlayer);

        }

    }
}
