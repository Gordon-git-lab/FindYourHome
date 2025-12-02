public class AddHouseViewModel {}
using FindYourHome.Models;
using FindYourHome.Services;

namespace FindYourHome.ViewModels;

public class AddHouseViewModel : BaseViewModel
{
    public House NewHouse { get; set; } = new();

    public Command SaveCommand { get; }

    private readonly HouseService _houses = new();

    public AddHouseViewModel()
    {
        SaveCommand = new Command(OnSave);
    }

    private async void OnSave()
    {
        if (string.IsNullOrWhiteSpace(NewHouse.Title))
        {
            await App.Current.MainPage.DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        _houses.Add(NewHouse);
        await Shell.Current.GoToAsync("..");
    }
}
