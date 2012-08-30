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
        List<string> errors = new List<string>();

        Race race = new Race();
        race.name = "Protoss";
        race.code = 'P';
        int raceID = DALRace.InsertRace(race, ref errors);
        race.id = raceID;

        Race race2 = new Race();
        race2.name = "Terran";
        race2.code = 'T';
        raceID = DALRace.InsertRace(race2, ref errors);
        race2.id = raceID;

        Race race3 = new Race();
        race3.name = "Zerg";
        race3.code = 'Z';
        raceID = DALRace.InsertRace(race3, ref errors);
        race3.id = raceID;

        League league = new League();
        league.name = "Diamond";
        int leagueID = DALLeague.InsertLeague(league, ref errors);
        league.id = leagueID;

        League league2 = new League();
        league2.name = "Platinum";
        leagueID = DALLeague.InsertLeague(league2, ref errors);
        league2.id = leagueID;

        League league3 = new League();
        league3.name = "Master";
        leagueID = DALLeague.InsertLeague(league3, ref errors);
        league3.id = leagueID;

        Map map = new Map();
        map.name = "Shakuras Plateau";
        map.spawns = 4;
        map.size = "120x100";
        int mapID = DALMap.InsertMap(map, ref errors);
        map.id = mapID;

        Map map2 = new Map();
        map2.name = "Daybreak";
        map2.spawns = 2;
        map2.size = "100x100";
        mapID = DALMap.InsertMap(map, ref errors);
        map2.id = mapID;

        Player player = new Player();
        player.name = "Niter";
        player.code = 777;
        player.race = race3;
        player.league = league2;
        int playerID = DALPlayer.InsertPlayer(player, ref errors);
        player.id = playerID;

        Player player2 = new Player();
        player2.name = "WolfBro";
        player2.code = 123;
        player2.race = race;
        player2.league = league;
        playerID = DALPlayer.InsertPlayer(player2, ref errors);
        player2.id = playerID;

        Player player3 = new Player();
        player3.name = "Corone";
        player3.code = 123;
        player3.race = race2;
        player3.league = league3;
        playerID = DALPlayer.InsertPlayer(player3, ref errors);
        player3.id = playerID;

        Game game = new Game();
        game.matchup = "ZVT";
        game.length = "0:23:00";
        game.player1 = player;
        game.player1_race = player.race;
        game.player2 = player2;
        game.player2_race = player2.race;
        game.winner = game.player1;
        game.map = new Map();
        game.map.id = 1;
        int gameID = DALGame.InsertGame(game, ref errors);
        game.id = gameID;


        Statistic statistic = new Statistic();
        statistic.player = game.player1;
        statistic.game = game;
        statistic.apm = 0;
        statistic.resources = 0;
        statistic.units = 0;
        statistic.structures = 0;

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
      statistic2.player = game.player2;
      statistic2.game = game;
      statistic2.apm = 1;
      statistic2.resources = 1;
      statistic2.units = 1;
      statistic2.structures = 1;
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

