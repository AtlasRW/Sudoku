using System;
using NUnit.Framework;

public class PositionTests
{
    public record Target(Position Pos, int RowIndex, int ColIndex, string ToStringResult);

    static readonly Target[] T = {
        new(Position.Get(Row.A, Column.A), 1, 1, "A1"),
        new(Position.Get(Row.A, Column.B), 1, 2, "A2"),
        new(Position.Get(Row.A, Column.C), 1, 3, "A3"),
        new(Position.Get(Row.A, Column.D), 1, 4, "A4"),
        new(Position.Get(Row.A, Column.E), 1, 5, "A5"),
        new(Position.Get(Row.A, Column.F), 1, 6, "A6"),
        new(Position.Get(Row.A, Column.G), 1, 7, "A7"),
        new(Position.Get(Row.A, Column.H), 1, 8, "A8"),
        new(Position.Get(Row.A, Column.I), 1, 9, "A9"),
        new(Position.Get(Row.B, Column.A), 2, 1, "B1"),
        new(Position.Get(Row.B, Column.B), 2, 2, "B2"),
        new(Position.Get(Row.B, Column.C), 2, 3, "B3"),
        new(Position.Get(Row.B, Column.D), 2, 4, "B4"),
        new(Position.Get(Row.B, Column.E), 2, 5, "B5"),
        new(Position.Get(Row.B, Column.F), 2, 6, "B6"),
        new(Position.Get(Row.B, Column.G), 2, 7, "B7"),
        new(Position.Get(Row.B, Column.H), 2, 8, "B8"),
        new(Position.Get(Row.B, Column.I), 2, 9, "B9"),
        new(Position.Get(Row.C, Column.A), 3, 1, "C1"),
        new(Position.Get(Row.C, Column.B), 3, 2, "C2"),
        new(Position.Get(Row.C, Column.C), 3, 3, "C3"),
        new(Position.Get(Row.C, Column.D), 3, 4, "C4"),
        new(Position.Get(Row.C, Column.E), 3, 5, "C5"),
        new(Position.Get(Row.C, Column.F), 3, 6, "C6"),
        new(Position.Get(Row.C, Column.G), 3, 7, "C7"),
        new(Position.Get(Row.C, Column.H), 3, 8, "C8"),
        new(Position.Get(Row.C, Column.I), 3, 9, "C9"),
        new(Position.Get(Row.D, Column.A), 4, 1, "D1"),
        new(Position.Get(Row.D, Column.B), 4, 2, "D2"),
        new(Position.Get(Row.D, Column.C), 4, 3, "D3"),
        new(Position.Get(Row.D, Column.D), 4, 4, "D4"),
        new(Position.Get(Row.D, Column.E), 4, 5, "D5"),
        new(Position.Get(Row.D, Column.F), 4, 6, "D6"),
        new(Position.Get(Row.D, Column.G), 4, 7, "D7"),
        new(Position.Get(Row.D, Column.H), 4, 8, "D8"),
        new(Position.Get(Row.D, Column.I), 4, 9, "D9"),
        new(Position.Get(Row.E, Column.A), 5, 1, "E1"),
        new(Position.Get(Row.E, Column.B), 5, 2, "E2"),
        new(Position.Get(Row.E, Column.C), 5, 3, "E3"),
        new(Position.Get(Row.E, Column.D), 5, 4, "E4"),
        new(Position.Get(Row.E, Column.E), 5, 5, "E5"),
        new(Position.Get(Row.E, Column.F), 5, 6, "E6"),
        new(Position.Get(Row.E, Column.G), 5, 7, "E7"),
        new(Position.Get(Row.E, Column.H), 5, 8, "E8"),
        new(Position.Get(Row.E, Column.I), 5, 9, "E9"),
        new(Position.Get(Row.F, Column.A), 6, 1, "F1"),
        new(Position.Get(Row.F, Column.B), 6, 2, "F2"),
        new(Position.Get(Row.F, Column.C), 6, 3, "F3"),
        new(Position.Get(Row.F, Column.D), 6, 4, "F4"),
        new(Position.Get(Row.F, Column.E), 6, 5, "F5"),
        new(Position.Get(Row.F, Column.F), 6, 6, "F6"),
        new(Position.Get(Row.F, Column.G), 6, 7, "F7"),
        new(Position.Get(Row.F, Column.H), 6, 8, "F8"),
        new(Position.Get(Row.F, Column.I), 6, 9, "F9"),
        new(Position.Get(Row.G, Column.A), 7, 1, "G1"),
        new(Position.Get(Row.G, Column.B), 7, 2, "G2"),
        new(Position.Get(Row.G, Column.C), 7, 3, "G3"),
        new(Position.Get(Row.G, Column.D), 7, 4, "G4"),
        new(Position.Get(Row.G, Column.E), 7, 5, "G5"),
        new(Position.Get(Row.G, Column.F), 7, 6, "G6"),
        new(Position.Get(Row.G, Column.G), 7, 7, "G7"),
        new(Position.Get(Row.G, Column.H), 7, 8, "G8"),
        new(Position.Get(Row.G, Column.I), 7, 9, "G9"),
        new(Position.Get(Row.H, Column.A), 8, 1, "H1"),
        new(Position.Get(Row.H, Column.B), 8, 2, "H2"),
        new(Position.Get(Row.H, Column.C), 8, 3, "H3"),
        new(Position.Get(Row.H, Column.D), 8, 4, "H4"),
        new(Position.Get(Row.H, Column.E), 8, 5, "H5"),
        new(Position.Get(Row.H, Column.F), 8, 6, "H6"),
        new(Position.Get(Row.H, Column.G), 8, 7, "H7"),
        new(Position.Get(Row.H, Column.H), 8, 8, "H8"),
        new(Position.Get(Row.H, Column.I), 8, 9, "H9"),
        new(Position.Get(Row.I, Column.A), 9, 1, "I1"),
        new(Position.Get(Row.I, Column.B), 9, 2, "I2"),
        new(Position.Get(Row.I, Column.C), 9, 3, "I3"),
        new(Position.Get(Row.I, Column.D), 9, 4, "I4"),
        new(Position.Get(Row.I, Column.E), 9, 5, "I5"),
        new(Position.Get(Row.I, Column.F), 9, 6, "I6"),
        new(Position.Get(Row.I, Column.G), 9, 7, "I7"),
        new(Position.Get(Row.I, Column.H), 9, 8, "I8"),
        new(Position.Get(Row.I, Column.I), 9, 9, "I9")
    };

