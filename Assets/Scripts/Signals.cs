public struct SignalOnBecomeVisible 
{
    public SignalOnBecomeVisible(bool visible)
    {
        this.isVisible = visible;
    }
    public bool isVisible; 
}

public struct PlaySoundSignal
{
    public PlaySoundSignal(Sounds sound)
    {
        this.sound = sound;
    }

    public Sounds sound;
}

public struct SignalOnBlockPlaced{};