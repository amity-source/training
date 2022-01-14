using OnlineShop_Linq.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop_Linq.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //get session and check if user session is null then redirect to Login page
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                    new RouteValueDictionary(
                    new { controller = "Login", action = "Index", Area = "Admin" }));
            }

            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;

            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success"; /*change alert class*/
                    break;
                case "warning":
                    TempData["AlertType"] = "alert-warning"; /*change alert class*/
                    break;
                case "error":
                    TempData["AlertType"] = "alert-danger"; /*change alert class*/
                    break;
                default:
                    break;
            }

        }

        protected bool InputValidation(string username, string name, string password)
        {
            if (string.IsNullOrEmpty(name))
                SetAlert("Please type in your name", "error");

            if (string.IsNullOrEmpty(password))
                SetAlert("Please type in your password", "error");

            if (string.IsNullOrEmpty(username))
                SetAlert("Please type in your username", "error");

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}