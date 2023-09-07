using Sysme.Service.DTOs.Schedules;

namespace Sysme.Service.Interfaces;

public interface IScheduleService
{
    Task<ScheduleResultDto> AddAsync(ScheduleCreationDto dto);
    Task<ScheduleResultDto> ModifyAsync(ScheduleUpdateDto dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<ScheduleResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<ScheduleResultDto>> RetrieveAllAsync();
}