using Sysme.Service.DTOs.Schedules;

namespace Sysme.Service.Interfaces;

public interface IScheduleService
{
    Task<ScheduleResultDto> AddAsync(ScheduleCreationDto dto);
    Task<ScheduleResultDto> UpdateAsync(ScheduleUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<ScheduleResultDto> GetAsync(long id);
    Task<IEnumerable<ScheduleResultDto>> GetAllAsync();
}