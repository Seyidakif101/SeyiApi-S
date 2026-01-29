using Seyid.Business.Dtos.ResultDtos;
using Seyid.Business.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResultDto> RegisterAsync(RegisterDto dto);
    }
}
