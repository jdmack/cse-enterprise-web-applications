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
         
        map.setName("map_name");
        map.setSpawns(0);
        map.setSize("0x0");
         
      List<string> errors = new List<string>();
      int mapID = DALMap.InsertMap(map, ref errors);
      map.setId(mapID);

      Assert.AreEqual(0, errors.Count);

      Map verifyMap = DALMap.GetMapDetail(map.getId(), ref errors);

      Assert.AreEqual(0, errors.Count);
   
      Assert.AreEqual(map.getName(), verifyMap.getName());
      Assert.AreEqual(map.getSpawns(), verifyMap.getSpawns());
      Assert.AreEqual(map.getSize(), verifyMap.getSize());

      Map map2 = new Map();
        map2.setName("map_name2");
        map2.setSpawns(1);
        map2.setSize("1x1");
        map2.setId(map.getId()); // use the existing student ID 

      DALMap.UpdateMap(map2, ref errors);

      verifyMap = DALMap.GetMapDetail(map2.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(map2.getId(), verifyMap.getId());
      Assert.AreEqual(map2.getName(), verifyMap.getName());
      Assert.AreEqual(map2.getSpawns(), verifyMap.getSpawns());
      Assert.AreEqual(map2.getSize(), verifyMap.getSize());

      DALMap.DeleteMap(map.getId(), ref errors);

      Map verifyEmptyMap = DALMap.GetMapDetail(map.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyMap);

    }
  }
}

