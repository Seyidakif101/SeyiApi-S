using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Seyid.Business.Dtos.ResultDtos;
using Seyid.Business.Dtos.UserDtos;
using Seyid.Business.Exceptions;
using Seyid.Business.Services.Abstractions;
using Seyid.Core.Entities;
using Seyid.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Services.Implementations;

internal class AuthService(UserManager<AppUser> _userManager, IMapper _mapper) : IAuthService
{
    public async Task<ResultDto> RegisterAsync(RegisterDto dto)
    {
        var isExistEmail = await _userManager.Users.AnyAsync(x => x.Email!.ToLower() == dto.Email.ToLower());

        var appUser = _mapper.Map<AppUser>(dto);

        var result = await _userManager.CreateAsync(appUser, dto.Password);

        if (!result.Succeeded)
        {
            string message = string.Join(",\n", result.Errors.Select(x => x.Description));

            throw new RegisterException(message);
        }

        await _userManager.AddToRoleAsync(appUser, IdentityRoles.Member.ToString());

        return new();

    }
}
