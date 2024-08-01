﻿using Cabinet;

namespace Bubble.Tetris.Assets;

public static class StandardTetraminos
{
    public static List<List<List<Block>>> Data => new() { ITetramino, OTetramino, LTetramino };

    public static List<List<Block>> ITetramino =>
        new()
        {
            new ()
            {
                new("I", new Vector2(0, 0)),
                new("I", new Vector2(0, -1)),
                new("I", new Vector2(0, -2)),
                new("I", new Vector2(0, -3)),
            },
            new ()
            {
                new("I", new Vector2(-2, -1)),
                new("I", new Vector2(-1, -1)),
                new("I", new Vector2(0, -1)),
                new("I", new Vector2(1, -1))
            }
        };

    public static List<List<Block>> OTetramino =>
        new()
        {
            new()
            {
                new("O", new Vector2(0, 0)),
                new("O", new Vector2(0, -1)),
                new("O", new Vector2(1, 0)),
                new("O", new Vector2(1, -1)),
            },
        };

    public static List<List<Block>> LTetramino =>
        new()
        {
            new()
            {
                new("L", new Vector2(0, 0)),
                new("L", new Vector2(0, -1)),
                new("L", new Vector2(0, -2)),
                new("L", new Vector2(1, -2)),
            },
            new()
            {
                new("L", new Vector2(-1, -1)),
                new("L", new Vector2(0, -1)),
                new("L", new Vector2(1, -1)),
                new("L", new Vector2(-1, -2)),
            },
            new()
            {
                new("L", new Vector2(0, -2)),
                new("L", new Vector2(0, -1)),
                new("L", new Vector2(0, 0)),
                new("L", new Vector2(-1, 0)),
            },
            new()
            {
                new("L", new Vector2(-1, -1)),
                new("L", new Vector2(0, -1)),
                new("L", new Vector2(1, -1)),
                new("L", new Vector2(1, 0)),
            },
        };

}