namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        private set => _agility = Math.Clamp(value, 0, 10);
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }

    public override void SayHi()
    {
        Console.WriteLine($"Greetings! I'm an Elf named {Name} with agility {Agility}.");
    }

    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility = Math.Clamp(Agility + 1, 0, 10);
        }
    }

    public override int Power => 8 * Level + 2 * Agility;
}
