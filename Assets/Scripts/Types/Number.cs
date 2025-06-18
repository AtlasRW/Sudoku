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

    public static implicit operator int(Number num) => num.value;
    public static implicit operator Number(int num) =>
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

    public readonly override string ToString() => value.ToString();
}