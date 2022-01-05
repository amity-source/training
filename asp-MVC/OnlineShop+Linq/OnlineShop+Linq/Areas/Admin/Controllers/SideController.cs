using OnlineShop_Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class SideController : Controller
    {
        // GET: Admin/Side
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //get session and check if user session is not null then redirect to Home page
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session != null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                    new RouteValueDictionary(
                    new { controller = "Home", action = "Index", Area = "Admin" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}