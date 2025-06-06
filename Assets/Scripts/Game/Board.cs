using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class Board : BaseInstance
{
    Cell selectedCell = null;
    List<Cell> highlightedCells = new();
    readonly List<Cell> cells = new();
    readonly List<Action> actions = new();

    public static Board Create() => Create<Board>();

    protected override void OnCreate()
    {
        foreach (int i in Enumerable.Range(1, 9))
            foreach (int j in Enumerable.Range(1, 9))
            {
                Position pos = Position.Get(i, j);

                cells.Add(
                    Cell.Create(
                        UIToolkit.UI.Query<Button>(
                            classes: new[] {
                                pos.row.ToClassName(),
                                pos.column.ToClassName()
                            }
                        ),
                        pos,
                        Random.Num(),
                        Random.Bool()
                    )
                );
            }

        GameEvents.Check.Subscribe(OnCheck);
        GameEvents.NewNumber.Subscribe(OnNewNumber);
        GameEvents.NewAction.Subscribe(OnNewAction);
        GameEvents.CellSelect.Subscribe(OnCellSelect);
        GameEvents.Revert.Click.Subscribe(OnRevert);
        GameEvents.Erase.Click.Subscribe(OnErase);
        GameEvents.Notes.Click.Subscribe(OnNotes);
        GameEvents.Hint.Click.Subscribe(OnHint);
    }

    protected override void OnDestroy()
    {
        foreach (Cell cell in cells) cell.Destroy();
        if (selectedCell) selectedCell.Unfocus();

        GameEvents.Check.Unsubscribe(OnCheck);
        GameEvents.NewNumber.Unsubscribe(OnNewNumber);
        GameEvents.NewAction.Unsubscribe(OnNewAction);
        GameEvents.CellSelect.Unsubscribe(OnCellSelect);
        GameEvents.Revert.Click.Unsubscribe(OnRevert);
        GameEvents.Erase.Click.Unsubscribe(OnErase);
        GameEvents.Notes.Click.Unsubscribe(OnNotes);
        GameEvents.Hint.Click.Unsubscribe(OnHint);
    }

    public override string ToString() => string.Join("", cells.ConvertAll(cell => cell.ExpectedNumber));

    Cell FindCell(Position pos) => cells.Find(c => c.Position == pos);
    List<Cell> FindRightCells() => cells.FindAll(c => c.State.IsRight());
    List<Cell> FindWrongCells() => cells.FindAll(c => c.State.IsWrong());
    List<Cell> FindMatchedCells(Number? num) => cells.FindAll(c => c.State.IsRight() && c.CurrentNumber == num);
    List<Cell> FindCells(Row row) => cells.FindAll(c => c.Position.row == row);
    List<Cell> FindCells(Column col) => cells.FindAll(c => c.Position.column == col);
    List<Cell> FindCells(Position pos) => cells.FindAll(c => c.Position.row == pos.row || c.Position.column == pos.column);

    void OnCheck()
    {
        if (IsSolved()) GameEvents.Solved.Publish(this);
    }

    void OnNewNumber(Number num)
    {
        if (selectedCell)
        {
            selectedCell.TryUpdateNumber(num);
            ResetHighlights();
        }
    }

    void OnCellSelect(Cell cell)
    {
        if (selectedCell) selectedCell.Unfocus();
        selectedCell = cell;
        selectedCell.Focus();
        ResetHighlights();
    }

    void OnNewAction(Action action)
    {
        actions.Add(action);
    }

    void OnRevert(ClickEvent e)
    {
        if (actions.Count > 0)
        {
            Action action = actions.Last();
            Cell cell = FindCell(action.cell.Position);

            if (action.from is Number num) cell.UpdateNumber(num);
            else cell.EraseNumber();

            actions.RemoveAt(actions.Count - 1);
            GameEvents.CellSelect.Publish(selectedCell);
        }
    }

    void OnErase(ClickEvent e)
    {
        if (selectedCell)
        {
            selectedCell.TryEraseNumber();
            ResetHighlights();
        }
    }

    void OnNotes(ClickEvent e)
    {
        Debug.Log("NOTES");
    }

    void OnHint(ClickEvent e)
    {
        Cell cell = Random.ListElement(FindWrongCells());
        if (cell)
        {
            cell.TryRevealNumber();
            GameEvents.CellSelect.Publish(cell);
        }
    }

    void ResetHighlights()
    {
        UnsetHighlights();
        SetHighlights();
    }

    void SetHighlights()
    {
        List<Cell> alignedCells = FindCells(selectedCell.Position);
        List<Cell> matchedCells = FindMatchedCells(selectedCell.CurrentNumber);

        foreach (Cell cell in alignedCells) cell.SetHighlight(Highlight.ALIGNED);
        foreach (Cell cell in matchedCells) cell.SetHighlight(Highlight.MATCHED);

        highlightedCells = alignedCells.Concat(matchedCells).ToList();
    }

    void UnsetHighlights()
    {
        foreach (Cell cell in highlightedCells) cell.SetHighlight(Highlight.NONE);
        highlightedCells = new();
    }

    bool IsSolved()
    {
        foreach (Cell cell in cells) if (cell.IsWrong()) return false;
        return true;
    }
}