using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Abstractions;
using MAUITutorial.Enums;

namespace MAUITutorial.ViewModels;

public partial class ErrorHandlingPageViewModel : ViewModelBase
{
    private readonly IErrorHandlingService _errorHandlingService;

    [ObservableProperty] private bool _isRunning;
    
    public ErrorHandlingPageViewModel(IErrorHandlingService errorHandlingService)
    {
        _errorHandlingService = errorHandlingService;
    }
    
    [RelayCommand]
    private async Task FailAction()
    {
        try
        {
            throw new InvalidOperationException();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            await _errorHandlingService.ShowErrorAsync(ErrorType.Alert, FailActionCommand);
        }
    }

    [RelayCommand]
    private async Task FailOpeningPage()
    {
        try
        {
            IsRunning = true;

            await Task.Delay(TimeSpan.FromSeconds(2));

            IsRunning = false;
            
            throw new InvalidOperationException();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            await _errorHandlingService.ShowErrorAsync(ErrorType.Modal, FailOpeningPageCommand);
        }
    }
}