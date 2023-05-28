using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MAUITutorial.Abstractions;

public interface INavigationService
{
    public Task NavigateToPage<T>(object? parameter) where T : ContentPage;
    public Task NavigateToPageModal<T>(object? parameter) where T : ContentPage;
    public Task NavigateToPage<T>() where T : ContentPage;
    public Task NavigateBack();
    public Task NavigateBackModal();
}