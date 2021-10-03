using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFinanceiro.Models
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var controller = filterContext.RouteData.Values.ContainsKey("Controller") ? filterContext.RouteData.Values["Controller"].ToString() : null;
            var action = filterContext.RouteData.Values.ContainsKey("Action") ? filterContext.RouteData.Values["Action"].ToString() : null;
            var area = filterContext.RouteData.DataTokens.ContainsKey("Area") ? filterContext.RouteData.DataTokens["Area"].ToString() : null;
            //var user = filterContext.HttpContext.User.Identity.GetUserId();

            //Task.Run(() => Generic().AreaActionLog(user, area, controller, action));

            //
            // Perform logging here
            //

            base.OnActionExecuting(filterContext);
        }
    }
}
