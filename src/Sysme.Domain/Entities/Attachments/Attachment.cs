using Sysme.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Domain.Entities.Attachments;

public class Attachment : AudiTable
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}
