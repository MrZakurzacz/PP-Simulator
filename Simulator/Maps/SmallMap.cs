using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Zbyt szeroki");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Zbyt dlugi");
        }
        _fields = new List<IMappable>?[sizeX, sizeY];
    }
    //add, remove, at...
    //add - dodaje stworzenie na mapie
    //remove - usuwa stworzenie z mapy
    //at - zwraca stworzenie/a z mapy

    //dodanie stworzenia na mapie
    public override void Add(IMappable creature, Point position)
    {
        if (!Exist(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Punkt poza mapą");
        }
        if (_fields[position.X, position.Y] == null)
        {
            _fields[position.X, position.Y] = new List<IMappable>();
        }
        _fields[position.X, position.Y].Add(creature);
    }
    //usunięcie stworzenia z mapy
    public override void Remove(Point point, IMappable creature)
    {
        if (!Exist(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Punkt poza mapą");
        }
        if (_fields[point.X, point.Y] == null)
        {
            throw new ArgumentOutOfRangeException(nameof(point), "Brak stworzeń na polu");
        }
        _fields[point.X, point.Y].Remove(creature);
    }


    //zwrócenie stworzenia z mapy
    public override IMappable? At(Point point)
    {
        return _fields[point.X, point.Y]?.FirstOrDefault();
    }


}