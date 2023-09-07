using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Service.DTOs.Appointments;

public class AppointmentCreationDto
{
    public long DoctorId { get; set; }
    public long PatientId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
}
