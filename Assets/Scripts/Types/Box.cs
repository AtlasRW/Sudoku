using System;

public readonly struct Box
{
    public readonly static Box A = new(1);
    public readonly static Box B = new(2);
    public readonly static Box C = new(3);
    public readonly static Box D = new(4);
    public readonly static Box E = new(5);
    public readonly static Box F = new(6);
    public readonly static Box G = new(7);
    public readonly static Box H = new(8);
    public readonly static Box I = new(9);

    readonly int value;
    Box(int box) => value = box;

    public static implicit operator int(Box box) => box.value;
    public static implicit operator Box(int box) =>
        box switch
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
    public readonly string ToClass() => $"box{ToString()}";
}