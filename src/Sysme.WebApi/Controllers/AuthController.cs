using Microsoft.AspNetCore.Mvc;
using Sysme.Service.Interfaces;
using Sysme.WebApi.Controllers.Commons;
using Sysme.WebApi.Models;

namespace Sysme.WebApi.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GenerateTokenAsync(string email, string password)
       => Ok(new Response { Data = await authService.GenerateTokenAsync(email, password) });
}
