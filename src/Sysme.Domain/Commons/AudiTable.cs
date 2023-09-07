namespace Sysme.Domain.Commons;

public class AudiTable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public bool IsDelete { get; set; }
}
