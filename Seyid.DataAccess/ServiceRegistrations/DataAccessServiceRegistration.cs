using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seyid.DataAccess.Contexts;
using Seyid.DataAccess.Repositories.Abstractions;
using Seyid.DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
