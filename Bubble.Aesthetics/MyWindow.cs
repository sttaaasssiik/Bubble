using Aesthetics.Base;

namespace Bubble.Aesthetics;

internal class MyWindow : Window
{
	public MyWindow()
	{
		Content.Content = new TetrisControl();
	}
}