using Sysme.Service.DTOs.Attachments;
using Sysme.Service.DTOs.Hospitals;

namespace Sysme.Service.Interfaces;

public interface IHospitalService
{
    Task<HospitalResultDto> AddAsync(HospitalCreationDto dto);
    Task<HospitalResultDto> UpdateAsync(HospitalUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<HospitalResultDto> GetAsync(long id);
    Task<IEnumerable<HospitalResultDto>> GetAllAsync();
    Task<HospitalResultDto> UploadImageAsync(long hospitalId, AttachmentCreationDto dto);
    Task<HospitalResultDto> ModifyImageAsync(long hospitalId, AttachmentCreationDto dto);
}