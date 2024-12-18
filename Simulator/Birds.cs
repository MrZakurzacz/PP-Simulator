using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals, IMappable
{
    public bool CanFly { get; set; } = true;

    string IMappable.Go(Direction direction)
    {
        if (CanFly)
        {
            var next = _map.NextDiagonal(Position, direction);
            if (_map.Exist(next))
            {
                _map.Move(Position, next, this);
                Position = next;
                return $"Moved {Name} to {next}";
            }
            return $"Cannot move {Name} to {next}";
        }
        else
        {
            var next = _map.Next(Position, direction);
            var next2 = next.Next(direction);
            if (_map.Exist(next2))
            {
                _map.Move(Position, next2, this);
                   Position = next2;
                   return $"Moved {Name} to {next2}";
               }
               return $"Cannot move {Name} to {next2}";
           }
    }
    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";
}
