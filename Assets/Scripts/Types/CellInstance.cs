using System;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public struct CellInstance
{
    public Cell Cell;
    [SerializeField] Button Element;

    public CellInstance(Cell cell)
    {
        Cell = cell;
        Element = UIToolkit.UI.Query<Button>(classes: Cell.Position.ToClasses());

        UIToolkit.UI.Query<Button>(name: "MyElement", classes: new[] { "class1", "class2", "class3" });

        if (cell.State == State.PREFILLED)
        {
            FillNumber(Cell.Value);
            SetState(State.PREFILLED);
        }

        Element.RegisterCallback<ClickEvent>(OnClick);
    }

    public void Destroy()
    {
        UnsetHighlights();
        UnsetStates();

        Element.UnregisterCallback<ClickEvent>(OnClick);
    }

    public override readonly string ToString() => Cell.ToString();

    readonly void OnClick(ClickEvent e)
    {
        GameEvents.CellSelect.Publish(this);
    }

    public readonly void Focus() => Element.AddToClassList(className: "focus");
    public readonly void Unfocus() => Element.RemoveFromClassList(className: "focus");

    public void TryUpdateNumber(Number num)
    {
        if (Cell.State.IsUpdatable() && Cell.CurrentValue != num)
        {
            GameEvents.NewAction.Publish(new(this, Cell.CurrentValue, num));
            UpdateNumber(num);
        }
    }

    public void TryEraseNumber()
    {
        if (Cell.State.IsErasable())
        {
            GameEvents.NewAction.Publish(new(this, Cell.CurrentValue, null));
            EraseNumber();
        }
    }

    public void TryRevealNumber()
    {
        if (!IsValid())
        {
            RevealNumber();
        }
    }

    public void UpdateNumber(Number num)
    {
        FillNumber(num);

        if (Cell.Value == num)
            SetState(State.FILLED);
        else
            SetState(State.ERROR);

        GameEvents.Check.Publish();
    }

    public void EraseNumber()
    {
        SetState(State.EMPTY);
        Cell.CurrentValue = null;
        Element.text = "0";
    }

    public void RevealNumber()
    {
        FillNumber(Cell.Value);
        SetState(State.PREFILLED);

        GameEvents.Check.Publish();
    }

    public void SetHighlight(Highlight highlight)
    {
        UnsetHighlights();
        Element.AddToClassList(className: highlight.ToClass());
    }

    readonly void UnsetHighlights()
    {
        Element.RemoveFromClassList(className: Highlight.ALIGNED.ToClass());
        Element.RemoveFromClassList(className: Highlight.MATCHED.ToClass());
    }

    void SetState(State state)
    {
        Cell.State = state;
        UnsetStates();
        Element.AddToClassList(className: state.ToClass());
    }

    readonly void UnsetStates()
    {
        Element.RemoveFromClassList(className: State.PREFILLED.ToClass());
        Element.RemoveFromClassList(className: State.FILLED.ToClass());
        Element.RemoveFromClassList(className: State.ERROR.ToClass());
    }

    void FillNumber(Number num)
    {
        Cell.CurrentValue = num;
        Element.text = num.ToString();
    }

    public readonly bool IsValid() => Cell.State.IsValid() && Cell.CurrentValue == Cell.Value;

    public static implicit operator bool(CellInstance? instance) => instance != null;
}