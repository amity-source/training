using System.Web.Mvc;

namespace OnlineShop_Linq.Areas.Admin2
{
    public class Admin2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin2_default",
                "Admin2/{controller}/{action}/{id}",
                new { action = "Index", controller = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop_Linq.Areas.Admin2.Controllers" }
            );
        }
    }
}