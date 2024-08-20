namespace Bubble.Tetris;

public class TetrisGame
{
    private readonly IEnumerator<Tetramino> tetraminos;
    private readonly IEnumerable<Block> boundaries;
    private readonly Pile pile = new();
    private Tetramino tetramino;

    public int LinesCollapsed { get; private set; }

    public int TotalLinesCollapsed { get; private set; }

    public TetrisGame(IEnumerable<Tetramino> tetraminos, IEnumerable<Block> boundaries)
    {
        this.boundaries = boundaries;
        this.tetraminos = tetraminos.GetEnumerator();
        this.tetraminos.MoveNext();
        tetramino = this.tetraminos.Current;
    }

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
            tetraminos.MoveNext();
            tetramino = tetraminos.Current;
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