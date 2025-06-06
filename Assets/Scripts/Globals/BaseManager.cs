public abstract class BaseManager : BaseComponent
{
    protected virtual void Awake()
    {
        AddComponent<UIToolkit>();
    }

    protected virtual void OnDestroy()
    {
        RemoveComponent<UIToolkit>();
    }
}
