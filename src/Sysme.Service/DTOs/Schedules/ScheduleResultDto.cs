using Sysme.Service.DTOs.Doctors;

namespace Sysme.Service.DTOs.Schedules;

public class ScheduleResultDto
{
    public long Id { get; set; }
    public long DoctorId { get; set; }
    public DoctorResultDto Doctor { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int InspectionTime { get; set; }
}
