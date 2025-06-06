public abstract class BaseManager : BaseComponent
{
    // [SerializeField] List<BaseComponent> Components = new();

    protected virtual void Awake()
    {
        AddComponent<UIToolkit>();
        // foreach (BaseComponent component in Components) AddComponent(component);
    }

    protected virtual void OnDestroy()
    {
        RemoveComponent<UIToolkit>();
        // foreach (BaseComponent component in Components) RemoveComponent(component);
    }
}
