using UnityEngine.UIElements;

public class UIToolkit : BaseComponent
{
    public static VisualElement UI;

    protected override void OnEnable()
    {
        UI = GetComponent<UIDocument>().rootVisualElement;
    }

    protected override void OnDisable() { }
}
