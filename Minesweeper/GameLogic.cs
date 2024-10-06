namespace Minesweeper.GameLogic;

public class Game
{
    private int[,] board; // 0 - puste, 1-8 - liczba sąsiadujących min, 9 - mina
    private bool[,] revealed; // true, jeśli pole jest odkryte
    private bool[,] flagged;   // true, jeśli pole jest oznaczone jako mina
    private int width;
    private int height;
    private int mines;

    public Game(int width, int height, int mines)
    {
        this.width = width;
        this.height = height;
        this.mines = mines;
        InitializeBoard();
    }

    // Inicjalizacja planszy
    private void InitializeBoard()
    {
        board = new int[width, height];
        revealed = new bool[width, height];
        flagged = new bool[width, height];

        PlaceMines();
        CalculateAdjacentMines();
    }

    // Losowe rozmieszczenie min
    private void PlaceMines()
    {
        Random random = new Random();
        int placedMines = 0;

        while (placedMines < mines)
        {
            int x = random.Next(width);
            int y = random.Next(height);

            if (board[x, y] != 9) // 9 oznacza minę
            {
                board[x, y] = 9;
                placedMines++;
            }
        }
    }

    // Obliczanie sąsiedztwa min
    private void CalculateAdjacentMines()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (board[x, y] == 9) continue;

                int mineCount = 0;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nx = x + i;
                        int ny = y + j;

                        if (nx >= 0 && ny >= 0 && nx < width && ny < height && board[nx, ny] == 9)
                        {
                            mineCount++;
                        }
                    }
                }

                board[x, y] = mineCount;
            }
        }
    }

    // Odkrywanie pola
    public bool RevealTile(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height || revealed[x, y])
        {
            return false;
        }

        revealed[x, y] = true;

        // Jeśli odkryto minę, gra jest przegrana
        if (board[x, y] == 9)
        {
            return true;
        }

        // Automatyczne odkrywanie sąsiadujących pustych pól
        if (board[x, y] == 0)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    RevealTile(x + i, y + j);
                }
            }
        }

        return false;
    }

    // Oznaczanie pola jako mina
    public void FlagTile(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height && !revealed[x, y])
        {
            flagged[x, y] = !flagged[x, y];
        }
    }

    // Sprawdzenie, czy gra jest wygrana
    public bool CheckWinCondition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (board[x, y] != 9 && !revealed[x, y])
                {
                    return false; // Wciąż są nieodkryte pola
                }
            }
        }
        return true; // Wszystkie pola bez min zostały odkryte
    }

    // Funkcje pomocnicze do uzyskania informacji o planszy
    public int GetTileValue(int x, int y) => board[x, y];
    public bool IsRevealed(int x, int y) => revealed[x, y];
    public bool IsFlagged(int x, int y) => flagged[x, y];
    public bool IsMine(int x, int y) => board[x, y] == 9;
    public int GetWidth() => width;
    public int GetHeight() => height;
}
