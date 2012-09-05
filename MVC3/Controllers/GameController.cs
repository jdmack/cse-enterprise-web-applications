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
        GameList games = new GameList();

        public ActionResult Index()
        {
            List<GameInfo> myGames = games.GetGameList();
            return View("Index",myGames);
        }

        public ActionResult Details(int id)
        {
            GameInfo g = games.GetGameDetail(id);
            return View("Details", g);
        }
    }
}
