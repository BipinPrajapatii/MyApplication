using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyApplication.Core.Model.Email.EmailConfiguration;
using MyApplication.Core.Model.FilePath;
using MyApplication.Data.Entities;
using MyApplication.Repo;
using MyApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.IoC
{
    public static class IocContainer
    {
        public static void ConfigureIOC(this IServiceCollection services, EmailConfiguration emailConfig, FilePathConfiguration filePathConfig)
        {
            services.AddScoped<IUserClaimsPrincipalFactory<User>, AdditionalUserClaimsPrincipalFactory>();
            if (emailConfig != null)
            {
                services.AddSingleton(emailConfig);
                services.AddTransient<IEmailSender, EmailSender>();
            }

            if (filePathConfig != null)
            {
                services.AddSingleton(filePathConfig);
            }

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
