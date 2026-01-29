using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Seyid.Business.Services.Abstractions;
using Seyid.Business.Services.Implementations;
using Seyid.Business.Validators.EmployeeValidators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.ServiceRegistrations
{
    public static class BusinessServiceRegistration
    {

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();


            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

            AddServices(services);

            services.AddAutoMapper(x => { },typeof(BusinessServiceRegistration).Assembly);


            return services;
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
