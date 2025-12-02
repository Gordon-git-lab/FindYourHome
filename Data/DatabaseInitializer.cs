public static class DatabaseInitializer {}
using FindYourHome.Models;
using System.Security.Cryptography;
using System.Text;

namespace FindYourHome.Data;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using var db = new AppDbContext();

        db.Database.EnsureCreated();

        if (!db.Houses.Any())
        {
            db.Houses.AddRange(new List<House>
            {
                new House { Title="Maison moderne à Bonapriso", Emplacement="Bonapriso", Loyer=250000, NbPieces=3, Description="Maison moderne bien située, sécurisée, proche commerces.", ImageUrl="house1.jpg" },
                new House { Title="Studio à Makepe", Emplacement="Makepe", Loyer=80000, NbPieces=1, Description="Studio propre et accessible, idéal étudiant.", ImageUrl="house2.jpg" },
                new House { Title="Appartement 2 chambres à Logpom", Emplacement="Logpom", Loyer=150000, NbPieces=2, Description="Bel appartement dans quartier calme.", ImageUrl="house3.jpg" }
            });

            db.SaveChanges();
        }

        if (!db.Users.Any())
        {
            db.Users.Add(new User
            {
                Nom = "Admin",
                Email = "admin@fyh.com",
                PasswordHash = Hash("admin123")
            });

            db.SaveChanges();
        }
    }

    private static string Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }
}
