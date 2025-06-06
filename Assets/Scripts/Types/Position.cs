public readonly struct Position
{
    public readonly Row row;
    public readonly Column column;
    Position(Row r, Column c)
    {
        row = r;
        column = c;
    }

    public static Position Get(Row r, Column c) => new(r, c);
    public static Position Get(int r, int c) => new(Row.Get(r), Column.Get(c));

    public static bool operator ==(Position a, Position b) => a.Equals(b);
    public static bool operator !=(Position a, Position b) => !a.Equals(b);
    public readonly override int GetHashCode() => (row, column).GetHashCode();
    public readonly override bool Equals(object obj) => obj is Position pos && row.Equals(pos.row) && column.Equals(pos.column);

    public readonly override string ToString() => $"{row}{column}";
}