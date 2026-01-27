using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Exceptions
{
    public class NotFoundException(string message = "Object is not found") : Exception(message)
    {
    }
}
