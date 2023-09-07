using Sysme.Domain.Commons;

namespace Sysme.Domain.Entities.Attachments;

public class Attachment : AudiTable
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}
