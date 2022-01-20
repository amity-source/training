using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop_Linq.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public static bool session = false;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (session == false)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                    new RouteValueDictionary(
                    new { controller = "Home", action = "Index" }));
                session = true;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}