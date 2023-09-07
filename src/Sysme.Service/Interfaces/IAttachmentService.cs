using Sysme.Domain.Entities.Attachments;
using Sysme.Service.DTOs.Attachments;

namespace Sysme.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}