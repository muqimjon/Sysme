namespace Sysme.Service.DTOs.Schedules;

public class ScheduleUpdateDto
{
    public long Id { get; set; }
    public long DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public TimeSpan InspectionTime { get; set; }
}