namespace Sysme.Service.Helpers;

public static class PasswordHasher
{
    public static string Hash(this string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public static bool Verify(this string password, string hash)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}