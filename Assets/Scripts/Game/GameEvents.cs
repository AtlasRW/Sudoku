using UnityEngine.UIElements;

public class GameEvents : BaseComponent
{
    public static BaseEvent Check;
    public static BaseEvent<Board> Solved;
    public static BaseEvent<CellInstance> CellSelect;
    public static BaseEvent<Action> NewAction;
    public static BaseEvent<Number> NewNumber;

    public static BaseInput<Button> Back;
    public static BaseInput<Button> Refresh;
    public static BaseInput<GroupBox> Revert;
    public static BaseInput<GroupBox> Erase;
    public static BaseInput<GroupBox> Notes;
    public static BaseInput<GroupBox> Hint;
    public static BaseInput<Button> Number1;
    public static BaseInput<Button> Number2;
    public static BaseInput<Button> Number3;
    public static BaseInput<Button> Number4;
    public static BaseInput<Button> Number5;
    public static BaseInput<Button> Number6;
    public static BaseInput<Button> Number7;
    public static BaseInput<Button> Number8;
    public static BaseInput<Button> Number9;

    protected override void OnEnable()
    {
        Check = new();
        CellSelect = new();
        NewAction = new();
        NewNumber = new();

        Solved = new();
        Back = new(name: "Back");
        Refresh = new(name: "Refresh");
        Revert = new(name: "Revert");
        Erase = new(name: "Erase");
        Notes = new(name: "Notes");
        Hint = new(name: "Hint");
        Number1 = new(name: "1", onClick: e => NewNumber.Publish(Number.ONE));
        Number2 = new(name: "2", onClick: e => NewNumber.Publish(Number.TWO));
        Number3 = new(name: "3", onClick: e => NewNumber.Publish(Number.THREE));
        Number4 = new(name: "4", onClick: e => NewNumber.Publish(Number.FOUR));
        Number5 = new(name: "5", onClick: e => NewNumber.Publish(Number.FIVE));
        Number6 = new(name: "6", onClick: e => NewNumber.Publish(Number.SIX));
        Number7 = new(name: "7", onClick: e => NewNumber.Publish(Number.SEVEN));
        Number8 = new(name: "8", onClick: e => NewNumber.Publish(Number.EIGHT));
        Number9 = new(name: "9", onClick: e => NewNumber.Publish(Number.NINE));
    }
    protected override void OnDisable() { }
}