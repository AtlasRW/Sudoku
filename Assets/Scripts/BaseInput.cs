using UnityEngine.UIElements;

public class BaseInput<T> where T : VisualElement
{
    public BaseEvent<ClickEvent> Click = new();
    private T InternalElement;

    public BaseInput(string name, EventCallback<ClickEvent> onClick = null, string className = null)
    {
        GetElement(name, className);
        RegisterClick(onClick);
    }
    public BaseInput(string name, EventCallback<ClickEvent> onClick = null, params string[] classes)
    {
        GetElement(name, classes);
        RegisterClick(onClick);
    }

    private void RegisterClick(EventCallback<ClickEvent> onClick = null)
    {
        if (onClick == null) InternalElement?.RegisterCallback<ClickEvent>(Click.Publish);
        else InternalElement?.RegisterCallback(onClick);
    }

    private void GetElement(string name, string className = null) => InternalElement = UIToolkit.UI.Query<T>(name: name, className: className);
    private void GetElement(string name, params string[] classes) => InternalElement = UIToolkit.UI.Query<T>(name: name, classes: classes);
}