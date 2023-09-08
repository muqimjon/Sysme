using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Interfaces;

namespace Sysme.Web.Controllers;
public class PatientsController : Controller
{
    private readonly IPatientService _service;

    public PatientsController(IPatientService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var patients = await _service.RetrieveAllAsync();
        return View(patients);
    }

    public async Task<IActionResult> Details(long id)
        => View(await _service.RemoveByIdAsync(id));

    public IActionResult Register()
        => View();

    [HttpPost]
    public async Task<IActionResult> Create(PatientCreationDto dto)
    {
        await _service.AddAsync(dto);
        return Redirect("Index");
    }

    public IActionResult Update()
        => View();

    [HttpPost]
    public async Task<IActionResult> Update(PatientUpdateDto dto)
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