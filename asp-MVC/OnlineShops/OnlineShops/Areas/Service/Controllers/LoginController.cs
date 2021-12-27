using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShops.Areas.Service.Controllers
{
    public class LoginController : Controller
    {
        // GET: Service/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.LoginModel model)
        {
            var result = new Model2.AccountModel().Login(model.UserName, model.Password);

            if (result && ModelState.IsValid)
            {
                Code.SessionHelper.SetSession(new Code.UserSession() { UserName = model.UserName });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect Username or Password.");
            }

            return View(model);
        }
    }
}