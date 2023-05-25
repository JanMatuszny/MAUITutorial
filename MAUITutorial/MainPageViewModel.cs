using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;

namespace MAUITutorial;

public partial class MainPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private int _counter;

    [RelayCommand]
    private Task OpenDeveloperPage() => _navigationService.NavigateToPage<DeveloperPage>(Counter);
    
    [RelayCommand]
    private void IncrementCounter() => Counter++;

    public MainPageViewModel(INavigationService navigationService) => _navigationService = navigationService;
}