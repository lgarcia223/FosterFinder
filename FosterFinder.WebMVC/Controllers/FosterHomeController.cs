using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FosterFinder.WebMVC.Controllers
{
    public class FosterHomeController : Controller
    {
        // GET: FosterHome
        public ActionResult FosterHomeIndex()
        {
            return View();
        }
    }
}