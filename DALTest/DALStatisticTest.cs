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
  public class DALStatisticTest
  {
    public DALStatisticTest()
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
    public void InsertStatisticTest()
    {
        Statistic statistic = new Statistic();
        statistic.player = new Player();
        statistic.player.id = 0;
        statistic.game = new Game();
        statistic.game.id = 0;
        statistic.apm = 0;
        statistic.resources = 0;
        statistic.units = 0;
        statistic.structures = 0;

      List<string> errors = new List<string>();
      var statisticID = DALStatistic.InsertStatistic(statistic, ref errors);
      statistic.id = statisticID;

      Assert.AreEqual(0, errors.Count);

      Statistic verifyStatistic = DALStatistic.GetStatisticDetail(statistic.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(statistic.id, verifyStatistic.id);
      Assert.AreEqual(statistic.player.id, verifyStatistic.player.id);
      Assert.AreEqual(statistic.game.id, verifyStatistic.game.id);
      Assert.AreEqual(statistic.apm, verifyStatistic.apm);
      Assert.AreEqual(statistic.resources, verifyStatistic.resources);
      Assert.AreEqual(statistic.units, verifyStatistic.units);
      Assert.AreEqual(statistic.structures, verifyStatistic.structures);

      Statistic statistic2 = new Statistic();
      statistic.player = new Player();
      statistic.player.id = 1;
      statistic.game = new Game();
      statistic.game.id = 1;
      statistic.apm = 1;
      statistic.resources = 1;
      statistic.units = 1;
      statistic.structures = 1;
      statistic2.id = statistic.id;

      DALStatistic.UpdateStatistic(statistic2, ref errors);

      verifyStatistic = DALStatistic.GetStatisticDetail(statistic2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(statistic2.id, verifyStatistic.id);
      Assert.AreEqual(statistic2.player.id, verifyStatistic.player.id);
      Assert.AreEqual(statistic2.game.id, verifyStatistic.game.id);
      Assert.AreEqual(statistic2.apm, verifyStatistic.apm);
      Assert.AreEqual(statistic2.resources, verifyStatistic.resources);
      Assert.AreEqual(statistic2.units, verifyStatistic.units);
      Assert.AreEqual(statistic2.structures, verifyStatistic.structures);

      DALStatistic.DeleteStatistic(statistic.id, ref errors);

      Statistic verifyEmptyStatistic = DALStatistic.GetStatisticDetail(statistic.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyStatistic);

    }
  }
}

