using Sysme.Service.DTOs.Appointments;

namespace Sysme.Service.Interfaces;

public interface IAppointmentService
{
    Task<AppointmentResultDto> AddAsync(AppointmentCreationDto dto);
    Task<AppointmentResultDto> UpdateAsync(AppointmentUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<AppointmentResultDto> GetAsync(long id);
    Task<IEnumerable<AppointmentResultDto>> GetAllAsync();
}