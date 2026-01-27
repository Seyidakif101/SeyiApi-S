using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seyid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(256);
            builder.Property(e => e.ImagePath).IsRequired().HasMaxLength(1000);
            builder.Property(e => e.Surname).IsRequired().HasMaxLength(256);
            builder.Property(e => e.Salary).IsRequired().HasPrecision(10, 3);
            builder.HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
