using Sysme.Domain.Enums;

namespace Sysme.Service.DTOs.Employees;

public class EmployeeUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Role Role { get; set; }
}
