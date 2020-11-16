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
    [Authorize]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userID);
            var model = service.GetPerson();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePersonService();

            if (service.CreatePerson(model))
            {
                TempData["SaveResult"] = "Person was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "New Person could not be created.");

            return View(model);
        }

        private PersonService CreatePersonService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userID);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePersonService();
            var model = svc.GetPersonByID(id);

            return View(model);
        }
    }
}