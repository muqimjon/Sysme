using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.Web.Models;
using System.Diagnostics;

namespace Sysme.Web.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService authService;
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

    /*public IActionResult Login()
    {
        return View();
    }*/
    public async Task<IActionResult> Login(string email, string password)
    {
        var checkEmail = email;
        var checkPassword = password;   
        var check = await authService.CheckLogin(checkEmail, checkPassword);
        if (check is true)
        {
            return RedirectToAction("Index","Patients");
        }
        else
        {
            TempData["errorMessage"] = "Invalid email or password!";
            return View("Login");
        }
    }
}