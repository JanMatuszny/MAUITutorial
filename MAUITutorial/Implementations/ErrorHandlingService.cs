using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;
using MAUITutorial.Enums;
using MAUITutorial.Pages;

namespace MAUITutorial.Implementations;

public class ErrorHandlingService : IErrorHandlingService
{
    private readonly INavigationService _navigationService;

    public ErrorHandlingService(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    
    public async Task ShowErrorAsync(ErrorType errorType, IRelayCommand command = null, string title = null, string message = null)
    {
        title ??= "An unexpected error occured.";
        message ??= "Please try again later.";
        
        if (errorType == ErrorType.Alert)
        {
            var result = await App.Current.MainPage.DisplayAlert(title, message, "Repeat action", "Cancel");

            if (result &&
                command is not null)
            {
                command.Execute(null);
            }
        }
        else if (errorType == ErrorType.Modal)
        {
            await _navigationService.NavigateToPageModal<ErrorPage>(command);
        }
    }
}