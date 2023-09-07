using Sysme.Service.DTOs.Employees;

namespace Sysme.Service.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeResultDto> AddAsync(EmployeeCreationDto dto);
    Task<EmployeeResultDto> ModifyAsync(EmployeeUpdateDto dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<EmployeeResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<EmployeeResultDto>> RetrieveAllAsync();
}
