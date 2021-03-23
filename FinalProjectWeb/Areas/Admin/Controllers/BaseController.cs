using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.EF;
using System.Web.Routing;
namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            User user = (User) Session["User"];
            if(user != null)
            {
                if ("us".Equals(user.roleID))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}