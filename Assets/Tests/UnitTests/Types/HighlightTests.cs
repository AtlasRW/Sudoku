using System;
using NUnit.Framework;

public class HighlightTests : BaseTests
{
    public record Target(Highlight Value, int Index, string ToClassResult, bool IsHighlightedResult);
    static readonly Target[] Targets = {
        new(Highlight.NONE, 1, null, false),
        new(Highlight.ALIGNED, 2, "aligned", true),
        new(Highlight.MATCHED, 3, "matched", true)
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(Targets.Length, Enum.GetNames(typeof(Highlight)).Length);

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
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value.IsHighlighted(), t2.IsHighlightedResult);
    }
}
