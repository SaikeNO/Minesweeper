using Spectre.Console;
using Minesweeper.GameLogic;

namespace Minesweeper.TUI;

class Program
{
    static void Main(string[] args)
    {
        var game = InitializeGame();
        var consoleView = new ConsoleView(game);
        consoleView.StartGame();
    }

    private static Game InitializeGame()
    {
        var difficulty = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow]Wybierz poziom trudności:[/]")
                .AddChoices("Łatwy (8x8, 10 min)", "Średni (16x16, 40 min)", "Trudny (24x24, 99 min)"));

        int width, height, mines;

        switch (difficulty)
        {
            case "Średni (16x16, 40 min)":
                width = 16;
                height = 16;
                mines = 40;
                break;
            case "Trudny (24x24, 99 min)":
                width = 24;
                height = 24;
                mines = 99;
                break;
            default: // Łatwy (8x8, 10 min)
                width = 8;
                height = 8;
                mines = 10;
                break;
        }

        return new Game(width, height, mines);
    }
}