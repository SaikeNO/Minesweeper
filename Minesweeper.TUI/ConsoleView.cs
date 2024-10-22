using Minesweeper.GameLogic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Minesweeper.TUI;

public class ConsoleView
{
    private Game Game;
    private int CursorX = 0;
    private int CursorY = 0;

    public ConsoleView(Game game)
    {
        Game = game;
    }

    public void StartGame()
    {
        while (true)
        {
            RenderBoard();
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    CursorY = Math.Max(0, CursorY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    CursorY = Math.Min(Game.GetHeight() - 1, CursorY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    CursorX = Math.Max(0, CursorX - 1);
                    break;
                case ConsoleKey.RightArrow:
                    CursorX = Math.Min(Game.GetWidth() - 1, CursorX + 1);
                    break;
                case ConsoleKey.Spacebar:
                    if (Game.RevealTile(CursorX, CursorY))
                    {
                        RenderBoard();
                        AnsiConsole.Markup(ConsoleStyles.EndGameLoseMessage);
                        return;
                    }
                    break;
                case ConsoleKey.F:
                    Game.FlagTile(CursorX, CursorY);
                    break;
            }

            if (Game.CheckWinCondition())
            {
                RenderBoard();
                AnsiConsole.Markup(ConsoleStyles.WinMessage);
                return;
            }
        }
    }

    private void RenderBoard()
    {
        AnsiConsole.Clear();
        var table = new Table();
        table.Border = TableBorder.None;

        // Zaktualizuj ilość kolumn w zależności od szerokości planszy
        for (int i = 0; i < Game.GetWidth(); i++)
        {
            table.AddColumn(""); // Dodaj pustą kolumnę
        }

        for (int y = 0; y < Game.GetHeight(); y++)
        {
            var row = new List<IRenderable>();
            for (int x = 0; x < Game.GetWidth(); x++)
            {
                var cell = RenderTile(x, y);
                if (cell is null) continue;

                row.Add(cell);
            }
            table.AddRow(row.ToArray());
        }

        AnsiConsole.Write(table);
    }

    private IRenderable? RenderTile(int x, int y)
    {
        var tile = Game.GetTile(x, y);

        if (tile == null) return null;

        // Sprawdź, czy to jest pozycja kursora
        if (x == CursorX && y == CursorY)
        {
            // Jeśli pole jest odkryte i nie jest miną
            if (tile.IsRevealed)
            {
                if (tile.IsMine)
                {
                    return new Markup($"{ConsoleStyles.CursorColor}*[/]"); // Mina pod kursorem
                }
                return new Markup($"{ConsoleStyles.CursorColor}{tile.AdjacentMines}[/]"); // Liczba sąsiadujących min wyróżniona kolorem kursora
            }
            else if (tile.IsFlagged)
            {
                return new Markup($"{ConsoleStyles.CursorColor}F[/]"); // Flaga wyróżniona kolorem kursora
            }
            return new Markup($"{ConsoleStyles.CursorColor}■[/]"); // Zakryte pole, które jest pod kursorem
        }

        // Normalne renderowanie, jeśli to nie jest pozycja kursora
        if (tile.IsRevealed)
        {
            if (tile.IsMine)
            {
                return new Markup($"{ConsoleStyles.MineColor}*[/]"); // Mina
            }

            return new Markup($"{ConsoleStyles.NumberColor}{tile.AdjacentMines}[/]"); // Liczba sąsiadujących min
        }
        else if (tile.IsFlagged)
        {
            return new Markup($"{ConsoleStyles.FlagColor}F[/]"); // Flaga
        }

        return new Markup($"{ConsoleStyles.CoveredTileColor}■[/]"); // Zakryte pole
    }
}
