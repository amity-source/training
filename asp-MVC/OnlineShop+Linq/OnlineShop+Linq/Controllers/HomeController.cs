using Model.Dao;
using OnlineShop_Linq.Models;
using OnlineShop_Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.slides = new SlideDao().ListAll();
            var product = new ProductDao();
            ViewBag.NewProducts = product.ListNewProduct(4);
            ViewBag.FeatureProducts = product.ListFeaturedProduct(4);
            return View();
        }

        //menus
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();

            if (cart!=null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

    }
}