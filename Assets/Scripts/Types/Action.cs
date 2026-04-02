public readonly struct Action
{
    public readonly CellInstance cell;
    public readonly Number? from;
    public readonly Number? to;
    public Action(CellInstance targetCell, Number? fromNum, Number? toNum)
    {
        cell = targetCell;
        from = fromNum;
        to = toNum;
    }

    public static bool operator ==(Action a, Action b) => a.Equals(b);
    public static bool operator !=(Action a, Action b) => !a.Equals(b);
    public readonly override int GetHashCode() => (cell, from, to).GetHashCode();
    public readonly override bool Equals(object obj) => obj is Action action && from == action.from && to == action.to;
}