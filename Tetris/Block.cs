using Cabinet;

namespace Tetris;

public record Block
{
	public string Id { get; private set; }

	public Vector2 Position { get; set; }

	public Block(string id, Vector2 position)
	{
		Id = id;
		Position = position;
	}
}