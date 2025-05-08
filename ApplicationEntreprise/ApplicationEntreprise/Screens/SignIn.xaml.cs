using System.Windows;
using System.Windows.Controls;

namespace UI.Screens
{
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void NavigateToSignUp(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.NavigateToSignUp(sender, e);
                mainWindow.navMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
} 