using AutoMapper;
using Seyid.Business.Dtos.EmployeeDtos;
using Seyid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Profiles
{
    internal class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeGetDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
        }
    }
}
