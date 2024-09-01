namespace Cabinet;

public struct Transform
{
	public Vector2 Position { get; set; }

	public Rotation Rotation { get; set; }

	public void MoveUp() => Position += Vector2.Up;

	public void MoveDown() => Position += Vector2.Down;

	public void MoveLeft() => Position += Vector2.Left;

	public void MoveRight() => Position += Vector2.Right;

	public void RotateCW() => Rotation = (int)Rotation < 4 ? Rotation + 1 : 0;
}