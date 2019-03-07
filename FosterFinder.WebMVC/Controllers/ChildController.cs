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
    public class ChildController : Controller
    {
        [Authorize] 
        // GET: Child
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChildService(userId);
            var model = service.GetChildren();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ChildService service = CreateChildService();

            service.CreateChild(model);

            return RedirectToAction("Index");
        }

        private ChildService CreateChildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChildService(userId);
            return service;
        }
    }
}