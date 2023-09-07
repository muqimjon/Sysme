using Sysme.Domain.Enums;
using Sysme.Service.DTOs.Hospitals;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public Gender Gender { get; set; }
    public HospitalResultDto Hospital { get; set; }
}
