public enum Highlight : byte
{
    NONE,
    ALIGNED,
    MATCHED
}

public static partial class Extensions
{
    public static string ToClass(this Highlight highlight) =>
        highlight switch
        {
            Highlight.NONE => null,
            Highlight.ALIGNED => "aligned",
            Highlight.MATCHED => "matched",
            _ => throw Error.Enum(highlight)
        };

    public static bool IsHighlighted(this Highlight highlight) => highlight == Highlight.ALIGNED || highlight == Highlight.MATCHED;
}