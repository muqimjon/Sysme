using Sysme.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Domain.Entities.Schedules;

public class Schedule : AudiTable
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
}
