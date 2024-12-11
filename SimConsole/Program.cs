using Simulator.Maps;
using Simulator;
using System.Text;
using System.Runtime.CompilerServices;
using SimConsole;

static class Program
{
    static void Main(string[] args)
    {
        
        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = 
        [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Króliki", Size = 10},
            new Birds {Description = "Orły", Size = 10, CanFly = true},
            new Birds {Description = "Strusie", Size = 8, CanFly = false}
        ];
        List<Point> points = [new(0, 0), new(7, 5), new(2, 2), new(5, 5), new(4, 1)];
        string moves = "lrdududuulrdllrdrrududdu";


        Simulation simulation = new Simulation(map, creatures, points, moves);
        SimulationHistory history = new SimulationHistory();
        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map, history);



        Console.WriteLine("Symulacja startuje. Naciśnij dowolny klawisz, aby przejść do kolejnej tury...");
        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            string cosiedzieje = $"Tura: {simulation.CurrentCreature.Name}, Ruch: {simulation.CurrentMoveName}";
            history.GarnekEntry(cosiedzieje);
            Console.WriteLine(cosiedzieje);


            //Console.WriteLine($"Tura: {simulation.CurrentCreature.Name}, Ruch: {simulation.CurrentMoveName}");
            Console.ReadKey();

            simulation.Turn();
        }



        //najlepsza muzyka do programowania: https://youtu.be/RP4cD35Xn5E

        mapVisualizer.Draw();
        Console.WriteLine("Symulacja zakończona!");
        Console.ReadKey();
        history.PrintHistory(6);
        Console.ReadKey();
        history.PrintHistory(11);
        Console.ReadKey();
        history.PrintHistory(16);
        Console.ReadKey();
        history.PrintHistory(21);
        Console.ReadKey();
        Console.WriteLine("Historia symulacji zakończona!");

    }
}
