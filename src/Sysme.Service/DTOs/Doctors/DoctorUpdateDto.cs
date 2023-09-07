using Sysme.Domain.Enums;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public long HospitalId { get; set; }
}
