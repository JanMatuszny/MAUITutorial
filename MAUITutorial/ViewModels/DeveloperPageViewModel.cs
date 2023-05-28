using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;
using MAUITutorial.Pages;

namespace MAUITutorial.ViewModels;

public partial class DeveloperPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    [ObservableProperty] private int _counter;
    
    public DeveloperPageViewModel(INavigationService navigationService) => _navigationService = navigationService;

    public override Task OnNavigatingTo(object parameter)
    {
        Counter = (int)parameter;
        return base.OnNavigatingTo(parameter);
    }
    
    [RelayCommand] 
    private Task GoBack() => _navigationService.NavigateBack();

    [RelayCommand]
    private Task OpenErrorHandlingPage() => _navigationService.NavigateToPage<ErrorHandlingPage>();
}