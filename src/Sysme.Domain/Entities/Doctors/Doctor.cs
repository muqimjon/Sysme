﻿using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Schedules;
using Sysme.Domain.Enums;

namespace Sysme.Domain.Entities.Doctors;

public class Doctor : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Gender Gender { get; set; }

    public long HospitalId { get; set; }
    public Hospital Hospital { get; set; } = default!;

    public ICollection<Appointment> Appointments { get; set; } = default!;
    public ICollection<Schedule> Schedules { get; set; } = default!;
}