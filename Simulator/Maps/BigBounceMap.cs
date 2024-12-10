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
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException("Dimensions cannot exceed 1000x1000.");
            }
            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable creature, Point position)
        {
            if (!Exist(position))
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map.");
            }

            if (!_fields.ContainsKey(position))
            {
                _fields[position] = new List<IMappable>();
            }

            _fields[position].Add(creature);
        }

        public override void Remove(Point point, IMappable creature)
        {
            if (!Exist(point))
            {
                throw new ArgumentOutOfRangeException(nameof(point), "Point is outside the map.");
            }

            if (_fields.TryGetValue(point, out var creatures))
            {
                creatures.Remove(creature);
                if (creatures.Count == 0)
                {
                    _fields.Remove(point);
                }
            }
            else
            {
                throw new ArgumentException("No creatures found at the given point.", nameof(point));
            }
        }

        public override void Move(Point from, Point to, IMappable creature)
        {
            if (!Exist(from) || !Exist(to))
            {
                throw new ArgumentOutOfRangeException("One or both points are outside the map.");
            }

            if (!_fields.TryGetValue(from, out var creatures) || !creatures.Contains(creature))
            {
                throw new InvalidOperationException("The creature is not at the starting position.");
            }

            Remove(from, creature);
            Add(creature, to);
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