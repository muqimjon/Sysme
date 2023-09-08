using Sysme.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sysme.Service.DTOs.Patients;

public class PatientCreationDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public Gender Gender { get; set; }
}