using Sysme.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Domain.Entities.Patients;

public class Patient : AudiTable
{
    public string FirstName { get; set; }
}
