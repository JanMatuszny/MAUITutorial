using Microsoft.Maui.Controls;

namespace MAUITutorial;

public partial class DeveloperPage : ContentPage
{
    public DeveloperPage(DeveloperPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}