using FosterFinder.Models;
using FosterFinder.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterFinder.WebMVC.Controllers
{
    [Authorize]
    public class FosterHomeController : Controller
    {
        // GET: FosterHome
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FosterHomeService(userId);
            var model = service.GetFosterHomes();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FosterHomeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FosterHomeService service = CreateFosterHomeService();

            service.CreateFosterHome(model);

            return RedirectToAction("Index");
        }

        private FosterHomeService CreateFosterHomeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FosterHomeService(userId);
            return service;
        }
    }
}