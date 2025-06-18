using UnityEngine.Events;

interface IEvent
{
    public void Publish();
    public void Subscribe(UnityAction sub);
    public void Unsubscribe(UnityAction sub);
}

interface IEvent<T>
{
    public void Publish(T arg);
    public void Subscribe(UnityAction<T> sub);
    public void Unsubscribe(UnityAction<T> sub);
}

public class BaseEvent : IEvent
{
    event UnityAction InternalEvent;
    public void Publish() => InternalEvent?.Invoke();
    public void Subscribe(UnityAction sub) => InternalEvent += sub;
    public void Unsubscribe(UnityAction sub) => InternalEvent -= sub;
}

public class BaseEvent<T> : IEvent<T>
{
    event UnityAction<T> InternalEvent;
    public void Publish(T arg) => InternalEvent?.Invoke(arg);
    public void Subscribe(UnityAction<T> sub) => InternalEvent += sub;
    public void Unsubscribe(UnityAction<T> sub) => InternalEvent -= sub;
}