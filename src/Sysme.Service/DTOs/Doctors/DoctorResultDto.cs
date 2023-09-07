using Sysme.Domain.Enums;
using Sysme.Service.DTOs.Hospitals;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public HospitalResultDto Hospital { get; set; } = default!;
}
