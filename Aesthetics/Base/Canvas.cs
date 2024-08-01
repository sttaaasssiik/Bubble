using Aesthetics.Input;
using Aesthetics.Rendering;
using Cabinet;

namespace Aesthetics.Base;

public class Canvas : Control
{
    public UIElementCollection Children { get; }

    public Canvas()
    {
        Children = new UIElementCollection(this);
    }

    public static void SetPosition(Control visual, Vector2 vector2) => visual.LocalPosition = vector2;

    protected internal override void OnRender(DrawingContext drawingContext)
    {
        foreach (var child in Children)
        {
            child.OnRender(drawingContext);
        }
    }

    protected internal override void OnUIEvent(UIEventArgs uIEventArgs) { }
}