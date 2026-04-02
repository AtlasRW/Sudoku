public readonly struct Row
{
    readonly byte value;
    Row(byte row) => value = row;

    public static implicit operator byte(Row row) => row.value;
    public static implicit operator Row(byte row) => row switch
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

    public readonly override string ToString() => value switch
    {
        1 => "A",
        2 => "B",
        3 => "C",
        4 => "D",
        5 => "E",
        6 => "F",
        7 => "G",
        8 => "H",
        9 => "I",
        _ => throw Error.Number()
    };
    public readonly string ToClass() => $"row{ToString()}";
}