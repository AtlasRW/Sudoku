using UnityEngine.UIElements;

public class CellInstance : BaseInstance
{
    public Cell Cell;
    private Button Element;
    public State State = State.EMPTY;
    public Number? CurrentValue = null;

    public static CellInstance Create(Cell cell, bool isPrefilled = false)
    {
        CellInstance instance = NewInstance<CellInstance>();
        instance.OnCreate(cell, isPrefilled);
        return instance;
    }

    protected void OnCreate(Cell cell, bool isPrefilled)
    {
        Cell = cell;
        Element = UIToolkit.UI.Query<Button>(classes: Cell.Position.ToClasses());
        if (isPrefilled)
        {
            FillNumber(Cell.Value);
            SetState(State.PREFILLED);
        }

        Element.RegisterCallback<ClickEvent>(OnClick);
    }

    protected override void OnDestroy()
    {
        UnsetHighlight();
        UnsetState();

        Element.UnregisterCallback<ClickEvent>(OnClick);
    }

    public override string ToString() => Cell.ToString();

    void OnClick(ClickEvent e)
    {
        GameEvents.CellSelect.Publish(this);
    }

    public void Focus() => Element.AddToClassList(className: "focus");
    public void Unfocus() => Element.RemoveFromClassList(className: "focus");

    public void TryUpdateNumber(Number num)
    {
        if (State.IsUpdatable() && CurrentValue != num)
        {
            GameEvents.NewAction.Publish(Action.Get(this, CurrentValue, num));
            UpdateNumber(num);
        }
    }

    public void TryEraseNumber()
    {
        if (State.IsErasable())
        {
            GameEvents.NewAction.Publish(Action.Get(this, CurrentValue, null));
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
        CurrentValue = null;
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
        UnsetHighlight();
        Element.AddToClassList(className: highlight.ToClass());
    }

    void UnsetHighlight()
    {
        Element.RemoveFromClassList(className: Highlight.ALIGNED.ToClass());
        Element.RemoveFromClassList(className: Highlight.MATCHED.ToClass());
    }

    void SetState(State state)
    {
        State = state;
        UnsetState();
        Element.AddToClassList(className: state.ToClass());
    }

    void UnsetState()
    {
        Element.RemoveFromClassList(className: State.PREFILLED.ToClass());
        Element.RemoveFromClassList(className: State.FILLED.ToClass());
        Element.RemoveFromClassList(className: State.ERROR.ToClass());
    }

    void FillNumber(Number num)
    {
        CurrentValue = num;
        Element.text = num.ToString();
    }

    public bool IsValid() => State.IsValid() && CurrentValue == Cell.Value;
}