using System;

// public enum State
public enum State : byte
{
    EMPTY,
    PREFILLED,
    FILLED,
    ERROR
}

public static partial class Extensions
{
    public static string ToClass(this State state) =>
        state switch
        {
            State.EMPTY => null,
            State.PREFILLED => "prefilled",
            State.FILLED => "filled",
            State.ERROR => "error",
            _ => throw new NotImplementedException()
        };

    public static bool IsUpdatable(this State state) => state == State.EMPTY || state == State.ERROR || state == State.FILLED;
    public static bool IsErasable(this State state) => state == State.FILLED || state == State.ERROR;
    public static bool IsValid(this State state) => state == State.PREFILLED || state == State.FILLED;
}