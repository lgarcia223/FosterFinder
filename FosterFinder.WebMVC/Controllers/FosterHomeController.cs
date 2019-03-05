using FosterFinder.Models;
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
        public ActionResult FosterHomeIndex()
        {
            var model = new FosterHomeListItem[0];
            return View(model);
        }
        public ActionResult FosterHomeCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FosterHomeCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}