using Microsoft.Maui.Controls;

namespace MAUITutorial;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}