using System.Collections;
using UnityEngine;

public class InvokeGameEvent : MonoBehaviour
{
    public GameEvent GameEvent;

    public void Execute() => GameEvent.Invoke();
}