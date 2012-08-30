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
        race.name = "race_name";
        race.code = 'R';

      List<string> errors = new List<string>();
      int raceID = DALRace.InsertRace(race, ref errors);
      race.id = raceID;

      Assert.AreEqual(0, errors.Count);

      Race verifyRace = DALRace.GetRaceDetail(race.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(race.id, verifyRace.id);
      Assert.AreEqual(race.name, verifyRace.name);
      Assert.AreEqual(race.code, verifyRace.code);

      Race race2 = new Race();
      race2.name = "race_name2";
      race2.code = '2';
      race2.id = race.id;

      DALRace.UpdateRace(race2, ref errors);

      verifyRace = DALRace.GetRaceDetail(race2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(race2.id, verifyRace.id);
      Assert.AreEqual(race2.name, verifyRace.name);
      Assert.AreEqual(race2.code, verifyRace.code);

      DALRace.DeleteRace(race.id, ref errors);

      Race verifyEmptyRace = DALRace.GetRaceDetail(race.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyRace);

    }
  }
}

