public class House {}
namespace FindYourHome.Models;

public class House
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Emplacement { get; set; }
    public decimal Loyer { get; set; }
    public int NbPieces { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool IsFavorite { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}