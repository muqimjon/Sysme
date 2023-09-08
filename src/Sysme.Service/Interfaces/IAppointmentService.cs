using Sysme.Service.DTOs.Appointments;

namespace Sysme.Service.Interfaces;

public interface IAppointmentService
{
    Task<AppointmentResultDto> AddAsync(AppointmentCreationDto dto);
    Task<AppointmentResultDto> ModifyAsync(AppointmentUpdateDto dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<AppointmentResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<AppointmentResultDto>> RetrieveAllAsync();
    Task<AppointmentResultDto> RetrieveByDoctorIdAsync(long id);
}