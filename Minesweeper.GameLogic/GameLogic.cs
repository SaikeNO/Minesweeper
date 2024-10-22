namespace Minesweeper.GameLogic;

public class Game(int width, int height, int mines)
{
    private readonly Board Board = new(width, height, mines);
    private bool IsGameOver = false;

    public bool RevealTile(int x, int y)
    {
        if (IsGameOver) return false;

        var tile = Board.GetTile(x, y);
        if (tile is null || tile.IsRevealed || tile.IsFlagged) return false;

        tile.Reveal();

        if (tile.IsMine)
        {
            IsGameOver = true;
            return true; // Gra przegrana
        }

        if (tile.AdjacentMines == 0)
        {
            RevealAdjacentTiles(x, y);
        }

        return false; // Gra kontynuowana
    }

    private void RevealAdjacentTiles(int x, int y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int nx = x + i;
                int ny = y + j;
                var adjacentTile = Board.GetTile(nx, ny);
                if (adjacentTile is not null && !adjacentTile.IsRevealed && !adjacentTile.IsMine)
                {
                    RevealTile(nx, ny);
                }
            }
        }
    }

    public void FlagTile(int x, int y)
    {
        var tile = Board.GetTile(x, y);
        if (tile != null && !tile.IsRevealed)
        {
            tile.ToggleFlag();
        }
    }

    public bool IsFlagged(int x, int y)
    {
        var tile = Board.GetTile(x, y);
        return tile != null && tile.IsFlagged;
    }

    public bool IsRevealed(int x, int y)
    {
        var tile = Board.GetTile(x, y);
        return tile != null && tile.IsRevealed;
    }

    public bool IsMine(int x, int y)
    {
        var tile = Board.GetTile(x, y);
        return tile != null && tile.IsMine;
    }

    public int GetTileValue(int x, int y)
    {
        var tile = Board.GetTile(x, y);
        return tile?.AdjacentMines ?? 0;
    }

    public bool CheckWinCondition()
    {
        for (int x = 0; x < Board.GetWidth(); x++)
        {
            for (int y = 0; y < Board.GetHeight(); y++)
            {
                var tile = Board.GetTile(x, y);
                if (tile is not null && !tile.IsMine && !tile.IsRevealed)
                {
                    return false;
                }
            }
        }
        return true; // Wszystkie pola bez min odkryte
    }

    public bool IsGameOverStatus() => IsGameOver;
    public int GetWidth() => Board.GetWidth();
    public int GetHeight() => Board.GetHeight();
    public Tile? GetTile(int x, int y) => Board.GetTile(x, y);
}
