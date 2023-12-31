﻿using Sysme.Service.DTOs.Attachments;

namespace Sysme.Service.DTOs.Hospitals;

public class HospitalResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public AttachmentResultDto Attachment { get; set; } = default!;
}