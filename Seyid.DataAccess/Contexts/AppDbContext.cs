using Microsoft.EntityFrameworkCore;
using Seyid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Contexts
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
