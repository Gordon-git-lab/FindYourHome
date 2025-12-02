public class LoginViewModel {}
using FindYourHome.Services;
using FindYourHome.Helpers;

namespace FindYourHome.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private string email;
    public string Email { get => email; set => Set(ref email, value); }

    private string password;
    public string Password { get => password; set => Set(ref password, value); }

    public Command LoginCommand { get; }

    private readonly AuthService _auth = new AuthService();

    public LoginViewModel()
    {
        LoginCommand = new Command(OnLogin);
    }

    private async void OnLogin()
    {
        var user = _auth.Login(Email, Password);

        if (user == null)
        {
            await App.Current.MainPage.DisplayAlert("Erreur", "Email ou mot de passe incorrect.", "OK");
            return;
        }

        Session.CurrentUser = user;
        await Shell.Current.GoToAsync("//HomePage");
    }
}
