using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUITutorial;

public abstract class ViewModelBase : ObservableObject
{
    public virtual Task OnNavigatingTo(object? parameter)
        => Task.CompletedTask;
    
    public virtual Task OnNavigatingFrom(bool isForwardNavigation)
        => Task.CompletedTask;
    
    public virtual Task OnNavigatedTo()
        => Task.CompletedTask;
}