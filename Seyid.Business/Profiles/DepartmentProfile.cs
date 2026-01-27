using AutoMapper;
using Seyid.Business.Dtos.DepartmentDtos;
using Seyid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Profiles
{
    internal class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        { 
            CreateMap<Department, DepartmentGetDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
        }
    }
}
