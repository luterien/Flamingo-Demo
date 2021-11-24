using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Manager")]
public class GameEventManager : ScriptableObject
{
    public GameEvent latest;

    public bool debugging = false;

    public void Invoke(GameEvent gameEvent)
    {
        if (CanInvoke(gameEvent))
        {
            if (debugging)
                Debug.Log("Invoking: " + gameEvent.name);

            latest = gameEvent;
            latest.NotifyListeners();
        }
    }

    private bool CanInvoke(GameEvent gameEvent)
    {
        if (debugging)
            Debug.Log("Checking: " + gameEvent.name);

        return latest == null || latest.followingEvents.Contains(gameEvent);
    }

    public void Reset()
    {
        latest = null;
    }
}