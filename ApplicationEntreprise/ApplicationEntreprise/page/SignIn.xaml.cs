using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        private readonly SignInViewModel<ApplicationPage, UserControl> _viewModel;
        public SignIn(SignInViewModel<ApplicationPage, UserControl> viewModel   )
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
