public struct Position
{
    readonly byte value;
    public Row row;
    public Column column;
    public Box box;
    Position(byte v)
    {
        if (v < 1 || v > 81) throw Error.Number(1, 81);

        value = v;
        column = (Column)(value % 9 == 0 ? 9 : value % 9);
        row = (Row)(column == 9 ? value / 9 : value / 9 + 1);
        box = (row, column);
    }

    public static implicit operator byte(Position pos) => pos.value;
    public static implicit operator Position(byte index) => new(index);

    public readonly bool Aligns(Position pos) => column == pos.column || row == pos.row || box == pos.box;

    public readonly override string ToString() => $"{row}{column}";
    public readonly string[] ToClasses() =>
        new[] {
            row.ToClass(),
            column.ToClass(),
            box.ToClass()
        };
}