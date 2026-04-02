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
    public static byte ToPrefills(this Difficulty difficulty) =>
        difficulty switch
        {
            Difficulty.EASY => Random.Byte(30, 32),
            Difficulty.MEDIUM => Random.Byte(28, 30),
            Difficulty.HARD => Random.Byte(25, 27),
            Difficulty.EXPERT => Random.Byte(23, 25),
            Difficulty.MASTER => Random.Byte(20, 22),
            Difficulty.EXTREME => Random.Byte(17, 19),
            _ => throw Error.Enum(difficulty)
        };
}