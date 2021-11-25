
[System.Serializable]
public class Timer : ITimer
{
    public bool Running { get; private set; }
    public bool Stopped { get; private set; }

    public float Duration { get; private set; }

    private float baseDuration;

    public Timer(float duration)
    {
        Duration = duration;
        baseDuration = duration;
        Running = false;
    }

    public void Tick(float deltaTime)
    {
        if (Stopped) return;

        if (Running)
        {
            Duration -= deltaTime;

            if (Duration <= 0f)
                Stop();
        }
    }

    public void Start()
    {
        Running = true;
    }

    public void Pause()
    {
        Running = false;
    }

    public void Restart()
    {
        Running = true;
        Stopped = false;

        Duration = baseDuration;
    }

    public void Resume()
    {
        if (!Stopped) Running = true;
    }

    public void Stop()
    {
        Running = false;
        Stopped = true;
    }
}