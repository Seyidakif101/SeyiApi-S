using Seyid.Core.Entities;
using Seyid.DataAccess.Contexts;
using Seyid.DataAccess.Repositories.Abstractions;
using Seyid.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.DataAccess.Repositories.Implementations
{
    internal class DepartmentRepository(AppDbContext _context) : Repository<Department>(_context), IDepartmentRepository
    {
    }
}
