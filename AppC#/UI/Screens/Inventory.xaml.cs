using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Windows.Controls;

namespace UI.Screens
{


    public partial class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
    }
    public partial class Inventory : Page
    {

        private ObservableCollection<Item> inventoryItems;
        public Inventory()
        {
            DataContext = this;
            inventoryItems = new ObservableCollection<Item>()
            {
                new Item{ItemId = 1, ItemName = "Coca can", Price = 2.50F, Description = "A can of Coca"},
                new Item{ItemId = 2, ItemName = "Velo", Price = 230F, Description = "Un velo den bon etat"},
            };

            InitializeComponent();
        }

        public ObservableCollection<Item> InventoryItems
        {
            get { return inventoryItems; }
            set { inventoryItems = value; }
        }

        private void ButtonDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Item item = (Item)InventoryListView.SelectedItem;
            InventoryItems.Remove(item);
        }
    }
} 