using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Schedules;
using Sysme.Domain.Enums;
using System.Text.Json.Serialization;

namespace Sysme.Domain.Entities.Doctors;

public class Doctor : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    
    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; } = default!;

    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Schedule> Schedules { get; set; } = default!;
}