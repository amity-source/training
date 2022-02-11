using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContact();

            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string address, string email, string content)
        {
            var feedBack = new FeedBack
            {
                Name = name,
                Phone = phone,
                Address = address,
                Email = email,
                Content = content,
                CreatedDate = DateTime.Now
            };

            //sending feedback data into contact table
            var result = new ContactDao().InsertFeedBack(feedBack);

            if (result > 0)
            {
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}