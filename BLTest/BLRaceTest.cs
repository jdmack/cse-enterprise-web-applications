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
    public class BLRaceTest
    {
        public BLRaceTest()
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
        public void InsertRaceErrorTest()
        {
            List<string> errors = new List<string>();

            BLRace.InsertRace(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Race race = new Race();
            BLRace.InsertRace(race, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void RaceErrorTest()
        {
            List<string> errors = new List<string>();

            BLRace.GetRace(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteRaceErrorTest()
        {
            List<string> errors = new List<string>();

            BLRace.DeleteRace(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void RaceInsertAndSelectTest()
        {
            Race race = new Race();
            race.name = "raceTest";
            race.code = 'R';

            List<string> errors = new List<string>();
            race.id = BLRace.InsertRace(race, ref errors);

            Assert.AreEqual(0, errors.Count);

            Race verifyRace = BLRace.GetRace(race.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(race.name, verifyRace.name);
            Assert.AreEqual(race.code, verifyRace.code);

            BLRace.DeleteRace(race.id, ref errors);

            Race verifyEmptyRace = BLRace.GetRace(race.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyRace);

        }

    }
}
