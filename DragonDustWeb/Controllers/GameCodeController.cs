using DragonDustWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DragonDustWeb.Controllers
{
    public class GameCodeController : Controller
    {
        ApplicationDbContext dbContext;
        public GameCodeController()
        {
            dbContext = new ApplicationDbContext();
        }

        // GET: GameCode
        public ActionResult Index()
        {
            return View("GameSelection");
        }

        public ActionResult GetCode(int gameId)
        {
            var game = dbContext.Games.SingleOrDefault(g => g.Id == gameId);
            if(game == null)
                return new HttpNotFoundResult();

            if(!CodeAvailable(game))
                return View("CodeUnavailable");

            return View("EmailRequest");
        }

        bool CodeAvailable(Game game)
        {
            return dbContext.GameCodes.Any(c =>
                c.GameId == game.Id
                && c.Used == false
                && c.ExpirationDate > DateTime.Now
            );
        }
    }
}