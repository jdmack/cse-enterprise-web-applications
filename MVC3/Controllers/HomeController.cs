using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            List<PLGame> popgames = GameClientService.GetPopularGameList();
            ViewBag.popgame = popgames;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
