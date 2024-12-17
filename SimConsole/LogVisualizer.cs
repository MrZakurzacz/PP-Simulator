using SimConsole;
using Simulator;
using Simulator.Maps;
using System;
using System.Numerics;
using System.Security.Authentication;
using System.Text;

public class LogVisualizer
{
    SimulationHistory Log { get; }
    public LogVisualizer(SimulationHistory log)
    {
        Log = log;
    }
    public void Draw(int turnbimbdex)
    {
        Console.Clear();
        int width = Log.SizeX;
        int height = Log.SizeY;
        string rysunekmapy = BuildTopBorder(width) + "\n"; 
        var placbudowy = Log.TurnLogs[turnbimbdex];

        for (int y = 0; y < height; y++)
        {
            StringBuilder row = new StringBuilder();
            row.Append(Box.Vertical);
            
            for (int x = 0; x < width; x++)
            {
                char sipa;
                if (placbudowy.Symbols.ContainsKey(new Point(x, y)))
                {
                    sipa = placbudowy.Symbols[new Point(x, y)];
                }
                else
                {
                    sipa = ' ';
                }   
               

                row.Append($" {sipa} ");
                row.Append(Box.Vertical);
            }
            rysunekmapy += row.ToString() + "\n";

            if (y < height - 1)

                rysunekmapy += BuildMidBorder(width) + "\n";
        }
        rysunekmapy += BuildBottomBorder(width) + "\n";
       
        Console.Write(rysunekmapy);
    }

    public static char symbols(IMappable creatures)
    {
        return creatures switch
        {

            Orc => 'O', // Ork
            Elf => 'E', // Elfy
            Birds => 'B', // Ptaki
            Animals => 'A', // Zwierzęta
            _ => '?',   // Nieznane stworzenie

        };
    }
    private string BuildTopBorder(int width)
    {
        StringBuilder border = new StringBuilder();
        border.Append(Box.TopLeft);
        for (int i = 0; i < width; i++)
        {
            border.Append($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
            border.Append(i < width - 1 ? Box.TopMid : Box.TopRight);
        }
        return border.ToString();
    }

    private string BuildMidBorder(int width)
    {
        StringBuilder border = new StringBuilder();
        border.Append(Box.MidLeft);
        for (int i = 0; i < width; i++)
        {
            border.Append($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
            border.Append(i < width - 1 ? Box.Cross : Box.MidRight);
        }
        return border.ToString();
    }

    private string BuildBottomBorder(int width)
    {
        StringBuilder border = new StringBuilder();
        border.Append(Box.BottomLeft);
        for (int i = 0; i < width; i++)
        {
            border.Append($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
            border.Append(i < width - 1 ? Box.BottomMid : Box.BottomRight);
        }
        return border.ToString();
    }

}
