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
		FieldChanged?.Invoke(Field);
	}

	public event Action<IEnumerable<Block>>? FieldChanged;

	public int LinesCollapsed { get; private set; }

	public int TotalLinesCollapsed { get; private set; }

	private IEnumerable<Block> CollidableBlocks => boundaries.Concat(pile.Blocks);

	public IEnumerable<Block> Field => tetramino.Blocks.Concat(pile.Blocks);

	public void Rotate()
	{
		Move(x => x.Rotate());
		FieldChanged?.Invoke(Field);
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
		FieldChanged?.Invoke(Field);
	}

	public void MoveLeft()
	{
		Move(x => x.MoveLeft());
		FieldChanged?.Invoke(Field);
	}

	public void MoveRight()
	{
		Move(x => x.MoveRight());
		FieldChanged?.Invoke(Field);
	}

	private void Move(Action<Tetramino> action)
	{
		var clone = tetramino.Clone();
		action(clone);
		if (!clone.IsCollided(CollidableBlocks))
		{
			tetramino = clone;
		}
		FieldChanged?.Invoke(Field);
	}

	private Tetramino InitTetramino()
	{
		var tetramino = tetraminoSequence.Next;
		tetramino.Position = startingPosition;
		return tetramino;
	}
}