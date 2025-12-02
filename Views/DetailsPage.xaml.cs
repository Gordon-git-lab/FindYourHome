public partial class DetailsPage {}
using FindYourHome.Models;
using FindYourHome.ViewModels;

namespace FindYourHome.Views;

[QueryProperty(nameof(House), "House")]
public partial class DetailsPage : ContentPage
{
    public House House 
    { 
        set => (BindingContext as DetailsViewModel).SelectedHouse = value;
    }

    public DetailsPage()
    {
        InitializeComponent();
    }
}
