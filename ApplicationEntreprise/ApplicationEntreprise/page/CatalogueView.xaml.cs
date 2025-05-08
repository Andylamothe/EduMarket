using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Catalogue.xaml
    /// </summary>
    public partial class CatalogueView : UserControl
    {
        private readonly CatalogueViewModel<ApplicationPage, UserControl> _viewModel;
        public CatalogueView(CatalogueViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
