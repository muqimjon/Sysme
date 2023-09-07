﻿using Sysme.Service.DTOs.Doctors;
using Sysme.Service.DTOs.Patients;

namespace Sysme.Service.DTOs.Appointments;

public class AppointmentResultDto
{
    public long id { get; set; }
    public DoctorResultDto Doctor { get; set; }
    public PatientResultDto Patient { get; set; }
    public DateTime AppointmentTime { get; set; }
    public decimal Price { get; set; }
    public string Notes { get; set; }
}