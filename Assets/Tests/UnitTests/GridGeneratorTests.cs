using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

public class GridGeneratorTests : BaseTests
{
    [SetUp]
    public void Init() { }

    [Test]
    public void GenerateGrid()
    {
        // List<Cell> grid = GridGenerator.Generate();
        // DebugTest.Log(string.Join("", grid.ConvertAll(cell => cell.Value)));
    }

    [Test]
    public void Temp1()
    {
        Log(Random.EnumMember<Difficulty>());
    }

    [Test]
    public void Temp2()
    {
        bool[] bools = new bool[81];
        bools[0] = true;
        bools[2] = true;
        foreach ((bool b, int i) in bools.WithIndex())
            Log($"#{i} : {b}");
    }

    [Test]
    public void Temp3()
    {
        // const int SEED = 30;
        // bool[] booleans = new bool[81];

        // Log(System.Random.Shuffle);
    }
}