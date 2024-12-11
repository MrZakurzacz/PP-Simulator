using SimConsole;
using Simulator;
using Simulator.Maps;
using System;
using System.Security.Authentication;
using System.Text;

public class MapVisualizer
{
    private readonly Map _map;
    private readonly SimulationHistory _history;

    public MapVisualizer(Map map, SimulationHistory history)
    {
        _map = map;
        _history = history;
    }

    SimulationHistory history = new SimulationHistory();
    public void Draw()
    {
        Console.Clear();
        int width = _map.SizeX;
        int height = _map.SizeY;
        string rysunekmapy = BuildTopBorder(width) + "\n";
        //Console.WriteLine(BuildTopBorder(width));

        for (int y = 0; y < height; y++)
        {
            StringBuilder row = new StringBuilder();
            row.Append(Box.Vertical);

            for (int x = 0; x < width; x++)
            {
                var creatures = GetCreaturesAt(x, y);
                char symbol = creatures switch
                {
                    null => ' ', // Puste pole
                    { Count: 0 } => ' ', // Puste pole
                    { Count: 1 } => (IMappable)creatures[0] switch
                    {
                        Orc => 'O', // Ork
                        Elf => 'E', // Elfy
                        Birds => 'B', // Ptaki
                        Animals => 'A', // Zwierzęta
                        _ => '?',   // Nieznane stworzenie
                    },
                    _ => 'X' // Pole zajęte przez więcej niż jedno stworzenie
                };

                row.Append($" {symbol} ");
                row.Append(Box.Vertical);
            }
            rysunekmapy += row.ToString() + "\n";
            //Console.WriteLine(row.ToString());

            if (y < height - 1)

                rysunekmapy += BuildMidBorder(width) + "\n";
            //Console.WriteLine(BuildMidBorder(width));
        }
        rysunekmapy += BuildBottomBorder(width) + "\n";
        //Console.WriteLine(BuildBottomBorder(width));

        _history.PamiecMapEntry(rysunekmapy);
        Console.Write(rysunekmapy);
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

    private List<IMappable>? GetCreaturesAt(int x, int y)
    {
        return _map.At(new Point(x, y)) is IMappable creature ? new List<IMappable> { creature } : null;
    }
}
