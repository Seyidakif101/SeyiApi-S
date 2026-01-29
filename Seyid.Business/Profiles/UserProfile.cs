using AutoMapper;
using Seyid.Business.Dtos.UserDtos;
using Seyid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
