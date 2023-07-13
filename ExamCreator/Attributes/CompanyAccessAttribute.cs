using CoreLayer.Helpers.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExamCreator.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class CompanyAccessAttribute : ActionFilterAttribute
    {
        private readonly Type _httpContextAccessorType;

        public CompanyAccessAttribute(Type httpContextAccessorType)
        {
            _httpContextAccessorType = httpContextAccessorType;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {


                base.OnActionExecuted(context);
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult(ex.Message);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var httpContextAccessor = (IHttpContextAccessor)context.HttpContext.RequestServices.GetService(_httpContextAccessorType);
                var companyID = CompanyIdFinder.GetCompanyID(httpContextAccessor);

                base.OnActionExecuting(context);
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
