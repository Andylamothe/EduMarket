using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Item.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        private readonly ItemViewModel<ApplicationPage, UserControl> _viewModel;
        public ItemView(ItemViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
