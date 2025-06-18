using System;

public readonly struct Position
{
    readonly int value;
    public readonly Row row;
    public readonly Column column;
    public readonly Box box;
    Position(int v)
    {
        if (v < 1 || v > 81) throw new NotImplementedException("Position Index must be between 1 and 81");
        value = v;
        column = value % 9 == 0 ? 9 : value % 9;
        row = column == 9 ? value / 9 : value / 9 + 1;
        box = (int)row switch
        {
            1 or 2 or 3 =>
                (int)column switch
                {
                    1 or 2 or 3 => 1,
                    4 or 5 or 6 => 2,
                    7 or 8 or 9 => 3,
                    _ => 0
                },
            4 or 5 or 6 =>
                (int)column switch
                {
                    1 or 2 or 3 => 4,
                    4 or 5 or 6 => 5,
                    7 or 8 or 9 => 6,
                    _ => 0
                },
            7 or 8 or 9 =>
                (int)column switch
                {
                    1 or 2 or 3 => 7,
                    4 or 5 or 6 => 8,
                    7 or 8 or 9 => 9,
                    _ => 0
                },
            _ => 0
        };
    }

    public static implicit operator int(Position pos) => pos.value;
    public static implicit operator Position(int index) => new(index);

    public readonly bool Aligns(Position pos) => column == pos.column || row == pos.row || box == pos.box;

    public readonly override string ToString() => $"{row}{column}";
    public readonly string[] ToClasses() =>
        new[] {
            row.ToClass(),
            column.ToClass(),
            box.ToClass()
        };
}