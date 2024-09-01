using Aesthetics.Input;
using Aesthetics.Rendering;
using SDL2;

namespace Aesthetics.Base;

public class Window
{
	private readonly nint windowImpl;

	private bool running = true;

	private readonly Dictionary<SDL.SDL_Keycode, Key> sdlToAesthetics = new()
	{
		[SDL.SDL_Keycode.SDLK_UP] = Key.Up,
		[SDL.SDL_Keycode.SDLK_RIGHT] = Key.Right,
		[SDL.SDL_Keycode.SDLK_DOWN] = Key.Down,
		[SDL.SDL_Keycode.SDLK_LEFT] = Key.Left,
	};

	public ContentControl Content { get; private set; } = null!;

	public string Title { get; set; } = "";

	public event UIEvent? UIEvent;

	public event RenderEvent? RenderEvent;

	public event KeyDown? KeyDown;

	protected DrawingContext DrawingContext { get; private set; } = null!;

	public Window()
	{
		windowImpl = SDL.SDL_CreateWindow(
				Title,
				SDL.SDL_WINDOWPOS_UNDEFINED,
				SDL.SDL_WINDOWPOS_UNDEFINED,
				640,
				640,
				SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

		if (windowImpl == nint.Zero)
		{
			Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
		}

		var rendererId = SDL.SDL_CreateRenderer(
			windowImpl,
			-1,
			SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
			SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

		if (rendererId == nint.Zero)
		{
			Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
		}

		DrawingContext = new DrawingContext(rendererId);
		Content = new ContentControl();

		SDL.SDL_SetRenderDrawBlendMode(DrawingContext.Id, SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND);
	}

	public void Run()
	{
		void PollEvents()
		{
			while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
			{
				switch (e.type)
				{
					case SDL.SDL_EventType.SDL_QUIT:
						running = false;
						break;
					case SDL.SDL_EventType.SDL_KEYDOWN:
						Content.Content?.OnKeyDown(sdlToAesthetics[e.key.keysym.sym]);
						break;
					default:
						UIEvent?.Invoke(e);
						break;
				}
			}
		}

		var renderer = new Renderer(DrawingContext);
		while (running)
		{
			PollEvents();
			Content.Render(DrawingContext);
			//RenderEvent?.Invoke(DrawingContext);
		}

		SDL.SDL_DestroyRenderer(DrawingContext.Id);
		SDL.SDL_DestroyWindow(windowImpl);
		SDL.SDL_Quit();
	}
}