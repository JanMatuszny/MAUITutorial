using MAUITutorial.ViewModels;

namespace MAUITutorial.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}