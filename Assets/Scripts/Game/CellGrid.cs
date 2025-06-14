using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class CellGrid : BaseInstance
{
    public readonly List<Cell> cells = new();

    public static CellGrid Create()
    {
        CellGrid grid = NewInstance<CellGrid>();
        grid.OnCreate();
        return grid;
    }

    protected void OnCreate()
    {
        List<GridGenerator.Cell> grid = GridGenerator.Generate();

        foreach (GridGenerator.Cell cell in grid)
        {
            Position pos = Position.Get(cell.Row, cell.Column, cell.Box);

            cells.Add(
                Cell.Create(
                    UIToolkit.UI.Query<Button>(
                        classes: new[] {
                                pos.row.ToClassName(),
                                pos.column.ToClassName(),
                                pos.box.ToClassName()
                        }
                    ),
                    pos,
                    Number.Get(cell.Value),
                    Random.Bool()
                )
            );
        }

        // foreach (int i in Enumerable.Range(1, 9))
        //     foreach (int j in Enumerable.Range(1, 9))
        //     {
        //         Position pos = Position.Get(i, j);

        //         cells.Add(
        //             Cell.Create(
        //                 UIToolkit.UI.Query<Button>(
        //                     classes: new[] {
        //                         pos.row.ToClassName(),
        //                         pos.column.ToClassName()
        //                     }
        //                 ),
        //                 pos,
        //                 Random.Num(),
        //                 Random.Bool()
        //             )
        //         );
        //     }
    }

    protected override void OnDestroy()
    {
        foreach (Cell cell in cells) cell.Destroy();
    }

    public override string ToString() => string.Join("", cells.ConvertAll(cell => cell.ExpectedNumber));

    public Cell FindCell(Position pos) => cells.Find(c => c.Position == pos);
    public List<Cell> FindRightCells() => cells.FindAll(c => c.State.IsRight());
    public List<Cell> FindWrongCells() => cells.FindAll(c => c.State.IsWrong());
    public List<Cell> FindMatchedCells(Number? num) => cells.FindAll(c => c.State.IsRight() && c.CurrentNumber == num);
    public List<Cell> FindCells(Box box) => cells.FindAll(c => c.Position.box == box);
    public List<Cell> FindCells(Row row) => cells.FindAll(c => c.Position.row == row);
    public List<Cell> FindCells(Column col) => cells.FindAll(c => c.Position.column == col);
    public List<Cell> FindCells(Position pos) => cells.FindAll(c => c.Position.box == pos.box || c.Position.row == pos.row || c.Position.column == pos.column);

    public bool IsSolved()
    {
        foreach (Cell cell in cells) if (cell.IsWrong()) return false;
        return true;
    }
}