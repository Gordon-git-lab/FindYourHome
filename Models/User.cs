public class User {}
namespace FindYourHome.Models;

public class User
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsOwner { get; set; } = false;
}
