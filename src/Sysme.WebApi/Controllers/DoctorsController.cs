using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.Interfaces;
using Sysme.Web.Models;
using Sysme.WebApi.Controllers.Commons;

namespace Sysme.WebApi.Controllers;

public class DoctorsController : BaseController
{
    private readonly IDoctorService doctorService;
    public DoctorsController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(DoctorCreationDto dto)
       => Ok(new Response { Data = await doctorService.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await doctorService.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(DoctorUpdateDto dto)
        => Ok(new Response { Data = await doctorService.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await doctorService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await doctorService.RetrieveAllAsync() });
}
