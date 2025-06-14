using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class GridGeneratorTests
{
    [SetUp]
    public void Init() { }

    [Test]
    public void GenerateGrid()
    {
        List<GridGenerator.Cell> grid = GridGenerator.Generate();
        DebugTest.Log(string.Join("", grid.ConvertAll(cell => cell.Value)));
    }
}