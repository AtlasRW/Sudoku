using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Board : BaseInstance
{
    CellGrid Grid;
    CellInstance SelectedCell = null;
    List<CellInstance> HighlightedCells = new();
    readonly List<Action> Actions = new();

    public static Board Create()
    {
        Board board = NewInstance<Board>();
        board.OnCreate();
        return board;
    }

    protected void OnCreate()
    {
        Grid = CellGrid.Create();

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
        if (SelectedCell) SelectedCell.Unfocus();
        Grid.Destroy();

        GameEvents.Check.Unsubscribe(OnCheck);
        GameEvents.NewNumber.Unsubscribe(OnNewNumber);
        GameEvents.NewAction.Unsubscribe(OnNewAction);
        GameEvents.CellSelect.Unsubscribe(OnCellSelect);
        GameEvents.Revert.Click.Unsubscribe(OnRevert);
        GameEvents.Erase.Click.Unsubscribe(OnErase);
        GameEvents.Notes.Click.Unsubscribe(OnNotes);
        GameEvents.Hint.Click.Unsubscribe(OnHint);
    }

    void OnCheck()
    {
        if (Grid.IsSolved()) GameEvents.Solved.Publish(this);
    }

    void OnNewNumber(Number num)
    {
        if (SelectedCell)
        {
            SelectedCell.TryUpdateNumber(num);
            ResetHighlights();
        }
    }

    void OnCellSelect(CellInstance cell)
    {
        if (SelectedCell) SelectedCell.Unfocus();
        SelectedCell = cell;
        SelectedCell.Focus();
        ResetHighlights();
    }

    void OnNewAction(Action action)
    {
        Actions.Add(action);
    }

    void OnRevert(ClickEvent e)
    {
        if (Actions.Count > 0)
        {
            Action action = Actions.Last();

            if (action.from is Number num)
                action.cell.UpdateNumber(num);
            else
                action.cell.EraseNumber();

            Actions.RemoveAt(Actions.Count - 1);
            GameEvents.CellSelect.Publish(SelectedCell);
        }
    }

    void OnErase(ClickEvent e)
    {
        if (SelectedCell)
        {
            SelectedCell.TryEraseNumber();
            ResetHighlights();
        }
    }

    void OnNotes(ClickEvent e)
    {
        Debug.Log("NOTES");
    }

    void OnHint(ClickEvent e)
    {
        CellInstance cell = Random.ListElement(Grid.FindCells(cell => !cell.Cell.State.IsValid()));
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
        List<CellInstance> alignedCells = Grid.FindCells(cell => cell.Cell.Aligns(SelectedCell.Cell.Position));
        List<CellInstance> matchedCells = Grid.FindCells(cell => cell.Cell.MatchesCurrent(SelectedCell.Cell.CurrentValue));

        foreach (CellInstance cell in alignedCells) cell.SetHighlight(Highlight.ALIGNED);
        foreach (CellInstance cell in matchedCells) cell.SetHighlight(Highlight.MATCHED);

        HighlightedCells = alignedCells.Concat(matchedCells).ToList();
    }

    void UnsetHighlights()
    {
        foreach (CellInstance cell in HighlightedCells) cell.SetHighlight(Highlight.NONE);
        HighlightedCells = new();
    }
}