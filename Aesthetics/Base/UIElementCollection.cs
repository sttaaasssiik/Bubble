namespace Aesthetics.Base;

public class UIElementCollection
{
    private readonly List<Control> uIElements = [];

    private readonly Canvas canvas;

    internal UIElementCollection(Canvas canvas) => this.canvas = canvas;

    public void Add(Control uIElement) => uIElements.Add(uIElement);

    public IEnumerator<Control> GetEnumerator() => uIElements.GetEnumerator();
}