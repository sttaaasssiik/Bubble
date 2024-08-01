using Aesthetics.Input;
using Aesthetics.Rendering;
using Cabinet;

namespace Aesthetics.Base;

public abstract class Control
{
    public event UIEvent? UIEvent;

    public event RenderEvent? RenderEvent;

    public event KeyDown? KeyDown;

    public virtual void OnKeyDown(Key key) { }

    internal Vector2 LocalPosition { get; set; }

    internal virtual void Render(DrawingContext drawingContext) { }

    protected internal virtual void OnRender(DrawingContext renderer) { }

    protected internal virtual void OnUIEvent(UIEventArgs uIEventArgs) { }
}