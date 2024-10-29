using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
    }
    public string Info => $"{Name} (Level {Level})";

    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} at Level {Level}.");
    }
}