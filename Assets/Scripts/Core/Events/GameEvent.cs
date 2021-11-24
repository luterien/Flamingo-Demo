using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    public List<GameEvent> followingEvents;

    [Header("Settings")]
    public GameEventManager manager;

    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        manager.Invoke(this);
    }

    public void Register(GameEventListener listener) => _listeners.Add(listener);
    public void Unregister(GameEventListener listener) => _listeners.Remove(listener);

    public void NotifyListeners()
    {
        foreach (var listener in _listeners)
            listener.RaiseEvent();
    }
}
