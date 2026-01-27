using Seyid.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Core.Entities
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
