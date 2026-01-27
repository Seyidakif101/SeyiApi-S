using Seyid.Business.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto dto);
        Task DeleteAsync(Guid id);
        Task<List<EmployeeGetDto>> GetAllAsync();
        Task UpdateAsync(EmployeeUpdateDto dto);
        Task<EmployeeGetDto?> GetByIdAsync(Guid id);
    }
}
