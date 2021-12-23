using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai2.Controllers
{
    public class ExtraController : Controller
    {
        // GET: Extra
        public ActionResult Index()
        {
            ViewBag.Hello = "Hello From ViewBag";
            var modelString = new Models.ExtraModel();
            modelString.HelloString = "Hello From Model";
            return View(modelString);
        }
    }
}