using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract void Add(IMappable creature, Point position);
    public abstract void Remove(Point point, IMappable creature);
    public abstract IMappable? At(Point point);

    protected Func<Map, Point, Direction, Point>? FNext;
    protected Func<Map, Point, Direction, Point>? FNextDiagonal;



    //remove
    //move
    //At(x,y)
    //at(p)
    //at zwraca zawartość bloku mapy


    public void Move(Point from, Point to, IMappable creature)
    {
        if (!Exist(from) || !Exist(to))
        {
            throw new ArgumentOutOfRangeException("One or both points are outside the map.");
        }
        

        Remove(from, creature);
        Add(creature, to);
    }

    protected readonly Rectangle _map;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Zbyt cienki");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Zbyt krótki");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    public int SizeX { get; }

    public int SizeY { get; }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;
}
