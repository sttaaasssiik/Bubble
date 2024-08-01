using Aesthetics.Rendering;
using Cabinet;

namespace Aesthetics.Base;

public class RectangleShape : Control
{
    public Color Background { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    protected internal override void OnRender(DrawingContext dc)
    {
        dc.SetRenderDrawColor(Background);
        dc.FillRectangle(new Rectangle() { Position = LocalPosition, Width = Width, Height = Height });
    }
}