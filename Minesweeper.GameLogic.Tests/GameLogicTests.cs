namespace Minesweeper.GameLogic.Tests;


[TestFixture]
public class GameLogicTests
{
    [Test]
    public void Game_RevealTile_RevealsTile()
    {
        // Arrange
        var game = new Game(5, 5, 3);

        // Act
        bool hitMine = game.RevealTile(1, 1);

        // Assert
        var tile = game.GetTile(1, 1);
        Assert.Multiple(() =>
        {
            Assert.That(tile, Is.Not.Null, "Tile should not be null.");
            Assert.That(tile!.IsRevealed, Is.True, "Tile should be revealed after calling RevealTile.");
            Assert.That(hitMine, Is.False, "Should not hit a mine.");
        });
    }

    [Test]
    public void Game_RevealTile_HitsMine_GameOver()
    {
        // Arrange
        var game = new Game(5, 5, 3);

        // We need to manually set a mine for testing purposes
        var tileWithMine = game.GetTile(0, 0);
        Assert.IsNotNull(tileWithMine, "Tile should not be null.");
        tileWithMine.IsMine = true;

        // Act
        bool hitMine = game.RevealTile(0, 0);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(hitMine, Is.True, "RevealTile should return true when a mine is hit.");
            Assert.That(game.IsGameOverStatus(), Is.True, "Game should be over after hitting a mine.");
        });
    }

    [Test]
    public void Game_FlagTile_FlagsTheTile()
    {
        // Arrange
        var game = new Game(5, 5, 3);

        // Act
        game.FlagTile(2, 2);
        var tile = game.GetTile(2, 2);

        // Assert
        Assert.That(tile, Is.Not.Null, "Tile should not be null.");
        Assert.That(tile.IsFlagged, Is.True, "Tile should be flagged after calling FlagTile.");
    }

    [Test]
    public void Game_CheckWinCondition_ReturnsTrueWhenAllNonMinesRevealed()
    {
        // Arrange
        var game = new Game(3, 3, 1);

        // Manually set one mine for predictable testing
        var mineTile = game.GetTile(0, 0);
        Assert.That(mineTile, Is.Not.Null, "Tile should not be null.");
        mineTile.IsMine = true;

        // Act: Reveal all non-mine tiles
        for (int x = 0; x < game.GetWidth(); x++)
        {
            for (int y = 0; y < game.GetHeight(); y++)
            {
                if (game.GetTile(x, y)?.IsMine == true) continue; // Skip mine
                game.RevealTile(x, y);
            }
        }

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(game.CheckWinCondition(), Is.True, "Win condition should be met when all non-mine tiles are revealed.");
            Assert.That(game.IsGameOverStatus(), Is.False, "Game should not be over.");
        });
    }
}
