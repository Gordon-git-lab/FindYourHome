public partial class App {}
using FindYourHome.Data;

namespace FindYourHome;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        DatabaseInitializer.Initialize();
        MainPage = new AppShell();
    }
}