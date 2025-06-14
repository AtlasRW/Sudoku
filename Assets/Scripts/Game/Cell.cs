using UnityEngine.UIElements;

public class Cell : BaseInstance
{
    public Position Position;
    public State State = State.EMPTY;
    public Number? CurrentNumber = null;
    public Number ExpectedNumber;
    private Button Element;

    public static Cell Create(Button element, Position pos, Number num, bool isPrefilled = false)
    {
        Cell cell = NewInstance<Cell>();
        cell.OnCreate(element, pos, num, isPrefilled);
        return cell;
    }

    protected void OnCreate(Button element, Position pos, Number num, bool isPrefilled)
    {
        Position = pos;
        Element = element;
        ExpectedNumber = num;
        if (isPrefilled)
        {
            FillNumber(num);
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

    public override string ToString() => Position.ToString();

    void OnClick(ClickEvent e)
    {
        GameEvents.CellSelect.Publish(this);
    }

    public void Focus() => Element.AddToClassList(className: "focus");
    public void Unfocus() => Element.RemoveFromClassList(className: "focus");

    public void TryUpdateNumber(Number num)
    {
        if (State.IsUpdatable() && CurrentNumber != num)
        {
            GameEvents.NewAction.Publish(Action.Get(this, CurrentNumber, num));
            UpdateNumber(num);
        }
    }

    public void TryEraseNumber()
    {
        if (State.IsErasable())
        {
            GameEvents.NewAction.Publish(Action.Get(this, CurrentNumber, null));
            EraseNumber();
        }
    }

    public void TryRevealNumber()
    {
        if (State.IsWrong() && CurrentNumber != ExpectedNumber)
        {
            RevealNumber();
        }
    }

    public void UpdateNumber(Number num)
    {
        FillNumber(num);

        if (ExpectedNumber == num)
            SetState(State.FILLED);
        else
            SetState(State.ERROR);

        GameEvents.Check.Publish();
    }

    public void EraseNumber()
    {
        SetState(State.EMPTY);
        CurrentNumber = null;
        Element.text = "0";
    }

    public void RevealNumber()
    {
        FillNumber(ExpectedNumber);
        SetState(State.PREFILLED);

        GameEvents.Check.Publish();
    }

    public void SetHighlight(Highlight highlight)
    {
        UnsetHighlight();
        Element.AddToClassList(className: highlight.ToClassName());
    }

    void UnsetHighlight()
    {
        Element.RemoveFromClassList(className: Highlight.ALIGNED.ToClassName());
        Element.RemoveFromClassList(className: Highlight.MATCHED.ToClassName());
    }

    void SetState(State state)
    {
        State = state;
        UnsetState();
        Element.AddToClassList(className: state.ToClassName());
    }

    void UnsetState()
    {
        Element.RemoveFromClassList(className: State.PREFILLED.ToClassName());
        Element.RemoveFromClassList(className: State.FILLED.ToClassName());
        Element.RemoveFromClassList(className: State.ERROR.ToClassName());
    }

    void FillNumber(Number num)
    {
        CurrentNumber = num;
        Element.text = num.ToString();
    }

    public bool IsRight() => State.IsRight() && CurrentNumber == ExpectedNumber;
    public bool IsWrong() => State.IsWrong() || CurrentNumber != ExpectedNumber;
}