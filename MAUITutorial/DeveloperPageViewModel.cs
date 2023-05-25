using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;

namespace MAUITutorial;

public partial class DeveloperPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    [ObservableProperty] private int _counter;

    [RelayCommand] 
    private Task GoBack() => _navigationService.NavigateBack();

    public DeveloperPageViewModel(INavigationService navigationService) => _navigationService = navigationService;

    public override Task OnNavigatingTo(object parameter)
    {
        Counter = (int)parameter;
        return base.OnNavigatingTo(parameter);
    }
}