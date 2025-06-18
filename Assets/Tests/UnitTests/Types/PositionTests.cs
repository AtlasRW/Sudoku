using System;
using NUnit.Framework;

public class PositionTests : BaseTests
{
    const int RANGE_LENGTH = 81;

    public record Target(Position Value, int Index, string ToStringResult, string[] ToClassesResult);
    static readonly Target[] Targets = {
        new((Position)1, 1, "A1", new[] {"rowA", "col1", "box1"}),
        new((Position)2, 2, "A2", new[] {"rowA", "col2", "box1"}),
        new((Position)3, 3, "A3", new[] {"rowA", "col3", "box1"}),
        new((Position)4, 4, "A4", new[] {"rowA", "col4", "box2"}),
        new((Position)5, 5, "A5", new[] {"rowA", "col5", "box2"}),
        new((Position)6, 6, "A6", new[] {"rowA", "col6", "box2"}),
        new((Position)7, 7, "A7", new[] {"rowA", "col7", "box3"}),
        new((Position)8, 8, "A8", new[] {"rowA", "col8", "box3"}),
        new((Position)9, 9, "A9", new[] {"rowA", "col9", "box3"}),
        new((Position)10, 10, "B1", new[] {"rowB", "col1", "box1"}),
        new((Position)11, 11, "B2", new[] {"rowB", "col2", "box1"}),
        new((Position)12, 12, "B3", new[] {"rowB", "col3", "box1"}),
        new((Position)13, 13, "B4", new[] {"rowB", "col4", "box2"}),
        new((Position)14, 14, "B5", new[] {"rowB", "col5", "box2"}),
        new((Position)15, 15, "B6", new[] {"rowB", "col6", "box2"}),
        new((Position)16, 16, "B7", new[] {"rowB", "col7", "box3"}),
        new((Position)17, 17, "B8", new[] {"rowB", "col8", "box3"}),
        new((Position)18, 18, "B9", new[] {"rowB", "col9", "box3"}),
        new((Position)19, 19, "C1", new[] {"rowC", "col1", "box1"}),
        new((Position)20, 20, "C2", new[] {"rowC", "col2", "box1"}),
        new((Position)21, 21, "C3", new[] {"rowC", "col3", "box1"}),
        new((Position)22, 22, "C4", new[] {"rowC", "col4", "box2"}),
        new((Position)23, 23, "C5", new[] {"rowC", "col5", "box2"}),
        new((Position)24, 24, "C6", new[] {"rowC", "col6", "box2"}),
        new((Position)25, 25, "C7", new[] {"rowC", "col7", "box3"}),
        new((Position)26, 26, "C8", new[] {"rowC", "col8", "box3"}),
        new((Position)27, 27, "C9", new[] {"rowC", "col9", "box3"}),
        new((Position)28, 28, "D1", new[] {"rowD", "col1", "box4"}),
        new((Position)29, 29, "D2", new[] {"rowD", "col2", "box4"}),
        new((Position)30, 30, "D3", new[] {"rowD", "col3", "box4"}),
        new((Position)31, 31, "D4", new[] {"rowD", "col4", "box5"}),
        new((Position)32, 32, "D5", new[] {"rowD", "col5", "box5"}),
        new((Position)33, 33, "D6", new[] {"rowD", "col6", "box5"}),
        new((Position)34, 34, "D7", new[] {"rowD", "col7", "box6"}),
        new((Position)35, 35, "D8", new[] {"rowD", "col8", "box6"}),
        new((Position)36, 36, "D9", new[] {"rowD", "col9", "box6"}),
        new((Position)37, 37, "E1", new[] {"rowE", "col1", "box4"}),
        new((Position)38, 38, "E2", new[] {"rowE", "col2", "box4"}),
        new((Position)39, 39, "E3", new[] {"rowE", "col3", "box4"}),
        new((Position)40, 40, "E4", new[] {"rowE", "col4", "box5"}),
        new((Position)41, 41, "E5", new[] {"rowE", "col5", "box5"}),
        new((Position)42, 42, "E6", new[] {"rowE", "col6", "box5"}),
        new((Position)43, 43, "E7", new[] {"rowE", "col7", "box6"}),
        new((Position)44, 44, "E8", new[] {"rowE", "col8", "box6"}),
        new((Position)45, 45, "E9", new[] {"rowE", "col9", "box6"}),
        new((Position)46, 46, "F1", new[] {"rowF", "col1", "box4"}),
        new((Position)47, 47, "F2", new[] {"rowF", "col2", "box4"}),
        new((Position)48, 48, "F3", new[] {"rowF", "col3", "box4"}),
        new((Position)49, 49, "F4", new[] {"rowF", "col4", "box5"}),
        new((Position)50, 50, "F5", new[] {"rowF", "col5", "box5"}),
        new((Position)51, 51, "F6", new[] {"rowF", "col6", "box5"}),
        new((Position)52, 52, "F7", new[] {"rowF", "col7", "box6"}),
        new((Position)53, 53, "F8", new[] {"rowF", "col8", "box6"}),
        new((Position)54, 54, "F9", new[] {"rowF", "col9", "box6"}),
        new((Position)55, 55, "G1", new[] {"rowG", "col1", "box7"}),
        new((Position)56, 56, "G2", new[] {"rowG", "col2", "box7"}),
        new((Position)57, 57, "G3", new[] {"rowG", "col3", "box7"}),
        new((Position)58, 58, "G4", new[] {"rowG", "col4", "box8"}),
        new((Position)59, 59, "G5", new[] {"rowG", "col5", "box8"}),
        new((Position)60, 60, "G6", new[] {"rowG", "col6", "box8"}),
        new((Position)61, 61, "G7", new[] {"rowG", "col7", "box9"}),
        new((Position)62, 62, "G8", new[] {"rowG", "col8", "box9"}),
        new((Position)63, 63, "G9", new[] {"rowG", "col9", "box9"}),
        new((Position)64, 64, "H1", new[] {"rowH", "col1", "box7"}),
        new((Position)65, 65, "H2", new[] {"rowH", "col2", "box7"}),
        new((Position)66, 66, "H3", new[] {"rowH", "col3", "box7"}),
        new((Position)67, 67, "H4", new[] {"rowH", "col4", "box8"}),
        new((Position)68, 68, "H5", new[] {"rowH", "col5", "box8"}),
        new((Position)69, 69, "H6", new[] {"rowH", "col6", "box8"}),
        new((Position)70, 70, "H7", new[] {"rowH", "col7", "box9"}),
        new((Position)71, 71, "H8", new[] {"rowH", "col8", "box9"}),
        new((Position)72, 72, "H9", new[] {"rowH", "col9", "box9"}),
        new((Position)73, 73, "I1", new[] {"rowI", "col1", "box7"}),
        new((Position)74, 74, "I2", new[] {"rowI", "col2", "box7"}),
        new((Position)75, 75, "I3", new[] {"rowI", "col3", "box7"}),
        new((Position)76, 76, "I4", new[] {"rowI", "col4", "box8"}),
        new((Position)77, 77, "I5", new[] {"rowI", "col5", "box8"}),
        new((Position)78, 78, "I6", new[] {"rowI", "col6", "box8"}),
        new((Position)79, 79, "I7", new[] {"rowI", "col7", "box9"}),
        new((Position)80, 80, "I8", new[] {"rowI", "col8", "box9"}),
        new((Position)81, 81, "I9", new[] {"rowI", "col9", "box9"})
    };
    static readonly int[] ExceptionTargets = { -1024, -5, -4, -3, -2, -1, 0, 82, 83, 84, 85, 86, 87, 1024 };

    static Position Get(int i) => (Position)i;

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
    public void ClassesComparisons([ValueSource(nameof(Targets))] Target t1, [ValueSource(nameof(Targets))] Target t2)
    {
        if (t1.Index == t2.Index) Assert.AreEqual(t1.Value.ToClasses(), t2.ToClassesResult);
        else Assert.AreNotEqual(t1.Value.ToClasses(), t2.ToClassesResult);
    }
}
