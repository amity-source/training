using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                model.CreatedDate = DateTime.Now;
                long id = dao.Insert(model);
                if (id > 0)
                {
                    SetAlert("Create Product " + model.Name + " Sucessful!", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Add Product Failed");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().GetbyID(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                product.ModifedDate = DateTime.Now;
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("Update Product " + product.Name + " Sucessful!", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Update Product Failed");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);

            return Json(new
            {
                status = result
            });
        }
        [HttpPost]
        public JsonResult ChangeVat(long id)
        {
            var result = new ProductDao().ChangeVAT(id);

            return Json(new
            {
                IncludeVAT = result
            });
        }
    }
}