using UnityEngine.UIElements;

public abstract class BaseInput<TElement, TEvent> : BaseEvent<TEvent>
where TElement : VisualElement
where TEvent : EventBase
{
    protected TElement InternalElement;

    protected BaseInput(string name, EventCallback<TEvent> onInput = null, string className = null)
    {
        GetElement(name, className);
        RegisterEvent(onInput);
    }
    protected BaseInput(string name, EventCallback<TEvent> onInput = null, params string[] classes)
    {
        GetElement(name, classes);
        RegisterEvent(onInput);
    }

    public abstract void RegisterEvent(EventCallback<TEvent> onInput = null);

    protected void GetElement(string name, string className = null) => InternalElement = UIToolkit.UI.Query<TElement>(name: name, className: className);
    protected void GetElement(string name, params string[] classes) => InternalElement = UIToolkit.UI.Query<TElement>(name: name, classes: classes);
}