using System;
using NUnit.Framework;

public class BoxTests : BaseTests
{
    const int RANGE_LENGTH = 9;

    public record Target(Box Value, int Index, string ToStringResult, string ToClassResult);
    static readonly Target[] Targets = {
        new((Box)1, 1, "1", "box1"),
        new((Box)2, 2, "2", "box2"),
        new((Box)3, 3, "3", "box3"),
        new((Box)4, 4, "4", "box4"),
        new((Box)5, 5, "5", "box5"),
        new((Box)6, 6, "6", "box6"),
        new((Box)7, 7, "7", "box7"),
        new((Box)8, 8, "8", "box8"),
        new((Box)9, 9, "9", "box9")
    };
    static readonly int[] ExceptionTargets = { -1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024 };

    static Box Get(int i) => (Box)i;

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