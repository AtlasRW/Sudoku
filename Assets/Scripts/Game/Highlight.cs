using System;

public readonly struct Highlight
{
    public enum EHighlight
    {
        NONE,
        ALIGNED,
        MATCHED
    }

    public readonly static Highlight NONE = new(EHighlight.NONE);
    public readonly static Highlight ALIGNED = new(EHighlight.ALIGNED);
    public readonly static Highlight MATCHED = new(EHighlight.MATCHED);

    readonly EHighlight value;
    Highlight(EHighlight state) => value = state;

    public static Highlight Get(EHighlight state) =>
        state switch
        {
            EHighlight.NONE => NONE,
            EHighlight.ALIGNED => ALIGNED,
            EHighlight.MATCHED => MATCHED,
            _ => throw new NotImplementedException()
        };

    public static bool operator ==(Highlight a, Highlight b) => a.Equals(b);
    public static bool operator !=(Highlight a, Highlight b) => !a.Equals(b);
    public readonly override int GetHashCode() => value.GetHashCode();
    public readonly override bool Equals(object obj) => obj is Highlight highlight && value == highlight.value;

    public readonly string ToClassName() =>
        value switch
        {
            EHighlight.NONE => null,
            EHighlight.ALIGNED => "aligned",
            EHighlight.MATCHED => "matched",
            _ => throw new NotImplementedException()
        };
}