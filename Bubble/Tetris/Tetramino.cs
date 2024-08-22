using Cabinet;

namespace Bubble.Tetris;

public class Tetramino(TetraminoAssetExtractor extractor, int kind, int rotation, Vector2 position)
{
    private readonly TetraminoAssetExtractor extractor = extractor;
    private readonly int kind = kind;
    private int rotation = rotation;

    public Vector2 Position { get; private set; } = position;

    public IEnumerable<Block> Blocks => extractor[kind, rotation]
        .Select(x => (x with { Position = Position + x.Position }));

    public Tetramino Clone() => new(extractor, kind, rotation, Position);

    public void Rotate() =>
        rotation = rotation < extractor.GetRotationsForKindCount(kind) - 1
        ? rotation + 1
        : 0;

    public void MoveDown() => Position -= Vector2.Up;

    public void MoveLeft() => Position -= Vector2.Right;

    public void MoveRight() => Position += Vector2.Right;

    public bool IsCollided(IEnumerable<Block> blocks)
    {
        static bool equals(Block x, Block y) => x.Position == y.Position;
        static int getHashCode(Block b) => 0;
        var blockPositionComparer = EqualityComparer<Block>.Create(equals, getHashCode);
        return Blocks.Intersect(blocks, blockPositionComparer).Any();
    }
}