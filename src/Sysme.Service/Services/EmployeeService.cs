using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Employees;
using Sysme.Service.DTOs.Employees;
using Sysme.Service.Exceptions;
using Sysme.Service.Interfaces;

namespace Sysme.Service.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> repository;
    private readonly IMapper mapper;
    public EmployeeService(IRepository<Employee> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<EmployeeResultDto> AddAsync(EmployeeCreationDto dto)
    {
        var existEmployee = await repository.GetAsync(h => h.Phone == dto.Phone);
        if (existEmployee is not null)
            throw new AlreadyExistException("This Employee already exist");

        var mappedEmployee = mapper.Map<Employee>(dto);
        await repository.CreateAsync(mappedEmployee);
        await repository.SaveChanges();

        return mapper.Map<EmployeeResultDto>(mappedEmployee);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var existEmployee = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Employee not found");

        repository.Delete(existEmployee);
        await repository.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<EmployeeResultDto>> RetrieveAllAsync()
    {
        var allEmployees = await repository.GetAll().ToListAsync();
        return mapper.Map<IEnumerable<EmployeeResultDto>>(allEmployees);
    }

    public async Task<EmployeeResultDto> RetrieveByIdAsync(long id)
    {
        var existEmployee = await repository.GetAsync(h => h.Id.Equals(id))
            ?? throw new NotFoundException("This Employee not found");

        return mapper.Map<EmployeeResultDto>(existEmployee);
    }

    public async Task<EmployeeResultDto> ModifyAsync(EmployeeUpdateDto dto)
    {
        var existEmployee = await repository.GetAsync(h => h.Id.Equals(dto.Id))
            ?? throw new NotFoundException("This Employee not found");

        mapper.Map(dto, existEmployee);
        repository.Update(existEmployee);
        await repository.SaveChanges();

        return mapper.Map<EmployeeResultDto>(existEmployee);
    }
}