using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Schedules;
using Sysme.Service.Interfaces;
using Sysme.WebApi.Controllers.Commons;
using Sysme.WebApi.Models;

namespace Sysme.WebApi.Controllers;

public class SchedulesController : BaseController
{
    private readonly IScheduleService scheduleService;
    public SchedulesController(IScheduleService scheduleService)
    {
        this.scheduleService = scheduleService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(ScheduleCreationDto dto)
       => Ok(new Response { Data = await scheduleService.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await scheduleService.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ScheduleUpdateDto dto)
        => Ok(new Response { Data = await scheduleService.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await scheduleService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await scheduleService.RetrieveAllAsync() });
}