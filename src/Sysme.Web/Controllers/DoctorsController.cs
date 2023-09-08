using Microsoft.AspNetCore.Mvc;
using Sysme.Service.DTOs.Doctors;
using Sysme.Service.Interfaces;

namespace Sysme.Web.Controllers;

public class DoctorsController : Controller
{
    private readonly IDoctorService _service;

    public DoctorsController(IDoctorService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
        => View(await _service.RetrieveAllAsync());

    public async Task<IActionResult> Details(long id)
        => View(await _service.RemoveByIdAsync(id));

    public IActionResult Create()
        => View();

    [HttpPost]
    public async Task<IActionResult> Cereate(DoctorCreationDto dto)
    {
        await _service.AddAsync(dto);
        return Redirect("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Search(string query)
    {
        var existQuery = query;
        var result = await _service.SearchByQuery(existQuery);
        return View("Detail", result);
    }

    public IActionResult Update()
        => View();

    [HttpPost]
    public async Task<IActionResult> Update(DoctorUpdateDto dto)
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