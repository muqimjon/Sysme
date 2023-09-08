using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Patients;

namespace Sysme.Service.DTOs.Appointments;

public class AppointmentResultDto
{
    public long Id { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DoctorResultDto Doctor { get; set; } = default!;
    public PatientResultDto Patient { get; set; } = default!;
    public string Notes { get; set; } = string.Empty;
}
