using Seyid.Business.Abstractions;
using Seyid.Business.Dtos.ResultDtos;

namespace Seyid.Api.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                ResultDto errorResult = new()
                {
                    IsSucced = false,
                    StatusCode = 500,
                    Message = "Internal Server Error"

                };


                if (ex is IBaseException baseException)
                {
                    errorResult.StatusCode = baseException.StatusCode;
                    errorResult.Message = ex.Message;
                }

                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = errorResult.StatusCode;

                await context.Response.WriteAsJsonAsync(errorResult);
            }
        }
    }
}
