using Microsoft.Maui.Controls;

namespace FindYourHome
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
