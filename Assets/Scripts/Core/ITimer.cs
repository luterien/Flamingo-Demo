
public interface ITimer
{
    bool Running { get; }

    void Tick(float deltaTime);
    void Start();
    void Pause();
    void Resume();
    void Restart();
    void Stop();
}