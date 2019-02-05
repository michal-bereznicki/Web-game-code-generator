using DragonDustWeb.Models;
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
        ApplicationDbContext dbContext;
        public GamesController()
        {
            dbContext = new ApplicationDbContext();
        }

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
                Description = "Explore the labyrinth and find the forgotten treasure.",
                GooglePlayLink = dbContext.Games.Single(g => g.Id == Game.AncientTombAdventureId).GooglePlayPageLink,
                ContentFolderName = "AncientTombAdventure"
            };
            return View("GameDisplay",viewModel);
        }

        public ActionResult KidsMusicComposer()
        {
            var viewModel = new GameDisplayViewModel
            {
                TitleOneliner = "Have fun playing realistic music instruments!",
                Description = "Compose and save your own songs.",
                GooglePlayLink = dbContext.Games.Single(g => g.Id == Game.KidsMusicComposerId).GooglePlayPageLink,
                ContentFolderName = "KidsMusicComposer"
            };
            return View("GameDisplay", viewModel);
        }
    }
}