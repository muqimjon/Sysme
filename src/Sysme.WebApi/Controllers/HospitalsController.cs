using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Attachments;
using Sysme.Service.DTOs.Hospitals;
using Sysme.Service.Interfaces;
using Sysme.WebApi.Controllers.Commons;
using Sysme.WebApi.Models;

namespace Sysme.WebApi.Controllers;


public class HospitalsController : BaseController
{
    private readonly IHospitalService HospitalService;
    public HospitalsController(IHospitalService HospitalService)
    {
        this.HospitalService = HospitalService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(HospitalCreationDto dto)
        => Ok(new Response { Data = await HospitalService.AddAsync(dto) });

    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(HospitalUpdateDto dto)
        => Ok(new Response { Data = await HospitalService.ModifyAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await HospitalService.RemoveByIdAsync(id) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response { Data = await HospitalService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await HospitalService.RetrieveAllAsync() });

    [HttpPost("upload-photo")]
    public async Task<IActionResult> UploadImage(long id, [FromForm] AttachmentCreationDto dto)
        => Ok(new Response { Data = await HospitalService.UploadImageAsync(id, dto) });

    [HttpPost("change-photo")]
    public async Task<IActionResult> ChangeImage(long id, [FromForm] AttachmentCreationDto dto)
        => Ok(new Response { Data = await HospitalService.ModifyImageAsync(id, dto) });
}