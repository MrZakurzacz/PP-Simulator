using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals : IMappable
{
    private Point _position;

    public Point Position
    {
        get => _position;
        protected set => _position = value;
    }

    public string Name { get; init; } = "Unknown";

    public void InitMapAndPosition(Map map, Point position)
    {
        _map = map;
        if (map.Exist(position))
        {
            Position = position;
        }
    }

    protected Map _map;
    private string _description = "Unknown";

    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    // Wirtualna metoda Info
    public virtual string Info => $"{Description} <{Size}>";

    // Nadpisanie ToString() dla wyświetlania nazwy typu i właściwości Info
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


    string IMappable.Go(Direction direction)
    {
        var next = _map.Next(Position, direction);
        if (_map.Exist(next))
        {
            _map.Move(Position, next, this);
            Position = next;
            return $"Moved {Name} to {next}";
        }
        return $"Cannot move {Name} to {next}";
    }
}
