using System;
using NUnit.Framework;

public class ColumnTests : BaseTests
{
    const int RANGE_LENGTH = 9;

    public record Target(Column Value, int Index, string ToStringResult, string ToClassResult);
    static readonly Target[] Targets = {
        new((Column)1, 1, "1", "col1"),
        new((Column)2, 2, "2", "col2"),
        new((Column)3, 3, "3", "col3"),
        new((Column)4, 4, "4", "col4"),
        new((Column)5, 5, "5", "col5"),
        new((Column)6, 6, "6", "col6"),
        new((Column)7, 7, "7", "col7"),
        new((Column)8, 8, "8", "col8"),
        new((Column)9, 9, "9", "col9")
    };
    static readonly int[] ExceptionTargets = { -1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024 };

    static Column Get(int i) => (Column)i;

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
