using System;

public readonly struct Row
{
    public readonly static Row A = new(1);
    public readonly static Row B = new(2);
    public readonly static Row C = new(3);
    public readonly static Row D = new(4);
    public readonly static Row E = new(5);
    public readonly static Row F = new(6);
    public readonly static Row G = new(7);
    public readonly static Row H = new(8);
    public readonly static Row I = new(9);

    readonly int value;
    Row(int row) => value = row;

    public static implicit operator int(Row row) => row.value;
    public static implicit operator Row(int row) =>
        row switch
        {
            1 => A,
            2 => B,
            3 => C,
            4 => D,
            5 => E,
            6 => F,
            7 => G,
            8 => H,
            9 => I,
            _ => throw new NotImplementedException()
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
        _ => throw new NotImplementedException()
    };
    public readonly string ToClass() => $"row{ToString()}";
}