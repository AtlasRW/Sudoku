public readonly struct Number
{
    readonly byte value;
    Number(byte num) => value = num;

    public static implicit operator byte(Number num) => num.value;
    public static implicit operator Number(byte num) => num switch
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
}