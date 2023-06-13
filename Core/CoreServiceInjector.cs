using CoreLayer.Helpers.E_mail.Mailkit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer
{
    public static class CoreServiceInjector
    {
        public static void CoreRegister(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SendEMailByGmail>();
        }
    }
}
