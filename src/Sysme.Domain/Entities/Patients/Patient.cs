using Sysme.Domain.Commons;
using Sysme.Domain.Enums;

namespace Sysme.Domain.Entities.Patients;

public class Patient : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}