using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Abstractions
{
    public interface IBaseException
    {
        public int StatusCode { get; set; }
    }
}
