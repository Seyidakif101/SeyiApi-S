using Seyid.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Exceptions
{
    public class AlreadyExistException(string message = "This item is already exist") : Exception(message), IBaseException
    {
        public int StatusCode { get; set; } = 409;
    }
}
