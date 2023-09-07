using Sysme.Domain.Enums;

namespace Sysme.Service.DTOs.Patients;

public class PatientUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Disease { get; set; }
    public Gender Gender { get; set; }
}
