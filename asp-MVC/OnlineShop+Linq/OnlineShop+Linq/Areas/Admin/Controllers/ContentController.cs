using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;   
using System.Web.Mvc;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            int page = 1, pageSize = 10;
            var dao = new ContentDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Status = true;
            SetViewBag();
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();

                model.CreatedDate = DateTime.Now;
                long id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Create " + model.Name + " Sucessful!", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Add Content Failed");
                }
            }
            SetViewBag();
            return View();
        }
    
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetbyID(id);

            SetViewBag(content.CategoryID);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.CategoryID);
            return View();
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAllCategory(), "ID", "Name", selectedId);
        } 
    }
}