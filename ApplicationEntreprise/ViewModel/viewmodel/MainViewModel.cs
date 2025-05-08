using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public class MainViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    public MainViewModel(INavigationService<TPage, T> navigationService) : base(navigationService)
    {
    }
}
