using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShops.Areas.Service.Controllers
{
    public class HomeController : Controller
    {
        // GET: Service/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}