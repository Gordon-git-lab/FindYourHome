public class UserService {}
using FindYourHome.Data;
using FindYourHome.Models;

namespace FindYourHome.Services;

public class UserService
{
    public User? GetByEmail(string email)
    {
        using var db = new AppDbContext();
        return db.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool EmailExists(string email)
    {
        using var db = new AppDbContext();
        return db.Users.Any(u => u.Email == email);
    }

    public void Add(User user)
    {
        using var db = new AppDbContext();
        db.Users.Add(user);
        db.SaveChanges();
    }
}
