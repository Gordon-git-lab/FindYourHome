using System.Windows.Input;
using Microsoft.Maui.Controls;
using FindYourHome.Models;
using FindYourHome.Services;
using System.Threading.Tasks;

namespace FindYourHome.ViewModels
{
    public class AddEditHouseViewModel : BaseViewModel
    {
        public House House { get; set; } = new House();
        public ICommand SaveCommand { get; }

        private readonly DatabaseService db;

        public AddEditHouseViewModel(DatabaseService databaseService)
        {
            db = databaseService;
            SaveCommand = new Command(async () => await Save());
        }

        private async Task Save()
        {
            if (House.Id == 0)
                await db.AddHouseAsync(House);
            else
                await db.UpdateHouseAsync(House);

            await Application.Current.MainPage.DisplayAlert("Succès", "Annonce sauvegardée", "OK");
            // navigate back
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
