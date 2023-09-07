using Sysme.Domain.Commons;
using Sysme.Domain.Enums;

namespace Sysme.Domain.Entities.Employees;

public class Employee : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public Role Role { get; set; }
}
