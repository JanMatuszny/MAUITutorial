using MAUITutorial.ViewModels;
using Microsoft.Maui.Controls;

namespace MAUITutorial.Pages;

public partial class ErrorPage : ContentPage
{
    public ErrorPage(ErrorPageViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}