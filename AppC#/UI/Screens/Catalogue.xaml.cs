using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace UI.Screens
{
    public partial class Catalogue : Page
    {
        private ObservableCollection<Item> catalogueItems;

        public Catalogue()
        {
            DataContext = this;
            catalogueItems = new ObservableCollection<Item>()
            {
                new Item { ItemId = 1, ItemName = "Coca Cola Bouteille", Price = 4.50F, Description = "A can of Coca" },
                new Item { ItemId = 2, ItemName = "Moto de course", Price = 2300.45F, Description = "Un velo den bon etat" },
                new Item { ItemId = 3, ItemName = "Piscine gonflable", Price = 30F, Description = "Piscine peu utilisee" }
            };
            InitializeComponent();
        }

        public ObservableCollection<Item> CatalogueItems
        {
            get { return catalogueItems; }
            set { catalogueItems = value; }
        }
    }
} 