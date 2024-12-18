using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;


internal static class MapMovement
{
    
    public static Point WallNext(Map m, Point p, Direction d)
    {
        if (m.Exist(p.Next(d))) return p.Next(d);
        return p;
    }

    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        if (m.Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
        return p;
    }

}
