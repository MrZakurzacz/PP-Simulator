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
    private List<string> history = new List<string>();
    private List<string> pamiecmap = new List<string>();

    public void GarnekEntry(string entry)
    {
        history.Add(entry);
    }
    public void PamiecMapEntry(string entry)
    {
        pamiecmap.Add(entry);
    }
    public void PrintHistory(int numerTury)
    {
        string historyEntry = history[numerTury];
        string pamiecmapEntry = pamiecmap[numerTury];
        Console.Clear();
        Console.WriteLine($"Tura {numerTury-1}");
        Console.WriteLine(pamiecmapEntry);
        Console.WriteLine(historyEntry);
    }
}
