using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Lab5a();
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc("Gorbag", rage: 7);
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
            o,
            e,
            new Orc("Morgash", 3, 8),
            new Elf("Elandor", 5, 3)
        };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }

        Creature c = new Elf("Elandor", 5, 3);
        Console.WriteLine(c);  // ELF: Elandor [5]
    }

    static void Lab4b()
    {
        object[] myObjects = {
            new Animals { Description = "dogs" },
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
        };

        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects)
        {
            Console.WriteLine(o);
        }
    }
    public static void Lab5a()
    {
        // Test prostokąta chudego
        try
        {
            Rectangle rect1 = new Rectangle(1, 5, 1, 6);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Błąd: " + e.Message);
        }

        Point p1 = new Point(1, 1);
        Point p2 = new Point(5, 5);
        Rectangle rect2 = new Rectangle(p1, p2);
        Console.WriteLine("Utworzono prostokąt: " + rect2);

        // test zawierania punktów
        Point insidePoint1 = new Point(3, 3);
        Point outsidePoint1 = new Point(4, 6);
        Point outsidePoint2 = new Point(6, 4);

        Console.WriteLine($"Czy punkt {insidePoint1} jest wewnątrz prostokąta? {rect2.Contains(insidePoint1)}");
        Console.WriteLine($"Czy punkt {outsidePoint1} jest wewnątrz prostokąta? {rect2.Contains(outsidePoint1)}");
        Console.WriteLine($"Czy punkt {outsidePoint2} jest wewnątrz prostokąta? {rect2.Contains(outsidePoint2)}");

        // testy metod Next i NextDiagonal
        Console.WriteLine($"Punkt {p1} po przesunięciu w górę: {p1.Next(Direction.Up)}"); // (1, 2)
        Console.WriteLine($"Punkt {p1} po przesunięciu w lewo: {p1.Next(Direction.Left)}"); // (0, 1)
        Console.WriteLine($"Punkt {p1} po przesunięciu w dół: {p1.Next(Direction.Down)}"); // (1, 0)
        Console.WriteLine($"Punkt {p1} po przesunięciu w prawo: {p1.Next(Direction.Right)}"); // (2, 1)
        Console.WriteLine($"Punkt {p1} po przesunięciu na skos w górę: {p1.NextDiagonal(Direction.Up)}"); // (2, 2)
        Console.WriteLine($"Punkt {p1} po przesunięciu na skos w lewo: {p1.NextDiagonal(Direction.Left)}"); // (0, 2)
        Console.WriteLine($"Punkt {p1} po przesunięciu na skos w dół: {p1.NextDiagonal(Direction.Down)}"); // (0, 0)
        Console.WriteLine($"Punkt {p1} po przesunięciu na skos w prawo: {p1.NextDiagonal(Direction.Right)}"); // (2, 0)
    }
}
