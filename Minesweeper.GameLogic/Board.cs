namespace Minesweeper.GameLogic;

public class Board
{
    private readonly int Width;
    private readonly int Height;
    private readonly int Mines;
    private readonly Tile[,] Tiles;

    public Board(int width, int height, int mines)
    {
        Width = width;
        Height = height;
        Mines = mines;
        Tiles = new Tile[Width, Height];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Tiles[x, y] = new Tile();
            }
        }
        PlaceMines();
        CalculateAdjacentMines();
    }

    private void PlaceMines()
    {
        Random random = new Random();
        int placedMines = 0;

        while (placedMines < Mines)
        {
            int x = random.Next(Width);
            int y = random.Next(Height);

            if (!Tiles[x, y].IsMine)
            {
                Tiles[x, y].IsMine = true;
                placedMines++;
            }
        }
    }

    private void CalculateAdjacentMines()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (Tiles[x, y].IsMine) continue;

                int mineCount = 0;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nx = x + i;
                        int ny = y + j;

                        if (nx >= 0 && ny >= 0 && nx < Width && ny < Height && Tiles[nx, ny].IsMine)
                        {
                            mineCount++;
                        }
                    }
                }

                Tiles[x, y].AdjacentMines = mineCount;
            }
        }
    }

    public Tile? GetTile(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return null;
        }

        return Tiles[x, y];
    }

    public int GetWidth() => Width;
    public int GetHeight() => Height;
}
