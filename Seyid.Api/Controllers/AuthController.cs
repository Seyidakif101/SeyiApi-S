using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seyid.Business.Dtos.UserDtos;
using Seyid.Business.Services.Abstractions;

namespace Seyid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _service) : ControllerBase
    {


        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            return Ok(result);
        }
    }
}
