using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        private set => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() { }

    public override string Greeting() => $"Worc worc named {Name} ra(n)ging {Rage}.";


    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0)
        {
            Rage = Validator.Limiter(Rage + 1, 0, 10);
        }
    }

    public override int Power => 7 * Level + 3 * Rage;
    public override string Info => $"{Name} [{Level}][{Rage}]";
}
