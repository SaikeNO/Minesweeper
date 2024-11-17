using Minesweeper.GameLogic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Minesweeper.GUI
{
    public partial class MainWindow : Window
    {
        private Game _game;
        private int _width;
        private int _height;
        private int _mines;
        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;
        private bool _gameStarted;

        public MainWindow(int width, int height, int mines)
        {
            InitializeComponent();
            _width = width;
            _height = height;
            _mines = mines;
            _elapsedTime = TimeSpan.Zero;
            _gameStarted = false;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;

            StartNewGame();
        }

        public void StartNewGame()
        {
            _game = new Game(_width, _height, _mines);
            _elapsedTime = TimeSpan.Zero;
            _gameStarted = true;
            _timer.Start();
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            GameGrid.Children.Clear();
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < _game.GetHeight(); i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < _game.GetWidth(); i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int row = 0; row < _game.GetHeight(); row++)
            {
                for (int col = 0; col < _game.GetWidth(); col++)
                {
                    var button = new Button
                    {
                        Content = "",
                        Tag = new Tuple<int, int>(row, col)
                    };

                    button.SetValue(Grid.RowProperty, row);
                    button.SetValue(Grid.ColumnProperty, col);
                    button.HorizontalAlignment = HorizontalAlignment.Stretch;
                    button.VerticalAlignment = VerticalAlignment.Stretch;

                    button.Click += (sender, args) =>
                    {
                        var coords = (Tuple<int, int>)button.Tag;
                        int x = coords.Item1;
                        int y = coords.Item2;

                        var isGameOver = _game.RevealTile(x, y);
                        UpdateBoard();

                        if (isGameOver)
                        {
                            ShowGameOverMessage("Przegrałeś!");
                        }
                        else if (_game.CheckWinCondition())
                        {
                            ShowGameOverMessage($"Gratulacje, wygrałeś! Twój czas to {_elapsedTime.ToString(@"mm\:ss")}");
                        }
                    };

                    button.PreviewMouseRightButtonDown += (sender, args) =>
                    {
                        var coords = (Tuple<int, int>)button.Tag;
                        int x = coords.Item1;
                        int y = coords.Item2;

                        _game.FlagTile(x, y);
                        UpdateBoard();
                    };

                    GameGrid.Children.Add(button);
                }
            }
        }

        private void UpdateBoard()
        {
            for (int row = 0; row < _game.GetHeight(); row++)
            {
                for (int col = 0; col < _game.GetWidth(); col++)
                {
                    var button = GameGrid.Children.Cast<Button>().FirstOrDefault(b =>
                        Grid.GetRow(b) == row && Grid.GetColumn(b) == col);

                    if (button != null)
                    {
                        var tile = _game.GetTile(row, col);
                        if (tile != null)
                        {
                            if (tile.IsRevealed)
                            {
                                button.Content = tile.IsMine ? "M" : (tile.AdjacentMines > 0 ? tile.AdjacentMines.ToString() : "");
                                button.IsEnabled = false;
                            }
                            else if (tile.IsFlagged)
                            {
                                button.Content = "F";
                            }
                            else
                            {
                                button.Content = "";
                                button.IsEnabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void ShowGameOverMessage(string message)
        {
            _timer.Stop();
            GameOverWindow gameOverWindow = new GameOverWindow(message, this);
            gameOverWindow.ShowDialog();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_gameStarted)
            {
                _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
                TimeDisplay.Text = _elapsedTime.ToString(@"mm\:ss");
            }
        }

    }
}
