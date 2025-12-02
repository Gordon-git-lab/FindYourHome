public class HomeViewModel {}
using System.Collections.ObjectModel;
using FindYourHome.Models;
using FindYourHome.Services;

namespace FindYourHome.ViewModels;

public class HomeViewModel : BaseViewModel
{
    public ObservableCollection<House> Houses { get; set; } = new();

    private readonly HouseService _house = new();

    public Command LoadCommand { get; }

    public HomeViewModel()
    {
        LoadCommand = new Command(LoadData);
        LoadData();
    }

    private void LoadData()
    {
        Houses.Clear();
        foreach (var h in _house.GetAll())
            Houses.Add(h);
    }
}
