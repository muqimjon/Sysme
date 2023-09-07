namespace Sysme.Service.DTOs.Appointments;

public class AppointmentUpdateDto
{
    public long Id { get; set; }
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
}