    [Test]
    public void Creations([Range(1, 9)] int i, [Range(1, 9)] int j)
    {
        Assert.DoesNotThrow(() => Position.Get(i, j));
    }

    [Test]
    public void Exceptions([Range(1, 9)] int i, [Values(-1024, -5, -4, -3, -2, -1, 0, 10, 11, 12, 13, 14, 15, 1024)] int j)
    {
        Assert.Throws<NotImplementedException>(() => Position.Get(i, j));
        Assert.Throws<NotImplementedException>(() => Position.Get(j, i));
    }

    [Test]
    public void TypesCheck([ValueSource("T")] Target t)
    {
        Assert.IsNotNull(t.Pos);
        Assert.AreEqual($"{t.Pos.GetType()}", "Position");
    }

    [Test, Pairwise]
    public void Comparisons([ValueSource("T")] Target t, [Range(1, 9)] int i, [Range(1, 9)] int j)
    {
        if (t.RowIndex == i && t.ColIndex == j)
            Assert.AreEqual(t.Pos, Position.Get(i, j));
        else
            Assert.AreNotEqual(t.Pos, Position.Get(i, j));
    }

    [Test, Pairwise]
    public void ConversionsString([ValueSource("T")] Target t, [Range(1, 9)] int i, [Range(1, 9)] int j)
    {
        string _str = $"{Row.Get(i)}{Column.Get(j)}";

        if (t.ToStringResult == _str)
            Assert.AreEqual(t.Pos.ToString(), _str);
        else
            Assert.AreNotEqual(t.Pos.ToString(), _str);
    }
}
