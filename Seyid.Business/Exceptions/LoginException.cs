using Seyid.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Exceptions
{
    public class LoginException(string message = "Some Credeantials are wrong") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 400;
    }
}
