using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Dtos.EmployeeDtos
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }=string.Empty;
        public string Surname { get; set; }=string.Empty;
        public IFormFile Image { get; set; }=null!;
        public Guid DepartmentId { get; set; }
    }
}
