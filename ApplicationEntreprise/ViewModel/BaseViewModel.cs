

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection.Metadata;
using ViewModel.navigationService;

namespace ViewModel;

public abstract partial class BaseViewModel<TPage, T> : ObservableObject where TPage : struct, Enum
{
    private readonly INavigationService<TPage, T> _navigationService;

    protected BaseViewModel(INavigationService<TPage, T> navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateTo(string namePage)
    {
        if(Enum.TryParse<TPage>(namePage, out var page))
        {
            _navigationService.NavigateTo(page);
        }
        
    }
}