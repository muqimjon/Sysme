using Sysme.Service.DTOs.Patients;

namespace Sysme.Service.Interfaces;

public interface IPatientService
{
    Task<PatientResultDto> AddAsync(PatientCreationDto dto);
    Task<PatientResultDto> ModifyAsync(PatientUpdateDto dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<PatientResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<PatientResultDto>> RetrieveAllAsync();
}
