using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Patients;

namespace Sysme.Domain.Entities.Appointments;

public class Appointment : AudiTable
{
    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentTime { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
}
