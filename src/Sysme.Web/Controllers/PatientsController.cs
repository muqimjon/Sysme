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

    public PatientsController(IPatientService service, IRepository<Patient> repository)
    {
        _service = service;
        _repository = repository;
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
        if(res is null) 
            await _service.AddAsync(dto);

        TempData["errorMessage"] = "This user is already exist!";    
        return View("Register");
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