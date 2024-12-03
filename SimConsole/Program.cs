using Simulator.Maps;
using Simulator;
using System.Text;

static class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallMap map = new SmallTorusMap(8,6);
        List<IMappable> creatures = 
        [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Króliki", Size = 10},
            new Birds {Description = "Orły", Size = 10, CanFly = true},
            new Birds {Description = "Strusie", Size = 8, CanFly = false}
        ];
        List<Point> points = [new(2, 2), new(3, 1), new(4, 2), new(3, 5), new(3, 3)];
        string moves = "dlrludllrlrdurldurllldddurrr";


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


        //śmierć brzmi jak najlepsza opcja

        mapVisualizer.Draw();
        Console.WriteLine("Symulacja zakończona!");
    }
}
