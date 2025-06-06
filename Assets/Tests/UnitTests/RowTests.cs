using System;
using NUnit.Framework;

public class RowTests
{
    public record Target(Row Row, int Index, string ToStringResult, string ToClassNameResult);

    static readonly Target[] T = {
        new(Row.A, 1, "A", "rowA"),
        new(Row.B, 2, "B", "rowB"),
        new(Row.C, 3, "C", "rowC"),
        new(Row.D, 4, "D", "rowD"),
        new(Row.E, 5, "E", "rowE"),
        new(Row.F, 6, "F", "rowF"),
        new(Row.G, 7, "G", "rowG"),
        new(Row.H, 8, "H", "rowH"),
        new(Row.I, 9, "I", "rowI")
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(T.Length, 9);

    [Test]
    public void Creations([Range(1, 9)] int i)
    {
        Assert.DoesNotThrow(() => Row.Get(i));
    }

    [Test]
    public void Exceptions([Values(-1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024)] int i)
    {
        Assert.Throws<NotImplementedException>(() => Row.Get(i));
    }

    [Test]
    public void TypesCheck([ValueSource("T")] Target t)
    {
        Assert.IsNotNull(t.Row);
        Assert.AreEqual($"{t.Row.GetType()}", "Row");
    }

    [Test]
    public void Comparisons([ValueSource("T")] Target t, [Range(1, 9)] int i)
    {
        if (t.Index == i)
            Assert.AreEqual(t.Row, Row.Get(i));
        else
            Assert.AreNotEqual(t.Row, Row.Get(i));
    }

    [Test]
    public void ConversionsString([ValueSource("T")] Target t, [Values("A", "B", "C", "D", "E", "F", "G", "H", "I")] string i)
    {
        if (t.ToStringResult == i)
            Assert.AreEqual(t.Row.ToString(), i);
        else
            Assert.AreNotEqual(t.Row.ToString(), i);
    }

    [Test]
    public void ConversionsClassName([ValueSource("T")] Target t, [Values("rowA", "rowB", "rowC", "rowD", "rowE", "rowF", "rowG", "rowH", "rowI")] string i)
    {
        if (t.ToClassNameResult == i)
            Assert.AreEqual(t.Row.ToClassName(), i);
        else
            Assert.AreNotEqual(t.Row.ToClassName(), i);
    }
}