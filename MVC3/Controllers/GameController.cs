using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/
        //GameList games = new GameList();

        public ActionResult Index()
        {
            List<PLGame> myGames = GameClientService.GetGameList();
            ViewData["breadCrumData"] = "Game List";
            return View("Index",myGames);
        }
        
        public ActionResult Details(int id)
        {
            PLGame g = GameClientService.GetGameDetail(id);
            return View("Details", g);
        }
         
        public ActionResult Create()
        {
            if (HttpContext != null)
            {
                UrlHelper url = new UrlHelper(HttpContext.Request.RequestContext);
                ViewBag.breadCrumbData = "<a href='" + url.Action("Index", "Game") + "'Game List</a>";
                ViewBag.breadCrumbData += " > Create";
            }
            PLGame game = new PLGame();
            return View("Create", game);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                PLGame game = new PLGame();
                game.id = -1;
                //PLGame.gameName = collection["gameName"];
                game.player1Name = collection["player1Name"];
                game.player1Race = collection["player1Race"];
                game.player1Code = collection["player1Code"];
                game.player1RaceCode = collection["player1RaceCode"];
                game.player1League = collection["player1League"];
                game.player2Name = collection["player2Name"];
                game.player2Race = collection["player2Race"];
                game.player2RaceCode = collection["player1RaceCode"];
                game.player2Code = collection["player2Code"];
                game.player2League = collection["player2League"];
                game.matchup = collection["matchup"];
                game.length = collection["length"];
                game.time = collection["time"];
                game.winnerName = collection["winnerName"];
                //game.downloadCount =collection["downloadCount"];
                game.map = collection["map"];
                game.spawns = collection["spawns"];
                game.size = collection["size"];

                GameClientService.CreateGame(game);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View();
            }
        }
    }
}
