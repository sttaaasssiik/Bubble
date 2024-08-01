using SDL2;

namespace Aesthetics.Input;

public class UIEventArgs : EventArgs
{
    public SDL.SDL_Event SDL_Event { get; internal set; }
}