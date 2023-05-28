using System.Diagnostics;
using MAUITutorial.Abstractions;

namespace MAUITutorial.Implementations;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;
    protected INavigation Navigation
    {
        get
        {
            INavigation? navigation = Application.Current?.MainPage?.Navigation;
            if (navigation is not null)
                return navigation;
            else
            {
                //This is not good!
                if (Debugger.IsAttached)
                    Debugger.Break();
                throw new Exception();
            }
        }
    }

    public NavigationService(IServiceProvider services) => _services = services;

    public async Task NavigateToPage<T>(object? parameter) where T : ContentPage
    {
        var toPage = ResolvePage<T>();

        if (toPage is not null)
        {
            toPage.NavigatedTo += OnPageNavigatedTo;
            
            var toViewModel = GetPageViewModelBase(toPage);

            if (toViewModel is not null)
            {
                await toViewModel.OnNavigatingTo(parameter);
            }

            await Navigation.PushAsync(toPage, true);

            toPage.NavigatedFrom += OnPageNavigatedFrom;
        }
        else
        {
            throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }
    }
    public async Task NavigateToPageModal<T>(object? parameter) where T : ContentPage
    {
        var toPage = ResolvePage<T>();

        if (toPage is not null)
        {
            toPage.NavigatedTo += OnPageNavigatedTo;
            
            var toViewModel = GetPageViewModelBase(toPage);

            if (toViewModel is not null)
            {
                await toViewModel.OnNavigatingTo(parameter);
            }

            await Navigation.PushModalAsync(toPage, true);

            toPage.NavigatedFrom += OnPageNavigatedFrom;
        }
        else
        {
            throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }
    }

    public async Task NavigateToPage<T>() where T : ContentPage
    {
        var toPage = ResolvePage<T>();

        if (toPage is not null)
        {
            toPage.NavigatedTo += OnPageNavigatedTo;
            
            var toViewModel = GetPageViewModelBase(toPage);

            if (toViewModel is not null)
            {
                await toViewModel.OnNavigatingTo(null);
            }

            await Navigation.PushAsync(toPage, true);

            toPage.NavigatedFrom += OnPageNavigatedFrom;
        }
        else
        {
            throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }
    }

    private ViewModelBase? GetPageViewModelBase(ContentPage page)
        => page?.BindingContext as ViewModelBase;

    private async void OnPageNavigatedTo(object sender, NavigatedToEventArgs e)
        => await CallNavigatedTo(sender as ContentPage);

    private Task CallNavigatedTo(ContentPage? page)
    {
        var fromViewModel = GetPageViewModelBase(page);

        if (fromViewModel is not null)
        {
            return fromViewModel.OnNavigatedTo();
        }

        return Task.CompletedTask;
    }

    private async void OnPageNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        var isForwardNavigation = Navigation.NavigationStack.Count > 1
                                  && Navigation.NavigationStack[^2] == sender;

        if (sender is ContentPage thisPage)
        {
            if (!isForwardNavigation)
            {
                thisPage.NavigatedTo += OnPageNavigatedTo;
                thisPage.NavigatedFrom += OnPageNavigatedFrom;
            }

            await CallNavigatedFrom(thisPage, isForwardNavigation);
        }
    }

    private Task CallNavigatedFrom(ContentPage page, bool isForward)
    {
        var fromViewModel = GetPageViewModelBase(page);

        if (fromViewModel is not null)
        {
            return fromViewModel.OnNavigatingFrom(isForward);
        }

        return Task.CompletedTask;
    }

    public Task NavigateBack()
    {
        if (Navigation.NavigationStack.Count > 1)
        {
            return Navigation.PopAsync();
        }

        throw new InvalidOperationException("No pages to navigate back to!");
    }
    
    public Task NavigateBackModal()
    {
        if (Navigation.ModalStack.Count > 0)
        {
            return Navigation.PopModalAsync();
        }

        throw new InvalidOperationException("No pages to navigate back to!");
    }

    private T? ResolvePage<T>() where T : ContentPage => _services.GetService<T>();
}