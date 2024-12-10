using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cricket_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Players = new ObservableCollection<string>();
            PlayersListBox.ItemsSource = Players;
        }
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("Player already exists in the roster.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Players.Add(playerName);
            PlayerNameTextBox.Clear();
            MessageBox.Show("Player added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = PlayersListBox.SelectedItem as string; 

            if (selectedPlayer != null)
            {
                Players.Remove(selectedPlayer);
                MessageBox.Show("Player removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
