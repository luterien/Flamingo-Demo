using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ExecuteInIntervals : MonoBehaviour
{
    [Header("Properties")]
    public float value;

    private Timer timer;

    private void Update()
    {
        timer.Tick(Time.deltaTime);

        if (timer.Stopped)
        {
            Execute();
            timer.Restart();
        }
    }

    private void OnEnable()
    {
        timer = new Timer(value);
        timer.Start();
    }

    private void OnDisable()
    {
        timer.Stop();
    }

    abstract public void Execute();
}