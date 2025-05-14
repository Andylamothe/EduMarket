using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.repository;
using Model.table;
using System.Diagnostics;
using ViewModel.messageService;
using ViewModel.navigationService;
using System.Linq;

namespace ViewModel.viewmodel;

public partial class SignInViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<UserModel> _handler;
    private readonly MessageHandler<Permission> _permissionHandler;
    private readonly Repository<UserModel> _userRepository;

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    public string password;

    public SignInViewModel(INavigationService<TPage, T> navigationService, Repository<UserModel> _userRepository, MessageHandler<UserModel> handler, MessageHandler<Permission> permissionHandler) : base(navigationService)
    {
        this._userRepository = _userRepository;
        _permissionHandler = permissionHandler;
        _handler = handler;
    }

    [RelayCommand]
    public async void SignIn()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }
        try{
            var users = await _userRepository.GetAllAsync();
                
            var user = users.FirstOrDefault(u => u.Login == Username && u.Password == Password);
            if (user != null)
            {
                Debug.WriteLine("User found: " + user.ToString());

                Username = string.Empty;
                Password = string.Empty;
                _handler.Send("/user", user);
                _permissionHandler.Send("/permission", user.GroupeUser.Permission);

                NavigateTo("Inventory");
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
