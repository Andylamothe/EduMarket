using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model.repository;
using Model.table;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ViewModel.messageService;
using ViewModel.navigationService;
using ViewModel.viewModelItem;

namespace ViewModel.viewmodel;

public partial class CatalogueViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly MessageHandler<ViewModelItem> _handler;
    private readonly Repository<Item> itemRepository;
    public ObservableCollection<ViewModelItem> Items { get; }
    
    [ObservableProperty]
    private ViewModelItem selectedItem;

    partial void OnSelectedItemChanged(ViewModelItem? value)
    {
        if (value is not null)
        {
            _handler.Send("/item", value);
            NavigateTo("Item");
            SelectedItem = null;
        }
    }

    public CatalogueViewModel(INavigationService<TPage, T> _navigationService, Repository<Item> itemRepository, MessageHandler<ViewModelItem> handler) : base(_navigationService) 
    {
        this.itemRepository = itemRepository;
        this.Items = new ObservableCollection<ViewModelItem>();
        this._handler = handler;
        LoadItemsAsync();
    }

    private async Task LoadItemsAsync()
    {
        var items = await itemRepository.GetAllAsync();
        if(items == null)
        {
            return;
        }
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(new ViewModelItem(item));
        }
    }

    [RelayCommand]
    public async void ReloadItemsAsync()
    {
        Debug.WriteLine("Reloading items...");
        var items = await itemRepository.GetAllAsync();
        if (items == null)
        {
            return;
        }
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(new ViewModelItem(item));
        }
    }
}
