using Sysme.Service.DTOs.Doctors;

namespace Sysme.Service.Interfaces;

public interface IDoctorService
{
    Task<DoctorResultDto> AddAsync(DoctorCreationDto dto);
    Task<DoctorResultDto> UpdateAsync(DoctorUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<DoctorResultDto> GetAsync(long id);
    Task<IEnumerable<DoctorResultDto>> GetAllAsync();
}
