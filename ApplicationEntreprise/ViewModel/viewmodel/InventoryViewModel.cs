using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public class InventoryViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    public InventoryViewModel(INavigationService<TPage, T> _navigationService) : base(_navigationService) { }
}