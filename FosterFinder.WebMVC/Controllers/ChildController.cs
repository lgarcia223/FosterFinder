using FosterFinder.Models;
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
        public ActionResult ChildIndex()
        {
            var model = new ChildListItem[0];
            return View(model);
        }
        public ActionResult ChildCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChildCreate model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}