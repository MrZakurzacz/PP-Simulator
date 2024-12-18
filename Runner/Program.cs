using Simulator.Maps;
using Simulator;
using System.Text;

/*static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallMap map = new SmallTorusMap(6);
        List<Creature> creatures = new List<Creature> { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new List<Point> { new Point(2, 2), new Point(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Symulacja startuje. Naciśnij dowolny klawisz, aby przejść do kolejnej tury...");
        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine($"Tura: {simulation.CurrentCreature.Name}, Ruch: {simulation.CurrentMoveName}");
            Console.ReadKey();
            simulation.Turn();
        }

        mapVisualizer.Draw();
        Console.WriteLine("Symulacja zakończona!");
    }
}
//śmierć brzmi jak najlepsza opcja
*/