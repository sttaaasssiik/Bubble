using Cabinet;

namespace Bubble.Tetris;

public class Tetramino
{
    private readonly TetraminoAssetExtractor representation;
    private readonly int kind;
    private Vector2 position;
    private int rotation;

    public Vector2 Position => position;

    public IEnumerable<Block> Blocks =>
        representation[kind, rotation]
        .Select(x => x with { Position = position + x.Position });
    //.Select(x => new Block(x.Id, position + x.Position));

    public Tetramino(TetraminoAssetExtractor tetraminoData, int kind, Vector2 position, int rotation)
    {
        representation = tetraminoData;
        this.kind = kind;
        this.position = position;
        this.rotation = rotation;
    }

    public Tetramino Clone() => new(representation, kind, position, rotation);

    public void Rotate() =>
        rotation = rotation < representation.GetRotationsForKindCount(kind) - 1
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