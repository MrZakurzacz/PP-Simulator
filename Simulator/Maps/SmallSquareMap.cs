using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public class SmallSquareMap : Map
{
    public int Size;
    private readonly Rectangle Limits;
    public SmallSquareMap(int size)
    {
        if (Math.Abs(size) < 5 || Math.Abs(size) > 20) throw new ArgumentOutOfRangeException("Niepoprawny rozmiar.");
        Size = size;
        if (size < 0)
        {
            Limits = new Rectangle(0, 0, size + 1, size + 1);
        }
        else
        {
            Limits = new Rectangle(0, 0, size - 1, size - 1);
        }
    }

    public override bool Exist(Point p)
    {
        return Limits.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if (Exist(p.Next(d))) return p.Next(d);
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
        return p;
    }
}