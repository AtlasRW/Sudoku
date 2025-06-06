using System;

public readonly struct Number
{
    public readonly static Number ONE = new(1);
    public readonly static Number TWO = new(2);
    public readonly static Number THREE = new(3);
    public readonly static Number FOUR = new(4);
    public readonly static Number FIVE = new(5);
    public readonly static Number SIX = new(6);
    public readonly static Number SEVEN = new(7);
    public readonly static Number EIGHT = new(8);
    public readonly static Number NINE = new(9);

    readonly int value;
    Number(int num) => value = num;

    public static Number Get(int num) =>
        num switch
        {
            1 => ONE,
            2 => TWO,
            3 => THREE,
            4 => FOUR,
            5 => FIVE,
            6 => SIX,
            7 => SEVEN,
            8 => EIGHT,
            9 => NINE,
            _ => throw new NotImplementedException()
        };

    public static bool operator ==(Number a, Number b) => a.Equals(b);
    public static bool operator !=(Number a, Number b) => !a.Equals(b);
    public readonly override int GetHashCode() => value.GetHashCode();
    public readonly override bool Equals(object obj) => obj is Number num && value == num.value;

    public readonly override string ToString() => value.ToString();

    public readonly int ToInt() => value;
}