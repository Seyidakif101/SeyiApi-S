using Microsoft.Extensions.DependencyInjection;
using Seyid.Business.Services.Abstractions;
using Seyid.Business.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.ServiceRegistrations
{
    public static class BusinessServiceRegistration
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.AddAutoMapper(x => { },typeof(BusinessServiceRegistration).Assembly);

            return services;
        }
    }
}
