using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seyid.Core.Entities;
using Seyid.DataAccess.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Contexts
{
    internal class AppDbContext(BaseAuditableInterceptor _interceptor, DbContextOptions options) : IdentityDbContext<AppUser, AppRole, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
