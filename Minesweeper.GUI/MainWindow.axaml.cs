using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Minesweeper.GameLogic;
using MsBox.Avalonia;
using System.Threading.Tasks;

namespace Minesweeper.GUI;

public partial class MainWindow : Window
{
    private Game game;
    private Grid boardGrid;
    private const int tileSize = 30;

    public MainWindow()
    {
        InitializeComponent();
        game = new Game(10, 10, 10); // Rozmiar planszy 10x10, 10 min

        boardGrid = this.FindControl<Grid>("BoardGrid");
        CreateBoard();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // Tworzenie planszy w gridzie
    private void CreateBoard()
    {
        boardGrid.RowDefinitions.Clear();
        boardGrid.ColumnDefinitions.Clear();

        // Definiowanie rozmiarów wierszy i kolumn
        for (int i = 0; i < game.GetHeight(); i++)
        {
            boardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(tileSize) });
        }
        for (int i = 0; i < game.GetWidth(); i++)
        {
            boardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(tileSize) });
        }

        // Tworzenie pól jako przyciski
        for (int x = 0; x < game.GetWidth(); x++)
        {
            for (int y = 0; y < game.GetHeight(); y++)
            {
                var button = new Button
                {
                    Content = "",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch
                };

                // Dodawanie akcji klikniêcia
                int posX = x, posY = y;
                button.Click += async (sender, e) =>  await OnTileClick(posX, posY, (Button)sender);

                // Umieszczanie przycisków w gridzie
                boardGrid.Children.Add(button);
                Grid.SetColumn(button, x);
                Grid.SetRow(button, y);
            }
        }
    }

    // Obs³uga klikniêcia na pole
    private async Task OnTileClick(int x, int y, Button button)
    {
        bool gameOver = game.RevealTile(x, y);
        UpdateBoard();

        if (gameOver)
        {
           await MessageBoxManager.GetMessageBoxStandard("Game Over", "Trafi³eœ na minê!").ShowWindowAsync();
        }
        else if (game.CheckWinCondition())
        {
            await MessageBoxManager.GetMessageBoxStandard("You Win!", "Gratulacje! Wygra³eœ!").ShowWindowAsync();
        }
    }

    // Aktualizacja zawartoœci planszy
    private void UpdateBoard()
    {
        for (int x = 0; x < game.GetWidth(); x++)
        {
            for (int y = 0; y < game.GetHeight(); y++)
            {
                var button = (Button)boardGrid.Children[y * game.GetWidth() + x];
                if (game.IsRevealed(x, y))
                {
                    if (game.IsMine(x, y))
                    {
                        button.Content = "*";
                        button.Background = Brushes.Red;
                    }
                    else
                    {
                        int tileValue = game.GetTileValue(x, y);
                        button.Content = tileValue > 0 ? tileValue.ToString() : "";
                        button.Background = Brushes.LightGray;
                    }
                }
                else if (game.IsFlagged(x, y))
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