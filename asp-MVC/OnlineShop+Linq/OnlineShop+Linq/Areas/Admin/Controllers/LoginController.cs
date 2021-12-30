using Model.Dao;
using OnlineShop_Linq.Areas.Admin.Models;
using OnlineShop_Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));

                switch (result)
                {
                    case  1:
                        var user = dao.GetByUserName(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.ID;

                        Session.Add(CommonConstant.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");

                    case  0:
                        ModelState.AddModelError("", "Account not found");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Account is locked");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Wrong password");
                        break;
                    default:
                        ModelState.AddModelError("", "Login Failed.");
                        break;
                }

            }

            return View("Index");
        }
    }
}