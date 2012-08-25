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
  public class DALRaceTest
  {
    public DALRaceTest()
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
    public void InsertRaceTest()
    {
        Race race = new Race();
        race.setName("race_name");
        race.setCode('R');

      List<string> errors = new List<string>();
      int raceID = DALRace.InsertRace(race, ref errors);
      race.setId(raceID);

      Assert.AreEqual(0, errors.Count);

      Race verifyRace = DALRace.GetRaceDetail(race.getId(), ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(race.getId(), verifyRace.getId());
      Assert.AreEqual(race.getName(), verifyRace.getName());
      Assert.AreEqual(race.getCode(), verifyRace.getCode());

      Race race2 = new Race();
      race2.setName("race_name2");
      race2.setCode('2');
      race2.setId(race.getId()); // use the existing student ID 

      DALRace.UpdateRace(race2, ref errors);

      verifyRace = DALRace.GetRaceDetail(race2.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(race2.getId(), verifyRace.getId());
      Assert.AreEqual(race2.getName(), verifyRace.getName());
      Assert.AreEqual(race2.getCode(), verifyRace.getCode());

      DALRace.DeleteRace(race.getId(), ref errors);

      Race verifyEmptyRace = DALRace.GetRaceDetail(race.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyRace);

    }
  }
}

