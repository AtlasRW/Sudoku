using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Game))]
public class GameEvents : BaseComponent
{
    public static BaseEvent Check;
    public static BaseEvent<Board> Solved;
    public static BaseEvent<CellInstance?> CellSelect;
    public static BaseEvent<Action> NewAction;
    public static BaseEvent<Number> NewNumber;

    public static ClickInput<Button> Back;
    public static ClickInput<Button> Refresh;
    public static ClickInput<GroupBox> Revert;
    public static ClickInput<GroupBox> Erase;
    public static ClickInput<GroupBox> Notes;
    public static ClickInput<GroupBox> Hint;

    public static ClickInput<Button> Number1;
    public static ClickInput<Button> Number2;
    public static ClickInput<Button> Number3;
    public static ClickInput<Button> Number4;
    public static ClickInput<Button> Number5;
    public static ClickInput<Button> Number6;
    public static ClickInput<Button> Number7;
    public static ClickInput<Button> Number8;
    public static ClickInput<Button> Number9;

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

        Number1 = new(name: "1", onClick: e => NewNumber.Publish(1));
        Number2 = new(name: "2", onClick: e => NewNumber.Publish(2));
        Number3 = new(name: "3", onClick: e => NewNumber.Publish(3));
        Number4 = new(name: "4", onClick: e => NewNumber.Publish(4));
        Number5 = new(name: "5", onClick: e => NewNumber.Publish(5));
        Number6 = new(name: "6", onClick: e => NewNumber.Publish(6));
        Number7 = new(name: "7", onClick: e => NewNumber.Publish(7));
        Number8 = new(name: "8", onClick: e => NewNumber.Publish(8));
        Number9 = new(name: "9", onClick: e => NewNumber.Publish(9));
    }
    protected override void OnDisable() { }
}