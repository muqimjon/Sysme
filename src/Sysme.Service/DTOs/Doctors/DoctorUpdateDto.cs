using Sysme.Domain.Enums;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public Gender Gender { get; set; }
    public long HospitalId { get; set; }
}
