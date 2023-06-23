using DataAccess.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace ExamCreator.Attributes
{
    public class RouteDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ECContext ctx = new ECContext();

            var areaName = context.RouteData.Values["area"];
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var url = areaName != null ? $"/{areaName}/{controllerName}/{actionName}" : $"/{controllerName}/{actionName}";


            var urls = ctx.RoleUrls.FirstOrDefault(x => x.Url == url);

            if (urls == null)
            {
                context.Result = new RedirectToActionResult("Denied", "Account", new { area = "" });
            }

            base.OnActionExecuting(context);
        }
    }
}
