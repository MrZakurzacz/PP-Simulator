using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public SmallTorusMap(int Size) : base(Size, Size)
    {

    }
    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return new Point(
            (next.X + Size) % Size,
            (next.Y + Size) % Size
        );
    }

    public override Point NextDiagonal(Point p, Direction d)
{
        var next = p.NextDiagonal(d);
        return new Point(
            (next.X + Size) % Size,
            (next.Y + Size) % Size
        );
    }
}