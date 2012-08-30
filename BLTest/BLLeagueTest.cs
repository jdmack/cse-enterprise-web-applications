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
    public class BLLeagueTest
    {
        public BLLeagueTest()
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
        public void InsertLeagueErrorTest()
        {
            List<string> errors = new List<string>();

            BLLeague.InsertLeague(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            League league = new League();
            league.id = -1;
            BLLeague.InsertLeague(league, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void LeagueErrorTest()
        {
            List<string> errors = new List<string>();

            BLLeague.GetLeague(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteLeagueErrorTest()
        {
            List<string> errors = new List<string>();

            BLLeague.DeleteLeague(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void LeagueInsertAndSelectTest()
        {
            League league = new League();
            league.name = "Master";

            List<string> errors = new List<string>();
            BLLeague.InsertLeague(league, ref errors);

            Assert.AreEqual(0, errors.Count);

            League verifyLeague = BLLeague.GetLeague(league.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(league.name, verifyLeague.name);

            BLLeague.DeleteLeague(league.id, ref errors);

            League verifyEmptyLeague = BLLeague.GetLeague(league.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyLeague);

        }

    }
}
