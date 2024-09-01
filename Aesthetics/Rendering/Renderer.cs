using Aesthetics.Base;
using Cabinet;

namespace Aesthetics.Rendering;

internal class Renderer
{
	private readonly DrawingContext drawingContext;

	internal Renderer(DrawingContext drawingContext)
	{
		this.drawingContext = drawingContext;
	}

	public void Render(Control control)
	{
		drawingContext.SetRenderDrawColor(Color.FromRgba(0, 0, 0, 0));
		drawingContext.Clear();
		control.OnRender(drawingContext);
		drawingContext.Present();
	}
}