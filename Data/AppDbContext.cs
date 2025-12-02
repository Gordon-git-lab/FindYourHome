public class AppDbContext {}
using Microsoft.EntityFrameworkCore;
using FindYourHome.Models;
using System.IO;

namespace FindYourHome.Data;

public class AppDbContext : DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly string _dbPath;

    public AppDbContext()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        _dbPath = Path.Combine(folder, "findyourhome.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}
