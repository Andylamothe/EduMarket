using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Inventory.xaml
    /// </summary>
    public partial class Inventory : UserControl
    {
        private readonly InventoryViewModel<ApplicationPage, UserControl> _viewModel;
        public Inventory(InventoryViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
