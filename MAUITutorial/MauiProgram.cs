using MAUITutorial.Abstractions;
using MAUITutorial.Implementations;
using MAUITutorial.Pages;
using MAUITutorial.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUITutorial;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<DeveloperPage>();
        builder.Services.AddTransient<DeveloperPageViewModel>();
        builder.Services.AddTransient<ErrorHandlingPage>();
        builder.Services.AddTransient<ErrorHandlingPageViewModel>();
        builder.Services.AddTransient<ErrorPage>();
        builder.Services.AddTransient<ErrorPageViewModel>();
        
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IErrorHandlingService, ErrorHandlingService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}