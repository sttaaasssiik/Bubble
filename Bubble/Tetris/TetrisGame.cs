namespace Bubble.Tetris;

public class TetrisGame(ITetraminoSequence tetraminoSequence, IEnumerable<Block> boundaries)
{
    private readonly IEnumerable<Block> boundaries = boundaries;
    private readonly Pile pile = new();
    private Tetramino tetramino = tetraminoSequence.Next;

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
            tetramino = tetraminoSequence.Next;
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
}