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
    Box(int b) => value = b;

    public static Box Get(int box) =>
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
    public static Box Get(Row r, Column c) => Get(r.ToInt(), c.ToInt());
    public static Box Get(int r, int c) =>
        r switch
        {
            1 or 2 or 3 =>
                c switch
                {
                    1 or 2 or 3 => A,
                    4 or 5 or 6 => B,
                    7 or 8 or 9 => C,
                    _ => throw new NotImplementedException()
                },
            4 or 5 or 6 =>
                c switch
                {
                    1 or 2 or 3 => D,
                    4 or 5 or 6 => E,
                    7 or 8 or 9 => F,
                    _ => throw new NotImplementedException()
                },
            7 or 8 or 9 =>
                c switch
                {
                    1 or 2 or 3 => G,
                    4 or 5 or 6 => H,
                    7 or 8 or 9 => I,
                    _ => throw new NotImplementedException()
                },
            _ => throw new NotImplementedException()
        };

    public static bool operator ==(Box a, Box b) => a.Equals(b);
    public static bool operator !=(Box a, Box b) => !a.Equals(b);
    public readonly override int GetHashCode() => value.GetHashCode();
    public readonly override bool Equals(object obj) => obj is Box box && value == box.value;

    public readonly int ToInt() => value;
    public readonly override string ToString() => value.ToString();
    public readonly string ToClassName() => $"box{ToString()}";
}