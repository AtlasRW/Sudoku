using UnityEngine.UIElements;

public class ClickInput<T> : BaseInput<T, ClickEvent> where T : VisualElement
{
    public ClickInput(string name, EventCallback<ClickEvent> onClick = null, string className = null) : base(name, onClick, className) { }
    public ClickInput(string name, EventCallback<ClickEvent> onClick = null, params string[] classes) : base(name, onClick, classes) { }

    public override void RegisterEvent(EventCallback<ClickEvent> onClick = null)
    {
        if (onClick == null) InternalElement?.RegisterCallback<ClickEvent>(Publish);
        else InternalElement?.RegisterCallback(onClick);
    }
}
