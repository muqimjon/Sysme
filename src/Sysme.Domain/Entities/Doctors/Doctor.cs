using Sysme.Domain.Commons;
using Sysme.Domain.Enums;

namespace Sysme.Domain.Entities.Doctors;

public class Doctor : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public Gender Gender { get; set; }
}