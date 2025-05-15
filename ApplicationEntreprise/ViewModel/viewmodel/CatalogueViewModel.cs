using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public class CatalogueViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    public CatalogueViewModel(INavigationService<TPage, T> _navigationService) : base(_navigationService) { }
}
