using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seyid.Core.Entities;
using Seyid.DataAccess.Abstractions;
using Seyid.DataAccess.Contexts;
using Seyid.DataAccess.DataInitalizers;
using Seyid.DataAccess.Interceptor;
using Seyid.DataAccess.Repositories.Abstractions;
using Seyid.DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContextInitalizer, DbContextInitalizer>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddIdentity<AppUser, AppRole>(options =>
            {

                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;

            }).AddDefaultTokenProviders()
      .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<BaseAuditableInterceptor>();
            return services;
        }
    }
}
