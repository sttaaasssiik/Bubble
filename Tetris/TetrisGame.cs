using Cabinet;

namespace Tetris;

public class TetrisGame
{
    private readonly IEnumerable<Block> boundaries;
    private readonly Pile pile = new();
    private readonly Vector2 startingPosition;
    private readonly ITetraminoSequence tetraminoSequence;

    private Tetramino tetramino;

    public TetrisGame(ITetraminoSequence tetraminoSequence, IEnumerable<Block> boundaries, Vector2 startingPosition)
    {
        this.tetraminoSequence = tetraminoSequence;
        this.boundaries = boundaries;
        this.startingPosition = startingPosition;
        tetramino = InitTetramino();
    }

    public int LinesCollapsed { get; private set; }

    public int TotalLinesCollapsed { get; private set; }

    private IEnumerable<Block> CollidableBlocks => boundaries.Concat(pile.Blocks);

    public IEnumerable<Block> Field => tetramino.Blocks.Concat(pile.Blocks);

    public void Rotate()
    {
        Move(x => x.Rotate());
    }

    public void MoveDown()
    {
        var clone = tetramino.Clone();
        clone.MoveDown();
        if (clone.IsCollided(CollidableBlocks))
        {
            LinesCollapsed = pile.AddRange(tetramino.Blocks);
            TotalLinesCollapsed += LinesCollapsed;
            tetramino = InitTetramino();
        }
        else
        {
            tetramino = clone;
        }
    }

    public void MoveLeft()
    {
        Move(x => x.MoveLeft());
    }

    public void MoveRight()
    {
        Move(x => x.MoveRight());
    }

    private void Move(Action<Tetramino> action)
    {
        var clone = tetramino.Clone();
        action(clone);
        if (!clone.IsCollided(CollidableBlocks))
        {
            tetramino = clone;
        }
    }

    private Tetramino InitTetramino()
    {
        var tetramino = tetraminoSequence.Next;
        tetramino.Position = startingPosition;
        return tetramino;
    }
}