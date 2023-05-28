using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;

namespace MAUITutorial.ViewModels;

public partial class ErrorPageViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private IRelayCommand _repeatCommand;

    public ErrorPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public override Task OnNavigatingTo(object parameter)
    {
        _repeatCommand = parameter as IRelayCommand;
        return base.OnNavigatingTo(parameter);
    }

    [RelayCommand]
    private Task GoBack() => _navigationService.NavigateBackModal();

    [RelayCommand]
    private void RepeatAction()
    {
        _navigationService.NavigateBackModal();
        _repeatCommand.Execute(null);
    }
}