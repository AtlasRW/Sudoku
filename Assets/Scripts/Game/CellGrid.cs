using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class CellGrid : BaseInstance
{
    public readonly List<CellInstance> cells = new();

    public static CellGrid Create()
    {
        CellGrid grid = NewInstance<CellGrid>();
        grid.OnCreate();
        return grid;
    }

    protected void OnCreate()
    {
        List<Cell> grid = GridGenerator.Generate();

        foreach (Cell cell in grid)
        {
            cells.Add(
                CellInstance.Create(
                    cell,
                    Random.Bool()
                )
            );
        }
    }

    protected override void OnDestroy()
    {
        foreach (CellInstance cell in cells) cell.Destroy();
    }

    public override string ToString() => string.Join("", cells.ConvertAll(cell => cell.Cell.Value));

    public CellInstance FindCell(Position pos) => FindCell(c => c.Cell.Aligns(pos));
    public CellInstance FindCell(Predicate<CellInstance> predicate) => cells.Find(predicate);
    public List<CellInstance> FindCells(Number num) => FindCells(c => c.Cell.Matches(num));
    public List<CellInstance> FindCells(Number? num) => FindCells(c => c.Cell.MatchesCurrent(num));
    public List<CellInstance> FindCells(Position position) => FindCells(c => c.Cell.Aligns(position));
    public List<CellInstance> FindCells(Predicate<CellInstance> predicate) => cells.FindAll(predicate);

    public bool IsSolved()
    {
        foreach (CellInstance cell in cells) if (!cell.IsValid()) return false;
        return true;
    }
}