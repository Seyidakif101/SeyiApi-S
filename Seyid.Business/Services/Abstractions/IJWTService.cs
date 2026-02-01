using Seyid.Business.Dtos.TokenDtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Seyid.Business.Services.Abstractions
{
    public interface IJWTService
    {
        AccessTokenDto CreateAccessToken(List<Claim> claims);
    }
}
