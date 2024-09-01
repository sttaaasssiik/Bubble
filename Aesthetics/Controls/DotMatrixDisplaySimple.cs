using Aesthetics.Rendering;
using Cabinet;

namespace Aesthetics.Controls;

public class DotMatrixDisplaySimple
{
	public Vector2 LocalPosition { get; set; }

	public required Vector2 DotSize { get; set; }

	public required Vector2 Size { get; set; }

	public required Color Background { get; set; }

	public IEnumerable<(Vector2 position, Color color)> Dots { get; set; } = [];

	public void Render(DrawingContext renderer)
	{
		renderer.SetRenderDrawColor(Background);

		for (int y = 0; y < Size.Y; y++)
		{
			for (int x = 0; x < Size.X; x++)
			{
				var rect = new Rectangle()
				{
					Position = new Vector2(x * DotSize.X + LocalPosition.X, y * DotSize.Y + LocalPosition.Y),
					Width = DotSize.X - 1,
					Height = DotSize.Y - 1
				};
				renderer.FillRectangle(rect);
			}
		}

		foreach (var (position, color) in Dots)
		{
			var rect = new Rectangle
			{
				Position = new Vector2(position.X * DotSize.X + LocalPosition.X, position.Y * DotSize.Y + LocalPosition.Y),
				Width = DotSize.X - 1,
				Height = DotSize.Y - 1
			};
			renderer.SetRenderDrawColor(color);
			renderer.FillRectangle(rect);
		}
	}
}