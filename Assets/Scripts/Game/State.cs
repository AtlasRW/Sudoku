using System;

public readonly struct State
{
    public enum EState
    {
        EMPTY,
        PREFILLED,
        FILLED,
        ERROR
    }

    public readonly static State EMPTY = new(EState.EMPTY);
    public readonly static State PREFILLED = new(EState.PREFILLED);
    public readonly static State FILLED = new(EState.FILLED);
    public readonly static State ERROR = new(EState.ERROR);

    readonly EState value;
    State(EState state) => value = state;

    public static State Get(EState state) =>
        state switch
        {
            EState.EMPTY => EMPTY,
            EState.PREFILLED => PREFILLED,
            EState.FILLED => FILLED,
            EState.ERROR => ERROR,
            _ => throw new NotImplementedException()
        };

    public static bool operator ==(State a, State b) => a.Equals(b);
    public static bool operator !=(State a, State b) => !a.Equals(b);
    public readonly override int GetHashCode() => value.GetHashCode();
    public readonly override bool Equals(object obj) => obj is State state && value == state.value;

    public readonly string ToClassName() =>
        value switch
        {
            EState.EMPTY => null,
            EState.PREFILLED => "prefilled",
            EState.FILLED => "filled",
            EState.ERROR => "error",
            _ => throw new NotImplementedException()
        };

    public readonly bool IsUpdatable() => Equals(EMPTY) || Equals(ERROR) || Equals(FILLED);
    public readonly bool IsErasable() => Equals(FILLED) || Equals(ERROR);
    public readonly bool IsRight() => Equals(PREFILLED) || Equals(FILLED);
    public readonly bool IsWrong() => Equals(EMPTY) || Equals(ERROR);
}