using UnityEngine;

public abstract class BaseComponent : MonoBehaviour
{
    protected abstract void OnEnable();
    protected abstract void OnDisable();

    protected T AddComponent<T>() where T : BaseComponent => gameObject.AddComponent<T>();
    protected T AddComponent<T>(T component) where T : BaseComponent => (T)gameObject.AddComponent(component.GetType());
    protected void RemoveComponent<T>() where T : BaseComponent => Destroy(GetComponent<T>());
    protected void RemoveComponent<T>(T component) where T : BaseComponent => Destroy(component);
}
