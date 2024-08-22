using Cabinet;

namespace Bubble.Tetris;

public class Tetramino(TetraminoAssetExtractor tetraminoData, int kind, Vector2 position, int rotation)
{
    private readonly TetraminoAssetExtractor extractor = tetraminoData;
    private readonly int kind = kind;

    private Vector2 position = position;
    private int rotation = rotation;

    public Vector2 Position => position;

    public IEnumerable<Block> Blocks => extractor[kind, rotation]
        .Select(x => x with { Position = position + x.Position });

    public Tetramino Clone() => new(extractor, kind, position, rotation);

    public void Rotate() =>
        rotation = rotation < extractor.GetRotationsForKindCount(kind) - 1
        ? rotation + 1
        : 0;

    public void MoveDown() => position -= Vector2.Up;

    public void MoveLeft() => position -= Vector2.Right;

    public void MoveRight() => position += Vector2.Right;

    public bool IsCollided(IEnumerable<Block> blocks)
    {
        static bool equals(Block x, Block y) => x.Position == y.Position;
        var blockPositionComparer = EqualityComparer<Block>.Create(equals, b => 0);
        return Blocks.Intersect(blocks, blockPositionComparer).Any();
    }
}