using UnityEngine;

public abstract class BaseInstance : ScriptableObject
{
    protected abstract void OnDestroy();
    public virtual void Destroy() => OnDestroy();
    protected static T NewInstance<T>() where T : ScriptableObject => (T)CreateInstance(typeof(T));
    // protected abstract void OnCreate();
    // protected static T Create<T>() where T : BaseInstance
    // {
    //     T instance = NewInstance<T>();
    //     instance.OnCreate();
    //     return instance;
    // }
}