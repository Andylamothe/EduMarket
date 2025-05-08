using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.messageService;
using ViewModel.navigationService;

namespace ViewModel.viewmodel;

public partial class SignInViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<string> _handler = new();

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    public SignInViewModel(INavigationService<TPage, T> navigationService) : base(navigationService)
    {
        _handler.RegisterChannel("username", (_, msg) => Username = msg)
            .RegisterChannel("password", (_, msg) => Password = msg)
            .Listen(this);
    }
}
