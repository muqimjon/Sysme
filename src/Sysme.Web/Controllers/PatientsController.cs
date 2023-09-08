using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Patients;
using Sysme.Service.DTOs.Patients;
using Sysme.Service.Interfaces;

namespace Sysme.Web.Controllers;
public class PatientsController : Controller
{
    private readonly IPatientService _service;
    private readonly IRepository<Patient> _repository;
    private readonly IMapper _mapper;   

    public PatientsController(IPatientService service, IMapper mapper, IRepository<Patient> repository)
    {
        _service = service;
        _repository = repository;
        _mapper = mapper;
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
        var res = await _repository.GetAsync(x => x.Email.Equals(dto.Email));
        if (res is null)
        {
            await _service.AddAsync(dto);
            return RedirectToAction("Index");
        }

        TempData["errorMessage"] = "This user is already exist!";    
        return View("Register");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var patient = await _service.RetrieveByIdAsync(id);
        var mappedUser = _mapper.Map<Patient>(patient);
        return View(mappedUser);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Patient model)
    {
        var mappedPatient = _mapper.Map<PatientUpdateDto>(model);
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