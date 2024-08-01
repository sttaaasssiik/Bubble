//using Aesthetics.Base;
//using Aesthetics.Controls;
//using Bubble.Snake;
//using Cabinet;
//using SDL2;

//namespace Bubble.UI;

//public class SnakeWindow : Window
//{
//    private readonly Dictionary<SDL.SDL_Keycode, Func<SnakeGame, GameState>> keyboard = new()
//    {
//        [SDL.SDL_Keycode.SDLK_UP] = snakeGame => snakeGame.Move(Direction.Down),
//        [SDL.SDL_Keycode.SDLK_RIGHT] = snakeGame => snakeGame.Move(Direction.Right),
//        [SDL.SDL_Keycode.SDLK_DOWN] = snakeGame => snakeGame.Move(Direction.Up),
//        [SDL.SDL_Keycode.SDLK_LEFT] = snakeGame => snakeGame.Move(Direction.Left),
//    };

//    public SnakeWindow()
//    {
//        SnakeGame snakeGame = new(new(20, 20));

//        DotMatrixDisplay dotMatrixDisplay = new(new Vector2(20, 20), new Vector2(20, 20))
//        {
//            Background = Color.FromRgba(20, 20, 20, 225),
//            Position = new Vector2(100, 100)
//        };

//        SimpleCanvas.Children.Add(dotMatrixDisplay);

//        void SetDots()
//        {
//            dotMatrixDisplay.Dots = snakeGame.Snake
//                .Select(x => (x, Color.FromRgba(255, 0, 0, 255)))
//                .Append((snakeGame.Piece, Color.FromRgba(0, 255, 0, 255)));
//        }

//        SetDots();

//        UIEvent += e =>
//        {
//            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
//            {
//                if (keyboard[e.key.keysym.sym](snakeGame) == GameState.GameOver)
//                {
//                    Console.WriteLine(GameState.GameOver);
//                }
//                SetDots();
//            }
//        };
//    }
//}