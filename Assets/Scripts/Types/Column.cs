using System;

public readonly struct Column
{
    public readonly static Column A = new(1);
    public readonly static Column B = new(2);
    public readonly static Column C = new(3);
    public readonly static Column D = new(4);
    public readonly static Column E = new(5);
    public readonly static Column F = new(6);
    public readonly static Column G = new(7);
    public readonly static Column H = new(8);
    public readonly static Column I = new(9);

    readonly int value;
    Column(int col) => value = col;

    public static implicit operator int(Column col) => col.value;
    public static implicit operator Column(int col) =>
        col switch
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

    public readonly override string ToString() => value.ToString();
    public readonly string ToClass() => $"col{ToString()}";
}