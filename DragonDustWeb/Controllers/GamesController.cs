using DragonDustWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DragonDustWeb.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AncientTombAdventure()
        {
            var viewModel = new GameDisplayViewModel
            {
                TitleOneliner = "Solve unique riddles in Ancient Tomb!",
                Description = "sad",
                GooglePlayLink = "https://play.google.com/store/apps/details?id=com.DragonDustGames.labyrinth.adventure.puzzle.riddle.ancient.tomb"
            };
            return View("GameDisplay",viewModel);
        }

        public ActionResult KidsMusicComposer()
        {
            var viewModel = new GameDisplayViewModel
            {
                TitleOneliner = "Have fun playing realistic music instruments!",
                Description = "opis 2",
                GooglePlayLink = "https://play.google.com/store/apps/details?id=com.dragondustgames.kids.music.learn.composer.KidsMusicComposerFunLearn"
            };
            return View("GameDisplay", viewModel);
        }
    }
}