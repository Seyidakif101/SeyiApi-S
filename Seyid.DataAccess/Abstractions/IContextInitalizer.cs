using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Abstractions
{
    public interface IContextInitalizer
    {
        Task InitDatabaseAsync();
    }
}
