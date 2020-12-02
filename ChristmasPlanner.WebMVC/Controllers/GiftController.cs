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
    public class GiftController : Controller
    {
        // GET: Gift
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftService(userID);
            var model = service.GetGift();

            return View(model);
        }
        public ActionResult Create()
        {
            var db = new PersonService();
            ViewBag.PersonID = new SelectList(db.GetPerson().OrderBy(e => e.FullName), "PersonID", "FullName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(GiftCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGiftService();

            if (service.CreateGift(model))
            {
                TempData["SaveResult"] = "Gift was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New Gift could not be created.");

            return View(model);
        }

        private GiftService CreateGiftService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftService(userID);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGiftService();
            var model = svc.GetGiftByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGiftService();
            var detail = service.GetGiftByID(id);
            var db = new PersonService();
            ViewBag.PersonID = new SelectList(db.GetPerson().OrderBy(e => e.FullName), "PersonID", "FullName");
            var model =
                new GiftEdit
                {
                    GiftID = detail.GiftID,
                    Description = detail.Description,
                    BoughtGift = detail.BoughtGift,
                    Person = detail.Person
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GiftEdit model)
        {
            var db = new PersonService();
            ViewBag.PersonID = new SelectList(db.GetPerson().OrderBy(e => e.FullName), "PersonID", "FullName");
            if (!ModelState.IsValid) return View(model);

            if (model.GiftID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateGiftService();

            if (service.UpdateGift(model))
            {
                TempData["SaveResult"] = "Gift was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gift could not be saved");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGiftService();
            var model = svc.GetGiftByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteGift(int id)
        {
            var service = CreateGiftService();

            service.DeleteGift(id);

            TempData["SaveResult"] = "Gift was deleted";

            return RedirectToAction("Index");
        }
    }
}