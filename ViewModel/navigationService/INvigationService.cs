

namespace ViewModel.navigationService;

public interface INavigationService<TPage, TView> where TPage : Enum
{
    public void NavigateTo(TPage page);

    public INavigationService<TPage, TView> RegisterPage(TPage page, Func<TView> viewFactory);

    public void DisposeView(TPage page);

    public Action<TView>? OnNavigate { get; set; }
}

