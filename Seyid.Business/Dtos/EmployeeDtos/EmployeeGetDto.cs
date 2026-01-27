using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Dtos.EmployeeDtos
{
    public class EmployeeGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Surname { get; set; }=string.Empty;
        public string ImagePath { get; set; }=string.Empty;
        public string DepartmentName { get; set; }=string.Empty;
    }
}
