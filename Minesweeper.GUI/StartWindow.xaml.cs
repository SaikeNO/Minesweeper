using System.Windows;

namespace Minesweeper.GUI
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(8, 8, 10); // Łatwy poziom: 8x8, 10 min
            mainWindow.Show();
            this.Close();
        }

        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(16, 16, 40); // Średni poziom: 16x16, 40 min
            mainWindow.Show();
            this.Close();
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(24, 24, 99); // Trudny poziom: 24x24, 99 min
            mainWindow.Show();
            this.Close();
        }
    }
}
