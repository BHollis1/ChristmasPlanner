using ChristmasPlanner.Models;
using ChristmasPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChristmasPlanner.WebMVC.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CardServices(userID);
            var model = service.GetCards();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCardService();

            if (service.CreateCard(model))
            {
                TempData["SaveResult"] = "Card was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New Card could not be created.");

            return View(model);
        }

        private CardServices CreateCardService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CardServices(userID);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCardService();
            var detail = service.GetCardByID(id);
            var model =
                new CardEdit
                {
                    CardID = detail.CardID,
                    SentCard = detail.SentCard,
                    PersonID = detail.PersonID
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CardID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateCardService();

            if (service.UpdateCard(model))
            {
                TempData["SaveResult"] = "Card was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Card could not be saved");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCardService();
            var model = svc.GetCardByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteCard(int id)
        {
            var service = CreateCardService();

            service.DeleteCard(id);

            TempData["SaveResult"] = "Card was deleted";

            return RedirectToAction("Index");
        }
    }
}