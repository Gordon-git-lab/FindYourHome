public class RegisterViewModel {}
using FindYourHome.Services;

namespace FindYourHome.ViewModels;

public class RegisterViewModel : BaseViewModel
{
    private string nom;
    public string Nom { get => nom; set => Set(ref nom, value); }

    private string email;
    public string Email { get => email; set => Set(ref email, value); }

    private string password;
    public string Password { get => password; set => Set(ref password, value); }

    private bool isOwner;
    public bool IsOwner { get => isOwner; set => Set(ref isOwner, value); }

    public Command RegisterCommand { get; }

    private readonly AuthService _auth = new AuthService();

    public RegisterViewModel()
    {
        RegisterCommand = new Command(OnRegister);
    }

    private async void OnRegister()
    {
        if (_auth.Register(Nom, Email, Password, IsOwner))
        {
            await App.Current.MainPage.DisplayAlert("Succès", "Compte créé !", "OK");
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Erreur", "Cet email existe déjà.", "OK");
        }
    }
}
