using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DragonDustWeb.Controllers
{
    public class GameCodeController : Controller
    {
        // GET: GameCode
        public ActionResult Index()
        {
            return View("GameSelection");
        }
    }
}