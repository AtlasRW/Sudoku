public struct Cell
{
    public readonly Position Position;
    public readonly Number Value;

    public Number? CurrentValue;
    public State State;

    // private Button Element;

    public Cell(int position, int value, bool prefill = false)
    {
        Position = position;
        Value = value;
        CurrentValue = prefill ? value : null;
        State = prefill ? State.PREFILLED : State.EMPTY;
    }

    public readonly override string ToString() => Position.ToString();

    public readonly bool Aligns(Position pos) => Position.Aligns(pos);
    public readonly bool Matches(Number? num) => num is Number && Value == num;
    public readonly bool MatchesCurrent(Number? num) => num is Number && CurrentValue == num;
}
