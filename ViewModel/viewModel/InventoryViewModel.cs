using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Model.repository;
using Model.table;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ViewModel.messageService;
using ViewModel.navigationService;
using ViewModel.viewModelItem;

namespace ViewModel.viewmodel;

public partial class InventoryViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<UserModel> _handler;
    private readonly Repository<Item> itemRepository;
    public ObservableCollection<ViewModelItem> Items { get; }

    [ObservableProperty]
    private UserModel user;

    [ObservableProperty]
    private ViewModelItem selectedItem;

    partial void OnSelectedItemChanged(ViewModelItem? value)
    {
        SelectedItem = value;
        Debug.WriteLine(value);
    }

    [ObservableProperty]
    private ViewModelItem newItem;
    public InventoryViewModel(INavigationService<TPage, T> _navigationService, Repository<Item> itemRepository, MessageHandler<UserModel> handler) : base(_navigationService) 
    {
        this.itemRepository = itemRepository;
        this.Items = new ObservableCollection<ViewModelItem>();
        this._handler = handler;
        this.newItem = new ViewModelItem()
        {
            Name = "",
            Description = "",
            Price = 0
        };
        _handler.RegisterChannel("/user", async (_, msg) => { User = msg;  LoadItemsAsync(msg); })
            .Listen(this);
    }

    [RelayCommand]
    public async void AddItem()
    {
        var item = new Item
        {
            UserId = User.UserId,
            Name = NewItem.Name,
            Description = NewItem.Description,
            Price = NewItem.Price
        };

        await itemRepository.AddAsync(item);
        Items.Add(new ViewModelItem(item));
        this.NewItem.Name = string.Empty;
        this.NewItem.Description = string.Empty;
        this.NewItem.Price = 0;
    }

    private async Task LoadItemsAsync(UserModel user)
    {
        var items = await itemRepository.GetAllAsync();
        if (items == null)
        {
            return;
        }
        Items.Clear();
        var user_item = items
            .Where(i => i.UserId == user.UserId)
            .ToList();
        foreach(var item in user_item)
        {
            Items.Add(new ViewModelItem(item));
        }
    }
}