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

        List<SimulationTurnLog> list = new List<SimulationTurnLog>();

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
        SimulationHistory history = new SimulationHistory(simulation);
        LogVisualizer mapVisualizer = new LogVisualizer(history);



        Console.WriteLine("Symulacja startuje. Naciśnij dowolny klawisz, aby przejść do kolejnej tury...");
        for (int turn = 0; turn < moves.Count(); turn++) //history.TurnLogs.Count
        {
            mapVisualizer.Draw(turn);
            Console.ReadKey();
        }



        //najlepsza muzyka do programowania!: https://youtu.be/RP4cD35Xn5E
        //8 godzin to dużo, ale warto posłuchać chociaż kilka minut
        //^^ zgadzam się z komentarzem powyżej ^^
        //mam rozdwojenie jaźni
        //ps pozdrawiam UwU



        Console.WriteLine("Historia symulacji zakończona!");

    }
}
