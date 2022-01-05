using Model.EF;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop_Linq.Common;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page,pageSize);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                //encrypt user password
                var encryptedMD5Password = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5Password;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add User Complete");
                }
            }
            return View("Index");


        }


    }
}