using Aesthetics.Base;
using Aesthetics.Controls;
using Aesthetics.Input;
using Aesthetics.Rendering;
using Cabinet;
using SDL2;
using Tetris;
using Tetris.Assets;
using Timer = System.Timers.Timer;

namespace Bubble.Aesthetics;

public class TetrisControl : Control
{
	private readonly TetrisGame tetrisGame = StandardTetrisGame.Create();

	private readonly Dictionary<Key, Action<TetrisGame>> keyboard = new()
	{
		[Key.Up] = tetrisGame => tetrisGame.Rotate(),
		[Key.Right] = tetrisGame => tetrisGame.MoveRight(),
		[Key.Down] = tetrisGame => tetrisGame.MoveDown(),
		[Key.Left] = tetrisGame => tetrisGame.MoveLeft(),
	};

	private readonly Dictionary<string, Color> colors = new()
	{
		["I"] = Color.FromRgba(230, 35, 35, 255),
		["O"] = Color.FromRgba(35, 230, 35, 255),
		["L"] = Color.FromRgba(35, 35, 230, 255),
		["J"] = Color.FromRgba(200, 200, 200, 255),
		["S"] = Color.FromRgba(200, 200, 200, 255),
		["Z"] = Color.FromRgba(200, 200, 200, 255),
	};

	private readonly DotMatrixDisplaySimple field = new()
	{
		Background = Color.FromRgba(50, 50, 50, 255),
		Size = new Vector2(10, 20),
		DotSize = new Vector2(20, 20)
	};

	private readonly DotMatrixDisplaySimple linesCounter = new()
	{
		LocalPosition = new Vector2(220, 0),
		Background = Color.FromRgba(50, 50, 50, 255),
		Size = new Vector2(10, 10),
		DotSize = new Vector2(10, 10)
	};

	public TetrisControl()
	{
		var timer = new Timer(1000);
		timer.Elapsed += (x, y) => tetrisGame.MoveDown();
		timer.Start();

		static Vector2 TransformPosition(Vector2 pos) => new(pos.X, -pos.Y + 19);

		tetrisGame.FieldChanged += f =>
		{
			field.Dots = f.Select(x => (TransformPosition(x.Position), colors[x.Id]));
			linesCounter.Dots = Enumerable
				.Range(0, tetrisGame.TotalLinesCollapsed)
				.Select(x => (new Vector2(x, 0), Color.FromRgba(230, 35, 35, 255)));
		};
	}

	public override void OnKeyDown(Key key)
	{
		keyboard[key](tetrisGame);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		field.Render(drawingContext);
		linesCounter.Render(drawingContext);

		SDL.SDL_RenderPresent(drawingContext.Id);
	}
}