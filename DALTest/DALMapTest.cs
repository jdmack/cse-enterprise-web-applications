using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DomainModel;

namespace DALTest
{
  [TestClass]
  public class DALMapTest
  {
    public DALMapTest()
    {
    }

    private TestContext testContextInstance;

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

    [TestMethod]
    public void InsertMapTest()
    {
        Map map = new Map();
         
        map.name = "map_name";
        map.spawns = 0;
        map.size = "0x0";
         
      List<string> errors = new List<string>();
      int mapID = DALMap.InsertMap(map, ref errors);
      map.id = mapID;

      Assert.AreEqual(0, errors.Count);

      Map verifyMap = DALMap.GetMapDetail(map.id, ref errors);

      Assert.AreEqual(0, errors.Count);
   
      Assert.AreEqual(map.name, verifyMap.name);
      Assert.AreEqual(map.spawns, verifyMap.spawns);
      Assert.AreEqual(map.size, verifyMap.size);

      Map map2 = new Map();
        map2.name = "map_name2";
        map2.spawns = 1;
        map2.size = "1x1";
        map2.id = map.id; // use the existing student ID 

      DALMap.UpdateMap(map2, ref errors);

      verifyMap = DALMap.GetMapDetail(map2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(map2.id, verifyMap.id);
      Assert.AreEqual(map2.name, verifyMap.name);
      Assert.AreEqual(map2.spawns, verifyMap.spawns);
      Assert.AreEqual(map2.size, verifyMap.size);

      DALMap.DeleteMap(map.id, ref errors);

      Map verifyEmptyMap = DALMap.GetMapDetail(map.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyMap);

    }
  }
}

