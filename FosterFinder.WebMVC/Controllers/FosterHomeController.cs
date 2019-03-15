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
        [Authorize(Roles ="Admin, FosterHomeManager")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, FosterHomeManager")]
        public ActionResult Create(FosterHomeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFosterHomeService();

            if (service.CreateFosterHome(model))
            {
                TempData["SaveResult"] = "The Foster Home was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Foster Home could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateFosterHomeService();
            var model = svc.GetHomeById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin, FosterHomeManager")]
        public ActionResult Edit(int id)
        {
            var service = CreateFosterHomeService();
            var detail = service.GetHomeById(id);
            var model =
                new FosterHomeEdit
                {
                    HomeId = detail.HomeId,
                    FamilyName = detail.FamilyName,
                    OpenBeds = detail.OpenBeds,
                    GenderPref = detail.GenderPref,
                    AgePrefMin = detail.AgePrefMin,
                    AgePrefMax = detail.AgePrefMax,
                    SchoolDistrict = detail.SchoolDistrict,
                    Agency = detail.Agency,
                    CaseworkerName = detail.CaseworkerName,
                    CaseworkerContact = detail.CaseworkerContact,
                    Comments = detail.Comments
                };
                return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, FosterHomeManager")]
        public ActionResult Edit(int id, FosterHomeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.HomeId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFosterHomeService();

            if (service.UpdateFosterHome(model))
            {
                TempData["SaveResult"] = "The Foster Home was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Foster Home could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        [Authorize(Roles = "Admin, FosterHomeManager")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFosterHomeService();
            var model = svc.GetHomeById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, FosterHomeManager")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFosterHomeService();

            service.DeleteHome(id);
            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private FosterHomeService CreateFosterHomeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FosterHomeService(userId);
            return service;
        }
        public ActionResult MatchChildren(int id)
        {
            var svc = CreateFosterHomeService();
            var model = svc.GetChildMatches(id);
            return View(model);
        }
    }
}