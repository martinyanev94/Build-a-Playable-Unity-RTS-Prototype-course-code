using System;
using System.Collections.Generic;

public sealed class MessageQueueManager
{
    private readonly Dictionary<Type, List<Delegate>> listeners = new();

    public static MessageQueueManager Instance { get; } = new();

    public void Subscribe<T>(Action<T> listener)
    {
        if (!listeners.TryGetValue(typeof(T), out var list))
        {
            list = new List<Delegate>();
            listeners[typeof(T)] = list;
        }

        list.Add(listener);
    }

    public void Unsubscribe<T>(Action<T> listener)
    {
        if (!listeners.TryGetValue(typeof(T), out var list))
            return;

        list.Remove(listener);
        if (list.Count == 0)
            listeners.Remove(typeof(T));
    }

    public void Publish<T>(T message)
    {
        if (!listeners.TryGetValue(typeof(T), out var list))
            return;

        foreach (var listener in list.ToArray())
            ((Action<T>)listener)(message);
    }
}
