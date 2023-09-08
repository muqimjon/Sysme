using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Appointments;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Services;

namespace Sysme.Web.Controllers;

public class AppointmentsController : Controller
{
    private readonly AppointmentService _service;

    public AppointmentsController(AppointmentService service)
    {
        _service = service;
    }

    public IActionResult Index()
        => View();

    public async Task<IActionResult> Details(long id)
        => View(await _service.RemoveByIdAsync(id));

    public IActionResult Create()
        => View();

    [HttpPost]
    public async Task<IActionResult> Cereate(AppointmentCreationDto dto)
    {
        await _service.AddAsync(dto);
        return Redirect("Index");
    }

    public IActionResult Update()
        => View();

    [HttpPost]
    public async Task<IActionResult> Update(AppointmentUpdateDto dto)
    {
        await _service.ModifyAsync(dto);
        return Redirect("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.RemoveByIdAsync(id);
        return Redirect("Index");
    }
}