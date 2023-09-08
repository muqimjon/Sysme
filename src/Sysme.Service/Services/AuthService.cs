using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sysme.Data.IRepositories;
using Sysme.Domain.Entities.Employees;
using Sysme.Domain.Entities.Patients;
using Sysme.Service.Exceptions;
using Sysme.Service.Helpers;
using Sysme.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sysme.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<Employee> repository;
    private readonly IRepository<Patient> patientRepository;
    private readonly IConfiguration configuration;
    public AuthService(IRepository<Employee> repository, IConfiguration configuration, IRepository<Patient> patientRepository)
    {
        this.repository = repository;
        this.configuration = configuration;
        this.patientRepository = patientRepository;
    }

    public async Task<bool> CheckLogin(string email, string password)
    {
        var employee = await patientRepository.GetAsync(x => x.Email.Equals(email));
        if(employee is null)
            return false;

        bool varifiedPassword = PasswordHasher.Verify(password, employee.Password);
        if (!varifiedPassword)
            return false;

        return true;
    }

    public async Task<string> GenerateTokenAsync(string email, string password)
    {
        var employee = await repository.GetAsync(x => x.Email.Equals(email))
            ?? throw new NotFoundException("Not found!");

        bool varifiedPassword = PasswordHasher.Verify(password, employee.Password);
        if (!varifiedPassword)
            throw new NotFoundException($"{email} is not valid or {password}.");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim("Email", employee.Email),
             new Claim("Id", employee.Id.ToString()),
             new Claim(ClaimTypes.Role, employee.Role.ToString())
          }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        string result = tokenHandler.WriteToken(token);
        return result;
    }
}
