public readonly struct Column
{
    readonly byte value;
    Column(byte col) => value = col;

    public static implicit operator byte(Column col) => col.value;
    public static implicit operator Column(byte col) => col switch
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

    public readonly override string ToString() => value.ToString();
    public readonly string ToClass() => $"col{ToString()}";
}