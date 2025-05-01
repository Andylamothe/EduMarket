using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Screens;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Catalogue());
        }

        private void ToggleNavigationMenu(object sender, RoutedEventArgs e)
        {
            if (navMenu.Visibility == Visibility.Visible)
            {
                navMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                navMenu.Visibility = Visibility.Visible;
            }
        }

        private void NavigateToCatalogue(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Catalogue());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void NavigateToSignIn(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SignIn());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void NavigateToInventory(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Inventory());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void NavigateToCalendrier(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Calendrier());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void NavigateToItem(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Item());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void NavigateToSignUp(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SignUp());
            navMenu.Visibility = Visibility.Collapsed;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}