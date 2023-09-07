using Sysme.Domain.Entities.Attachments;
using Sysme.Service.DTOs.Attachments;
using Sysme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysme.Service.Services;

public class AttachmentService : IAttachmentService
{
    public Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<bool> RemoveAsync(Attachment attachment)
    {
        throw new NotImplementedException();
    }
}