﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult Category(long categoryId)
        {
            var category = new ProductCategoryDao().ViewDetail(categoryId);

            return View(category);
        }

        public ActionResult Detail(long productId)
        {
            var product = new ProductDao().GetbyID(productId);

            return View(product);
        } 

    }
}