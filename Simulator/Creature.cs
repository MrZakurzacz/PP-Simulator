using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }



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
    public string Go(Direction direction)
    {
        var next = Map.Next(Position, direction);
        if (Map.Exist(next))
        {
            Map.Move(Position, next, this);
            Position = next;
            return $"Moved {Name} to {next}";
        }
        return $"Cannot move {Name} to {next}";
    }
    // ma użyć reguł mapy
    //sprawdzić pozycję używająca next, jeśli prawdziwy ruch to aktualizacja Position i powiadomienie mapy przy użyciu move
    //move będzie się składać z remove i add 
    //remove będzie usuwać z mapy
    //add dodawać na mapę

    //do usunięcie

    //do usunięcia
    //public string[] Go(string directions)=> Go(DirectionParser.Parse(directions));
}
