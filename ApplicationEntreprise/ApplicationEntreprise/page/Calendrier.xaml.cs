using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Calendrier.xaml
    /// </summary>
    public partial class Calendrier : UserControl
    {
        private readonly CalendrierViewModel<ApplicationPage, UserControl> _viewModel;
        public Calendrier(CalendrierViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
