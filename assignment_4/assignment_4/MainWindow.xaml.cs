using System.Collections.ObjectModel;
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

namespace assignment_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string playerName = TextBox.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("Player name already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Players.Add(playerName);
            TextBox.Clear();
            MessageBox.Show($"{playerName} has been added to the team.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.SelectedItem is string selectedPlayer)
            {
                Players.Remove(selectedPlayer);
                MessageBox.Show($"{selectedPlayer} has been removed from the team.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}