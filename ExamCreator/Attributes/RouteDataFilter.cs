using CoreLayer.Constants;
using DataAccess.Concrete.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ExamCreator.Attributes
{
    public class RouteDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var areaName = context.RouteData.Values["area"];
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var url = areaName != null ? $"/{areaName}/{controllerName}/{actionName}" : $"/{controllerName}/{actionName}";

            var roleBasedData = context.HttpContext.Session.GetString(SessionNames.UserRoleURLs);

            if (string.IsNullOrEmpty(roleBasedData))
                context.Result = new RedirectToActionResult("Denied", "Account", new { area = "" });

            List<string> urls = JsonConvert.DeserializeObject<List<string>>(roleBasedData);

            if(!urls.Contains(url))
                context.Result = new RedirectToActionResult("Denied", "Account", new { area = "" });

            base.OnActionExecuting(context);
        }
    }
}
