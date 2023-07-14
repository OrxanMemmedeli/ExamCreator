using Business.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Transactions;

namespace ExamCreator.Middlewares
{
    internal class DataBaseTransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public DataBaseTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, DbContext dbContext)
        {
            // çağırılmış method məlumatlarının tapılması
            var method = context.GetEndpoint()?.Metadata?.GetMetadata<MethodInfo>();

            // method məlumatlarının dolu olması və lazimi atributa bərabər olması
            if (method != null && method.GetCustomAttribute<TransactionAttribute>() != null)
            {
                IDbContextTransaction _transaction = null;
                try
                {
                    _transaction = await dbContext.Database.BeginTransactionAsync();

                    await _next(context);

                    await _transaction.CommitAsync();
                }
                catch
                {
                    if (_transaction != null)
                        await _transaction.RollbackAsync();
                    throw;
                }
                finally { _transaction?.Dispose(); }
            }
        }
    }

    internal static class DataBaseTransactionMiddlewareExtension
    {
        internal static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app)
        {
            app.UseMiddleware<DataBaseTransactionMiddleware>();
            return app;
        }
    }
}
