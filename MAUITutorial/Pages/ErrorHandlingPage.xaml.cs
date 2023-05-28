using MAUITutorial.ViewModels;

namespace MAUITutorial.Pages;

public partial class ErrorHandlingPage : ContentPage
{
    public ErrorHandlingPage(ErrorHandlingPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}