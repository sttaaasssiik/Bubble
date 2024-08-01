using Aesthetics.Base;
using Bubble.UI;

namespace Bubble.Aesthetics;

internal class MyWindow : Window
{
    public MyWindow()
    {
        Content.Content = new TetrisControl();
    }
}