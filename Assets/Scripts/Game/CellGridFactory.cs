using System.Collections.Generic;
using UnityEngine;

public static class CellGridFactory
{
    public static CellGrid GenerateCellGrid()
    {
        CellGrid cellGrid = ScriptableObject.CreateInstance<CellGrid>();
        List<Cell> grid = GridGenerator.Generate();

        foreach (Cell cell in grid) cellGrid.cells.Add(cell);

        return cellGrid;
    }
}