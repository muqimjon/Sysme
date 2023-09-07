using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Schedules;
using Sysme.Domain.Enums;
using System.Text.Json.Serialization;

namespace Sysme.Domain.Entities.Doctors;

public class Doctor : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialty { get; set; }
    public Gender Gender { get; set; }
    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; }

    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; }
    [JsonIgnore]
    public ICollection<Schedule> Schedules { get; set; }
}