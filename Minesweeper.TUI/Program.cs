using Minesweeper.GameLogic;

namespace Minesweeper.TUI;

class Program
{
    static void Main(string[] args)
    {
        var game = new Game(10, 10, 10);
        var consoleView = new ConsoleView(game);
        consoleView.StartGame();
    }
}