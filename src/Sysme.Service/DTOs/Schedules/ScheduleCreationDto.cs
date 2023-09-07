namespace Sysme.Service.DTOs.Schedules;

public class ScheduleCreationDto
{
    public long DoctorId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int InspectionTime { get; set; }
}