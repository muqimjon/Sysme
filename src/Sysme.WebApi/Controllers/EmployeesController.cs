using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Employees;
using Sysme.WebApi.Controllers.Commons;
using Sysme.WebApi.Models;

namespace Sysme.WebApi.Controllers;

public class EmployeesController : BaseController
{
    private readonly IEmployeeService employeeService;
    public EmployeesController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(EmployeeCreationDto dto)
       => Ok(new Response { Data = await employeeService.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await employeeService.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(EmployeeUpdateDto dto)
        => Ok(new Response { Data = await employeeService.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await employeeService.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await employeeService.RetrieveAllAsync() });
}