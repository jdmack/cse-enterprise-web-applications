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
    public class BLMapTest
    {
        public BLMapTest()
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
        public void InsertMapErrorTest()
        {
            List<string> errors = new List<string>();

            BLMap.InsertMap(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Map map = new Map();
            BLMap.InsertMap(map, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void MapErrorTest()
        {
            List<string> errors = new List<string>();

            BLMap.GetMap(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteMapErrorTest()
        {
            List<string> errors = new List<string>();

            BLMap.DeleteMap(-1, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void MapInsertAndSelectTest()
        {
            Map map = new Map(1,"test",2,"10x10");
   
            List<string> errors = new List<string>();
            BLMap.InsertMap(map, ref errors);

            Assert.AreEqual(0, errors.Count);

            Map verifyMap = BLMap.GetMap(map.getId(), ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(map.getName(), verifyMap.getName());
            Assert.AreEqual(map.getSpawns(), verifyMap.getSpawns());
            Assert.AreEqual(map.getSize(), verifyMap.getSize());

            BLMap.DeleteMap(map.getId(), ref errors);

            Map verifyEmptyMap = BLMap.GetMap(map.getId(), ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyMap);

        }

    }
}
