using CoreLayer.Helpers.E_mail.Mailkit;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DALServiceInjection
    {
        public static void DALServiceRegister(this IServiceCollection services)
        {
            //services.UseAutoMigration();
        }

        public static void DALAppRegister(this IApplicationBuilder app)
        {
            app.UseAutoMigration();
        }
    }
}
