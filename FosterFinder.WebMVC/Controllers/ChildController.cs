﻿using FosterFinder.Models;
using FosterFinder.Services;
using FosterFinder.Data;
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

        [Authorize(Roles = "Admin, ChildManager, FosterHomeManager")]
        // GET: Child
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChildService(userId);
            var model = service.GetChildren();

            return View(model);
        }

        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult Create(ChildCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateChildService();

            if (service.CreateChild(model))
            {
                TempData["SaveResult"] = "Child's info was saved.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Child's info could not be saved.");

            return View(model);
        }

        [Authorize(Roles = "Admin, ChildManager, FosterHomeManager")]
        public ActionResult Details(int id)
        {
            var svc = CreateChildService();
            var model = svc.GetChildById(id);

            return View(model);
        }

        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult Edit(int id)
        {
            var service = CreateChildService();
            var detail = service.GetChildById(id);
            var model =
                new ChildEdit
                {
                    ChildId = detail.ChildId,
                    ChildName = detail.ChildName,
                    BedsNeed = detail.BedsNeed,
                    ChildGender = detail.ChildGender,
                    ChildAge = detail.ChildAge,
                    SchoolDistNeed = detail.SchoolDistNeed,
                    Comments = detail.Comments,
                    CaseworkerName = detail.CaseworkerName,
                    CaseworkerContact = detail.CaseworkerContact,
                    PhotoUrl = detail.PhotoUrl,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult Edit(int id, ChildEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ChildId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateChildService();

            if (service.UpdateChild(model))
            {
                TempData["SaveResult"] = "The child's info has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The child's info could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult Delete(int id)
        {
            var svc = CreateChildService();
            var model = svc.GetChildById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin, ChildManager")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateChildService();

            service.DeleteChild(id);
            TempData["SaveResult"] = "The child's info was deleted.";

            return RedirectToAction("Index");
        }

        private ChildService CreateChildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChildService(userId);
            return service;
        }
        public ActionResult MatchHomes(int id)
        {
            var svc = CreateChildService();
            var model = svc.GetHomeMatches(id);
            return View(model);
        }
    }
}