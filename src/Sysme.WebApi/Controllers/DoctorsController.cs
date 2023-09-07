using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.Web.Models;
using Sysme.WebApi.Controllers.Commons;

namespace Sysme.WebApi.Controllers;

public class DoctorsController : BaseController
{
    private readonly IDoctorService octorService;
    public DoctorsController(IDoctorService octorService)
    {
        this.octorService = octorService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
       => Ok(new Response
       {
           StatusCode = 200,
           Message = "Success",
           Data = await userService.AddAsync(dto)
       });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.DeleteAsync(id)
        });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UpdateAsync(dto)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAsync(id)
        });

    [Authorize(Roles = "Admin")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAllAsync(@params)
        });

}
