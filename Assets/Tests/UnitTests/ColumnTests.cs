using System;
using NUnit.Framework;

public class ColumnTests
{
    public record Target(Column Col, int Index, string ToStringResult, string ToClassNameResult);

    static readonly Target[] Targets = {
        new(Column.A, 1, "1", "col1"),
        new(Column.B, 2, "2", "col2"),
        new(Column.C, 3, "3", "col3"),
        new(Column.D, 4, "4", "col4"),
        new(Column.E, 5, "5", "col5"),
        new(Column.F, 6, "6", "col6"),
        new(Column.G, 7, "7", "col7"),
        new(Column.H, 8, "8", "col8"),
        new(Column.I, 9, "9", "col9")
    };

    [OneTimeSetUp]
    public void Init() => Assert.AreEqual(Targets.Length, 9);

    [Test]
    public void Creations([Range(1, 9)] int i)
    {
        Assert.DoesNotThrow(() => Column.Get(i));
    }

    [Test]
    public void Exceptions([Values(-1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024)] int i)
    {
        Assert.Throws<NotImplementedException>(() => Column.Get(i));
    }

    [Test]
    public void TypesCheck([ValueSource(nameof(Targets))] Target t)
    {
        Assert.IsNotNull(t.Col);
        Assert.AreEqual($"{t.Col.GetType()}", "Column");
    }

    [Test]
    public void Comparisons([ValueSource(nameof(Targets))] Target t, [Range(1, 9)] int i)
    {
        if (t.Index == i)
            Assert.AreEqual(t.Col, Column.Get(i));
        else
            Assert.AreNotEqual(t.Col, Column.Get(i));
    }

    [Test]
    public void ConversionsString([ValueSource(nameof(Targets))] Target t, [Values("1", "2", "3", "4", "5", "6", "7", "8", "9")] string i)
    {
        if (t.ToStringResult == i)
            Assert.AreEqual(t.Col.ToString(), i);
        else
            Assert.AreNotEqual(t.Col.ToString(), i);
    }

    [Test]
    public void ConversionsClassName([ValueSource(nameof(Targets))] Target t, [Values("col1", "col2", "col3", "col4", "col5", "col6", "col7", "col8", "col9")] string i)
    {
        if (t.ToClassNameResult == i)
            Assert.AreEqual(t.Col.ToClassName(), i);
        else
            Assert.AreNotEqual(t.Col.ToClassName(), i);
    }
}
