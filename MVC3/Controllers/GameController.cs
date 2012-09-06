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
        /*
        public ActionResult Details(int id)
        {
            GameInfo g = GameClientService.GetGameDetail(id);
            return View("Details", g);
        }
         */
    }
}
