using Sysme.Domain.Commons;
using Sysme.Domain.Entities.Doctors;

namespace Sysme.Domain.Entities.Schedules;

public class Schedule : AudiTable
{
    public TimeSpan EndTime { get; set; }
    public TimeSpan StartTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int InspectionTime { get; set; }

    public long DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;
}