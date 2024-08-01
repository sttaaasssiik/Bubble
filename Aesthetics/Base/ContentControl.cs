using Aesthetics.Input;
using Aesthetics.Rendering;

namespace Aesthetics.Base;

public class ContentControl : Control
{
    public Control? Content { get; set; }

    protected internal override void OnRender(DrawingContext drawingContext) { }

    protected internal override void OnUIEvent(UIEventArgs uIEventArgs) { }

    internal override void Render(DrawingContext drawingContext)
    {
        Content?.OnRender(drawingContext);
    }
}