namespace Sysme.Service.DTOs.Hospitals;

public class HospitalUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
