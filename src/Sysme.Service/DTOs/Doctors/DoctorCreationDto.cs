using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Service.DTOs.Doctors;

public class DoctorCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public long HospitalId { get; set; }
}