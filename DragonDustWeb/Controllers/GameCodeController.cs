using DragonDustWeb.Models;
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

            var code = GetCode(game);
            if(code == null)
                return View("CodeUnavailable");
                
            var viewModel = new EmailViewModel
            {
                RequestedGameId = gameId
            };

            return View("EmailRequest", viewModel);
        }

        public ActionResult Upload()
        {
            var viewModel = new CodesUploadViewModel
            {
                GameIds = dbContext.Games.Select(g => g.Id).ToList(),
                GameNames = dbContext.Games.Select(g => g.Name).ToList()
            };

            return View("CodeUpload", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadCodes(CodesUploadViewModel model)
        {
            //TODO
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEmail(EmailViewModel model)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var game = dbContext.Games.SingleOrDefault(g => g.Id == model.RequestedGameId);
            if(game == null)
                return new HttpNotFoundResult();

            var code = GetCode(game);
            if(code == null)
                return View("CodeUnavailable");

            var user = dbContext.Users.SingleOrDefault(u => u.Email.Equals(model.Email));
            if(user == null)
            {
                user = new User
                {
                    Email = model.Email
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            else if(dbContext.Orders.Any(o => o.UserId == user.Id && o.GameId == game.Id))
                return GetFeedbackView("Game code was already sent to this email adress.", FeedbackMessageType.Error);

            EmailSender.SendGameCode(model.Email, "testGameCode");

            var order = new Order
            {
                UserId = user.Id,
                GameId = game.Id,
                OrderTypeId = OrderType.FreePromoCodeByEmailId
            };

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            return GetFeedbackView("Email sent successfully!", FeedbackMessageType.Confirmation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEmailNoOrder(EmailViewModel model)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var user = dbContext.Users.SingleOrDefault(u => u.Email.Equals(model.Email));
            if(user == null)
            {
                user = new User
                {
                    Email = model.Email
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            return GetFeedbackView("Email submitted successfully. Thank you!", FeedbackMessageType.Confirmation);
        }

        GameCode GetCode(Game game)
        {
            return dbContext.GameCodes.FirstOrDefault(c =>
                c.GameId == game.Id
                && c.Used == false
                && c.ExpirationDate > DateTime.Now
            );
        }

        ViewResult GetFeedbackView(string msg, FeedbackMessageType messageType)
        {
            var viewModel = new FeedbackMessageViewModel
            {
                Message = msg,
                MessageType = messageType
            };
            return View("FeedbackMessage", viewModel);
        }
    }
}