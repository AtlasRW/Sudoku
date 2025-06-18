using System;
using NUnit.Framework;

public class StateTests : BaseTests
{
    public record Target(State Value, int Index, string ToClassResult, bool IsUpdatableResult, bool IsErasableResult, bool IsValidResult);
    static readonly Target[] Targets = {
        new(State.EMPTY, 1, null, true, false, false),
        new(State.PREFILLED, 2, "prefilled", false, false, true),
        new(State.FILLED, 3, "filled", true, true, true),
        new(State.ERROR, 4, "error", true, true, false)
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(Targets.Length, Enum.GetNames(typeof(State)).Length);

    [Test, Pairwise]
    public void ValueComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value, t2.Value);
        else Assert.AreNotEqual(t1.Value, t2.Value);
    }

    [Test, Pairwise]
    public void ClassComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value.ToClass(), t2.ToClassResult);
        else Assert.AreNotEqual(t1.Value.ToClass(), t2.ToClassResult);
    }

    [Test, Pairwise]
    public void StatusComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index)
        {
            Assert.AreEqual(t1.Value.IsUpdatable(), t2.IsUpdatableResult);
            Assert.AreEqual(t1.Value.IsErasable(), t2.IsErasableResult);
            Assert.AreEqual(t1.Value.IsValid(), t2.IsValidResult);
        }
    }
}
