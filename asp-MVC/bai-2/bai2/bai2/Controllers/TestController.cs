using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.WelcomeString = "Hello From ViewBag";
            var message = new Models.MessageModel();
            message.welcome = "Welcome from model";
            return View(message);
        }

        public ActionResult images()
        {
            ViewBag.imagestring = "a Random Image";
            return View();
        }
    }
}