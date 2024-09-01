using Cabinet;

namespace Bubble.Snake;

public class SnakeGame
{
	private readonly List<Vector2> snake = [new Vector2(0, 0), new Vector2(1, 0), new Vector2(2, 0), new Vector2(3, 0)];

	private readonly Random random = new();

	private List<Vector2> shadowSnake = [];

	private Direction currentDirection = Direction.Right;

	public Vector2 Piece { get; private set; }

	public Vector2 FieldSize { get; private set; }

	public IEnumerable<Vector2> Snake => snake;

	public SnakeGame(Vector2 fieldSize)
	{
		FieldSize = fieldSize;
	}

	public GameState Move(Direction direction)
	{
		if (direction.IsOpposite(currentDirection))
		{
			return GameState.Running;
		}
		var newHead = snake[^1] + direction.GetMoveVector();
		if (newHead.X < 0 ||
			newHead.Y < 0 ||
			newHead.X >= FieldSize.X ||
			newHead.Y >= FieldSize.Y)
		{
			return GameState.GameOver;
		}
		if (snake[..^1].Contains(newHead))
		{
			return GameState.GameOver;
		}
		if (newHead == Piece)
		{
			snake.Add(newHead);
			GenerateNewPiece();
		}
		else
		{
			shadowSnake = [.. snake];
			for (int i = 0; i < snake.Count - 1; i++)
			{
				snake[i] = shadowSnake[i + 1];
			}
			snake[^1] += direction.GetMoveVector();
		}
		currentDirection = direction;
		return GameState.Running;
	}

	private void MoveBody()
	{
		for (int i = 0; i < snake.Count - 1; i++)
		{
			snake[i] += currentDirection.GetMoveVector();
		}
	}

	private void ScanForPiece() { throw new NotImplementedException(); }

	private void GenerateNewPiece()
	{
		do
		{
			var x = random.Next(10);
			var y = random.Next(10);
			Piece = new Vector2(x, y);
		} while (snake.Contains(Piece));
	}
}