﻿using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    private int _currentTurn = 0; // Zlicza wykonane tury, obsługuje cykliczność ruchów.
    private readonly List<Direction> _parsedMoves;

    public Creature CurrentCreature => Creatures[_currentTurn % Creatures.Count];

    public string CurrentMoveName => _parsedMoves[_currentTurn % _parsedMoves.Count].ToString().ToLower();

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Lista stworzeń nie może być pusta.");
        }
        if (positions == null || positions.Count != creatures.Count)
        {
            throw new ArgumentException("Liczba pozycji początkowych musi odpowiadać liczbie stworzeń.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        // Parsujemy listę kierunków
        _parsedMoves = DirectionParser.Parse(Moves);

        // Umieszczamy stworzenia na mapie
        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Pozycja {position} nie należy do mapy.");
            }

            map.Add(creature, position);
            creature.InitMapAndPosition(map, position);
        }
    }

    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Symulacja została już zakończona.");
        }

        var currentCreature = CurrentCreature;
        var currentMove = _parsedMoves[_currentTurn % _parsedMoves.Count];

        var currentPosition = currentCreature.Position;
        var nextPosition = Map.Next(currentPosition, currentMove);

        // Wykonujemy ruch tylko, jeśli punkt docelowy jest na mapie
        if (Map.Exist(nextPosition))
        {
            Map.Move(currentPosition, nextPosition, currentCreature);
            currentCreature.InitMapAndPosition(Map, nextPosition);
        }

        _currentTurn++;

        // Sprawdzamy, czy wszystkie ruchy zostały wykonane
        if (_currentTurn >= _parsedMoves.Count * Creatures.Count)
        {
            Finished = true;
        }
    }
}