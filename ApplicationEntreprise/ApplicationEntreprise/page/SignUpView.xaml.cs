using System.Windows.Controls;
using ViewModel.navigationService;
using ViewModel.viewmodel;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour SignUp.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private readonly SignUpViewModel<ApplicationPage, UserControl> _viewModel;  
        public SignUpView(SignUpViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
