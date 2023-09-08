using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sysme.Domain.Entities.Patients;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Interfaces;

namespace Sysme.Web.Controllers;
public class PatientsController : Controller
{
    private readonly IPatientService _service;
    private readonly IMapper mapper;

    public PatientsController(IPatientService service, IMapper mapper)
    {
        _service = service;
        this.mapper = mapper;
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

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var patient = await _service.RetrieveByIdAsync(id);
        var mappedUser = mapper.Map<Patient>(patient);
        return View(mappedUser);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Patient model)
    {
        var mappedPatient = mapper.Map<PatientUpdateDto>(model);
        var patient = await _service.ModifyAsync(mappedPatient);
        return RedirectToAction("Index");
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.RemoveByIdAsync(id);
        return Redirect("Index");
    }
}