using Aesthetics.Controls;
using Cabinet;

namespace Aesthetics.VisualTests.Tests;

public class DotMatrixDisplaySimpleTest : TestWindow
{
    public DotMatrixDisplaySimpleTest()
    {
        var dotMatrixDisplaySimple = new DotMatrixDisplaySimple
        {
            LocalPosition = new Vector2(0, 0),
            Background = Color.FromRgba(50, 50, 50, 255),
            Size = new Vector2(10, 1),
            DotSize = new Vector2(50, 50),
            Dots = Enumerable.Range(0, 5).Select(x => (new Vector2(x, 0), Color.FromRgba(230, 35, 35, 255)))
        };
        dotMatrixDisplaySimple.Render(DrawingContext);
        DrawingContext.Present();
    }
}