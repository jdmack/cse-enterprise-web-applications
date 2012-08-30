﻿using System;
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
    public class BLStatisticTest
    {
        public BLStatisticTest()
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
        public void InsertStatisticErrorTest()
        {
            List<string> errors = new List<string>();

            BLStatistic.InsertStatistic(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Statistic statistic = new Statistic();
            BLStatistic.InsertStatistic(statistic, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void StatisticErrorTest()
        {
            List<string> errors = new List<string>();

            BLStatistic.GetStatistic(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteStatisticErrorTest()
        {
            List<string> errors = new List<string>();

            BLStatistic.DeleteStatistic(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void StatisticInsertAndSelectTest()
        {
            Statistic statistic = new Statistic();
            statistic.id = 1;
            statistic.player = 2;
            statistic.game = 3;
            statistic.apm = 100;
            statistic.resources = 2000;
            statistic.units = 150;
            statistic.structures = 1000;

        
            List<string> errors = new List<string>();
            BLStatistic.InsertStatistic(statistic, ref errors);

            Assert.AreEqual(0, errors.Count);

            Statistic verifyStatistic = BLStatistic.GetStatistic(statistic.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(statistic.player, verifyStatistic.player);
            Assert.AreEqual(statistic.game, verifyStatistic.game);
            Assert.AreEqual(statistic.apm, verifyStatistic.apm);
            Assert.AreEqual(statistic.resources, verifyStatistic.resources);
            Assert.AreEqual(statistic.units, verifyStatistic.units);
            Assert.AreEqual(statistic.structures, verifyStatistic.structures);

            BLStatistic.DeleteStatistic(statistic.id, ref errors);

            Statistic verifyEmptyStatistic = BLStatistic.GetStatistic(statistic.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStatistic);

        }

    }
}
