using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private readonly ItemViewModel<ApplicationPage, UserControl> _viewModel;
        public Item(ItemViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
