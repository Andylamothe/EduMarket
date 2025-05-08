

using CommunityToolkit.Mvvm.Input;
using ViewModel.messageService;
using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public partial class SignUpViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<string> _handler = new();

    public SignUpViewModel(INavigationService<TPage, T> _navigationService) : base(_navigationService) { }

    [RelayCommand]
    public void SendData()
    {
        _handler.Send("username", "tata");
    }
}
