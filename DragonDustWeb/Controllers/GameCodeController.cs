﻿using DragonDustWeb.Models;
using DragonDustWeb.ViewModels;
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

        public ActionResult RequestCode(int gameId)
        {
            var game = dbContext.Games.SingleOrDefault(g => g.Id == gameId);
            if(game == null)
                return new HttpNotFoundResult();

            /*var code = GetCode(game);
            if(code == null)
                return View("CodeUnavailable");
                */
            var viewModel = new EmailViewModel
            {
                RequestedGameId = gameId
            };

            return View("EmailRequest", viewModel);
        }

        [HttpPost]
        public ActionResult SubmitEmail(EmailViewModel model)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var game = dbContext.Games.SingleOrDefault(g => g.Id == model.RequestedGameId);
            if(game == null)
                return new HttpNotFoundResult();

            var code = GetCode(game);
            /*if(code == null)
                return View("CodeUnavailable");
                */

            //EmailSender.SendGameCode(model.Email, code.Code);
            EmailSender.SendGameCode(model.Email, "kod123");

            return View("EmailSentConfirmation");
        }

        GameCode GetCode(Game game)
        {
            return dbContext.GameCodes.FirstOrDefault(c =>
                c.GameId == game.Id
                && c.Used == false
                && c.ExpirationDate > DateTime.Now
            );
        }
    }
}