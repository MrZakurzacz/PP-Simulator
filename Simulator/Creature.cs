namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameSet = false;
    private bool _levelSet = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameSet) return;

            value = value.Trim();

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _name = value;
            _nameSet = true;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_levelSet) return;

            _level = Math.Clamp(value, 1, 10);
            _levelSet = true;
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract void SayHi();

    public abstract int Power { get; }

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }
}