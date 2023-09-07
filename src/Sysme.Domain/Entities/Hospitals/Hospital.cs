using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Attachments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Employees;
using Sysme.Domain.Entities.Patients;
using System.Text.Json.Serialization;

namespace Sysme.Domain.Entities.Hospitals;

public class Hospital : AudiTable
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    [JsonIgnore]
    public ICollection<Patient> Patients { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Doctor> Doctors { get; set; } = default!;
    [JsonIgnore]
    public ICollection<Employee> Employees { get; set; } = default!;
}