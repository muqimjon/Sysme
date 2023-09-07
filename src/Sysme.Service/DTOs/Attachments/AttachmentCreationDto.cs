using Microsoft.AspNetCore.Http;

namespace Sysme.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; } = default!;
}