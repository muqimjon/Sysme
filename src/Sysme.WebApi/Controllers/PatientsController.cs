using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Interfaces;
using Sysme.WebApi.Controllers.Commons;
using Sysme.WebApi.Models;

namespace Sysme.WebApi.Controllers;

public class PatientsController : BaseController
{
    private readonly IPatientService patientservice;
    public PatientsController(IPatientService patientservice)
    {
        this.patientservice = patientservice;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(PatientCreationDto dto)
       => Ok(new Response { Data = await patientservice.AddAsync(dto) });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await patientservice.RemoveByIdAsync(id) });

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(PatientUpdateDto dto)
        => Ok(new Response { Data = await patientservice.ModifyAsync(dto) });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response { Data = await patientservice.RetrieveByIdAsync(id) });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response { Data = await patientservice.RetrieveAllAsync() });
}