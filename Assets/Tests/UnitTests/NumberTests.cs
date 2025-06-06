using System;
using NUnit.Framework;

public class NumberTests
{
    public record Target(Number Num, int Index, int ToIntResult, string ToStringResult);

    static readonly Target[] T = {
        new(Number.ONE, 1, 1, "1"),
        new(Number.TWO, 2, 2, "2"),
        new(Number.THREE, 3, 3, "3"),
        new(Number.FOUR, 4, 4, "4"),
        new(Number.FIVE, 5, 5, "5"),
        new(Number.SIX, 6, 6, "6"),
        new(Number.SEVEN, 7, 7, "7"),
        new(Number.EIGHT, 8, 8, "8"),
        new(Number.NINE, 9, 9, "9")
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(T.Length, 9);

    [Test]
    public void Creations([Range(1, 9)] int i)
    {
        Assert.DoesNotThrow(() => Number.Get(i));
    }

    [Test]
    public void Exceptions([Values(-1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024)] int i)
    {
        Assert.Throws<NotImplementedException>(() => Number.Get(i));
    }

    [Test]
    public void TypesCheck([ValueSource("T")] Target t)
    {
        Assert.IsNotNull(t.Num);
        Assert.AreEqual($"{t.Num.GetType()}", "Number");
    }

    [Test]
    public void Comparisons([ValueSource("T")] Target t, [Range(1, 9)] int i)
    {
        if (t.Index == i)
            Assert.AreEqual(t.Num, Number.Get(i));
        else
            Assert.AreNotEqual(t.Num, Number.Get(i));
    }

    [Test]
    public void ConversionsInteger([ValueSource("T")] Target t, [Range(1, 9)] int i)
    {
        if (t.ToIntResult == i)
            Assert.AreEqual(t.Num.ToInt(), i);
        else
            Assert.AreNotEqual(t.Num.ToInt(), i);
    }

    [Test]
    public void ConversionsString([ValueSource("T")] Target t, [Values("1", "2", "3", "4", "5", "6", "7", "8", "9")] string i)
    {
        if (t.ToStringResult == i)
            Assert.AreEqual(t.Num.ToString(), i);
        else
            Assert.AreNotEqual(t.Num.ToString(), i);
    }
}
