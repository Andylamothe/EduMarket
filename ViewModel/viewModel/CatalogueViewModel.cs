using CommunityToolkit.Mvvm.Input;
using Model.repository;
using Model.table;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ViewModel.navigationService;
using ViewModel.viewModelItem;

namespace ViewModel.viewmodel;

public partial class CatalogueViewModel<TPage, T> : BaseViewModel<TPage, T> where TPage : struct, Enum
{
    private readonly Repository<Item> itemRepository;
    public ObservableCollection<ViewModelItem> Items { get; }
    public CatalogueViewModel(INavigationService<TPage, T> _navigationService, Repository<Item> itemRepository) : base(_navigationService) 
    {
        this.itemRepository = itemRepository;
        this.Items = new ObservableCollection<ViewModelItem>();
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
