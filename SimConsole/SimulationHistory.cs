using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;


namespace SimConsole;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var simps = new Dictionary<Point, char>();
            foreach (var symb in _simulation.Creatures)
            {
                if (simps.ContainsKey(symb.Position)) simps[symb.Position] = 'X';
                else simps.Add(symb.Position, LogVisualizer.symbols(symb));
            }
            TurnLogs.Add(new SimulationTurnLog()
            {

                Mappable = _simulation.CurrentCreature.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = simps
            });

            _simulation.Turn();
        }
    }
}