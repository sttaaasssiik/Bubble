using Cabinet;

namespace Bubble.Snake;

public static class DirectionExtensions
{
	public static bool IsOpposite(this Direction direction, Direction anotherDirection) =>
		direction == Direction.Up && anotherDirection == Direction.Down ||
		direction == Direction.Right && anotherDirection == Direction.Left ||
		direction == Direction.Down && anotherDirection == Direction.Up ||
		direction == Direction.Left && anotherDirection == Direction.Right;

	public static Vector2 GetMoveVector(this Direction direction) => direction switch
	{
		Direction.Up => Vector2.Up,
		Direction.Right => Vector2.Right,
		Direction.Down => Vector2.Down,
		Direction.Left => Vector2.Left,
		_ => throw new ArgumentOutOfRangeException(nameof(direction))
	};
}