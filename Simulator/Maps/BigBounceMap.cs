using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }


        public override IMappable? At(Point point)
        {
            if (_fields.TryGetValue(point, out var creatures) && creatures.Count > 0)
            {
                return creatures.FirstOrDefault();
            }

            return null;
        }

        public List<IMappable>? AllAt(Point point)
        {
            return _fields.TryGetValue(point, out var creatures) ? creatures : null;
        }

        public override Point Next(Point p, Direction d)
        {
            int x, y;
            Point check = new Point(p.X, p.Y);
            check = check.Next(d);
            (x, y) = ImplementBounce(SizeX, SizeY, check, p);
            if ((x, y) == (0, 0)) return p;
            return new Point(x, y);
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            int x, y;
            Point check = new Point(p.X, p.Y);
            check = check.NextDiagonal(d);
            (x, y) = ImplementBounce(SizeX, SizeY, check, p);
            if ((x, y) == (0, 0)) return p;
            return new Point(x, y);
        }
        private (int, int) ImplementBounce(int SizeX, int SizeY, Point outcome, Point current)
        {
            int x, y;
            if (!_map.Contains(outcome))
            {
                x = 2 * current.X - outcome.X;
                y = 2 * current.Y - outcome.Y;
                if (!_map.Contains(new Point(x, y))) { return (0, 0); }
                return (x, y);
            }
            return (outcome.X, outcome.Y);
        }
    }
}