using Seyid.Core.Entities;
using Seyid.DataAccess.Contexts;
using Seyid.DataAccess.Repositories.Abstractions;
using Seyid.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Repositories.Implementations
{
    internal class EmployeeRepository(AppDbContext _context) : Repository<Employee>(_context), IEmployeeRepository
    {

    }
}
