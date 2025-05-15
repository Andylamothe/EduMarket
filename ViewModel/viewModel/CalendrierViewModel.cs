using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public class CalendrierViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    public CalendrierViewModel(INavigationService<TPage, T> _navigationService) : base(_navigationService) { }
}
