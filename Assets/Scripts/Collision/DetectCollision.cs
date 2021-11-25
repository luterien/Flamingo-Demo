using System;
using UnityEngine;

abstract public class DetectCollision : ExecuteInIntervals
{
    public event Action<Collider> OnDetect;

    protected void TriggerDetection(Collider collider) 
        => OnDetect?.Invoke(collider);
}
