using System.Collections.ObjectModel;
using FindYourHome.Models;

namespace FindYourHome.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<House> Houses { get; } = new ObservableCollection<House>();

        public MainViewModel()
        {
            // sample data for design-time and initial testing
            Houses.Add(new House { Id = 1, Title = "Appartement centre-ville", Address="Douala", Price=120000, ImageUrl = "" });
            Houses.Add(new House { Id = 2, Title = "Maison familiale", Address="Yaoundé", Price=250000, ImageUrl = "" });
        }
    }
}
