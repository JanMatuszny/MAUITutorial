using MAUITutorial.Abstractions;
using Microsoft.Maui.Controls;

namespace MAUITutorial;

public partial class App : Application
{
    public App(INavigationService navigationService)
    {
        InitializeComponent();
        MainPage = new NavigationPage();
        navigationService.NavigateToPage<MainPage>();
    }
}