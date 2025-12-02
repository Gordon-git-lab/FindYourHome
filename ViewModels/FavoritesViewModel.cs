public class FavoritesViewModel {}
using System.Collections.ObjectModel;
using FindYourHome.Models;
using FindYourHome.Services;

namespace FindYourHome.ViewModels;

public class FavoritesViewModel : BaseViewModel
{
    public ObservableCollection<House> Favorites { get; set; } = new();

    private readonly HouseService _houses = new();

    public Command LoadCommand { get; }

    public FavoritesViewModel()
    {
        LoadCommand = new Command(LoadData);
        LoadData();
    }

    private void LoadData()
    {
        Favorites.Clear();
        foreach (var h in _houses.GetFavorites())
            Favorites.Add(h);
    }
}
