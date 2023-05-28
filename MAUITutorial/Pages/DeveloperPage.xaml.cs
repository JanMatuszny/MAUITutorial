using MAUITutorial.ViewModels;

namespace MAUITutorial.Pages;

public partial class DeveloperPage : ContentPage
{
    public DeveloperPage(DeveloperPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}