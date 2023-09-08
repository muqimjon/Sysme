using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.Web.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.Xml;

namespace Sysme.Web.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService authService
    public HomeController(IAuthService authService)
    {
        this.authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Login(string email, string password)
        => View(await authService.GenerateTokenAsync(email, password));    
}