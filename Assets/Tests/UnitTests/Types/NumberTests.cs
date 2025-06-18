using System;
using NUnit.Framework;

public class NumberTests : BaseTests
{
    const int RANGE_LENGTH = 9;

    public record Target(Number Value, int Index, string ToStringResult);
    static readonly Target[] Targets = {
        new((Number)1, 1, "1"),
        new((Number)2, 2, "2"),
        new((Number)3, 3, "3"),
        new((Number)4, 4, "4"),
        new((Number)5, 5, "5"),
        new((Number)6, 6, "6"),
        new((Number)7, 7, "7"),
        new((Number)8, 8, "8"),
        new((Number)9, 9, "9")
    };
    static readonly int[] ExceptionTargets = { -1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024 };

    static Number Get(int i) => (Number)i;

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(Targets.Length, RANGE_LENGTH);

    [Test]
    public void Creations([Range(1, RANGE_LENGTH)] int i)
    {
        Assert.DoesNotThrow(() => Get(i));
    }

    [Test]
    public void Exceptions([ValueSource(nameof(ExceptionTargets))] int i)
    {
        Assert.Throws<NotImplementedException>(() => Get(i));
    }

    [Test, Pairwise]
    public void ValueComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value, t2.Value);
        else Assert.AreNotEqual(t1.Value, t2.Value);
    }

    [Test, Pairwise]
    public void StringComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value.ToString(), t2.ToStringResult);
        else Assert.AreNotEqual(t1.Value.ToString(), t2.ToStringResult);
    }
}
