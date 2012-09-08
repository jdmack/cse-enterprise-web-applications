using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVC3;
using MVC3.Controllers;
using MVC3.Models;

/// ==============================================================================
/// NOTE FROM THE PROFESSOR:
/// Be sure to add the service reference in the MVC3.Tests project.  
/// Otherwise, the controller tests will fail.
/// Right-click on your MVC3.Tests project and select "Add Service Reference".
/// Then, copy the entire <system.serviceModel> section from web.config and paste 
/// into the app.config.
/// ==============================================================================

namespace MVC3.Tests.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void CreateGameTest()
        {
            GameController controller = new GameController();

            // simulate web form posting data
            FormCollection createFormValues = new FormCollection();

            string gameID = "15";
            createFormValues.Add("id", gameID);
            createFormValues.Add("player1Name", "TestPlayer1");
            createFormValues.Add("player1Race", "TestPlayer1Race");
            createFormValues.Add("player1Code", "222");
            createFormValues.Add("player1RaceCode", "T");
            createFormValues.Add("player1League", "TestLeague1");
            createFormValues.Add("player2Name", "TestPlayer2");
            createFormValues.Add("player2Race", "TestPlayer2Race");
            createFormValues.Add("player2RaceCode", "Z");
            createFormValues.Add("player2Code", "333");
            createFormValues.Add("player2League", "TestLeague2");
            createFormValues.Add("matchup", "TvZ");
            createFormValues.Add("length", "00:15:00");
            createFormValues.Add("time", "9/9/2012 2:58:00 AM");
            createFormValues.Add("winnerName", "TestPlayer2");
            createFormValues.Add("map", "TestMap");
            createFormValues.Add("spawns", "4");
            createFormValues.Add("size", "100x100");

            /*
            createFormValues.Add("player1_id", "10");
            createFormValues.Add("player1_race_id", "10");
            createFormValues.Add("player1_league_id", "10");
            createFormValues.Add("player2_id", "11");
            createFormValues.Add("player2_race_id", "11");
            createFormValues.Add("player2_league_id", "11");
            createFormValues.Add("map_id", "11");
            */
             
            // Call the form submission to create a new game
            RedirectToRouteResult result = controller.Create(createFormValues) as RedirectToRouteResult;

            // Verify the redirection
            string action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);

            // let's take a look a the edit page's info for this student ID just created
            ViewResult editViewResult = (ViewResult)controller.Edit(gameID);

            // verify we are preloading the data correctly in the edit view 
            MVC3.Models.PLGame model = (MVC3.Models.PLGame)editViewResult.ViewData.Model;
            Assert.AreEqual(gameID, model.id);
            Assert.AreEqual("TestPlayer1", model.player1Name);
            Assert.AreEqual("TestPlayer1Race", model.player1Race);
            Assert.AreEqual("222", model.player1Code);
            Assert.AreEqual("T", model.player1RaceCode);
            Assert.AreEqual("TestLeague1", model.player1League);
            Assert.AreEqual("TestPlayer2", model.player1Name);
            Assert.AreEqual("TestPlayer2Race", model.player2Race);
            Assert.AreEqual("Z", model.player2RaceCode);
            Assert.AreEqual("333", model.player2Code);
            Assert.AreEqual("TestLeague2", model.player2League);
            Assert.AreEqual("TvZ", model.matchup);
            Assert.AreEqual("00:15:00", model.length);
            Assert.AreEqual("9/9/2012 2:58:00 AM", model.time);
            Assert.AreEqual("TestPlayer2", model.winnerName);
            Assert.AreEqual("TestMap", model.map);
            Assert.AreEqual("4", model.spawns);
            Assert.AreEqual("100x100", model.size);
            /*
            Assert.AreEqual("10", model.player1_id);
            Assert.AreEqual("10", model.player1_race_id);
            Assert.AreEqual("10", model.player1_league_id);
            Assert.AreEqual("11", model.player2_id);
            Assert.AreEqual("11", model.player2_race_id);
            Assert.AreEqual("11", model.player2_league_id);
            Assert.AreEqual("11", model.map_id);
            */
            // let's test the editing of this student
            FormCollection editFormValues = new FormCollection();

            result = controller.Edit(gameID, editFormValues) as RedirectToRouteResult;

            editFormValues.Add("id", gameID);
            editFormValues.Add("player1Name", "TestPlayer1b");
            editFormValues.Add("player1Race", "TestPlayer1Raceb");
            editFormValues.Add("player1Code", "2224");
            editFormValues.Add("player1RaceCode", "B");
            editFormValues.Add("player1League", "TestLeague1b");
            editFormValues.Add("player2Name", "TestPlayer2b");
            editFormValues.Add("player2Race", "TestPlayer2Raceb");
            editFormValues.Add("player2RaceCode", "B");
            editFormValues.Add("player2Code", "3332");
            editFormValues.Add("player2League", "TestLeague2b");
            editFormValues.Add("matchup", "BvB");
            editFormValues.Add("length", "00:15:59");
            editFormValues.Add("time", "9/9/2012 2:58:59 AM");
            editFormValues.Add("winnerName", "TestPlayer2b");
            editFormValues.Add("map", "TestMapb");
            editFormValues.Add("spawns", "5");
            editFormValues.Add("size", "100x101");

            /*
            editFormValues.Add("player1_id", "10");
            editFormValues.Add("player1_race_id", "10");
            editFormValues.Add("player1_league_id", "10");
            editFormValues.Add("player2_id", "11");
            editFormValues.Add("player2_race_id", "11");
            editFormValues.Add("player2_league_id", "11");
            editFormValues.Add("map_id", "11");
            */

            // Verify the redirection is back to index page
            action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);

            // let's verify the edit is successful by looking at the detail view page
            ViewResult detailViewResult = (ViewResult)controller.Details(Convert.ToInt32(gameID));

            // verify we are preloading the data correctly in the edit view 
            model = (MVC3.Models.PLGame)detailViewResult.ViewData.Model;

            Assert.AreEqual(gameID, model.id);
            Assert.AreEqual("TestPlayer1b", model.player1Name);
            Assert.AreEqual("TestPlayer1Raceb", model.player1Race);
            Assert.AreEqual("2224", model.player1Code);
            Assert.AreEqual("B", model.player1RaceCode);
            Assert.AreEqual("TestLeague1b", model.player1League);
            Assert.AreEqual("TestPlayer2b", model.player1Name);
            Assert.AreEqual("TestPlayer2Raceb", model.player2Race);
            Assert.AreEqual("B", model.player2RaceCode);
            Assert.AreEqual("3332", model.player2Code);
            Assert.AreEqual("TestLeague2b", model.player2League);
            Assert.AreEqual("BvB", model.matchup);
            Assert.AreEqual("00:15:59", model.length);
            Assert.AreEqual("9/9/2012 2:58:59 AM", model.time);
            Assert.AreEqual("TestPlayer2b", model.winnerName);
            Assert.AreEqual("TestMapb", model.map);
            Assert.AreEqual("5", model.spawns);
            Assert.AreEqual("100x101", model.size);
            /*
            Assert.AreEqual("10", model.player1_id);
            Assert.AreEqual("10", model.player1_race_id);
            Assert.AreEqual("10", model.player1_league_id);
            Assert.AreEqual("11", model.player2_id);
            Assert.AreEqual("11", model.player2_race_id);
            Assert.AreEqual("11", model.player2_league_id);
            Assert.AreEqual("11", model.map_id);
            */

            // now, delete the student we just created
            result = controller.Delete(gameID) as RedirectToRouteResult;
            action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);
        }
    }
}
