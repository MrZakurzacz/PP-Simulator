using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        private set => _agility = Validator.Limiter(value, 0, 10);
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }

    public override string Greeting() => $"Hi, my name is, what? My name is, who?\r\nMy name is, chka-chka {Name} and i move so good - {Agility}.";


    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility = Validator.Limiter(Agility + 1, 0, 10);
        }
    }

    public override int Power => 8 * Level + 2 * Agility;
    public override string Info => $"{Name} [{Level}][{Agility}]";
}
