using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public class ItemViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    public ItemViewModel(INavigationService<TPage, T> _navigationService) : base(_navigationService) { }
}

