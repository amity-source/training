using Model.Dao;
using OnlineShop_Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop_Linq.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null) 
            {
                list = (List<CartItem>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];

            if (cart != null)
            {
                //if there is item (cart is not null)
                var list = (List<CartItem>)cart;

                if (list.Exists(u => u.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            //increase item quantity
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //make new cart item
                    var item = new CartItem(); 
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //add list to session
                Session[CartSession] = list;
            }
            else
            {
                //if there is no item (cart is null)
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;

                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }
    }
}