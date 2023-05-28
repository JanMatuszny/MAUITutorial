using MAUITutorial.Abstractions;
using MAUITutorial.Pages;

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