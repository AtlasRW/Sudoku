using UnityEngine;

public abstract class BaseScriptableObject : ScriptableObject
{
    protected abstract void OnDestroy();
    public virtual void Destroy() => OnDestroy();
    protected static T NewInstance<T>() where T : ScriptableObject => (T)CreateInstance(typeof(T));
}

public abstract class BaseInstance : BaseScriptableObject
{
    protected abstract void OnCreate();
    protected static T Create<T>() where T : BaseInstance
    {
        T instance = NewInstance<T>();
        instance.OnCreate();
        return instance;
    }
}

public abstract class BaseInstance<P1> : BaseScriptableObject
{
    protected abstract void OnCreate(P1 p1);
    protected static T Create<T>(P1 p1) where T : BaseInstance<P1>
    {
        T instance = NewInstance<T>();
        instance.OnCreate(p1);
        return instance;
    }
}

public abstract class BaseInstance<P1, P2> : BaseScriptableObject
{
    protected abstract void OnCreate(P1 p1, P2 p2);
    protected static T Create<T>(P1 p1, P2 p2) where T : BaseInstance<P1, P2>
    {
        T instance = NewInstance<T>();
        instance.OnCreate(p1, p2);
        return instance;
    }
}

public abstract class BaseInstance<P1, P2, P3> : BaseScriptableObject
{
    protected abstract void OnCreate(P1 p1, P2 p2, P3 p3);
    protected static T Create<T>(P1 p1, P2 p2, P3 p3) where T : BaseInstance<P1, P2, P3>
    {
        T instance = NewInstance<T>();
        instance.OnCreate(p1, p2, p3);
        return instance;
    }
}

public abstract class BaseInstance<P1, P2, P3, P4> : BaseScriptableObject
{
    protected abstract void OnCreate(P1 p1, P2 p2, P3 p3, P4 p4);
    protected static T Create<T>(P1 p1, P2 p2, P3 p3, P4 p4) where T : BaseInstance<P1, P2, P3, P4>
    {
        T instance = NewInstance<T>();
        instance.OnCreate(p1, p2, p3, p4);
        return instance;
    }
}

public abstract class BaseInstance<P1, P2, P3, P4, P5> : BaseScriptableObject
{
    protected abstract void OnCreate(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
    protected static T Create<T>(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5) where T : BaseInstance<P1, P2, P3, P4, P5>
    {
        T instance = NewInstance<T>();
        instance.OnCreate(p1, p2, p3, p4, p5);
        return instance;
    }
}