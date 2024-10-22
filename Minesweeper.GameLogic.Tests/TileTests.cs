namespace Minesweeper.GameLogic.Tests;

[TestFixture]
public class TileTests
{
    [Test]
    public void Tile_Initially_NotRevealed_And_NotFlagged()
    {
        // Arrange
        var tile = new Tile();

        // Act & Assert
        Assert.Multiple(() =>
        {
            Assert.That(tile.IsRevealed, Is.False, "Tile should not be revealed initially.");
            Assert.That(tile.IsFlagged, Is.False, "Tile should not be flagged initially.");
        });
    }

    [Test]
    public void Tile_ToggleFlag_ChangesFlagState()
    {
        // Arrange
        var tile = new Tile();

        // Act
        tile.ToggleFlag();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(tile.IsFlagged, Is.True, "Tile should be flagged after toggling.");

            // Act again
            tile.ToggleFlag();

            // Assert again
            Assert.That(tile.IsFlagged, Is.False, "Tile should not be flagged after toggling again.");
        });
    }

    [Test]
    public void Tile_Reveal_SetsIsRevealedToTrue()
    {
        // Arrange
        var tile = new Tile();

        // Act
        tile.Reveal();

        // Assert
        Assert.That(tile.IsRevealed, Is.True, "Tile should be revealed after calling Reveal.");
    }
}