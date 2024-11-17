using System.Windows;

namespace Minesweeper.GUI
{
    public partial class GameOverWindow : Window
    {
        private readonly MainWindow _mainWindow;

        public GameOverWindow(string message, MainWindow mainWindow)
        {
            InitializeComponent();
            GameOverMessage.Text = message;
            _mainWindow = mainWindow;
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.StartNewGame();
            this.Close();
        }
    }
}