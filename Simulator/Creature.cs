using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _name = Validator.Shortener(value, 3, 25, '#');
            _nameSet = true;
        }
    }

    public abstract string Info { get; }

    public int Level
    {
        get => _level;
        set
        {
            if (_levelSet) return;
            _level = Validator.Limiter(value, 1, 10);
            _levelSet = true;
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();

    public abstract int Power { get; }

    public void Upgrade()
    {
        Level = Validator.Limiter(Level + 1, 1, 10);
    }
    public string Go(Direction direction) => ($"{Name} goes {direction.ToString().ToLower()}.");

    public string[] Go(Direction[] directions)
    {
        List<string> list = new List<string>();
        foreach (var direction in directions) list.Add(Go(direction));
        return list.ToArray();
    }
    public string[] Go(string directions)=> Go(DirectionParser.Parse(directions));
}
