using UnityEngine.Events;

public class BaseEvent
{
    event UnityAction InternalEvent;
    public void Publish() => InternalEvent?.Invoke();
    public void Subscribe(UnityAction sub) => InternalEvent += sub;
    public void Unsubscribe(UnityAction sub) => InternalEvent -= sub;
}

public class BaseEvent<T>
{
    event UnityAction<T> InternalEvent;
    public void Publish(T arg) => InternalEvent?.Invoke(arg);
    public void Subscribe(UnityAction<T> sub) => InternalEvent += sub;
    public void Unsubscribe(UnityAction<T> sub) => InternalEvent -= sub;
}