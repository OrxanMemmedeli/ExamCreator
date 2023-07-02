using DataAccess.Concrete.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    internal static class AutoMigrateDB
    {
        internal static IApplicationBuilder UseAutoMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<ECContext>();

                ctx?.Database.Migrate();
            }
            return app;
        }

        //internal static IServiceCollection UseAutoMigration(this IServiceCollection services)
        //{
        //    using (var scope = services.BuildServiceProvider().CreateScope())
        //    {
        //        var ctx = scope.ServiceProvider.GetRequiredService<ECContext>();

        //        ctx?.Database.Migrate();
        //    }
        //    return services;
        //}

    }
}
