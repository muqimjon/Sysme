using Sysme.Service.DTOs.Patients;

namespace Sysme.Service.Interfaces;

public interface IPatientService
{
    Task<PatientResultDto> AddAsync(PatientCreationDto dto);
    Task<PatientResultDto> UpdateAsync(PatientUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<PatientResultDto> GetAsync(long id);
    Task<IEnumerable<PatientResultDto>> GetAllAsync();
}
