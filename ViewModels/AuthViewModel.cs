using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using FindYourHome.Services;

namespace FindYourHome.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private string email;
        public string Email { get => email; set => SetProperty(ref email, value); }

        private string password;
        public string Password { get => password; set => SetProperty(ref password, value); }

        private string fullName;
        public string FullName { get => fullName; set => SetProperty(ref fullName, value); }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private readonly AuthService authService;

        public AuthViewModel()
        {
            authService = new AuthService();
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
        }

        private async Task Login()
        {
            var ok = await authService.LoginAsync(Email, Password);
            if (ok)
            {
                // Navigate to home
                await Application.Current.MainPage.DisplayAlert("Succès", "Connecté", "OK");
                Application.Current.MainPage = new AppShell();
            }
            else
                await Application.Current.MainPage.DisplayAlert("Erreur", "Identifiants invalides", "OK");
        }

        private async Task Register()
        {
            var ok = await authService.RegisterAsync(FullName, Email, Password);
            if (ok)
                await Application.Current.MainPage.DisplayAlert("Succès", "Compte créé", "OK");
            else
                await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de créer le compte", "OK");
        }
    }
}
