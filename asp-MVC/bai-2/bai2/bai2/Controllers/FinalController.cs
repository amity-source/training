using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai2.Controllers
{
    public class FinalController : Controller
    {
        // GET: Final
        public ActionResult Index()
        {
            //using viewbag
            ViewBag.Hello = "Hello From ViewBag";
            //using viewmodel
            var FinalModel = new Models.FinalModel();
            FinalModel.MyString = "Hello From Model";
            return View(FinalModel);
        }

    }
}