using System;

public enum Difficulty : byte
{
    EASY,
    MEDIUM,
    HARD,
    EXPERT,
    MASTER,
    EXTREME
}

public static partial class Extensions
{
    public static int ToPrefills(this Difficulty difficulty) =>
        difficulty switch
        {
            Difficulty.EASY => Random.Int(30, 32),
            Difficulty.MEDIUM => Random.Int(28, 30),
            Difficulty.HARD => Random.Int(25, 27),
            Difficulty.EXPERT => Random.Int(23, 25),
            Difficulty.MASTER => Random.Int(20, 22),
            Difficulty.EXTREME => Random.Int(17, 19),
            _ => throw new NotImplementedException()
        };
}