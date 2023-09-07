using Sysme.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.Service.DTOs.Appointments;
using Sysme.WebApi.Controllers.Commons;

namespace Sysme.WebApi.Controllers;

public class AppointmentsController : BaseController
{
    private readonly IAppointmentService AppointmentService;
    public AppointmentsController(IAppointmentService AppointmentService)
    {
        this.AppointmentService = AppointmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AppointmentCreationDto dto)
       => Ok(new Response { Data = await AppointmentService.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await AppointmentService.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AppointmentUpdateDto dto)
        => Ok(new Response { Data = await AppointmentService.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await AppointmentService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await AppointmentService.RetrieveAllAsync() });
}