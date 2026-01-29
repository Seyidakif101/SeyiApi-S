using Seyid.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Exceptions
{
    public class RegisterException(string message = "Registration failed") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }
}
