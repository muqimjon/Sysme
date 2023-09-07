using Sysme.Domain.Enums;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public long HospitalId { get; set; }
}