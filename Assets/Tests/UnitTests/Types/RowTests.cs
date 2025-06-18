using System;
using NUnit.Framework;

public class RowTests : BaseTests
{
    const int RANGE_LENGTH = 9;

    public record Target(Row Value, int Index, string ToStringResult, string ToClassResult);
    static readonly Target[] Targets = {
        new((Row)1, 1, "A", "rowA"),
        new((Row)2, 2, "B", "rowB"),
        new((Row)3, 3, "C", "rowC"),
        new((Row)4, 4, "D", "rowD"),
        new((Row)5, 5, "E", "rowE"),
        new((Row)6, 6, "F", "rowF"),
        new((Row)7, 7, "G", "rowG"),
        new((Row)8, 8, "H", "rowH"),
        new((Row)9, 9, "I", "rowI")
    };
    static readonly int[] ExceptionTargets = { -1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024 };

    static Row Get(int i) => (Row)i;

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

    [Test, Pairwise]
    public void ClassComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value.ToClass(), t2.ToClassResult);
        else Assert.AreNotEqual(t1.Value.ToClass(), t2.ToClassResult);
    }
}