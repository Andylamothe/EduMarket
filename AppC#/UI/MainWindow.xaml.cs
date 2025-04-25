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

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToScreen1(null, null);
        }

        private void NavigateToScreen1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Screen1());
        }

        private void NavigateToScreen2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Screen2());
        }

        private void NavigateToScreen3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Screen3());
        }

        private void NavigateToScreen4(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Screen4());
        }
    }
}