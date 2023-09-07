using Sysme.Service.DTOs.Attachments;
using Sysme.Service.DTOs.Hospitals;

namespace Sysme.Service.Interfaces;

public interface IHospitalService
{
    Task<HospitalResultDto> AddAsync(HospitalCreationDto dto);
    Task<HospitalResultDto> ModifyAsync(HospitalUpdateDto dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<HospitalResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<HospitalResultDto>> RetrieveAllAsync();
    Task<HospitalResultDto> UploadImageAsync(long hospitalId, AttachmentCreationDto dto);
    Task<HospitalResultDto> ModifyImageAsync(long hospitalId, AttachmentCreationDto dto);
}