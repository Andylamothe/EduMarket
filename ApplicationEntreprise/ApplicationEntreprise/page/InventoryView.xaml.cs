using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Inventory.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        private readonly InventoryViewModel<ApplicationPage, UserControl> _viewModel;
        public InventoryView(InventoryViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
