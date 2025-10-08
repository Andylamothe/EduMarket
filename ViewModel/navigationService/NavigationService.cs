namespace ViewModel.navigationService;

public class NavigationService<TPage, TView> : INavigationService<TPage, TView> where TPage : Enum
{
    private readonly Dictionary<TPage, Func<TView>> _pages = new();
    private readonly Dictionary<TPage, TView> _views = new();
    public Action<TView>? OnNavigate { get; set; }

    public void DisposeView(TPage page)
    {
        if (_views.TryGetValue(page, out var view))
        {
            if (view is IDisposable disposableView)
            {
                disposableView.Dispose();
            }
            _views.Remove(page);
        }
    }

    public void NavigateTo(TPage page)
    {
        if (_pages.TryGetValue(page, out var factory))
        {
            var view = factory();
            _views[page] = view;
            OnNavigate?.Invoke(view);
        }
    }

    public INavigationService<TPage, TView> RegisterPage(TPage page, Func<TView> viewFactory)
    {
        _pages[page] = viewFactory;
        return this;
    }
}