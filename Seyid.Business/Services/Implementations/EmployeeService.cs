using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Seyid.Business.Dtos.EmployeeDtos;
using Seyid.Business.Exceptions;
using Seyid.Business.Services.Abstractions;
using Seyid.Core.Entities;
using Seyid.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seyid.Business.Services.Implementations
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public EmployeeService(IEmployeeRepository repository, IDepartmentRepository departmentRepository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task CreateAsync(EmployeeCreateDto dto)
        {
            var isExistDepartment = _departmentRepository.AnyAsync(x=>x.Id==dto.DepartmentId);
            if (!isExistDepartment.Result)
                throw new NotFoundException("Category is not found");
            var employee = _mapper.Map<Employee>(dto);
            var imagePath =await _cloudinaryService.FileUploadAsync(dto.Image);
            employee.ImagePath = imagePath;
            await _repository.AddAsync(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee is null)
                throw new NotFoundException("Employee is not found");
            await _cloudinaryService.FileDeleteAsync(employee.ImagePath);
            _repository.DeleteAsync(employee);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var employees =await _repository.GetAll().Include(x=>x.Department).ToListAsync();
            var dtos= _mapper.Map<List<EmployeeGetDto>>(employees);
            return dtos;
        }

        public async Task<EmployeeGetDto?> GetByIdAsync(Guid id)
        {
            var employee =await  _repository.GetByIdAsync(id);
            if (employee is null)
                throw new NotFoundException("Employee is not found");
            var dto = _mapper.Map<EmployeeGetDto>(employee);
            return dto;
        }

        public async Task UpdateAsync(EmployeeUpdateDto dto)
        {
            var isExistDepartment = _departmentRepository.AnyAsync(x => x.Id == dto.DepartmentId);
            if (!isExistDepartment.Result)
                throw new NotFoundException("Category is not found");
            var existItem = await _repository.GetByIdAsync(dto.Id);
            if (existItem is null)
                throw new NotFoundException("Employee is not found");
            existItem=_mapper.Map(dto, existItem);
            if(dto.Image is not null)
            {
                await _cloudinaryService.FileDeleteAsync(existItem.ImagePath);
                var imagePath = await _cloudinaryService.FileUploadAsync(dto.Image);
                existItem.ImagePath = imagePath;
            }
            _repository.UpdateAsync(existItem);
            await _repository.SaveChangesAsync();
        }
    }
}
