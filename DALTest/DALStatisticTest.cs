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
        statistic.setPlayer(0);
        statistic.setGame(0);
        statistic.setAPM(0);
        statistic.setResources(0);
        statistic.setUnits(0);
        statistic.setStructures(0);

      List<string> errors = new List<string>();
      var statisticID = DALStatistic.InsertStatistic(statistic, ref errors);
      statistic.setId(statisticID);

      Assert.AreEqual(0, errors.Count);

      Statistic verifyStatistic = DALStatistic.GetStatisticDetail(statistic.getId(), ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(statistic.getId(), verifyStatistic.getId());
      Assert.AreEqual(statistic.getPlayer(), verifyStatistic.getPlayer());
      Assert.AreEqual(statistic.getGame(), verifyStatistic.getGame());
      Assert.AreEqual(statistic.getAPM(), verifyStatistic.getAPM());
      Assert.AreEqual(statistic.getResources(), verifyStatistic.getResources());
      Assert.AreEqual(statistic.getUnits(), verifyStatistic.getUnits());
      Assert.AreEqual(statistic.getStructures(), verifyStatistic.getStructures());

      Statistic statistic2 = new Statistic();
        statistic2.setPlayer(1);
        statistic2.setGame(1);
        statistic2.setAPM(1);
        statistic2.setResources(1);
        statistic2.setUnits(1);
        statistic2.setStructures(1);
        statistic2.setId(statistic.getId()); // use the existing student ID 

      DALStatistic.UpdateStatistic(statistic2, ref errors);

      verifyStatistic = DALStatistic.GetStatisticDetail(statistic2.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(statistic2.getId(), verifyStatistic.getId());
      Assert.AreEqual(statistic2.getPlayer(), verifyStatistic.getPlayer());
      Assert.AreEqual(statistic2.getGame(), verifyStatistic.getGame());
      Assert.AreEqual(statistic2.getAPM(), verifyStatistic.getAPM());
      Assert.AreEqual(statistic2.getResources(), verifyStatistic.getResources());
      Assert.AreEqual(statistic2.getUnits(), verifyStatistic.getUnits());
      Assert.AreEqual(statistic2.getStructures(), verifyStatistic.getStructures());

      DALStatistic.DeleteStatistic(statistic.getId(), ref errors);

      Statistic verifyEmptyStatistic = DALStatistic.GetStatisticDetail(statistic.getId(), ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyStatistic);

    }
  }
}

