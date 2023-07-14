using CoreLayer.Utilities.Exceptions;
using DataAccess.Concrete.Context;
using EntityLayer.Concrete;
using FluentValidation;

namespace ExamCreator.Middlewares
{
    internal class GlobalErrorHandlingMiddleware
    {
        //middleware olmasi ucun esas teleblerden birincisi
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //middleware olmasi ucun esas teleblerden ikincisi
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using (ECContext ctx = new())
                {
                    var entity = new SysException()
                    {
                        Id = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        Exception = ex.ToString(),
                        Message = ex.Message,
                        RequestPath = context.Request.Path,
                        StackTrace = ex.StackTrace,
                        UserName = context.User.Identity.Name,
                        UserIP = context.Connection.RemoteIpAddress?.ToString(),
                    };

                    switch (ex)
                    {
                        case NotFoundException:
                            entity.StatusCode = StatusCodes.Status404NotFound;
                        break;
                        case BadRequestException:
                            entity.StatusCode = StatusCodes.Status400BadRequest;
                            break;
                        case UnhadleException:
                            entity.StatusCode = StatusCodes.Status500InternalServerError;
                            break;
                        default:
                            entity.StatusCode = StatusCodes.Status500InternalServerError; 
                            break;
                    }

                    await ctx.SysExceptions.AddAsync(entity);
                    await ctx.SaveChangesAsync();
                }
            }
            //return _next.Invoke(context);
        }
    }

    internal static class GlobalErrorHandlingMiddlewareExtention
    {
        internal static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return builder;
        }
    }
}
