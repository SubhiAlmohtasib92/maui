using Ethel.Views;
using CommunityToolkit.Maui;
using Ethel.Auth;

namespace Ethel;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
        builder.Services.AddScoped<MainPage>();
        builder.Services.AddScoped<LandingPage>();
        builder.Services.RegisterServices();
        builder.UseMauiCommunityToolkit();
        return builder.Build();
    }
}