namespace Sysme.Service.DTOs.Appointments;

public class AppointmentCreationDto
{
    public decimal Price { get; set; }
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Notes { get; set; } = string.Empty;
}