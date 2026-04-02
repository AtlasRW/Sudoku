using UnityEngine.UIElements;

public class ChangeInput<T, V> : BaseInput<T, ChangeEvent<V>> where T : VisualElement
{
    public ChangeInput(string name, EventCallback<ChangeEvent<V>> onValueChange = null, string className = null) : base(name, onValueChange, className) { }
    public ChangeInput(string name, EventCallback<ChangeEvent<V>> onValueChange = null, params string[] classes) : base(name, onValueChange, classes) { }

    public override void RegisterEvent(EventCallback<ChangeEvent<V>> onValueChange = null)
    {
        if (onValueChange == null) InternalElement?.RegisterCallback<ChangeEvent<V>>(Publish);
        else InternalElement?.RegisterCallback(onValueChange);
    }
}