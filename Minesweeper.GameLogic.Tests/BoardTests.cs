namespace Minesweeper.GameLogic.Tests;


[TestFixture]
public class BoardTests
{
    [Test]
    public void Board_Initialize_CreatesCorrectSizeBoard()
    {
        // Arrange
        int width = 5;
        int height = 5;
        int mines = 3;

        // Act
        var board = new Board(width, height, mines);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(board.GetWidth(), Is.EqualTo(width), "Board width should match the initialized value.");
            Assert.That(board.GetHeight(), Is.EqualTo(height), "Board height should match the initialized value.");
        });
    }

    [Test]
    public void Board_GetTile_ReturnsNullForOutOfBounds()
    {
        // Arrange
        var board = new Board(5, 5, 3);

        // Act & Assert
        Assert.Multiple(() =>
        {
            Assert.That(board.GetTile(-1, 0), Is.Null, "GetTile should return null for out of bounds coordinates.");
            Assert.That(board.GetTile(0, -1), Is.Null, "GetTile should return null for out of bounds coordinates.");
            Assert.That(board.GetTile(5, 5), Is.Null, "GetTile should return null for out of bounds coordinates.");
        });
    }

    [Test]
    public void Board_PlaceMines_CorrectNumberOfMinesPlaced()
    {
        // Arrange
        int width = 5;
        int height = 5;
        int mines = 3;
        var board = new Board(width, height, mines);

        // Act
        int mineCount = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tile = board.GetTile(x, y);
                if (tile != null && tile.IsMine)
                {
                    mineCount++;
                }
            }
        }

        // Assert
        Assert.That(mineCount, Is.EqualTo(mines), "The number of placed mines should match the initialized mine count.");
    }
}
