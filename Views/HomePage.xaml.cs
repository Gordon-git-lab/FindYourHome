public partial class HomePage {}
using FindYourHome.Models;

namespace FindYourHome.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnSelect(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is House selected)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(DetailsPage)}",
                new Dictionary<string, object> { { "House", selected } }
            );
        }
    }
}
