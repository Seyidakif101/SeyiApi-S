using Seyid.Business.Dtos.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task CreateAsync(DepartmentCreateDto dto);
        Task UpdateAsync(DepartmentUpdateDto dto);
        Task DeleteAsync(Guid id);
        Task<List<DepartmentGetDto>> GetAllAsync();
        Task<DepartmentGetDto?> GetByIdAsync(Guid id);

    }
}
