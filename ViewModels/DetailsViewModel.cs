public class DetailsViewModel {}
using FindYourHome.Models;
using FindYourHome.Services;

namespace FindYourHome.ViewModels;

public class DetailsViewModel : BaseViewModel
{
    private House selectedHouse;
    public House SelectedHouse { get => selectedHouse; set => Set(ref selectedHouse, value); }

    private readonly HouseService _houses = new();

    public Command ToggleFavoriteCommand { get; }

    public DetailsViewModel()
    {
        ToggleFavoriteCommand = new Command(ToggleFavorite);
    }

    private void ToggleFavorite()
    {
        _houses.ToggleFavorite(SelectedHouse.Id);
        SelectedHouse.IsFavorite = !SelectedHouse.IsFavorite;
        OnPropertyChanged(nameof(SelectedHouse));
    }
}
