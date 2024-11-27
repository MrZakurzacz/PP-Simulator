using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> IMappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    private int _currentTurn = 0; // Zlicza wykonane tury, obsługuje cykliczność ruchów.
    private readonly List<Direction> _parsedMoves;

    public IMappable CurrentIMappable => IMappables[_currentTurn % IMappables.Count];

    public string CurrentMoveName => _parsedMoves[_currentTurn % _parsedMoves.Count].ToString().ToLower();

    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("Lista stworzeń nie może być pusta.");
        }
        if (positions == null || positions.Count != mappables.Count)
        {
            throw new ArgumentException("Liczba pozycji początkowych musi odpowiadać liczbie stworzeń.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        // Parsujemy listę kierunków
        _parsedMoves = DirectionParser.Parse(Moves);

        // Umieszczamy stworzenia na mapie
        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Pozycja {position} nie należy do mapy.");
            }

            map.Add(mappable, position);
            mappable.InitMapAndPosition(map, position);
        }
    }

    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Symulacja została już zakończona.");
        }

        var currentIMappable = CurrentIMappable;
        var currentMove = _parsedMoves[_currentTurn % _parsedMoves.Count];

        var currentPosition = currentIMappable.Position;
        var nextPosition = Map.Next(currentPosition, currentMove);

        // Wykonujemy ruch tylko, jeśli punkt docelowy jest na mapie
        if (Map.Exist(nextPosition))
        {
            Map.Move(currentPosition, nextPosition, currentIMappable);
            currentIMappable.InitMapAndPosition(Map, nextPosition);
        }

        _currentTurn++;

        // Sprawdzamy, czy wszystkie ruchy zostały wykonane
        if (_currentTurn >= _parsedMoves.Count * IMappables.Count)
        {
            Finished = true;
        }
    }
}
