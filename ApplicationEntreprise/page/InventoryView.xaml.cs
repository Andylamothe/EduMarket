using System.Windows;
using System.Windows.Controls;
using ViewModel.viewmodel;
using Model.table;
using ViewModel.navigationService;
using ViewModel.viewModelItem;

namespace WpfApplication.page
{
    /// <summary>
    /// Logique d'interaction pour Inventory.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        private readonly InventoryViewModel<ApplicationPage, UserControl> _viewModel;

        public InventoryView(InventoryViewModel<ApplicationPage, UserControl> viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private async void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string name = ItemNameTextBox.Text;
            string description = ItemDescriptionTextBox.Text;

            if (float.TryParse(ItemPriceTextBox.Text, out float price))
            {
                var newViewModelItem = new ViewModelItem(new Item
                {
                    Name = name,
                    Description = description,
                    Price = price,
                    Customer = null
                });

                // Appeler la méthode dans le ViewModel pour ajouter l'item
                if (_viewModel != null)
                {
                    var newItem = new Item
                    {
                        Name = newViewModelItem.Name,
                        Description = newViewModelItem.Description,
                        Price = newViewModelItem.Price,
                        Customer = null
                    };

                    await _viewModel.AddItemAsync(newItem);
                }

                // Réinitialiser les champs du formulaire
                ItemNameTextBox.Text = string.Empty;
                ItemDescriptionTextBox.Text = string.Empty;
                ItemPriceTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Veuillez entrer un prix valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic to delete the selected item from the ListView
            if (InventoryListView.SelectedItem != null)
            {
                var selectedItem = InventoryListView.SelectedItem;
                // Assuming Items is an ObservableCollection bound to the ListView
                (InventoryListView.ItemsSource as System.Collections.ObjectModel.ObservableCollection<object>)?.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un élément à supprimer.", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}