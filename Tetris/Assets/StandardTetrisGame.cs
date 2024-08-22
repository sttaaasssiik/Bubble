using Cabinet;

namespace Tetris.Assets;

public class StandardTetrisGame
{
    public static TetrisGame Create()
    {
        var extractor = new TetraminoAssetExtractor(StandardTetraminos.Data);
        var startingPosition = new Vector2(4, 18);

        var sequence = new RandomTetraminoSequence(extractor);

        return new TetrisGame(sequence, StandardBoundaries.Create(), startingPosition);
    }
}