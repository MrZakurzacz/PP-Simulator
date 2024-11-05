namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        private set => _rage = Math.Clamp(value, 0, 10);
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() { }

    public override void SayHi()
    {
        Console.WriteLine($"Grr! I'm an Orc named {Name} with rage {Rage}.");
    }

    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0)
        {
            Rage = Math.Clamp(Rage + 1, 0, 10);
        }
    }

    public override int Power => 7 * Level + 3 * Rage;
}
