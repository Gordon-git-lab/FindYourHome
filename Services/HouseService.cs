public class HouseService {}
using FindYourHome.Data;
using FindYourHome.Models;

namespace FindYourHome.Services;

public class HouseService
{
    public List<House> GetAll()
    {
        using var db = new AppDbContext();
        return db.Houses.OrderByDescending(h => h.CreatedAt).ToList();
    }

    public House? GetById(int id)
    {
        using var db = new AppDbContext();
        return db.Houses.Find(id);
    }

    public List<House> Search(string? keyword, string? emplacement, decimal? minLoyer, decimal? maxLoyer)
    {
        using var db = new AppDbContext();
        var q = db.Houses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
            q = q.Where(h => h.Title.Contains(keyword) || h.Description.Contains(keyword));

        if (!string.IsNullOrWhiteSpace(emplacement))
            q = q.Where(h => h.Emplacement == emplacement);

        if (minLoyer.HasValue)
            q = q.Where(h => h.Loyer >= minLoyer.Value);

        if (maxLoyer.HasValue)
            q = q.Where(h => h.Loyer <= maxLoyer.Value);

        return q.ToList();
    }

    public void Add(House house)
    {
        using var db = new AppDbContext();
        db.Houses.Add(house);
        db.SaveChanges();
    }

    public void Update(House house)
    {
        using var db = new AppDbContext();
        db.Houses.Update(house);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppDbContext();
        var h = db.Houses.Find(id);
        if (h != null)
        {
            db.Houses.Remove(h);
            db.SaveChanges();
        }
    }

    public void ToggleFavorite(int id)
    {
        using var db = new AppDbContext();
        var h = db.Houses.Find(id);
        if (h != null)
        {
            h.IsFavorite = !h.IsFavorite;
            db.SaveChanges();
        }
    }

    public List<House> GetFavorites()
    {
        using var db = new AppDbContext();
        return db.Houses.Where(h => h.IsFavorite).ToList();
    }
}
