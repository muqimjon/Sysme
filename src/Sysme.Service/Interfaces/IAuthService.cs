namespace Sysme.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string email, string password);
    Task<bool> CheckLogin(string email, string password);
}
