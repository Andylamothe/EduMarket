using System.Windows;
using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace ApplicationEntreprise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel<ApplicationPage, UserControl> _viewModel;

        public MainWindow(MainViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void ToggleNavigationMenu(object sender, RoutedEventArgs e)
        {
            navMenu.Visibility = navMenu.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
}