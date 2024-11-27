using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int Size) : base(Size, Size)
    {

    }
    public override Point Next(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.Next(d);

        (x, y) = ImplementProperTorusMovement(SizeX, SizeY, check);
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x, y;
        Point check = new Point(p.X, p.Y);
        check = check.NextDiagonal(d);

        (x, y) = ImplementProperTorusMovement(SizeX, SizeY, check);
        return new Point(x, y);
    }

    private (int, int) ImplementProperTorusMovement(int SizeX, int SizeY, Point outcome)
    {
        int x, y;
        if (outcome.X < 0) x = outcome.X + SizeX;
        else if (outcome.X >= SizeX) x = outcome.X - SizeX;
        else x = outcome.X;

        if (outcome.Y < 0) y = outcome.Y + SizeY;
        else if (outcome.Y >= SizeY) y = outcome.Y - SizeY;
        else y = outcome.Y;
        return (x, y);
    }
}