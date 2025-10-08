
using CommunityToolkit.Mvvm.ComponentModel;
using Model.table;

namespace ViewModel.viewModelItem;

public partial class ViewModelItem : ObservableObject
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private float price;

    public ViewModelItem(){}

    public ViewModelItem(Item dbItem)
    {
        this.name = dbItem.Name;
        this.price = dbItem.Price;
        this.description = dbItem.Description;
    }
}
