using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MAUITutorial.Enums;

namespace MAUITutorial.Abstractions;

public interface IErrorHandlingService
{
    public Task ShowErrorAsync(ErrorType errorType, IRelayCommand command = null, string title = null,
        string message = null);
}