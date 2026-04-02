using System;
using UnityEngine;

[Serializable]
public struct Cell
{
    [SerializeField] public Position Position;
    [SerializeField] public Number Value;

    [SerializeField] public Number? CurrentValue;
    [SerializeField] public State State;

    // Button Element;

    public Cell(byte position, byte value, bool prefill = false)
    {
        Position = position;
        Value = value;
        CurrentValue = prefill ? value : null;
        State = prefill ? State.PREFILLED : State.EMPTY;
    }

    public readonly override string ToString() => $"{Position}:{Value}:{CurrentValue?.ToString() ?? "X"}";

    public static implicit operator CellInstance(Cell cell) => new(cell);
    public static implicit operator Cell(CellInstance instance) => instance.Cell;

    public readonly bool Aligns(Position? value) => value is Position pos && Position.Aligns(pos);
    public readonly bool Matches(Number? value) => value is Number num && Value == num;
    public readonly bool MatchesCurrent(Number? value) => value is Number num && CurrentValue == num;

    public static bool operator ==(Cell a, Cell b) => a.Equals(b);
    public static bool operator !=(Cell a, Cell b) => !a.Equals(b);
    public readonly override bool Equals(object obj) => obj is Cell cell && Position == cell.Position;
    public readonly override int GetHashCode() => (Position, Value, CurrentValue, State).GetHashCode();
}
