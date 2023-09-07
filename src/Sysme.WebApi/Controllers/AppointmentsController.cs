using Sysme.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.Service.DTOs.Appointments;
using Sysme.WebApi.Controllers.Commons;

namespace Sysme.WebApi.Controllers;

public class AppointmentsController : BaseController
{
    private readonly IAppointmentService appointmentService;
    public AppointmentsController(IAppointmentService appointmentService)
    {
        this.appointmentService = appointmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AppointmentCreationDto dto)
       => Ok(new Response { Data = await appointmentService.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await appointmentService.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AppointmentUpdateDto dto)
        => Ok(new Response { Data = await appointmentService.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await appointmentService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await appointmentService.RetrieveAllAsync() });
}