﻿using Aesthetics.Base;
using Aesthetics.Controls;
using Aesthetics.Input;
using Aesthetics.Rendering;
using Bubble.Tetris;
using Bubble.Tetris.Assets;
using Cabinet;
using SDL2;
using Timer = System.Timers.Timer;

namespace Bubble.Aesthetics;

public class TetrisControl : Control
{
    private readonly TetrisGame tetrisGame = CreateTetrisGame();

    private readonly Dictionary<Key, Action<TetrisGame>> keyboard = new()
    {
        [Key.Up] = tetrisGame => tetrisGame.Rotate(),
        [Key.Right] = tetrisGame => tetrisGame.MoveRight(),
        [Key.Down] = tetrisGame => tetrisGame.MoveDown(),
        [Key.Left] = tetrisGame => tetrisGame.MoveLeft(),
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

    private readonly Timer timer = new(1000);

    public TetrisControl()
    {
        timer.Elapsed += (x, y) => tetrisGame.MoveDown();
        timer.Start();
    }

    public override void OnKeyDown(Key key)
    {
        keyboard[key](tetrisGame);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        static Vector2 TransformPosition(Vector2 pos) => new(pos.X, -pos.Y + 19);
        field.Dots = tetrisGame.Field.Select(x => (TransformPosition(x.Position), Color.FromRgba(230, 35, 35, 255)));
        field.Render(drawingContext);

        linesCounter.Dots = Enumerable
            .Range(0, tetrisGame.TotalLinesCollapsed)
            .Select(x => (new Vector2(x, 0), Color.FromRgba(230, 35, 35, 255)));
        linesCounter.Render(drawingContext);

        SDL.SDL_RenderPresent(drawingContext.Id);
    }

    private static TetrisGame CreateTetrisGame()
    {
        var tetraminosBlockRepresentation = new TetraminoAssetExtractor(StandardTetraminos.Data);
        var position = new Vector2(4, 18);
        var tetraminoFactory = new TetraminoFactory(tetraminosBlockRepresentation, position);
        return new TetrisGame(tetraminoFactory, StandardBoundaries.Create());
    }
}