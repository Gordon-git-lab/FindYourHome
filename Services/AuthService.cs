public class AuthService {}
using System.Security.Cryptography;
using System.Text;
using FindYourHome.Models;

namespace FindYourHome.Services;

public class AuthService
{
    private readonly UserService _users = new UserService();

    public bool Register(string nom, string email, string password, bool isOwner = false)
    {
        if (_users.EmailExists(email)) return false;

        var user = new User
        {
            Nom = nom,
            Email = email,
            PasswordHash = Hash(password),
            IsOwner = isOwner
        };

        _users.Add(user);
        return true;
    }

    public User? Login(string email, string password)
    {
        var user = _users.GetByEmail(email);
        if (user == null) return null;

        return user.PasswordHash == Hash(password) ? user : null;
    }

    private static string Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }
}
