using Cabinet;

namespace Bubble.Tetris;

public class TetraminoFactory
{
    private readonly TetraminoAssetExtractor representation;
    private readonly Vector2 startingPosition;
    private readonly Random random = new();

    public TetraminoFactory(TetraminoAssetExtractor representation, Vector2 startingPosition)
    {
        this.representation = representation;
        this.startingPosition = startingPosition;
    }

    public Tetramino Create()
    {
        var kind = random.Next() % representation.KindsCount;
        return new Tetramino(representation, kind, startingPosition, 0);
    }
}