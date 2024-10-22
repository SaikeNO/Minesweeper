namespace Minesweeper.GameLogic;
public class Tile
{
    public bool IsRevealed { get; private set; }
    public bool IsFlagged { get; private set; }
    public bool IsMine { get; set; }
    public int AdjacentMines { get; set; }

    public Tile()
    {
        IsRevealed = false;
        IsFlagged = false;
        IsMine = false;
        AdjacentMines = 0;
    }

    public void Reveal()
    {
        IsRevealed = true;
    }

    public void ToggleFlag()
    {
        IsFlagged = !IsFlagged;
    }
}