public class ProfileViewModel {}
using FindYourHome.Helpers;

namespace FindYourHome.ViewModels;

public class ProfileViewModel : BaseViewModel
{
    public string Nom => Session.CurrentUser?.Nom ?? "";
    public string Email => Session.CurrentUser?.Email ?? "";
    public bool IsOwner => Session.CurrentUser?.IsOwner ?? false;

    public Command LogoutCommand { get; }

    public ProfileViewModel()
    {
        LogoutCommand = new Command(OnLogout);
    }

    private async void OnLogout()
    {
        Session.CurrentUser = null;
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
