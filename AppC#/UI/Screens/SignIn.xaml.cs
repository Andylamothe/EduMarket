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
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new SignUp());
                mainWindow.navMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
} 