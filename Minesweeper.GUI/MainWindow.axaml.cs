using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Minesweeper.GameLogic;
using MsBox.Avalonia;
using System.Threading.Tasks;

namespace Minesweeper.GUI;

public partial class MainWindow : Window
{
    private Game Game;
    private const int TileSize = 30;

    public MainWindow()
    {
        InitializeComponent();
        Game = new Game(10, 10, 10); // Size 10x10, 10 mines
        BoardGrid = this.FindControl<Grid>("BoardGrid");
        CreateBoard();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // Tworzenie planszy w gridzie
    private void CreateBoard()
    {
        BoardGrid.RowDefinitions.Clear();
        BoardGrid.ColumnDefinitions.Clear();

        // Definiowanie rozmiarów wierszy i kolumn
        for (int i = 0; i < Game.GetHeight(); i++)
        {
            BoardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(TileSize) });
        }
        for (int i = 0; i < Game.GetWidth(); i++)
        {
            BoardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(TileSize) });
        }

        // Tworzenie pól jako przyciski
        for (int x = 0; x < Game.GetWidth(); x++)
        {
            for (int y = 0; y < Game.GetHeight(); y++)
            {
                var button = new Button
                {
                    Content = "",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch
                };

                // Dodawanie akcji klikniêcia
                int posX = x, posY = y;
                button.Click += async (sender, e) => await OnTileClick(posX, posY, (Button)sender);

                // Obs³uga prawego przycisku
                button.PointerPressed += (sender, e) =>
                {
                    if (e.GetCurrentPoint(button).Properties.IsRightButtonPressed)
                    {
                        Game.FlagTile(posX, posY);
                        UpdateBoard();
                    }
                };

                // Umieszczanie przycisków w gridzie
                BoardGrid.Children.Add(button);
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
            }
        }
    }

    // Obs³uga klikniêcia na pole
    private async Task OnTileClick(int x, int y, Button button)
    {
        bool gameOver = Game.RevealTile(x, y);
        UpdateBoard();

        if (gameOver)
        {
            await MessageBoxManager.GetMessageBoxStandard("Game Over", "You hit a mine!").ShowWindowAsync();
        }
        else if (Game.CheckWinCondition())
        {
            await MessageBoxManager.GetMessageBoxStandard("You Win!", "Congratulations! You won!").ShowWindowAsync();
        }
    }

    // Aktualizacja zawartoœci planszy
    private void UpdateBoard()
    {
        for (int x = 0; x < Game.GetWidth(); x++)
        {
            for (int y = 0; y < Game.GetHeight(); y++)
            {
                var button = (Button)BoardGrid.Children[y * Game.GetWidth() + x];
                if (Game.IsRevealed(x, y))
                {
                    if (Game.IsMine(x, y))
                    {
                        button.Content = "*";
                        button.Background = Brushes.Red;
                    }
                    else
                    {
                        int tileValue = Game.GetTileValue(x, y);
                        button.Content = tileValue > 0 ? tileValue.ToString() : "";
                        button.Background = Brushes.LightGray;
                    }
                }
                else if (Game.IsFlagged(x, y))
                {
                    button.Content = "F";
                    button.Background = Brushes.Yellow;
                }
                else
                {
                    button.Content = "";
                    button.Background = Brushes.Gray;
                }
            }
        }
    }
}
