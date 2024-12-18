using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
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
            if (Exist(p.Next(d))) return p.Next(d);
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
            return p;
        }

    }


}
