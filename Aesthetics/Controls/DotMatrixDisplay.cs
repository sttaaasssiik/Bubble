using Aesthetics.Base;
using Aesthetics.Rendering;
using Cabinet;

namespace Aesthetics.Controls;

public class DotMatrixDisplay : Control
{
    public Vector2 DotSize { get; private set; }

    public Vector2 Size { get; private set; }

    public Color Background { get; set; }

    public IEnumerable<(Vector2 position, Color color)> Dots { get; set; } = [];

    public DotMatrixDisplay(Vector2 size, Vector2 dotSize)
    {
        Size = size;
        DotSize = dotSize;
    }

    protected internal override void OnRender(DrawingContext renderer)
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