using Minesweeper.GameLogic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Minesweeper.TUI;

public class ConsoleView
{
    private Game game;
    private int cursorX = 0;
    private int cursorY = 0;

    public ConsoleView(Game game)
    {
        this.game = game;
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
                    cursorY = Math.Max(0, cursorY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    cursorY = Math.Min(game.GetHeight() - 1, cursorY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    cursorX = Math.Max(0, cursorX - 1);
                    break;
                case ConsoleKey.RightArrow:
                    cursorX = Math.Min(game.GetWidth() - 1, cursorX + 1);
                    break;
                case ConsoleKey.Spacebar:
                    if (game.RevealTile(cursorX, cursorY))
                    {
                        RenderBoard();
                        AnsiConsole.Markup("[bold red]Koniec gry! Trafiłeś na minę![/]");
                        return;
                    }
                    break;
                case ConsoleKey.F:
                    game.FlagTile(cursorX, cursorY);
                    break;
            }

            if (game.CheckWinCondition())
            {
                RenderBoard();
                AnsiConsole.Markup("[bold green]Gratulacje! Wygrałeś![/]");
                return;
            }
        }
    }

    private void RenderBoard()
    {
        AnsiConsole.Clear();
        var table = new Table();
        table.Border = TableBorder.None;
        table.AddColumns("", "", "", "", "", "", "", "", "", "");

        for (int y = 0; y < game.GetHeight(); y++)
        {
            var row = new List<IRenderable>();
            for (int x = 0; x < game.GetWidth(); x++)
            {
                var cell = RenderTile(x, y);
                row.Add(cell);
            }
            table.AddRow(row.ToArray());
        }

        AnsiConsole.Write(table);
        AnsiConsole.Markup($"Pozycja kursora: {cursorX}, {cursorY}");
    }

    private IRenderable RenderTile(int x, int y)
    {
        if (game.IsRevealed(x, y))
        {
            if (game.IsMine(x, y))
            {
                return new Markup("[red]*[/]");
            }

            int value = game.GetTileValue(x, y);
            return new Markup($"[green]{value}[/]");
        }
        else if (game.IsFlagged(x, y))
        {
            return new Markup("[yellow]F[/]");
        }

        return new Markup("[blue]■[/]");
    }
}