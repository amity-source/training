using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop_Linq
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductCategory",
                url: "product/{metatitle}-{categoryId}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "ProductDetail",
                url: "detail/{metatitle}-{productId}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Add To Cart",
                url: "add-to-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "checkout",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "success",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Error",
                url: "order-error",
                defaults: new { controller = "Cart", action = "OrderError", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "About", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Delivery",
                url: "delivery",
                defaults: new { controller = "Delivery", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "News",
                url: "news",
                defaults: new { controller = "News", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Contact", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Controllers" }
            );

        }
    }
}
