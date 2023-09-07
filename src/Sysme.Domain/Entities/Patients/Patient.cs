using Sysme.Domain.Commons;
using Sysme.Domain.Enums;

namespace Sysme.Domain.Entities.Patients;

public class Patient : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Disease { get; set; }
    public Gender Gender { get; set; }
}