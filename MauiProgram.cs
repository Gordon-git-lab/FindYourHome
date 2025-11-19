using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FindYourHome.Services;
using FindYourHome.ViewModels;

namespace FindYourHome
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => { });
            // Register services and viewmodels
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddTransient<MainViewModel>();
            return builder.Build();
        }
    }
}
