public readonly struct Box
{
    readonly byte value;
    Box(byte box) => value = box;
    Box(byte row, byte column) => value = row switch
    {
        1 or 2 or 3 =>
            column switch
            {
                1 or 2 or 3 => 1,
                4 or 5 or 6 => 2,
                7 or 8 or 9 => 3,
                _ => throw Error.Number()
            },
        4 or 5 or 6 =>
            column switch
            {
                1 or 2 or 3 => 4,
                4 or 5 or 6 => 5,
                7 or 8 or 9 => 6,
                _ => throw Error.Number()
            },
        7 or 8 or 9 =>
            column switch
            {
                1 or 2 or 3 => 7,
                4 or 5 or 6 => 8,
                7 or 8 or 9 => 9,
                _ => throw Error.Number()
            },
        _ => throw Error.Number()
    };

    public static implicit operator byte(Box box) => box.value;
    public static implicit operator Box(byte box) => box switch
    {
        1 => new(1),
        2 => new(2),
        3 => new(3),
        4 => new(4),
        5 => new(5),
        6 => new(6),
        7 => new(7),
        8 => new(8),
        9 => new(9),
        _ => throw Error.Number()
    };
    public static implicit operator Box((Row row, Column column) pos) => new(pos.row, pos.column);

    public readonly override string ToString() => value.ToString();
    public readonly string ToClass() => $"box{ToString()}";
}