using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.messageService;
using ViewModel.navigationService;
using ViewModel.viewModelItem;

namespace ViewModel.viewmodel;

public partial class ItemViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<ViewModelItem> _handler;

    [ObservableProperty]
    private ViewModelItem item;

    public ItemViewModel(INavigationService<TPage, T> _navigationService, MessageHandler<ViewModelItem> handler) : base(_navigationService) 
    {
        this._handler = handler;
        _handler.RegisterChannel("/item", (_, msg) => Item = msg)
            .Listen(this);
    }
}

