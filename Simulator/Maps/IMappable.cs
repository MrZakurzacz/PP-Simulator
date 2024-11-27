namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; }

    void InitMapAndPosition(Map map, Point position);
}
