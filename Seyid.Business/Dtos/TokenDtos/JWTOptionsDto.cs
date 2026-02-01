using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Dtos.TokenDtos
{
    public class JWTOptionsDto
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpiredDate { get; set; }
    }
}
